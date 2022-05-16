using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product_Agreements.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Product_Agreements_Services
{
    public interface IProductService
    {
        IEnumerable<SelectListItem> GetAllProducts(int? prodGroupId);
        Product GetProduct(int productId);
    }
}
