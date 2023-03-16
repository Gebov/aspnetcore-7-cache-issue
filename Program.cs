namespace output_cache_tests
{
    public partial class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddOutputCache((x) =>
            {
                x.AddPolicy("default", new CustomCachePolicy());
            });

            var app = builder.Build();
            app.UseRouting();
            app.UseOutputCache();
            app.UseEndpoints((endpoints) =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();
        }
    }
}
