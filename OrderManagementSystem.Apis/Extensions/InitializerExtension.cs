namespace OrderManagementSystem.Apis.Extensions
{
    public static class InitializerExtensions
    {
        public static async Task<WebApplication> InitializeDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var dbContext = services.GetRequiredService<OrderManagementDbContext>();

                await dbContext.Database.EnsureCreatedAsync(); // For In-Memory
                // await dbContext.Database.MigrateAsync();    // Use this if switching to real DB with migrations

                // TODO: Seed initial data here (optional for now)
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger("DB Initializer");
                logger.LogError(ex, "An error occurred while initializing the database.");
            }

            return app;
        }
    }
}
