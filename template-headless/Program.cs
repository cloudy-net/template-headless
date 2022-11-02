using Microsoft.EntityFrameworkCore;
using template_headless;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCloudy(cloudy =>
    cloudy.AddAdmin(admin => admin.Unprotect())
    .AddContext<MyContext>()
);

builder.Services.AddDbContext<MyContext>(options => options.UseInMemoryDatabase("test"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles(new StaticFileOptions().MustValidate());

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
