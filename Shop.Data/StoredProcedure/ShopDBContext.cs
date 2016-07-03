using Shop.Entities.Procedures;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Shop.Data
{
    public partial class ShopDBContext : IShopStoredProcedures
    {
        //public IEnumerable<ProductUIDetail> ProductUIDetail()
        //{
        //    //var customerIDParameter = customerID != null ?
        //    //    new SqlParameter("@CustomerID", customerID) :
        //    //    new SqlParameter("@CustomerID", typeof (string));
        //    return Database.SqlQuery<ProductUIDetail>("CustOrderHist ", null);//@CustomerID", customerIDParameter);
        //}


        //IEnumerable<ProductUIDetail>  ProductUIDetail()
        //{
        //    return Database.SqlQuery<ProductUIDetail>("CustOrderHist ", null);
        //    //throw new System.NotImplementedException();
        //}

        IEnumerable<ProductUIDetail> IShopStoredProcedures.ProductUIDetail()
        {
            var customerIDParameter =  new SqlParameter("@CategoryID", 9);
         //new SqlParameter("@CategoryID", typeof(int));
            return Database.SqlQuery<ProductUIDetail>("ProductUIDetail @CategoryID", customerIDParameter);
        }
    }

    public interface IShopStoredProcedures
    {
        IEnumerable<ProductUIDetail> ProductUIDetail();
    }
}
