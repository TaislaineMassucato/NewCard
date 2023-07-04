using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NewCard.Attributes
{
        [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]

        public class ApiKeyAttribute : Attribute, IAsyncActionFilter
        {
            public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
                ActionExecutionDelegate next)
            {
                if (!context.HttpContext.Request.Query.TryGetValue(Configuracao.ApiKeyName, out var extractedApiKey))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 401,
                        Content = "ApiKey não encontrada"
                    };
                    return;
                }

                if (!Configuracao.ApiKey.Equals(extractedApiKey))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 403,
                        Content = "Acesso não autorizado"

                    };
                    return;
                }

                await next();
            }
        }
}
