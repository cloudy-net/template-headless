using Microsoft.EntityFrameworkCore;
using template_headless;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddApplicationPart(typeof(CloudyUIAssemblyHandle).Assembly);
builder.Services.AddCloudy(cloudy =>
    cloudy.AddAdmin(admin => admin.Unprotect())
    .AddContext<MyContext>()
);

builder.Services.AddDbContext<MyContext>(options => options.UseInMemoryDatabase("test"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseStaticFiles(new StaticFileOptions
{
    // Not strictly necessary, but good - browsers will cache but revalidate on ETag every time.
    OnPrepareResponse = ctx => ctx.Context.Response.Headers.Append("Cache-Control", $"no-cache")
});

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
