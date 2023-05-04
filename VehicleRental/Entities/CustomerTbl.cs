using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Entities
{
    public partial class CustomerTbl
    {
        public CustomerTbl()
        {
            OrdersTbls = new HashSet<OrdersTbl>();
        }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordCust { get; set; }

        public string Salt { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrdersTbl> OrdersTbls { get; set; }
        [NotMapped]
        public string Token { get; set; }
       

    }
}
