using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using PersonalLifeOS.Application;
using PersonalLifeOS.Domain.Finance;
using PersonalLifeOS.Infrastructure;

namespace PersonalLifeOS.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services
            .AddControllers(options =>
            {
                options.ReturnHttpNotAcceptable = true;
            })
            .AddXmlSerializerFormatters()
            .AddOData(options => options
                .Select()
                .Filter()
                .OrderBy()
                .Expand()
                .Count()
                .SetMaxTop(100)
                .AddRouteComponents("odata", GetEdmModel()));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowWebClient", policy =>
            {
                policy
                    .WithOrigins("http://localhost:5231", "https://localhost:7227")
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowWebClient");
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }

    public static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();

        builder.EntitySet<Transaction>("Transactions");
        builder.EntitySet<Category>("Categories");

        return builder.GetEdmModel();
    }
}
