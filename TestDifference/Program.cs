using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Drawing;
using CaptchaGen.NetCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestDifference
{
    class Program
    {
        static void Main(string[] args)
        {

            //using (FileStream fs = File.OpenWrite(Directory.GetCurrentDirectory()+"/1.jpg"))
            //using (Stream picStream = ImageFactory.BuildImage("cool", 50, 100, 20, 10, ImageFormatType.Jpeg))
            //{
            //    picStream.CopyTo(fs);
            //}

            //var builder =
            //                new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())//SetBasePath设置配置文件所在路径
            //                .AddJsonFile("settings.json");
            //var configRoot = builder.Build();
            //var value =
            //            configRoot.GetSection("db").GetSection("type").Value;
            //System.Console.WriteLine(value);

            using (MyDbContext con=new MyDbContext() )
            {
                //Person person = new Person { Age = 18, Gender = false, Name = "dalong" };
                //con.Persons.Add(person);
                //con.SaveChanges();
                var d = con.Dogs.Include(e=>e.Person).First();
                var p = d.Person.Name;
                Console.WriteLine(p);

            }
          


            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}
