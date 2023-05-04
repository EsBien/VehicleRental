using System;
using System.Collections.Generic;

#nullable disable

namespace MyFirstWebProject.Models
{
    public partial class CustomerTbl
    {
        public CustomerTbl()
        {
            OrdersTbls = new HashSet<OrdersTbl>();
        }

        public string Email { get; set; }
        public string PasswordCust { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<OrdersTbl> OrdersTbls { get; set; }
    }
}
