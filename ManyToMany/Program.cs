using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyDbContext con=new MyDbContext())
            {
                var user = con.Users.First();
                var relations = con.UserRoleRelations.Where(e => e.UserId == user.Id);
                foreach (var relation in relations.Include(e=>e.Role))
                {
                    Console.WriteLine(relation.Role.Name);
                }
            }


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
