using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using TestCore.web.Models;
using TestCore.web.Services;

namespace TestCore.web.Controllers
{
    public class HomeController : Controller
    {
        private TestService testService;
        private IUserService userService;
        private IAdminService adminService;
        private IHostingEnvironment hostingEnvironment;
        private IMemoryCache memoryCache;
        private ILogger logger;

        public HomeController(
            TestService testService, IUserService userService, IAdminService adminService, IHostingEnvironment hostingEnvironment,
            IMemoryCache memoryCache, ILogger<HomeController> logger)
        {
            this.testService = testService;
            this.userService = userService;
            this.adminService = adminService;
            this.hostingEnvironment = hostingEnvironment;
            this.memoryCache = memoryCache;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            //string s = null;
            //s.ToString();
           
            //memoryCache.Set<string>("name","dalong"+DateTime.Now,TimeSpan.FromSeconds(10));

            //HttpContext.Session.SetString("name","longlong");

            logger.LogInformation("go to index html");
            logger.LogWarning("there are risk in the front...");

            //try
            //{
            //    string s = null;
            //    s.ToString();
            //}
            //catch (Exception ex)
            //{
            //    logger.LogError(ex.Message);
            //}
           




            return Content(testService.Hello()+","+userService.GetUserCount()+","+adminService.GetPassword());
        }

        public IActionResult About()
        {
             dynamic d= HttpContext.RequestServices.GetService(typeof(IUserService));
            string webRootPath = hostingEnvironment.WebRootPath;
            string contentRootPath = hostingEnvironment.ContentRootPath;
            bool isDevEnv = hostingEnvironment.IsDevelopment();
            string settingsPath = Path.Combine(contentRootPath, @"appsettings.json");
            string icoPath = Path.Combine(webRootPath, @"favicon.ico");

            //ViewData["Message"] = d.GetUserCount();
            //ViewData["Message"] = "webRootPath: "+webRootPath+"</br>"
            //                        + ", contentRootPath: "+contentRootPath + "</br>" 
            //                        + ", isDevEnv: "+isDevEnv + "</br>"
            //                        + ", settingsPath: "+settingsPath + "</br>"
            //                        + ", icoPath: " + icoPath;
            //ViewData["Message"] = "Your application description page.";

            //string name;
            //if (memoryCache.TryGetValue<string>("name",out name))
            //{
            //    ViewData["Message"] = name;
            //}
            //else
            //{
            //    ViewData["Message"] = "can't find name in cache";
            //}

            //name = HttpContext.Session.GetString("name");

            HtmlEncoder htmlEncoder = HtmlEncoder.Default;

           

            string encodeHtml = htmlEncoder.Encode("<br/>");
            string html = "<br/>";

                ViewData["Message"] = encodeHtml+","+html;
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
