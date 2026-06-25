using FinanceTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using FinanceTracker.Models;
using AutoMapper;


namespace FinanceTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<FinanceDbContext>(
                options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("FinanceTracker"))
                    );

            // Add services to the container.
            builder.Services.AddControllers(
                options =>
                {
                    options.ReturnHttpNotAcceptable = true; //nếu thêm thằng này vào thì thằng client có yêu cầu các dạng không được chấp thuận như pdf thì sẽ tra về lỗi 
                }).AddXmlSerializerFormatters()
                .AddOData(options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100)
                .AddRouteComponents("odata", GetEdmModel())); //setup to use odata and odata's method, setup separate url for odata

            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<FinanceTracker.Mappings.MappingProfile>());
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Configure CORS
            builder.Services.AddCors(options => 
            {
                options.AddPolicy("AllowMvcClient", policy => 
                {
                    policy.WithOrigins("http://localhost:5231", "https://localhost:7227")
                            .WithMethods("GET", "POST", "PUT", "DELETE")
                            .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowMvcClient");



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
}
