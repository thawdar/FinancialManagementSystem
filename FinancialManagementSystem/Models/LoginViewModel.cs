using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialManagementSystem.Models
{
    public class LoginViewModel
    {
        #region Properties

        /// <summary>
        /// Gets or sets to username address.
        /// </summary>
        [Required]
        [Display(Name = "User ID")]
        public string LoginId { get; set; }

        /// <summary>
        /// Gets or sets to password address.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Pwd { get; set; }

        #endregion
    }
}
