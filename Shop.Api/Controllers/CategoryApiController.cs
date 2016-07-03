
using Repository.Pattern.UnitOfWork;
using Shop.Entities;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Api.Controllers
{
    [RoutePrefix("api/categoryapi")]
    public class CategoryApiController : ApiControllerBase
    {
        private readonly ICategoryService _service;
        IErrorService _errorService;
        IUnitOfWorkAsync _unitOfWork;
        public CategoryApiController(ICategoryService service, IErrorService errorService, IUnitOfWorkAsync unitOfWork)
            : base(errorService)
        {
            _unitOfWork = unitOfWork;
            _service = service;
            _errorService = errorService;
        }

        [HttpGet]
        [Route("GetCategory")]
        public HttpResponseMessage Get(HttpRequestMessage request )//, string filter)
        {
            //filter = filter.ToLower();
            return CreateHttpResponse(request, () =>
            {
                //HttpResponseMessage response = null;
                var categories = _service.Queryable();
                    //.Where(x => x.CategoryName.Contains(filter));
                return request.CreateResponse<IEnumerable<Category>>(HttpStatusCode.OK, categories);
            });
        }

        //// GET: api/CategoryApi/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/CategoryApi
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/CategoryApi/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/CategoryApi/5
        //public void Delete(int id)
        //{
        //}
    }
}
