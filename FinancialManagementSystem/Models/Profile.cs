using System;
using Model.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinancialManagementSystem.Models
{
    public class Profile
    {
        [PrimaryKey]
        public Guid ProfileId { get; set; }

        [Display(Name ="display name")]
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string DisplayName { get; set; }

        [Display(Name = "login ID")]
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string LoginId { get; set; }

        [Display(Name = "password")]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Required]
        public string Pwd { get; set; }

        public bool Active { get; set; }
    }
}
