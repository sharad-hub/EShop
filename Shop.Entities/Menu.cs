using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
    public partial class Menu : Entity
    {
        public int Id { get; set; }
        public Menu Parent { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public string NavigationPath { get; set; }
        //public string MyProperty { get; set; }
    }
}
