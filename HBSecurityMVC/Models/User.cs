using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HBSecurityMVC.Models
{
    public class User 
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Company Name is required.")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Contact Name is required.")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "Contact Title is required.")]
        public string ContactTitle { get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Postal Code is required.")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Company Name is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Company Name is required.")]
        public string Password { get; set; }

    }
}