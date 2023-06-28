using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication4.Models;

namespace WebApplication4.Filters
{
    public class Actionfilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string day = DateTime.Now.DayOfWeek.ToString();
            
            

            if (day != "Wednesday")
            {
                context.HttpContext.Items["message"] = "Sorry it's not wednesday you cannot acces it";

                // string message = "it's not allowed other than wednesday";

                context.Result = new RedirectToActionResult("save","Home",null);
                

            }
            



            
        }
    }
}
