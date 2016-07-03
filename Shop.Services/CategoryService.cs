 
using Repository.Pattern.Repositories;
using Service.Pattern;
using Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services
{
    public interface ICategoryService:IService<Category>
    {

    }
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly IRepositoryAsync<Category> _repository;
        public CategoryService(IRepositoryAsync<Category> repository)
            :base(repository)
        {
            _repository = repository;
        }

    }
}
