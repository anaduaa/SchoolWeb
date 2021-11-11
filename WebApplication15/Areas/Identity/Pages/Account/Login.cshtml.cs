using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApplication15.Models;

namespace WebApplication15.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<MyUser> signInManager, 
            ILogger<LoginModel> logger,
            Microsoft.AspNetCore.Identity.UserManager<MyUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    //    var UserManager = new Microsoft.AspNet.Identity.UserManager<ApplicationDbContext>(new UserStore<WebApplication15User>(WebApplication15Context));
                    //    UserManager.AddToRole(UserManager.().Id, "Admin");
                    //var UserName =  User.Identity.GetUserId();
                    //var _context = new WebApplication15Context();
                    //Microsoft.AspNetCore.Identity.UserManager<WebApplication15User> UserManager = new Microsoft.AspNetCore.Identity.UserManager<WebApplication15User>(new UserStore<WebApplication15User>(_context));
                    //object p = UserManager.AddToRoleAsync("UserName", "UserRole");
                     //var user=User.Identity.GetUserId();

                    //  if(user)
                    //  AddToRole(user,"Admin");
                    // var roleIds = appdbcontext.UserRoles.Where(u => u.UserId == user).Select(r => r.RoleId).ToList();
                    //   var roleIds = _userManager.FindByIdAsync(User.Identity.GetUserId())..Select(r => r.RoleId);

                    //var roleNames = await _userManager.GetRolesAsync(user);

                    //var roleIds = _roleManager.Roles.Where(r => roleNames.AsEnumerable().Contains(r.Name)).Select(r => r.Id).ToList();
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
