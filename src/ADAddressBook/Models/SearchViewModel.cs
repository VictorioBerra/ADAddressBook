using System;
using System.ComponentModel.DataAnnotations;

namespace ADAddressBook.Models
{
    public class SearchViewModel
    {
        [Required]
        [Display(Name = "UID, DisplayName, CN or SN")]
        public string username { get; set; }
    }
}