using System.ServiceModel;

namespace WebServiceProgRozpr.Services;

[ServiceContract]
public interface IMatrixMultiplyService
{
    /// Multiplies two matrices passed via file paths and saves the result to a file as a matrix.
    /// <param name="filename1">The file path of the first matrix file. It should contain a valid matrix with dimensions specified in the first line.</param>
    /// <param name="filename2">The file path of the second matrix file. It should contain a valid matrix with dimensions specified in the first line.</param>
    /// <returns>The file path where the result of the matrix multiplication is saved.</returns>
    /// <exception cref="FileNotFoundException">Thrown when one of the files specified does not exist.</exception>
    /// <exception cref="ArgumentException">Thrown when the file contents are invalid or do not represent a valid matrix.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the matrices cannot be multiplied due to mismatched dimensions.</exception>
    [OperationContract]
    string Multiply(string filename1, string filename2);

    /// Saves a given matrix to a file in a specific format, with the matrix dimensions written in the first line.
    /// <param name="matrix">The matrix to be saved, represented as a two-dimensional array of floats.</param>
    /// <returns>The file path where the matrix has been saved.</returns>
    /// <exception cref="DirectoryNotFoundException">Thrown when the directory where the file is to be saved cannot be created or accessed.</exception>
    /// <exception cref="IOException">Thrown when an I/O error occurs during the write operation.</exception>
    [OperationContract]
    string SaveToFile(float[][] matrix);

    /// Reads a matrix from a file where the matrix dimensions are specified in the first line,
    /// followed by the matrix elements in subsequent lines.
    /// <param name="filename">The file path of the matrix file to be read. The file must specify the matrix dimensions in the first line and include the corresponding matrix data in subsequent lines.</param>
    /// <returns>A two-dimensional array of floats representing the matrix read from the file.</returns>
    /// <exception cref="FileNotFoundException">Thrown when the specified file does not exist.</exception>
    /// <exception cref="ArgumentException">Thrown when the file is empty or does not follow the expected format.</exception>
    /// <exception cref="FormatException">Thrown when the matrix dimensions or element values in the file are not in the correct format.</exception>
    [OperationContract]
    float[][] ReadMatrix(string filename);
}
