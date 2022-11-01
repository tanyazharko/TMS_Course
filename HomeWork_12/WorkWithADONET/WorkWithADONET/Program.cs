using NodaTime;
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
    User user1 = new User { Username = "Tom11", Name = "Tom", Gender = "Male", Age = 33, Weight = 90, Height = 189 };
  
    db.Users.AddRange(user1);
    db.SaveChanges();
}

using (CourseWorkContext db = new CourseWorkContext())
{
    var users = db.Users.ToList();
    Console.WriteLine("Users list:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}

app.Run();
