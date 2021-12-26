using Shared.Interfaces.Business;
using Shared.Interfaces.Repository;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryBusiness(ICategoryRepository _categoryRepository)
        {
            this.categoryRepository = _categoryRepository;
        }

        public List<Category> GetAllCategories()
        {
            return this.categoryRepository.GetAllCategories();
        }


    }

}
