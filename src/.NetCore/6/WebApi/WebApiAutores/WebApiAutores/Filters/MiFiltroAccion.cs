using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiAutores.Filters
{
    public class MiFiltroAccion : IActionFilter
    {
        private readonly ILogger<MiFiltroAccion> logger;

        public MiFiltroAccion(ILogger<MiFiltroAccion> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogDebug("Antes de iniciar la acción");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogDebug("Después de iniciar la acción");
        }
    }
}