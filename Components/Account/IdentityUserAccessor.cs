using Microsoft.AspNetCore.Identity;
using NetCareer.Models;

namespace NetCareer.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<ApplicationUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<ApplicationUser> GetRequiredUserAsync(HttpContext context)
        {
            var JobPost = await userManager.GetUserAsync(context.User);

            if (JobPost is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load JobPost with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return JobPost;
        }
    }
}
