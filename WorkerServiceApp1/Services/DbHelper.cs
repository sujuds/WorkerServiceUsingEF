using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkerServiceApp1.Models;

namespace WorkerServiceApp1.Services
{
    public class DbHelper
    {
        private AppDbContext dbContext;

        private DbContextOptions<AppDbContext> GetAllOptions()
        {
            var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBuilder.UseMySql(AppSettings.ConnectionString, ServerVersion.AutoDetect(AppSettings.ConnectionString));
            return optionBuilder.Options;
        }


        //GetAllUser
        public List<User> GetAllUser()
        {
            using (dbContext = new AppDbContext(GetAllOptions()))
            {
                try
                {
                    var users = dbContext.Users.ToList();
                    if (users != null)
                    {
                        return users;
                    }
                    else
                    {
                        return new List<User>();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        //Seed Data
        //Used when no data is present, we want some default data to fill in the database
        public void SeedData()
        {
            using(dbContext=new AppDbContext(GetAllOptions()))
            {
                dbContext.Users.Add(new User
                {
                    Name = "Sujud",
                    Address = "Denpasar, Bali"
                });
                dbContext.SaveChanges();
            }
        }
    }
}
