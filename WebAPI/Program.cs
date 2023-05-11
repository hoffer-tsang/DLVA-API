/*==============================================================================
 *
 * Main Program to run the swagger API
 *
 * Copyright © Dorset Software Services Ltd, 2023
 *
 * TSD Section: P775 Web API Task Set 1 Task 2
 *
 *============================================================================*/
using Microsoft.EntityFrameworkCore;
using EntityFrameWorkModel;

namespace WebAPI
{
    /// <summary>
    /// Main Program that start the swagger API page
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Function of the program
        /// </summary>
        /// <param name="args"> the string args array </param>
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
