﻿using System.ComponentModel.DataAnnotations;

namespace TGTG_Portal.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? EmailAddress { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
