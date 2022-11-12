using Microsoft.AspNetCore.Mvc.RazorPages;
using NodaTime;
using System.Reflection;
using WorkWithADONET;

var builder = WebApplication.CreateBuilder(args);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (CourseWorkContext db = new CourseWorkContext())
{
    User user1 = new User { Username = "Tom112", Name = "Tom", Gender = "Male", Age = 33, Weight = 90, Height = 189 };
  
    db.Users.Add(user1);
    db.SaveChanges();
}

using (CourseWorkContext db = new CourseWorkContext())
{
    var users = db.Users.ToList();
    Console.WriteLine("Users list:");

    foreach (User u in users)
    {
        Console.WriteLine($"{u.Username}.{u.Name} - {u.Age}");
    }
}

using (CourseWorkContext db = new CourseWorkContext())
{
    User user = db.Users.FirstOrDefault();

    if (user != null)
    {
        user.Username = "Bob_12";
        user.Name = "Bob";
        user.Gender = "Male";
        user.Age = 33;
        user.Weight = 90;
        user.Height = 189;

        db.SaveChanges();
    }
}

using (CourseWorkContext db = new CourseWorkContext())
{
    User user = db.Users.FirstOrDefault();

    if (user != null)
    {
        db.Users.Remove(user);
        db.SaveChanges();
    }
}

app.Run();
