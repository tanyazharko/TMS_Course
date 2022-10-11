using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeWork_10.Filters
{
    public class ResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            string path = "ResourceFilter.txt";
            string text = "ResourceFilter(OnResourceExecuted) \n";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync(text);
            }
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string path = "ResourceFilter.txt";
            string text = "ResourceFilter(OnResourceExecuting) \n";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync(text);
            }
        }
    }
}
