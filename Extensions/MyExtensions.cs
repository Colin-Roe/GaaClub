using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GaaClub.Helpers
{
    public static class MyExtensions
    {
        public static string YesNo(this bool value)
        {
            return value ? "Yes" : "No";
        }

        public static string YesNo(this byte value)
        {
            if (value == 0)
                return "No";
            else
                return "Yes";
        }
    }
}
