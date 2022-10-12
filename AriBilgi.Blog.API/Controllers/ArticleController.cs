using AriBilgi.Blog.Data.Concrete;
using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Service.Concrete;
using AriBilgi.Blog.Shared.Result;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AriBilgi.Blog.API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ArticleController : ControllerBase
    {
        ArticleManager articleManager;
        public ArticleController()
        {
            articleManager = new ArticleManager(new UnitOfWork());
        }


        [HttpPost]
        [Route("ArticleGet")]
        public DataResult<ArticleDto> ArticleList(ArticleGetDto articleGetDto)
        {
            return articleManager.Get(articleGetDto);
        }

        [HttpPost]
        [Route("ArticleList")]
        public DataResult<List<ArticleDto>> ArticleList()
        {
            return articleManager.GetAll();
        }

        [HttpPost]
        [Route("ArticleAdd")]
        public Result ArticleAdd(ArticleAddDto articleAddDto)
        {
            return articleManager.Add(articleAddDto);
        }

        [HttpPost]
        [Route("ArticleUpdate")]
        public Result ArticleUpdate(ArticleUpdateDto articleUpdateDto)
        {
            return articleManager.Update(articleUpdateDto);
        }

        [HttpPost]
        [Route("ArticleRemove")]
        public Result ArticleRemove(ArticleRemoveDto articleRemoveDto)
        {
            return articleManager.Remove(articleRemoveDto);
        }
    }
}
