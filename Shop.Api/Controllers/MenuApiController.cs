using Repository.Pattern.UnitOfWork;
using Shop.Api.Models.ViewModels;
using Shop.Entities;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Shop.Api.Controllers
{
    [RoutePrefix("api/MenuApi")]
    public class MenuApiController : ApiControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsyn;
        private readonly IErrorService _errorService;
        public MenuApiController(IMenuService menuService, IUnitOfWorkAsync unitOfWorkAsyn, IErrorService errorService)
            : base(errorService)
        {
            _errorService = errorService;
            _unitOfWorkAsyn = unitOfWorkAsyn;
            _menuService = menuService;
        }

        public HttpResponseMessage Get(HttpRequestMessage request)//, string filter)
        {
            // filter = filter.ToLower().Trim();

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                var menus = _menuService.Queryable().AsEnumerable().Select(x => new MenuViewModel
                {
                    ParentId = x.Parent == null ? 0 : x.Parent.Id,
                    Order = x.Order,
                    NavigationPath = x.NavigationPath,
                    Name = x.Name,
                    IsActive = x.IsActive,
                    Id = x.Id
                });
                //.Where(c => c.ProductName.ToLower().Contains(filter));
                // var customersVm = Mapper.Map<IEnumerable<Product>, IEnumerable<CustomerViewModel>>(customers);

                response = request.CreateResponse<IEnumerable<MenuViewModel>>(HttpStatusCode.OK, menus);

                return response;
            });
        }
        // response = request.CreateResponse<IEnumerable<CustomerViewModel>>(HttpStatusCode.OK, customersVm);

    }
}