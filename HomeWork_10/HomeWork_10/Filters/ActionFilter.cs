using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeWork_10.Filters
{
    public class ActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string path = "ActionFilter.txt";
            string text = "ActionFilter (OnActionExecuted) \n";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync(text);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string path = "ActionFilter.txt";
            string text = "ActionFilter(OnActionExecuting) \n";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync(text);
            }
        }
    }
}
