﻿namespace OpenRedding.Identity.Areas.Identity.Pages.Account
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    [AllowAnonymous]
    public class ResetPasswordConfirmation : PageModel
    {
        public void OnGet()
        {
        }
    }
}
