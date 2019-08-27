using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinancialManagementSystem.Models;
using FinancialManagementSystem.Models.DB;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace FinancialManagementSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LoginContext loginStoreManager;

        [BindProperty]
        public LoginViewModel user { get; set; }

        public IndexModel(LoginContext context)
        {
            try
            {
                // Settings.
                this.loginStoreManager = context;
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }
        }

        public IActionResult OnGet()
        {
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    return RedirectToPage("/App/Index");
                }
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                // Verification.
                if (ModelState.IsValid)
                {
                    // Initialization.
                    var loginInfo = await this.loginStoreManager.LoginMethodAsync(user.LoginId, user.Pwd);

                    // Verification.
                    if (loginInfo != null && loginInfo.Count() > 0)
                    {
                        // Initialization.
                        var logindetails = loginInfo.First();

                        // Login In.
                        await this.SignInUser(logindetails.LoginId, false);

                        // Info.
                        return this.RedirectToPage("/App/Index");
                    }
                    else
                    {
                        // Setting.
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Info.
            return this.Page();
        }

        private async Task SignInUser(string username, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Sign In.
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }
    }
}
