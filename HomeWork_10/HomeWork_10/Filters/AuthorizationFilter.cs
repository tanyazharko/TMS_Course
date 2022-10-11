using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeWork_10.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string path = "AuthorizationFilter.txt";
            string text = "AuthorizationFilter \n";

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync(text);
            }
        }
    }
}
