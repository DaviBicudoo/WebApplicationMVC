using Microsoft.AspNetCore.Mvc.Razor;

namespace Web_App.Extensions
{
    public static class RazorExtensions
    {
        public static string DocumentFormat(this RazorPage page, int peopleType, string document)
        {
            return peopleType == 1
                ? Convert.ToUInt64(document).ToString(@"000\.000\.000\-00")
                : Convert.ToUInt64(document).ToString(@"00\.000\.000\/0000/-00");
        }
    }
}
