using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                 if(context.Database.GetPendingMigrations().Any())   // bekleyen migration varsa uygulanır.
                 {                                                   // GetpendingMigrations any metodu ile bekleyen migration varsa kontrol ediyoruz ve uyguluyoruz
                       context.Database.Migrate();
                 }

                 if(!context.Tags.Any())
                 {
                    context.AddRange(
                           new Tag {Text = "Web Programlama", Url="web-programlama", Color=TagColors.info},
                           new Tag {Text = "Backend", Url="backend", Color=TagColors.warning},
                           new Tag {Text = "Frontend", Url="frontend",Color=TagColors.success},
                           new Tag {Text = "FullStack", Url="fullstack",Color=TagColors.secondary},
                           new Tag {Text = "php", Url="php",Color=TagColors.primary}
                    );
                    context.SaveChanges();
                 }

                 if(!context.Users.Any())
                 {
                    context.AddRange(
                            new User { UserName = "kaankaya",Name="Kaan Kaya", Email="kaan@info.abc", Password="123456", Image="kaan2.jpg"},
                             new User { UserName = "enesbener",Name="Enes Bener", Email="enes@info.abc", Password="654321", Image="enes1.jpg"}

                    );
                    context.SaveChanges();
                 }

                 if(!context.Posts.Any())
                 {
                    context.AddRange(
                           new Post {
                                 Title = "Asp.Net",
                                 Content ="Asp.Net Dersleri",
                                 Description ="Asp.Net Dersleri",
                                 Url = "aspnet-core",
                                 IsActive = true,
                                 PublishedOn = DateTime.Now.AddDays(-10),
                                 Tags = context.Tags.Take(3).ToList(),
                                 Image ="1.jpg",
                                 UserId = 1,
                                 Comments = new List<Comment> {
                                     new Comment { Text="iyi bir kurs", PublishedOn = new DateTime(),UserId =1},
                                     new Comment { Text="çok faydasini gördüm", PublishedOn = new DateTime(),UserId =2}
                                     }
                                     
                           },
                           new Post {
                                 Title = "Php",
                                 Content ="Php Dersleri",
                                 Description ="Php Dersleri",
                                 Url = "php",
                                 IsActive = true,
                                 PublishedOn = DateTime.Now.AddDays(-20),
                                 Tags = context.Tags.Take(2).ToList(),
                                 Image ="2.jpg",
                                 UserId = 1
                           },
                           new Post {
                                 Title = "Django",
                                 Content ="Django Dersleri",
                                 Description ="Django Dersleri",
                                 Url = "django",
                                 IsActive = true,
                                 PublishedOn = DateTime.Now.AddDays(-30),
                                 Tags = context.Tags.Take(4).ToList(),
                                 Image ="3.jpg",
                                 UserId = 2
                           },
                           new Post {
                                 Title = "React",
                                 Content ="React Dersleri",
                                 Description ="React Dersleri",
                                 Url = "react",
                                 IsActive = true,
                                 PublishedOn = DateTime.Now.AddDays(-40),
                                 Tags = context.Tags.Take(4).ToList(),
                                 Image ="3.jpg",
                                 UserId = 2
                           },
                           new Post {
                                 Title = "Angular",
                                 Content ="Angular Dersleri",
                                 Description ="Angular Dersleri",
                                 Url = "angular",
                                 IsActive = true,
                                 PublishedOn = DateTime.Now.AddDays(-50),
                                 Tags = context.Tags.Take(4).ToList(),
                                 Image ="3.jpg",
                                 UserId = 2
                           },
                           new Post {
                                 Title = "Java",
                                 Content ="Java Dersleri",
                                 Description ="Java Dersleri",
                                 Url = "java",
                                 IsActive = true,
                                 PublishedOn = DateTime.Now.AddDays(-60),
                                 Tags = context.Tags.Take(4).ToList(),
                                 Image ="3.jpg",
                                 UserId = 2
                           }
                    );
                    context.SaveChanges();
                 }
            }
        }


    }
}