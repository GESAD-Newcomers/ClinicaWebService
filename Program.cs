// using System.Net.Mail;
// using src.Enums;
// using System.Reflection;
// using SoapCore;
// using src.Interaces;

// var builder = WebApplication.CreateBuilder(args);
// //
// builder.Services.AddSingleton<IService, Service>();
// //
// builder.Services.AddSoapCore();
// var app = builder.Build();

// ((IApplicationBuilder)app).UseSoapEndpoint<IService>("/Clinica.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);

// app.Run();




using System;
using src.Models;
using src.Utils.DbInteractions;

AgendamentoDbInteraction m = new AgendamentoDbInteraction();

AgendamentoModel model = new AgendamentoModel();

// model.data = DateTime.Now;

// model.medicoID = 1; model.pacienteID = 1;

// m.INSERT(model);

foreach( var aaa in m.SELECT_ALL())
{
    Console.WriteLine(aaa.toDbInsert().values);
}