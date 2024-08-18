using IDMT.Application;
using IDMT.Application.Abstractions.Identity;
using IDMT.Infrastructure;
using IDMT.Web.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(option =>
{
    option.AccessDeniedPath = "/Accounts/AccessDenied";
    option.LoginPath = "/Accounts/Login";
});

builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Accounts}/{action=Login}/{id?}");

app.Run();
