using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IncidentSystem.API.ActionFilters
{
    public class TransactionScopeFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            
            var resultContext = await next();

            scope.Complete();
            scope.Dispose();
        }
    }
}
