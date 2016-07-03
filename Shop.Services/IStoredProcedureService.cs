#region

using Shop.Entities.Procedures;
using System.Collections.Generic;
 

#endregion

namespace Shop.Services
{
    public interface IStoredProcedureService
    {
        IEnumerable<ProductUIDetail> GetProductsForUI();
        //int CustOrdersDetail(int? orderID);
        //IEnumerable<CustomerOrderDetail> CustomerOrderDetail(string customerID);
    }
}