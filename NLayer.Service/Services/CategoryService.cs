using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryService categoryService) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<CustomResponseDTO<CateogryWithProductsDTO>> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            var category = await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId);
            var categoryDTO = _mapper.Map<CateogryWithProductsDTO>(category);

            return CustomResponseDTO<CateogryWithProductsDTO>.Success(200, categoryDTO);
        }
    }
}
