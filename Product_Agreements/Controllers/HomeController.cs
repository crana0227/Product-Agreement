using Microsoft.AspNetCore.Mvc;
using Product_Agreements.Models;
using Product_Agreements.Entities;
using Product_Agreements_Services;
using System.Diagnostics;
using Product_Agreements.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Product_Agreements.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductAgreementService _productAgrService;
        private readonly IProductGroupService _prodGroupService;
        private readonly IProductService _prodService;

        public HomeController(ILogger<HomeController> logger, 
                    IProductAgreementService productAgrService,
                    IProductGroupService prodGroupService,
                    IProductService prodService)
        {
            _logger = logger;
            _productAgrService = productAgrService;
            _prodGroupService = prodGroupService;
            _prodService = prodService;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult LoadProductAgreements()
        {
            List<ProductAgreementViewModel> prodAgreementVM = new List<ProductAgreementViewModel>();
            try
            {
                var logInUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault(); ;
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                /* Define SearchCriteria Object Model */
                SearchCriteriaViewModel searchParams = new SearchCriteriaViewModel();
                searchParams.OffSetValue = string.IsNullOrEmpty(start) ? 0 : Convert.ToInt32(start);
                searchParams.PagingSize = pageSize;
                searchParams.SearchText = string.IsNullOrEmpty(searchValue)? String.Empty: searchValue;
                searchParams.SortColumn = string.IsNullOrEmpty(sortColumn) ? String.Empty : sortColumn;
                searchParams.SortOrder  = string.IsNullOrEmpty(sortColumnDirection) ? String.Empty : sortColumnDirection;
                /* Call to Service Method class to fetch Data from Database */
                prodAgreementVM = _productAgrService.GetAllProductAgreements(searchParams, logInUserId);
                recordsTotal = prodAgreementVM.FirstOrDefault() != null ? Convert.ToInt32(prodAgreementVM.FirstOrDefault().filtertotalcount):0;
                
                var data = prodAgreementVM.ToList();
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public IActionResult Save(int Id)
        {
            /* Call to Service Method class to fetch Data from Database */
            var prodAgreementEntity = _productAgrService.GetProductAgreement(Id);
            /* Call to Service Method class to fetch Data from Database */
            ViewBag.ProductGroupList = _prodGroupService.GetAllProductGroups();
            /* Call to Service Method class to fetch Data from Database */
            ViewBag.ProductList = prodAgreementEntity != null ? _prodService.GetAllProducts(prodAgreementEntity.ProductGroupId): _prodService.GetAllProducts(null);
            var prodAgreementModel = new ProductAgreementModel();
            if (prodAgreementEntity != null)
            {
                prodAgreementModel.UserId = prodAgreementEntity.UserId;
                prodAgreementModel.ProductGroupId = prodAgreementEntity.ProductGroupId;
                prodAgreementModel.ProductId = prodAgreementEntity.ProductId;
                prodAgreementModel.EffectiveDate = prodAgreementEntity.EffectiveDate;
                prodAgreementModel.ExpirationDate = prodAgreementEntity.ExpirationDate;
                prodAgreementModel.ProductPrice = prodAgreementEntity.ProductPrice;
                prodAgreementModel.NewPrice = prodAgreementEntity.NewPrice;
            }
            else
            {
                prodAgreementModel.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                prodAgreementModel.ProductPrice = 0;
            }
            return View(prodAgreementModel);            
        }
        [HttpPost]
        public IActionResult DeleteAgreement(int Id)
        {
            try
            {
                /* Call to Service Method class to fetch Data from Database */
                var result = _productAgrService.DeleteProductAgreement(Id);
                var jsonData = "";
                if (result)
                    jsonData = "Deleted";
                else
                    jsonData = "Not Deleted";
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public ActionResult Save(ProductAgreementModel objProductAgreemetModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var prodAgreementEntity = new Agreement();
                    if (objProductAgreemetModel.Id > 0)
                    {
                        //Edit 
                        /* Call to Service Method class to fetch Data from Database */
                        prodAgreementEntity = _productAgrService.GetProductAgreement(objProductAgreemetModel.Id);
                    }
                    else
                    {
                        //Save
                        /* Call to Service Method class to fetch Data from Database */
                        prodAgreementEntity.Id = 0;                        
                    }
                    prodAgreementEntity.UserId = objProductAgreemetModel.UserId;
                    prodAgreementEntity.ProductGroupId = objProductAgreemetModel.ProductGroupId;
                    prodAgreementEntity.ProductId = objProductAgreemetModel.ProductId;
                    prodAgreementEntity.EffectiveDate = objProductAgreemetModel.EffectiveDate;
                    prodAgreementEntity.ExpirationDate = objProductAgreemetModel.ExpirationDate;
                    prodAgreementEntity.ProductPrice = objProductAgreemetModel.ProductPrice;
                    prodAgreementEntity.NewPrice = objProductAgreemetModel.NewPrice;
                    _productAgrService.SaveProductAgreement(prodAgreementEntity);
                    status = true;
                }
                var jsonData = new { status = status };
                return new JsonResult(jsonData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult GetProductsByGroupId(int productGroupId)
        {
            try
            {
                var objProductList = _prodService.GetAllProducts(productGroupId);
                return Json(objProductList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult GetProductPriceById(int productId)
        {
            try
            {
                var objProduct = _prodService.GetProduct(productId);
                return Json(objProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}