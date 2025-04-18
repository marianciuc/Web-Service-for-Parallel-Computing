using System.ServiceModel;
using SoapCore;
using WebServiceProgRozpr.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IMatrixMultiplyService, MatrixMultiplyService>();
builder.Services.AddSingleton<IMandelbrotSetService, MandelbrotSetService>();

builder.Services.AddSoapCore();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi.json");
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "api"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<IMatrixMultiplyService>(
        path: "/MatrixService.asmx",
        encoder: new SoapEncoderOptions(),
        serializer: SoapSerializer.XmlSerializer,
        caseInsensitivePath: false,
        soapModelBounder: null,
        indentXml: true,
        omitXmlDeclaration: true,
        schemeOverride: null
    );
});


((IEndpointRouteBuilder)app).UseSoapEndpoint<IMandelbrotSetService>(
    path: "/MandelbrotSetService.asmx",
    encoder: new SoapEncoderOptions(),
    serializer: SoapSerializer.XmlSerializer,
    caseInsensitivePath: false,
    soapModelBounder: null,
    indentXml: true,
    omitXmlDeclaration: true,
    schemeOverride: null
);



app.UseAuthorization();

app.MapControllers();

app.Run();