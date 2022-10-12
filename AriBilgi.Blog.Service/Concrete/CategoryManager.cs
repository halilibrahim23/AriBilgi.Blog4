using AriBilgi.Blog.Data.Abstract;
using AriBilgi.Blog.Entities.Concrete;
using AriBilgi.Blog.Entities.Dtos;
using AriBilgi.Blog.Service.Abstract;
using AriBilgi.Blog.Shared.Result;
using System;
using System.Collections.Generic;

namespace AriBilgi.Blog.Service.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Result Add(CategoryAddDto categoryAddDto)
        {
            try
            {
                _unitOfWork.Categories.AddAsync(new Category
                {
                    Title = categoryAddDto.Title,
                    Content = categoryAddDto.Content
                });
                _unitOfWork.SaveAsync();

                return new Result(200, new List<string> { "Kategori başarıyla eklenmiştir" });
            }
            catch (Exception ex)
            {
                return new Result(500, new List<string> { "Kategori eklenirken sistemsel bir hata oluştu." }, ex);
            }
        }

        public DataResult<CategoryDto> Get(CategoryGetDto categoryGetDto)
        {
            try
            {
                Category category = _unitOfWork.Categories.GetAsync(x => x.Id == categoryGetDto.Id);

                CategoryDto categoryDto = new()
                {
                    Id = category.Id,
                    Content = category.Content,
                    Title = category.Title,
                    CommentCount = _unitOfWork.Comments.CountAsync(x => x.Article.CategoryId == categoryGetDto.Id)
                };

                return new DataResult<CategoryDto>(200, categoryDto, null);

            }
            catch (Exception ex)
            {

                return new DataResult<CategoryDto>(200, null, new List<string>() { "Teknik bir hata oluştu." }, ex);
            }
        }

        public DataResult<List<CategoryDto>> GetAll()
        {
            try
            {
                List<Category> category = _unitOfWork.Categories.GetAllAsync();

                List<CategoryDto> categories = new();

                foreach (var item in category)
                {
                    categories.Add(new CategoryDto
                    {
                        Id = item.Id,
                        Content = item.Content,
                        Title = item.Title,
                        CommentCount = _unitOfWork.Comments.CountAsync(x => x.Article.CategoryId == item.Id)
                    });
                }



                return new DataResult<List<CategoryDto>>(200, categories, null);

            }
            catch (Exception ex)
            {

                return new DataResult<List<CategoryDto>>(200, null, new List<string>() { "Teknik bir hata oluştu." }, ex);
            }
        }

        public Result Remove(CategoryRemoveDto categoryRemoveDto)
        {
            try
            {
                var category = _unitOfWork.Categories.GetAsync(c => c.Id == categoryRemoveDto.Id);
                if (category != null)
                {
                    _unitOfWork.Categories.HardDeleteAsync(category);
                    _unitOfWork.SaveAsync();

                    return new Result(200, new List<string> { "Kategori başarıyla silinmiştir." });
                }
                return new Result(200, new List<string> { "Silmek istediğiniz kategori bulunumadı." });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string> { "Teknik bir sorun oluştu." }, ex);
            }

        }

        public Result Update(CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                var category = _unitOfWork.Categories.GetAsync(c => c.Id == categoryUpdateDto.Id);
                if (category != null)
                {
                    category.Title = categoryUpdateDto.Title;
                    category.Content = categoryUpdateDto.Content;
                    category.ModifedBy = 1;
                    category.ModifedDate = DateTime.Now;


                    _unitOfWork.Categories.UpdateAsync(category);
                    _unitOfWork.SaveAsync();

                    return new Result(200, new List<string> { "Kategori başarıyla güncellenmiştir." });
                }
                return new Result(200, new List<string> { "Güncellemek istediğiniz kategori bulunumadı." });
            }
            catch (Exception ex)
            {

                return new Result(500, new List<string> { "Teknik bir sorun oluştu." }, ex);
            }
        }
    }
}
