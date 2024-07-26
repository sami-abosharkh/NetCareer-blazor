using Microsoft.AspNetCore.Identity;
using NetCareer.Components.Pages;
using NetCareer.Models;

namespace NetCareer.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<ApplicationUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<ApplicationUser> GetRequiredUserAsync(HttpContext context)
        {
            var User = await userManager.GetUserAsync(context.User);

            if (User is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load User with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return User;
        }
    }
}
