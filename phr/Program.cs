using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using phr.Config;
using phr.Data;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
builder.Services.AddScoped<ApiService>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromDays(365); // Set session timeout
	options.Cookie.HttpOnly = true; // Cookie is accessible only by the server
	options.Cookie.IsEssential = true;
});


builder.Services.AddControllersWithViews(); // Add MVC services

builder.Services.AddRazorPages();

//builder.Services.AddAuthorization();

//builder.Services.AddRazorPages()
//    .AddMicrosoftIdentityUI();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

//app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
