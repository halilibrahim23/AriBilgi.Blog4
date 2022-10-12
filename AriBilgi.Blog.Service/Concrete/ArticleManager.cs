using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Entities.Concrete;
using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Service.Abstract;
using AriBilgi.Blog.Shared.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Service.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Add(ArticleAddDto article)
        {

            try
            {
                _unitOfWork.Articles.AddAsync(new Article
                {
                    CategoryId = article.CategoryId,
                    Title = article.Title,
                    Content = article.Content,
                    UserId = article.UserId
                });

                _unitOfWork.SaveAsync();

                return new Result(200, new List<string>() { "Makale başarıyla eklenmiştir," });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string>() { "Makale eklenirken teknik hata oluştu." }, ex);
            }

        }

        public Result Update(ArticleUpdateDto article)
        {

            try
            {
                Article currentArticle = _unitOfWork.Articles.GetAsync(a => a.Id == article.Id);

                currentArticle.Title = article.Title;
                currentArticle.Content = article.Content;
                currentArticle.ModifedBy = 1;
                currentArticle.ModifedDate = DateTime.Now;

                _unitOfWork.Articles.UpdateAsync(currentArticle);
                _unitOfWork.SaveAsync();

                return new Result(200, new List<string>() { "Makale başarıyla güncellenmiştir." });
            }
            catch (Exception ex)
            {

                return new Result(200, new List<string>() { "Makale güncellenirken teknik bir hata oluşmuştur." }, ex);
            }


        }

        public Result Remove(ArticleRemoveDto article)
        {
            try
            {
                Article currentArticle = _unitOfWork.Articles.GetAsync(a => a.Id == article.Id);

                _unitOfWork.Articles.HardDeleteAsync(currentArticle);

                _unitOfWork.SaveAsync();

                return new Result(200, new List<string>() { "Makale başarıyla silinmiştir." });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string>() { "Makale silinirken teknik bir hata oluşmuştur." }, ex);
            }
        }

        public DataResult<List<ArticleDto>> GetAll()
        {
            var articles = _unitOfWork.Articles.GetAllAsync();
            if (articles.Count > 0)
            {
                List<ArticleDto> articleDtos = new();

                foreach (var item in articles)
                {
                    articleDtos.Add(new ArticleDto
                    {
                        Id = item.Id,
                        CategoryId = item.CategoryId,
                        Content = item.Content,
                        Title = item.Title,
                        UserId = item.UserId,

                    });
                }

                return new DataResult<List<ArticleDto>>(200, articleDtos, null);
            }
            else
            {
                return new DataResult<List<ArticleDto>>(200, null, new List<string>() { "Veritabanında kayıt bulunumadı" }, null);
            }
        }

        public DataResult<ArticleDto> Get(ArticleGetDto articleGetDto)
        {
            try
            {
                Article currentArticle = _unitOfWork.Articles.GetAsync(a => a.Id == articleGetDto.Id);

                ArticleDto articleDto = new()
                {
                    Id = currentArticle.Id,
                    CategoryId = currentArticle.CategoryId,
                    Content = currentArticle.Content,
                    Title = currentArticle.Title,
                    UserId = currentArticle.UserId
                };

                return new DataResult<ArticleDto>(200, articleDto, null);

            }
            catch (Exception ex)
            {
                return new DataResult<ArticleDto>(500, null, new List<string>() { "Teknik bir hata oluştu" }, ex);
            }
        }
    }
}
