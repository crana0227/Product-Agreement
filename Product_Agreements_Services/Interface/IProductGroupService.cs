using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Product_Agreements.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Product_Agreements_Services
{
    public interface IProductGroupService
    {
        IEnumerable<SelectListItem> GetAllProductGroups();
    }
}
