using System;
using System.IO;
using NUnit.Framework;
using WebServiceProgRozpr.Services;

namespace Tests
{
    [TestFixture]
    [Description("Tests for matrix multiplication service")]
    public class MatrixMultiplyServiceTests
    {
        private IMatrixMultiplyService _service;
        private string _testDirectory;
        private string _matrix1FilePath;
        private string _matrix2FilePath;

        [SetUp]
        public void Setup()
        {
            _service = new MatrixMultiplyService();

            _testDirectory = Path.Combine(Path.GetTempPath(), "MatrixTest_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_testDirectory);

            _matrix1FilePath = Path.Combine(_testDirectory, "matrix1.txt");
            _matrix2FilePath = Path.Combine(_testDirectory, "matrix2.txt");
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_testDirectory))
            {
                Directory.Delete(_testDirectory, true);
            }
        }

        private void CreateMatrixFile(string filePath, float[][] matrix)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"{matrix.Length} {matrix[0].Length}");
                foreach (var row in matrix)
                {
                    writer.WriteLine(string.Join(" ", row));
                }
            }
        }

        [Test]
        [Description("Verifies that a valid matrix file is read correctly")]
        public void ReadMatrix_ValidFile_ReturnsCorrectMatrix()
        {
            float[][] expectedMatrix = new float[][]
            {
                new float[] { 1.0f, 2.0f },
                new float[] { 3.0f, 4.0f }
            };
            CreateMatrixFile(_matrix1FilePath, expectedMatrix);

            float[][] result = _service.ReadMatrix(_matrix1FilePath);

            Assert.That(result.Length, Is.EqualTo(expectedMatrix.Length));
            for (int i = 0; i < expectedMatrix.Length; i++)
            {
                Assert.That(result[i].Length, Is.EqualTo(expectedMatrix[i].Length));
                for (int j = 0; j < expectedMatrix[i].Length; j++)
                {
                    Assert.That(result[i][j], Is.EqualTo(expectedMatrix[i][j]));
                }
            }
        }


        [Test]
        [Description("Verifies that attempting to read a non-existent file throws FileNotFoundException")]
        public void ReadMatrix_NonExistentFile_ThrowsFileNotFoundException()
        {
            string nonexistentFile = Path.Combine(_testDirectory, "nonexistent.txt");
            Assert.Throws<FileNotFoundException>(() => _service.ReadMatrix(nonexistentFile));
        }

        [Test]
        [Description("Verifies that attempting to read an empty file throws ArgumentException")]
        public void ReadMatrix_EmptyFile_ThrowsArgumentException()
        {
            string emptyFilePath = Path.Combine(_testDirectory, "empty.txt");
            File.WriteAllText(emptyFilePath, "");
            Assert.Throws<ArgumentException>(() => _service.ReadMatrix(emptyFilePath));
        }

        [Test]
        [Description("Verifies that attempting to read a file with invalid format throws ArgumentException")]
        public void ReadMatrix_InvalidFormat_ThrowsFormatException()
        {
            string invalidFilePath = Path.Combine(_testDirectory, "invalid.txt");
            File.WriteAllText(invalidFilePath, "invalid content");
            Assert.Throws<ArgumentException>(() => _service.ReadMatrix(invalidFilePath));
        }

        [Test]
        [Description("Verifies that a matrix is correctly saved to a file")]
        public void SaveToFile_ValidMatrix_SavesCorrectly()
        {
            float[][] matrix = new float[][]
            {
                new float[] { 9.0f, 8.0f },
                new float[] { 7.0f, 6.0f }
            };
            string filePath = _service.SaveToFile(matrix);

            Assert.That(File.Exists(filePath), Is.True);

            string[] lines = File.ReadAllLines(filePath);
            Assert.That("2 2", Is.EqualTo(lines[0]));
            Assert.That("9 8", Is.EqualTo(lines[1]));
            Assert.That("7 6", Is.EqualTo(lines[2]));
        }

        [Test]
        [Description("Verifies that attempting to save a null matrix throws ArgumentNullException")]
        public void SaveToFile_NullMatrix_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _service.SaveToFile(null));
        }

        [Test]
        [Description("Verifies that attempting to save an empty matrix throws ArgumentException")]
        public void SaveToFile_EmptyMatrix_ThrowsArgumentException()
        {
            float[][] emptyMatrix = new float[0][];
            Assert.Throws<ArgumentException>(() => _service.SaveToFile(emptyMatrix));
        }

        [Test]
        [Description("Verifies that multiplication of valid matrices returns the correct result")]
        public void Multiply_ValidMatrices_ReturnsCorrectResult()
        {
            float[][] matrix1 = new float[][]
            {
                new float[] { 1.0f, 2.0f },
                new float[] { 3.0f, 4.0f }
            };

            float[][] matrix2 = new float[][]
            {
                new float[] { 5.0f, 6.0f },
                new float[] { 7.0f, 8.0f }
            };

            CreateMatrixFile(_matrix1FilePath, matrix1);
            CreateMatrixFile(_matrix2FilePath, matrix2);

            string resultFilePath = _service.Multiply(_matrix1FilePath, _matrix2FilePath);

            Assert.That(File.Exists(resultFilePath), Is.True);

            float[][] result = _service.ReadMatrix(resultFilePath);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(2, Is.EqualTo(result[0].Length));

            Assert.That(19.0f, Is.EqualTo(result[0][0]));
            Assert.That(22.0f, Is.EqualTo(result[0][1]));
            Assert.That(43.0f, Is.EqualTo(result[1][0]));
            Assert.That(50.0f, Is.EqualTo(result[1][1]));
        }

        [Test]
        [Description("Verifies that attempting to multiply incompatible matrices throws InvalidOperationException")]
        public void Multiply_IncompatibleMatrices_ThrowsInvalidOperationException()
        {
            float[][] matrix1 = new float[][]
            {
                new float[] { 1.0f, 2.0f },
                new float[] { 3.0f, 4.0f }
            };

            float[][] matrix2 = new float[][]
            {
                new float[] { 5.0f, 6.0f, 7.0f },
                new float[] { 8.0f, 9.0f, 10.0f },
                new float[] { 11.0f, 12.0f, 13.0f }
            };

            CreateMatrixFile(_matrix1FilePath, matrix1);
            CreateMatrixFile(_matrix2FilePath, matrix2);

            Assert.Throws<InvalidOperationException>(() => _service.Multiply(_matrix1FilePath, _matrix2FilePath));
        }

        [Test]
        [Description("Verifies that attempting to multiply with a non-existent file throws FileNotFoundException")]
        public void Multiply_NonExistentFile_ThrowsFileNotFoundException()
        {
            string nonexistentFile = Path.Combine(_testDirectory, "nonexistent.txt");
            CreateMatrixFile(_matrix1FilePath, new float[][] { new float[] { 1, 2 }, new float[] { 3, 4 } });

            Assert.Throws<FileNotFoundException>(() => _service.Multiply(nonexistentFile, _matrix1FilePath));
            Assert.Throws<FileNotFoundException>(() => _service.Multiply(_matrix1FilePath, nonexistentFile));
        } 
    }
}