using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities

{
    /// <summary>
    /// HomeCinema Role
    /// </summary>
    public class Role : Entity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
