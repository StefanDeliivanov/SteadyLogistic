namespace SteadyLogistic.Areas.Identity.Pages.Account
{
    using System;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;   
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using SteadyLogistic.Data.Models;

    using static SteadyLogistic.Areas.AreaGlobalConstants.Roles;
    using static SteadyLogistic.Data.DataConstants.Displays;
    using static SteadyLogistic.Data.DataConstants.ErrorMessages;
    using static SteadyLogistic.Data.DataConstants.Global; 

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;    

        public RegisterModel(
            SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;         
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {         
            [Required]
            [EmailAddress(ErrorMessage = emailErrorMessage)]
            [StringLength(emailMaxLength, MinimumLength = emailMinLength,
                ErrorMessage = emailErrorMessage)]
            public string Email { get; set; }

            [Required]
            [StringLength(passwordMaxLength, MinimumLength = passwordMinLength, 
                ErrorMessage = passwordErrorMessage)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = confirmPassword)]
            [Compare("Password", ErrorMessage = confirmPasswordErrorMessage)]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    RegisteredOn = DateTime.UtcNow
                };

                var result = await this.userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await this.userManager.AddToRoleAsync(user, MemberRoleName);
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}