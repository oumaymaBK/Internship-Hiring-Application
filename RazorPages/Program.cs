using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using RazorPages.Data;
using RazorPages.Models;
using RazorPages.Utility;

var builder = WebApplication.CreateBuilder(args);

//Add service ToastNotify 
builder.Services.AddRazorPages().AddNToastNotifyToastr(new ToastrOptions()
{
    ProgressBar = true,
    PositionClass=ToastPositions.TopCenter,
    PreventDuplicates=true,
    CloseButton=true,//si je veux le fermer je clique sur le bouton close 

});
// Add services to the container.
builder.Services.AddRazorPages();
//Add service de Mapping
builder.Services.AddAutoMapper(typeof(MappingProfile));
//Add Service ProjetDbContext
string strcon = builder.Configuration.GetConnectionString("ProjetDb");
builder.Services.AddDbContext<ProjetDbContext>(options =>options.UseSqlServer(strcon));

builder.Services.AddDistributedMemoryCache();
////udemy

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(36000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Add Service Identity 
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password = new PasswordOptions
    {
        RequireDigit = true,
        RequireUppercase = false,
        RequireLowercase = true,
        RequireNonAlphanumeric = false
    };
}).AddEntityFrameworkStores<ProjetDbContext>();
var app = builder.Build();


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
app.UseAuthentication();
app.UseAuthorization();
//Udemy
app.UseSession();

//Udemy
app.MapRazorPages();

app.Run();
