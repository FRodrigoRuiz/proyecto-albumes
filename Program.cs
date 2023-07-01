using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Albumes.Data;
using Albumes.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AlbumContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AlbumContext") ?? throw new InvalidOperationException("Connection string 'AlbumContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AlbumContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<ISongService, SongService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");
    
app.MapRazorPages();

app.Run();
