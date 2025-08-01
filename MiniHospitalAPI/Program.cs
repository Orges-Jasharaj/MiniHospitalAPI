﻿using MiniHospitalAPI.Services;
using MiniHospitalAPI.Middlwares;

namespace MiniHospitalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllers();

           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            builder.Services.AddSingleton<HospitalServices>();

            var app = builder.Build();

            
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

          
             app.UseMiddleware<LoggingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

           
            app.MapControllers();

            app.Run();
        }
    }
}
