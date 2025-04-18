using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ServiceReference;

namespace SoapClientConsole
{
    /// <summary>
    /// The Program class contains the entry point for the application and coordinates the demonstration
    /// of matrix multiplication, utilizing a SOAP web service for matrix operations.
    /// This class manages the setup of dependencies and execution of functional workflows.
    /// </summary>
    internal class Program(ILogger<Program> logger, MatrixMultiplyServiceClient client = null)
    {
        private readonly MatrixMultiplyServiceClient _client = client ?? new MatrixMultiplyServiceClient();

        static async Task Main(string[] args)
        {
            using var client = new MatrixMultiplyServiceClient();
            var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = loggerFactory.CreateLogger<Program>();
            var program = new Program(logger, client);

            try
            {
                await program.RunMatrixMultiplicationDemoAsync();
            }
            catch (Exception e)
            {
                logger.LogError("Matrix multiplication error: {Message}", e.Message);
                throw;
            }
        }

        public async Task RunMatrixMultiplicationDemoAsync()
        {
            var firstMatrix = CreateSampleMatrix1();
            var secondMatrix = CreateSampleMatrix2();

            var firstMatrixFilePath = await SaveMatrixToFileAsync(firstMatrix);
            var secondMatrixFilePath = await SaveMatrixToFileAsync(secondMatrix);

            var resultFilePath = await MultiplyMatricesAsync(firstMatrixFilePath, secondMatrixFilePath);
            
            await DisplayResultMatrixAsync(resultFilePath);
        }

        private static ArrayOfFloat[] CreateSampleMatrix1()
        {
            return new ArrayOfFloat[]
            {
                new ArrayOfFloat { 1, 2 },
                new ArrayOfFloat { 3, 4 }
            };
        }

        private static ArrayOfFloat[] CreateSampleMatrix2()
        {
            return new ArrayOfFloat[]
            {
                new ArrayOfFloat { 5, 6 },
                new ArrayOfFloat { 7, 8 }
            };
        }

        private async Task<string> SaveMatrixToFileAsync(ArrayOfFloat[] matrix)
        {
            var response = await _client.SaveToFileAsync(matrix);
            var filePath = response.Body.SaveToFileResult;
            logger.LogInformation("Matrix saved to file: {FilePath}", filePath);
            return filePath;
        }

        private async Task<string> MultiplyMatricesAsync(string firstMatrixFilePath, string secondMatrixFilePath)
        {
            var resultFile = await _client.MultiplyAsync(firstMatrixFilePath, secondMatrixFilePath);
            var resultFilePath = resultFile.Body.MultiplyResult;
            logger.LogInformation("Multiplication result saved to file: {FilePath}", resultFilePath);
            return resultFilePath;
        }

        private async Task DisplayResultMatrixAsync(string resultFilePath)
        {
            var result = await _client.ReadMatrixAsync(resultFilePath);
            var resultMatrix = result.Body.ReadMatrixResult;
            
            logger.LogInformation("Matrix multiplication result:");
            foreach (var row in resultMatrix)
            {
                logger.LogInformation("{Row}", string.Join(" ", row));
            }
        }
    }
}