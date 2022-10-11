using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeWork_10.Filters
{
    public class ResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            string path = "ResultFilter.txt";
            string text = "ResultFilter (OnResultExecuted) \n";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync(text);
            }
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            string path = "ResultFilter.txt";
            string text = "ResultFilter (OnResultExecuting) \n";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync(text);
            }
        }
    }
}
