using Microsoft.AspNetCore.Mvc;
using TrendyolProduct.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace TrendyolProduct.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly TyContext _dashboardContext;
        public Class12 Textimony;

        public CategoryController(TyContext dashboardContext)
        {
            Textimony = new Class12();
            _dashboardContext = dashboardContext;
        }

        [HttpGet(Name = "PostCategory")]
        public IEnumerable<ProductURL> Get()
        {
            string filePath = @"C:\File\link.txt"; // Replace with the path to your text file
            
            List<string> lines = Textimony.ReadFileLines(filePath);

            
            foreach (string line in lines)
            {
                var linevar = new Category
                {
                    
                    Name = line
                };
                _dashboardContext.Category.Add(linevar);
            }
            _dashboardContext.SaveChanges();


            return null;
        }

        
    }
}
