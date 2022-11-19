using System;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;


namespace R5T.E0064.W001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();

            builder.Services.AddSingleton<BlogPostTextProvider>();

            var app = builder.Build();

            app.UseRouting();

            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}