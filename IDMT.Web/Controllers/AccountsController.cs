using IDMT.Application.Abstractions.Email;
using IDMT.Application.Models;
using IDMT.Infrastructure.Identity;
using IDMT.Web.Utilities;
using IDMT.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace IDMT.Web.Controllers
{
	public class AccountsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        public AccountsController(UserManager<ApplicationUser> userManager,
                                    RoleManager<IdentityRole> roleManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    IEmailService emailService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }
        public IActionResult Login()
        {
            var user = new LoginVM();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = await _userManager.FindByNameAsync(loginVM.UserName);

                if (applicationUser is null)
                {
                    TempData["error"] = "Access Denied!";
                    return RedirectToAction(nameof(AccessDenied));
                }

                var result = await _signInManager
                    .PasswordSignInAsync(applicationUser.UserName, loginVM.Password, false, lockoutOnFailure: false);


                if (result.Succeeded)
                {
                    await _signInManager.SignInWithClaimsAsync(applicationUser, false, new List<Claim>()
                            {
                                new Claim(Constants.Claim_Full_Name,applicationUser.FullName)
                            });
                    TempData["success"] = $"Hello {applicationUser.FullName}.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Invalid login attempt.";
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            return View(loginVM);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

        public IActionResult Register()
        {
            if (!_roleManager.RoleExistsAsync(Constants.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Constants.Role_Admin)).Wait();
                _roleManager.CreateAsync(new IdentityRole(Constants.Role_User)).Wait();
            }

            RegisterUserVM registerVM = new()
            {
                RoleList = _roleManager.Roles.Select(role => new SelectListItem
                {
                    Text = role.Name,
                    Value = role.Name
                }),
            };

            return View(registerVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserVM registerVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new()
                {
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Email = registerVM.UserName.Trim() + Constants.Email_Domain,
                    NormalizedEmail = (registerVM.UserName.Trim() + Constants.Email_Domain).ToUpper(),
                    EmailConfirmed = true,
                    UserName = registerVM.UserName,
                    CreatedAt = DateTime.Now
                };

                var result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(registerVM.Role))
                    {
                        await _userManager.AddToRoleAsync(user, registerVM.Role);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, Constants.Role_User);
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    TempData["success"] = $"User {user.FullName} has been successfully registered.";

                    return RedirectToAction("Index", "Home");
                }

                TempData["error"] = $"Registeration User {user.FullName} has been failed.";
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            registerVM.RoleList = _roleManager.Roles.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name
            });


            return View(registerVM);
        }
        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPasswordVM { Token = token, Email = email };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            if (!ModelState.IsValid)
                return View(resetPasswordVM);
            var user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user == null)
                RedirectToAction(nameof(ResetPasswordConfirmation));
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);
            if (!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
            TempData["success"] = $"Your password has been successfully reset";
            return RedirectToAction(nameof(ResetPasswordConfirmation));
        }
        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }




        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            ChangePasswordVM changePasswordVM = new() { UserName = User.FindFirst(ClaimTypes.Name).Value };



            //var applicationUser = await _userManager.FindByNameAsync(changePasswordVM.UserName);
            //IdentityResult result =await _userManager.ChangePasswordAsync(applicationUser, model.CurrentPassword, model.NewPassword);
            return View(changePasswordVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM changePasswordVM)
        {
            if (!ModelState.IsValid)
                return View(changePasswordVM);

            var applicationUser = await _userManager.FindByNameAsync(changePasswordVM.UserName);

            IdentityResult result = await _userManager.ChangePasswordAsync(applicationUser, changePasswordVM.CurrentPassword, changePasswordVM.NewPassword);

            if (result.Succeeded)
            {
                TempData["success"] = $"Your password has been successfully changed";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                TempData["error"] = $"Changing your password has been failed!";
                return View(changePasswordVM);
            }
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgetPasswordVM forgotPasswordVM)
        {
            if (!ModelState.IsValid)
                return View(forgotPasswordVM);
            var user = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);
            if (user == null)
                return RedirectToAction(nameof(ForgotPasswordConfirmation));
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callback = Url.Action(nameof(ResetPassword), "Accounts", new { token, email = user.Email }, Request.Scheme);

            IEnumerable<string> toMails = new List<string>() { user.Email };

            // email message:
            var message =  EmailMessage.Create(toMails, "Reset password token", callback);

            //// Call mail service to send email message
            await _emailService.SendAsync(message);

            // Send Reset Link Via email
            return RedirectToAction(nameof(ForgotPasswordConfirmation));
        }

        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

    }
}