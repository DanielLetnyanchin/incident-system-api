using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IncidentSystem.API.ActionFilters
{
    public class TransactionScopeFilter: IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            TransactionScope scope = new TransactionScope();
            context.HttpContext.Items.Add("scope",scope);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}
