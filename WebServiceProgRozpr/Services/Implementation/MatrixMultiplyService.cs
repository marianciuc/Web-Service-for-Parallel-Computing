using System.Globalization;

namespace WebServiceProgRozpr.Services;

public class MatrixMultiplyService : IMatrixMultiplyService
{
    public float[][] ReadMatrix(string filename)
    {
        int rows = 0;
        int columns = 0;
        
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException($"File doesn't exists: {filename}");
        }
        
        string[] lines = File.ReadAllLines(filename);

        if (lines.Length <= 1)
        {
            throw new ArgumentException("File is empty");
        }
        
        string[] firstLine = lines[0].Split(' ');
        rows = int.Parse(firstLine[0]);
        columns = int.Parse(firstLine[1]);
        
        float[][] matrix = new float[rows][];

        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (values.Length != columns)
            {
                throw new ArgumentException("File is not a matrix");
            }
            
            matrix[i - 1] = values.Select(x => float.Parse(x, CultureInfo.InvariantCulture)).ToArray();
        }
        return matrix;
    }
    
    public string Multiply(string filename1, string filename2)
    {
        float[][] matrixA = ReadMatrix(filename1);
        float[][] matrixB = ReadMatrix(filename2);
        
        if (matrixA[0].Length != matrixB.Length)
        {
            throw new InvalidOperationException(
                $"Matrix multiplication exception: numnber of matrix column ({matrixA[0].Length}) " +
                $" is not equile to number of rows in second matrix ({matrixB.Length})");
        }
        
        
        int m = matrixA.Length;    
        int n = matrixA[0].Length;
        int p = matrixB[0].Length;   
        
        float[][] result = new float[m][];
        for (int i = 0; i < m; i++)
        {
            result[i] = new float[p];
        }

        Parallel.For(0, m, i =>
        {
            for (int j = 0; j < p; j++)
            {
                result[i][j] = 0;
                for (int k = 0; k < n; k++)
                {
                    result[i][j] += matrixA[i][k] * matrixB[k][j];
                }
            }
        });
        
        return SaveToFile(result);
    }

    public string SaveToFile(float[][] matrix)
    {
        if (matrix == null) throw new ArgumentNullException(nameof(matrix));
        if (matrix.Length == 0) throw new ArgumentException("Matrix is empty");
        
        string resultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Results");
        Directory.CreateDirectory(resultPath);

        string fileName = $"result_matrix_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

        using StreamWriter writer = new StreamWriter(fileName);
        writer.WriteLine($"{matrix.Length} {matrix[0].Length}");
        for (int i = 0; i < matrix.Length; i++)
        {
            string line = string.Join(" ", matrix[i].Select(x => x.ToString(CultureInfo.InvariantCulture)));
            writer.WriteLine(line);
        }

        return fileName;
    }
}