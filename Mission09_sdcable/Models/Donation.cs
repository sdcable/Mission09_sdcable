using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mission09_sdcable.Models
{
    public class Donation
    {
        [Key]
        [BindNever]
        public int DonationId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }
        [Required(ErrorMessage = "Please Enter a valid name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter a valid Address: ")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        [Required(ErrorMessage = "Please Enter a valid City Name: ")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter a state: ")]
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public bool Anonymous { get; set; }
    }
}
