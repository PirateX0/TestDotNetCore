using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCore.web.Services;

namespace TestCore.web.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private ILogService logService;
        public ExceptionFilter(ILogService logService)
        {
            this.logService = logService;
        }
        public void OnException(ExceptionContext context)
        {
            logService.Log(context.Exception.Message);
        }
    }
}
