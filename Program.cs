
using Microsoft.EntityFrameworkCore;
using RSGymPT.ClientManagement.Data;
using System.Globalization; // Namespace onde está o DbContext

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<RSGymPTContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RSGymPTContext")));


var cultureInfo = new CultureInfo("pt-PT");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Clientes}/{action=Index}/{id?}");

app.Run();
