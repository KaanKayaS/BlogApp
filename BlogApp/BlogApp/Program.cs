using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();   // controllerı viewlerle ilişkilendirme 


builder.Services.AddDbContext<BlogContext>(options => {
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("mssql_connection");
   // options.UseSqlite(connectionString);
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath ="/Users/Login";
});

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);


app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/details/{url}",
    defaults: new { controller ="Posts", action ="Details"}
);

app.MapControllerRoute(
    name: "posts_by_tag",
    pattern: "posts/tag/{tag}",
    defaults: new { controller ="Posts", action ="Index"}
);

app.MapControllerRoute(
    name: "user_profile",
    pattern: "profile/{username}",
    defaults: new { controller ="Users", action ="Profile"}
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=posts}/{action=Index}/{id?}"
);

app.Run();
