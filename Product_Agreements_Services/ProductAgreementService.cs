using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Product_Agreements.Data;
using Product_Agreements.Entities;
using Product_Agreements.ViewModel;
using Product_Agreements.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Product_Agreements_Services
{
    public class ProductAgreementService : IProductAgreementService
    {
        private readonly ProductAgreementDbContext _prdAgreementDbContext;
        private readonly IConfiguration _configuration;
        public ProductAgreementService(ProductAgreementDbContext prdAgreementDbContext, IConfiguration configuration)
        {
            this._prdAgreementDbContext = prdAgreementDbContext;
            this._configuration = configuration;
        }
        public void AddProductAgreement(Agreement objAgreement)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductAgreement(int id)
        {
            var objProductAgreement = _prdAgreementDbContext.Agreements.Find(id);
            if (objProductAgreement == null)
                return false;
            _prdAgreementDbContext.Agreements.Remove(objProductAgreement);
            _prdAgreementDbContext.SaveChanges();
            return true;
        }

        public List<ProductAgreementViewModel> GetAllProductAgreements(SearchCriteriaViewModel searchParams,string logInUserId)
        {
            DataTable dtProdAgreement = new DataTable();
            List<ProductAgreementViewModel> lstProgAgreement = new List<ProductAgreementViewModel>();
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                conn.Open();
                SqlCommand com = new SqlCommand("spDataInDataTable", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@sortColumn", searchParams.SortColumn);
                com.Parameters.AddWithValue("@sortOrder", searchParams.SortOrder);
                com.Parameters.AddWithValue("@OffsetValue", searchParams.OffSetValue);
                com.Parameters.AddWithValue("@PagingSize", searchParams.PagingSize);
                com.Parameters.AddWithValue("@SearchText", searchParams.SearchText);
                com.Parameters.AddWithValue("@LogInUserId", logInUserId);
                SqlDataAdapter daProdAgreement = new SqlDataAdapter(com);
                daProdAgreement.Fill(dtProdAgreement);

                if (dtProdAgreement != null && dtProdAgreement.Rows.Count > 0)
                {
                    foreach (DataRow drProdAgreement in dtProdAgreement.Rows)
                    {
                        ProductAgreementViewModel vmProgrammingAgreement = new ProductAgreementViewModel();
                        vmProgrammingAgreement.id = string.IsNullOrEmpty(drProdAgreement["Id"].ToString()) ? 0 : Convert.ToInt32(drProdAgreement["Id"].ToString());
                        vmProgrammingAgreement.username = string.IsNullOrEmpty(drProdAgreement["UserName"].ToString()) ? string.Empty : drProdAgreement["UserName"].ToString();
                        vmProgrammingAgreement.productgroupcode = string.IsNullOrEmpty(drProdAgreement["GroupCode"].ToString()) ? string.Empty : drProdAgreement["GroupCode"].ToString();
                        vmProgrammingAgreement.productgroupdescription = string.IsNullOrEmpty(drProdAgreement["GroupDescription"].ToString()) ? string.Empty : drProdAgreement["GroupDescription"].ToString();
                        vmProgrammingAgreement.productnumber = string.IsNullOrEmpty(drProdAgreement["ProductNumber"].ToString()) ? string.Empty : drProdAgreement["ProductNumber"].ToString();
                        vmProgrammingAgreement.productdescription = string.IsNullOrEmpty(drProdAgreement["ProductDescription"].ToString()) ? string.Empty : drProdAgreement["ProductDescription"].ToString();
                        vmProgrammingAgreement.effectivedate = string.IsNullOrEmpty(drProdAgreement["EffectiveDate"].ToString()) ? DateTime.Now : Convert.ToDateTime(drProdAgreement["EffectiveDate"].ToString());
                        vmProgrammingAgreement.expirationdate = string.IsNullOrEmpty(drProdAgreement["ExpirationDate"].ToString()) ? DateTime.Now : Convert.ToDateTime(drProdAgreement["ExpirationDate"].ToString());
                        vmProgrammingAgreement.productprice = string.IsNullOrEmpty(drProdAgreement["ProductPrice"].ToString()) ? 0 : Convert.ToDecimal(drProdAgreement["ProductPrice"].ToString());
                        vmProgrammingAgreement.newprice = string.IsNullOrEmpty(drProdAgreement["NewPrice"].ToString()) ? 0 : Convert.ToDecimal(drProdAgreement["NewPrice"].ToString());
                        vmProgrammingAgreement.filtertotalcount = string.IsNullOrEmpty(drProdAgreement["FilterTotalCount"].ToString()) ? 0 : Convert.ToInt32(drProdAgreement["FilterTotalCount"].ToString());
                        lstProgAgreement.Add(vmProgrammingAgreement);
                    }
                }
            }
            return lstProgAgreement;
        }

        public Agreement GetProductAgreement(int id)
        {
            var objAgreementEnt = new Agreement();
            objAgreementEnt = _prdAgreementDbContext.Agreements.Where(a => a.Id == id).FirstOrDefault();
            return objAgreementEnt;
        }

        public void SaveProductAgreement(Agreement objProductAgreement)
        {
            if (objProductAgreement.Id == 0)
            {
                _prdAgreementDbContext.Agreements.Add(objProductAgreement);
            }
            _prdAgreementDbContext.SaveChanges();
        }
    }
}
