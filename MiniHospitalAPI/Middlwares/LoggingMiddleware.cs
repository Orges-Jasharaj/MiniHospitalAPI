﻿namespace MiniHospitalAPI.Middlwares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine($"[LOG] {context.Request.Method} {context.Request.Path}");
            await _next(context);
        }

    }
}
