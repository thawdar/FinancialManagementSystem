using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinancialManagementSystem.Models;

namespace FinancialManagementSystem.Pages
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public Profile profile { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            //generate new profile id
            profile.ProfileId = Guid.NewGuid();
            profile.Active = true;

            //create a new profile
            await DataAccess.Profile.Insert(profile);

            return RedirectToPage("/RegisterThanks");
        }
    }
}