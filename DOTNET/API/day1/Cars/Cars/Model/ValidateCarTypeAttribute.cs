using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace Cars.Model
{
    public class ValidateCarTypeAttribute: ActionFilterAttribute
    {
        private readonly IConfiguration configuration;

        public ValidateCarTypeAttribute(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var types = configuration.GetSection("CarTypes").Get<List<string>>();

            if (types != null && context.ActionArguments["car"] is Car car && car != null)
            {
                if (!types.Any(t => t == car.Type))
                {
                    context.ModelState.AddModelError("Type", $"{car.Type} is not supported");
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
            }

        }
    }
}
