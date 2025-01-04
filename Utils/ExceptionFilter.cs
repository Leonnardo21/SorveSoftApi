using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SorveSoftApi.Utils
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var response = new
            {
                message = "Um erro inexperado ocorreu, tente novamente mais tarde.",
                details = context.Exception.Message
            };

            context.Result = new JsonResult(response)
            {
                StatusCode = 500
            };
        }
    }
}
