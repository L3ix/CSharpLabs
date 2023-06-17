using HelloApp.Classes;
using HelloApp.Classes.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace HelloApp
{
    class Program
    { 
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Database.ExecuteSqlRaw("TRUNCATE TABLE [Users];");

                User user1 = new User { Name = "Tom", Age = 33 };
                User user2 = new User { Name = "Alice", Age = 26 };

                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                var users = db.Users.ToList();
                Console.WriteLine("Список объектов:");
                foreach (User u in users)
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            }
            Console.Read();
        }
    }
}