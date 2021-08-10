namespace SteadyLogistic.Areas.Identity.Pages.Account
{
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;   
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using SteadyLogistic.Data.Models;

    using static SteadyLogistic.Data.DataConstants.Global;
    using static SteadyLogistic.Areas.AreaGlobalConstants.Roles;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [StringLength(emailMaxLenght, MinimumLength = emailMinLenght)]
            public string Email { get; set; }

            [Required]
            [StringLength(passwordMaxLenght, MinimumLength = passwordMinLenght, ErrorMessage ="The password length must be between {2} and {1} characters")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and it's confirmation do not match.")]
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
                    Email = Input.Email
                };

                var result = await userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, MemberRoleName);
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}