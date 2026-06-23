using FinanceTracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using FinanceTracker.Models;


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

        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Transaction>("Transactions");
            builder.EntitySet<Category>("Categories");

            return builder.GetEdmModel();

        }

    }
}
