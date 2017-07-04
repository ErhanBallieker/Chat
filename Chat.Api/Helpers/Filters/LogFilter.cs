using Chat.ApplicationService.LogService;
using Chat.Data.Domain;
using Chat.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Chat.Api.Helpers.Filters
{
    public class LogFilter : ActionFilterAttribute
    {
        Guid reqGuid;
        private ILogService logService;
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            logService = new LogService(new Repository<Log>(new Data.Context.ChatContext()));
            var req = JsonConvert.SerializeObject(actionContext.Request?.Content);
            reqGuid = Guid.NewGuid();
            logService.CreateApiLog(new Log
            {
                Key = reqGuid,
                Request = $"Uri{actionContext.Request?.RequestUri} -- {req}"
            });
            base.OnActionExecuting(actionContext);
        }

        public override async void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            logService = new LogService(new Repository<Log>(new Data.Context.ChatContext()));
            if (actionExecutedContext.ActionContext?.Response?.Content != null)
            {
                var res = await actionExecutedContext.ActionContext?.Response?.Content?.ReadAsStringAsync();
                logService.CreateApiLog(new Log
                {
                    Key = reqGuid,
                    Response = $"Uri{actionExecutedContext.Request.RequestUri} -- {res ?? string.Empty} *** exception: {actionExecutedContext.Exception?.InnerException} ***"
                });
            }
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}