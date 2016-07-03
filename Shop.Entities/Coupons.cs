using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Entities
{
   public class Coupons :Entity
    {
        public int ID { get; set; }
        public String CouponCode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int value { get; set; }
        public CouponType CouponType { get; set; }
    }
}
