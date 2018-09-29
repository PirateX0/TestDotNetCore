using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore.web.Services
{
    public class AdminService : IAdminService
    {
        private IUserService userService;
        public AdminService(IUserService userService)
        {
            this.userService = userService;
        }

        public string GetPassword()
        {
            return "don't tell you my pwd! I tell you the user count: "+ userService.GetUserCount();
        }
    }
}
