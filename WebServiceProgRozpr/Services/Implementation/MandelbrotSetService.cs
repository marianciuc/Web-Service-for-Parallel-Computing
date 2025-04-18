using System.Drawing;
using System.Drawing.Imaging;

namespace WebServiceProgRozpr.Services;

public class MandelbrotSetService(ILogger<MandelbrotSetService> logger) : IMandelbrotSetService
{
    private const int MaxIterations = 1000;
    private const double XMin = -2.5, XMax = 1;
    private const double YMin = -1, YMax = 1;

    public Bitmap Generate(int width, int height, int threads)
    {
        logger.LogInformation("Generate Mandelbrot Set");
        logger.LogInformation("Width: {width}, Height: {height}, Threads: {threads}", width, height, threads);

        ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxCompletionPortThreads);
        ThreadPool.GetAvailableThreads(out var workerThreads, out var completionPortThreads);

        if (maxWorkerThreads < threads || workerThreads < threads)
        {
            throw new InvalidOperationException($"Not enough threads. Avialible threads is {maxWorkerThreads}");
        }
        
        var pixelData = new Color[width, height];
        ParallelOptions parallelOptions = new ParallelOptions
        {
            MaxDegreeOfParallelism = threads
        };

        Parallel.For(0, width, parallelOptions, x =>
        {
            for (var y = 0; y < height; y++)
            {
                double real = XMin + (x / (double)width) * (XMax - XMin);
                double imaginary = YMin + (y / (double)height) * (YMax - YMin);

                int iterations = ComputeMandelbrot(real, imaginary);
                pixelData[x, y] = iterations == MaxIterations ? Color.Black : GetColor();
            }
        });

        Bitmap bitmap = new Bitmap(width, height);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                bitmap.SetPixel(x, y, pixelData[x, y]);
            }
        }


        logger.LogInformation("Mandelbrot Set generated");
        return bitmap;
    }

    private int ComputeMandelbrot(double real, double imaginary)
    {
        double zr = 0, zi = 0;
        int iteration = 0;

        while (zr * zr + zi * zi <= 4 && iteration < MaxIterations)
        {
            double temp = zr * zr - zi * zi + real;
            zi = 2 * zr * zi + imaginary;
            zr = temp;
            iteration++;
        }

        return iteration;
    }


    private Color GetColor()
    {
        var r = (Thread.CurrentThread.ManagedThreadId * 9) % 256;
        var g = (Thread.CurrentThread.ManagedThreadId * 2) % 256;
        var b = (Thread.CurrentThread.ManagedThreadId * 3) % 256;
        return Color.FromArgb(r, g, b);
    }
}