using System.Drawing;
using System.ServiceModel;

namespace WebServiceProgRozpr.Services;

[ServiceContract]
public interface IMandelbrotSetService
{
    /// <summary>
    /// Generates a Mandelbrot set image with the specified dimensions and thread count.
    /// </summary>
    /// <param name="width">The width of the generated image in pixels.</param>
    /// <param name="height">The height of the generated image in pixels.</param>
    /// <param name="threads">The number of threads to utilize for parallel processing.</param>
    /// <returns>A Bitmap object representing the generated Mandelbrot set image.</returns>
    [OperationContract]
    Bitmap Generate(int width, int height, int threads);
}