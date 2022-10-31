using CatalagoApi.ApiEndpoints;
using CatalagoApi.AppServicesExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAuthenticationJwt();

var app = builder.Build();

app.MapAutenticacaoEndpoints();
app.MapCategoriasEndpoints();
app.MapProdutosEndpoints();

var enviroment = app.Environment;
app.UseExceptionHandling(enviroment)
    .UseSwaggerMiddleWare()
    .UseAppCors();

app.UseAuthentication();
app.UseAuthorization();

app.Run();