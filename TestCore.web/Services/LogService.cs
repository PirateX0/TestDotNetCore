using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore.web.Services
{
    public class LogService : ILogService
    {
        public void Log(string msg)
        {
            using (FileStream fs=File.OpenWrite(Directory.GetCurrentDirectory() + "/1.txt"))
            {
                using (StreamWriter sw=new StreamWriter(fs))
                {
                    sw.Write(msg);
                }
            }
        }
    }
}
