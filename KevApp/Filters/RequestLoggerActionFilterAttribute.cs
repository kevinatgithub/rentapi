using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using KevApp.Services;

namespace KevApp.Api.Filters
{
    public class RequestLoggerActionFilterAttribute : ActionFilterAttribute
    {
        private readonly IRequestLogService requestLogService;

        public RequestLoggerActionFilterAttribute(IRequestLogService requestLogService) => this.requestLogService = requestLogService ?? throw new ArgumentNullException(nameof(requestLogService));

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            requestLogService.Log(actionName);


            base.OnActionExecuting(context);
        }
    }

    public class RequestLogger : ServiceFilterAttribute
    {
        public RequestLogger() : base(typeof(RequestLoggerActionFilterAttribute))
        {
        }
    }
}
