using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDifference
{
    public class MyDbContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Dog> Dogs { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=10.164.99.112;database=longUbuntu;uid=debian-sys-maint;pwd=root;SslMode = none;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var etPerson = modelBuilder.Entity<Person>();
            //etPerson.ToTable("T_Persons");

            //var etDog = modelBuilder.Entity<Dog>();
            //etDog.ToTable("T_Dogs");
            //etDog.HasOne(e => e.Person).WithMany().HasForeignKey(e => e.PersonId);

            //查找所有FluentAPI配置
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);

            //应用FluentAPI
            foreach (var type in typesToRegister)
            {
                //dynamic使C#具有弱语言的特性，在编译时不对类型进行检查

                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }

    }
}
