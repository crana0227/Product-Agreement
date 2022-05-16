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
    public class ProductGroupService : IProductGroupService
    {
        private readonly ProductAgreementDbContext _prdAgreementDbContext;
        public ProductGroupService(ProductAgreementDbContext prdAgreementDbContext)
        {
            this._prdAgreementDbContext = prdAgreementDbContext;
        }
        public IEnumerable<SelectListItem> GetAllProductGroups()
        {
            var objProductGroupList = (from productGroup in _prdAgreementDbContext.ProductGroups
                                       select new SelectListItem()
                                       {
                                           Text = productGroup.GroupCode,
                                           Value = productGroup.Id.ToString(),
                                       }).ToList();

            objProductGroupList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });


            return objProductGroupList;
            
        }
    }
}
