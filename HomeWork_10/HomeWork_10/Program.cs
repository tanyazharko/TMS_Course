using HomeWork_10.Controllers;
using HomeWork_10.Filters;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(AuthorizationFilter));
    options.Filters.Add(typeof(ResourceFilter));
    options.Filters.Add(typeof(ActionFilter));
    options.Filters.Add(typeof(ExceptionFilter));
    options.Filters.Add(typeof(ResultFilter));

});

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseMiddleware<Middleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
