
using Amax.InsurancePro.Web.Infrastructure;
using Amax.InsurancePro.Web.Infrastructure.Extensions;
using Amax.InsurancePro.Web.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapperProfiles));
builder.Services.AddControllersWithViews()
	.ConfigureApiBehaviorOptions(options =>
	{
		options.InvalidModelStateResponseFactory = context =>
		{
			//var errors = context.ModelState
			//	.Where(e => e.Value.Errors.Count > 0)
			//	.SelectMany(e => e.Value.Errors.Select(error => $"{e.Key}: {error.ErrorMessage}"))
			//	.ToList();

			//throw new Exception(string.Join(" ", errors));

			var errors = context.ModelState.ToDictionary(
				kvp => kvp.Key,
				kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToList()
			);

			throw new Exception("errors");
		};
	});
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureAppSettings(builder.Configuration);
builder.Services.ConfigureSession(builder.Configuration);
builder.Services.ConfigureCookiePolicy();
builder.Services.ConfigureServices(builder.Configuration);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
		options.SlidingExpiration = true;
		options.AccessDeniedPath = "/Forbidden/";
		options.LoginPath = "/Auth/Login";
		options.Events.OnValidatePrincipal = context =>
		{
			var c = context.Principal;
			// Custom logic here
			return Task.CompletedTask;
		};
	});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("AdminOnly", policy =>
		policy.RequireRole("role", "admin"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
