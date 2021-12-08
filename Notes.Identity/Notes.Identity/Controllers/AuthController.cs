using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Notes.Identity.Models;
using System.Threading.Tasks;

namespace Notes.Identity.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;



        public AuthController(SignInManager<AppUser> signInManager, 
            UserManager<AppUser> userManager, 
            IIdentityServerInteractionService interactionService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _interactionService = interactionService;
        }


        #region Login the user

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var loginVm = new LoginVm
            {
                ReturnUrl = returnUrl
            };
            return View(loginVm);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            // Check the model data
            if (!ModelState.IsValid)
                return View(loginVm);

            // Try to find the user
            var user = await _userManager.FindByNameAsync(loginVm.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(loginVm);
            }

            // Try sign in
            var result = await _signInManager.PasswordSignInAsync(loginVm.UserName,
                loginVm.Password, false, false);
            if (result.Succeeded)
            {
#warning Hardcode: redirection to the address manually
                return Redirect(loginVm.ReturnUrl ?? "https://localhost:44345/api/note");
            }
        //  else
            ModelState.AddModelError(string.Empty, "Login error");
            return View(loginVm);
        }

        #endregion


        #region Register the user

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var registerVm = new RegisterVm
            {
                ReturnUrl = returnUrl
            };

            return View(registerVm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            // Check the view model data
            if (!ModelState.IsValid)
                return View(registerVm);

            // Create the user
            var newUser = new AppUser
            {
                UserName = registerVm.UserName
            };

            // Try register user and sign in
            var result = await _userManager.CreateAsync(newUser, registerVm.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(newUser, false);

                // If ReturnUrl is null, redirect to login page
#warning Hardcode: redirection to the address manually
                return Redirect(registerVm.ReturnUrl ?? "/auth/login");
            }

        //  Else, return the error
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(registerVm);
        }

        #endregion


        #region Logout

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }

        #endregion
    }
}
