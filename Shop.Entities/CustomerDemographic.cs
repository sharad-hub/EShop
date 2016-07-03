using System;
using System.Collections.Generic;
using Repository.Pattern.Ef6;

namespace Shop.Entities
{
    public partial class CustomerDemographic : Entity
    {
        public CustomerDemographic()
        {
            this.Customers = new List<Customer>();
        }

        public string CustomerTypeID { get; set; }
        public string CustomerDesc { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
