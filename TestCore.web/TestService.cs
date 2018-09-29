using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore.web
{
    public class TestService
    {
        private DataService dataService;

        public TestService(DataService dataService)
        {
            this.dataService = dataService;
        }

        public string Hello()
        {
            return "hello dalong"+dataService.GetCount();
        }
    }
}
