﻿using CatalagoApi.Models;
using CatalagoApi.Services;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

namespace CatalagoApi.ApiEndpoints
{
    public static class AutenticacaoEndpoints
    {
        public  static void MapAutenticacaoEndpoints(this WebApplication app)
        {
            app.MapPost("/login", [AllowAnonymous] (UserModel userModel, ITokenService tokenService) =>
            {
                if (userModel == null)
                    return Results.BadRequest("Login Inválido");
                if (userModel.UserName == "clara" && userModel.Password == "vieira#123")
                {
                    var tokenString = tokenService.GerarToken(app.Configuration["Jwt:Key"],
                            app.Configuration["Jwt:Issuer"],
                            app.Configuration["Jwt:Audience"],
                            userModel);
                    return Results.Ok(new { token = tokenString });
                }
                else
                    return Results.BadRequest("Login Inválido");
            }).Produces(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status200OK)
              .WithName("Login")
              .WithTags("Autenticação");
        }
    }
}
