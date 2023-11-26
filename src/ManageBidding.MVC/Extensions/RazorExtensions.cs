using Microsoft.AspNetCore.Mvc.Razor;

namespace ManageBidding.MVC.Extensions
{
    public static class RazorExtensions
    {
        public static string FormarBiddingNumber(this RazorPage page, int biddingNumber)
        {
            return biddingNumber.ToString(@"0000000000");
        }
    }
}
