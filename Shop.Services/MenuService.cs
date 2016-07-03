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
    public interface IMenuService:IService<Menu>{}
    public class MenuService : Service<Menu>, IMenuService
    {
        public readonly IRepositoryAsync<Menu> _repository;
        public MenuService(IRepositoryAsync<Menu> repository) :base(repository)
        {
            _repository = repository;
        }
    }   
}
