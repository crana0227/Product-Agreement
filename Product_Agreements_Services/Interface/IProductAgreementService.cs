using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Product_Agreements.Entities;
using Product_Agreements.ViewModel;
using Product_Agreements.Models;

namespace Product_Agreements_Services
{
    public interface IProductAgreementService
    {
        List<ProductAgreementViewModel> GetAllProductAgreements(SearchCriteriaViewModel searchParams, string logInUserId);
        Agreement GetProductAgreement(int id);
        void AddProductAgreement(Agreement objProductAgreement);
        void SaveProductAgreement(Agreement objProductAgreement);
        bool DeleteProductAgreement(int id);
    }
}
