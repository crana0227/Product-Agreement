using Microsoft.AspNetCore.Mvc.Rendering;
using Product_Agreements.Data;
using Product_Agreements.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Agreements_Services
{
    public class ProductService : IProductService
    {
        private readonly ProductAgreementDbContext _prdAgreementDbContext;
        public ProductService(ProductAgreementDbContext prdAgreementDbContext)
        {
            this._prdAgreementDbContext = prdAgreementDbContext;
        }
        public IEnumerable<SelectListItem> GetAllProducts(int? prodGroupId)
        {
            var objProductList = new List<SelectListItem>();
            if (prodGroupId != 0 && prodGroupId != null)
            {
                objProductList = (from product in _prdAgreementDbContext.Products
                                      where product.ProductGroupId == prodGroupId
                                      select new SelectListItem()
                                      {
                                          Text = product.ProductNumber,
                                          Value = product.Id.ToString(),
                                      }).ToList();
            }
            else
            {
                objProductList = (from product in _prdAgreementDbContext.Products
                                      //where product.ProductGroupId == prodGroupId
                                      select new SelectListItem()
                                      {
                                          Text = product.ProductNumber,
                                          Value = product.Id.ToString(),
                                      }).ToList();
            }
            objProductList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });

            return objProductList;
        }

        public Product GetProduct(int productId)
        {
            var objProduct = new Product();
            objProduct = _prdAgreementDbContext.Products.Where(a => a.Id == productId).FirstOrDefault();
            return objProduct;
        }
    }
}
