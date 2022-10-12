using AriBilgi.Blog.Data.Concrete;
using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Service.Concrete;
using AriBilgi.Blog.Shared.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AriBilgi.Blog.API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryManager categoryManager;
        public CategoryController()
        {
            categoryManager = new CategoryManager(new UnitOfWork());
        }

        [HttpPost]
        [Route("CategoryAdd")]
        public Result CategoryAdd(CategoryAddDto categoryAddDto)
        {
            return categoryManager.Add(categoryAddDto);
        }

        [HttpPost]
        [Route("CategoryGet")]
        public DataResult<CategoryDto> CategoryGet(CategoryGetDto categoryGetDto)
        {
            return categoryManager.Get(categoryGetDto);
        }

        [HttpPost]
        [Route("CategoryGetList")]
        public DataResult<List<CategoryDto>> CategoryGetList()
        {
            return categoryManager.GetAll();
        }

        [HttpPost]
        [Route("CategoryRemove")]
        public Result CategoryRemove(CategoryRemoveDto categoryRemoveDto)
        {
            return categoryManager.Remove(categoryRemoveDto);
        }

        [HttpPost]
        [Route("CategoryUpdate")]
        public Result CategoryUpdate(CategoryUpdateDto categoryUpdateDto)
        {
            return categoryManager.Update(categoryUpdateDto);
        }
    }
}
