using EcommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public static List<Category> categories = new List<Category>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                //linq id trên object query
                var category = categories.SingleOrDefault(cate => cate.CategoryID == Guid.Parse(id));
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost]
        public IActionResult Add(CategoryVM categoryVM)
        {
            var category = new Category
            {
                CategoryID = Guid.NewGuid(),
                CategoryName = categoryVM.CategoryName
            };
            categories.Add(category);

            return Ok(new
            {
                Success = true,
                data = category
            });
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Category categoryUpdate)
        {
            try
            {
                var category = categories.SingleOrDefault(cate => cate.CategoryID == Guid.Parse(id));
                if (category == null)
                {
                    return NotFound();
                }
                if(id != category.CategoryID.ToString())
                {
                    return BadRequest();
                }
                category.CategoryName = categoryUpdate.CategoryName;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete ("{id}")]
        public IActionResult Remove(string id)
        {
            try
            {
                var category = categories.SingleOrDefault(cate => cate.CategoryID == Guid.Parse(id));
                if (category == null)
                {
                    return NotFound();
                }
                if (id != category.CategoryID.ToString())
                {
                    return BadRequest();
                }
                categories.Remove(category);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
