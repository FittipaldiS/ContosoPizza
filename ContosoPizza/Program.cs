using ContosoPizza.Data;
using ContosoPizza.Services;
using Microsoft.EntityFrameworkCore;
using ContosoPizza.Areas.Identity.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration
    .GetConnectionString("ContosoPizzaContextConnection") ?? throw new InvalidOperationException("Connection string 'ContosoPizzaContextConnection' not found.");
builder.Services.AddDbContext<ContosoPizzaContext>(options => options.UseSqlite(connectionString));
builder.Services.AddDefaultIdentity<ContosoPizzaUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContosoPizzaContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<PizzaService>();
builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseSqlite("Data Source=ContosoPizza.db"));

//builder.Services.AddDefaultIdentity<ContosoPizzaUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ContosoPizzaContext>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();

app.MapRazorPages();

app.Run();
