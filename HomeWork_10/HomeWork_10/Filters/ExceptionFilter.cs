using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeWork_10.Filters
{
    public class ExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string path = "ExceptionFilter.txt";
            string text = "ExceptionFilter \n";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync(text);
            }
        }
    }
}
