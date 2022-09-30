using System.Net.Mail;
using src.Enums;
using System.Reflection;
using SoapCore;
using src.Interaces;

var builder = WebApplication.CreateBuilder(args);
//
builder.Services.AddSingleton<IService, Service>();
//
builder.Services.AddSoapCore();
var app = builder.Build();

((IApplicationBuilder)app).UseSoapEndpoint<IService>("/Clinica.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);

app.Run();
