
using OrderManagementSystem.Apis.Extensions;

namespace OrderManagementSystem.Apis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services

            builder.Services.AddControllers();
            builder.Services
    .AddControllers()
    .AddApplicationPart(typeof(OrderManagementSystem.Controllers.Controllers.BaseApiController).Assembly);


            // DbContext using In-Memory DB
            builder.Services.AddDbContext<OrderManagementDbContext>(options =>
                options.UseInMemoryDatabase("OrderDb"));

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #endregion

            var app = builder.Build();

            #region Initialize Database
            await app.InitializeDatabaseAsync();
            #endregion

            #region Configure Middleware

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
