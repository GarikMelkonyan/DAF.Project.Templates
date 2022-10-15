//using GarMel.Framework.Development;
using GarMel.Framework.Development;
using GarMel.Framework.Web.Controllers;
using GarMel.Framework.Web.Core;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc().AddNewtonsoftJson().AddApplicationPart(typeof(FormController).Assembly);
builder.Services.AddDaf(builder.Configuration, o => o.CustomModules.Add(new DevelopmentModule()));
builder.Services.AddAuthentication("dummy").AddScheme<AuthenticationSchemeOptions, DummyAuthenticationHandler>("dummy", null);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseDaf();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDaf("/");
    endpoints.MapDefaultControllerRoute();
});

app.Run();
