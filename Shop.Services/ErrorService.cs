
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
   public interface IErrorService :IService<Error>
    {
       void AddError();
    }

   public class ErrorService : Service<Error>, IErrorService
   {

       private readonly IRepositoryAsync<Error> _repository;

       public ErrorService(IRepositoryAsync<Error> repository)
            : base(repository)
        {
            _repository = repository;
        }

       public void AddError()
       {
           throw new NotImplementedException();
       }
   }
    
}
