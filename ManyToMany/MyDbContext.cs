using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManyToMany
{
    class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleRelation> UserRoleRelations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=10.164.99.112;database=longUbuntu;uid=debian-sys-maint;pwd=root;SslMode = none;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var typeUser = modelBuilder.Entity<User>();
            typeUser.ToTable("T_Users");

            var typeRole = modelBuilder.Entity<Role>();
            typeRole.ToTable("T_Roles");

            var typeUserRoleRelation = modelBuilder.Entity<UserRoleRelation>();
            typeUserRoleRelation.ToTable("T_UserRoleRelations");

            typeUserRoleRelation.HasOne(e => e.Role).WithMany().HasForeignKey(e => e.RoleId).IsRequired();
            typeUserRoleRelation.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId).IsRequired();

        }
    }
}
