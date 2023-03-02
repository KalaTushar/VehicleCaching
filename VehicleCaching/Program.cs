using EasyCaching.Core.Configurations;
using EasyCaching.Serialization;
namespace VehicleCaching
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEasyCaching(options =>
            {
                options.UseRedis(redis =>
                {
                    redis.DBConfig.Endpoints.Add(new ServerEndPoint("localhost", 6379));
                    redis.DBConfig.AllowAdmin = true;
                    redis.SerializerName = "app-message-pack";
                }, "DefaultRedis").WithMessagePack("app-message-pack");
            });
            var app = builder.Build();
            app.MapControllers();
            app.Run();
        }
    }
}