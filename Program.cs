namespace Products
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options=>options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection")));
            //OR
            builder.Services.AddDbContext<ApplicationDbContext>(options=>
            {
                var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseMySql(ConnectionString,ServerVersion.AutoDetect(ConnectionString));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Default}/{action=Index2}/{id?}");

            app.Run();
        }
    }
}