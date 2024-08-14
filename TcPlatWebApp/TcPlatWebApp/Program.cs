using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using SQLDatAccessLibrary;
using SQLDatAccessLibrary.Anagrafici;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/"; // Path to your custom login page
        options.LogoutPath = "/logout";
        options.AccessDeniedPath = "/access-denied";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsAuthenticated", policy =>
    {
        policy.RequireAuthenticatedUser();
    });
});


// Add your own data access services
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<ILoginData, LoginData>();
builder.Services.AddScoped<IAnagraficiData, AnagraficiData>();
builder.Services.AddScoped<IRegistrazioneData, RegistrazioneData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable Authentication and Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
