
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using Shop.Api.Infrastructure.Core;
using Shop.Entities;
using Shop.Entities.Procedures;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Api.Controllers
{
    [RoutePrefix("api/ProductApi")]
    public class ProductApiController : ApiControllerBase
    {
        private readonly IProductService _productService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IErrorService _errorService;
        private readonly IStoredProcedureService _storedProcedureService;
        public ProductApiController(IUnitOfWorkAsync unitOfWorkAsync,IStoredProcedureService storedProcedureService, IProductService productService, IErrorService errorService)
            : base(errorService)
        {
            _unitOfWorkAsync = unitOfWorkAsync;
            _productService = productService;
            _errorService = errorService;
            _storedProcedureService =storedProcedureService;
           
        }

        public HttpResponseMessage Get(HttpRequestMessage request,int pageNo=1, int  pageSize=10, string filter="")
        {
            filter = filter.ToLower().Trim();
            int toSkip = (pageNo - 1) * 10;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var products = _productService.Queryable()  //.AsQueryable()
                    .Where(c => c.ProductName.ToLower().Contains(filter)).OrderBy(x=>x.ProductName).Skip(toSkip).Take(pageSize).ToList(); 
               // var customersVm = Mapper.Map<IEnumerable<Product>, IEnumerable<CustomerViewModel>>(customers);
                response = request.CreateResponse<IEnumerable<Product>>(HttpStatusCode.OK, products);
                return response;
            });
        }
          // response = request.CreateResponse<IEnumerable<CustomerViewModel>>(HttpStatusCode.OK, customersVm);
        [Route("GetProduct")]
        public HttpResponseMessage GetProduct(HttpRequestMessage request , int pageNo = 1, int pageSize = 10, string filter = "")
        {
           // filter = filter.ToLower().Trim();
             int toSkip = (pageNo - 1) * 10;
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var products = _storedProcedureService.GetProductsForUI().OrderBy(x => x.ProductName).Skip(toSkip).Take(pageSize).ToList();
                // var customersVm = Mapper.Map<IEnumerable<Product>, IEnumerable<CustomerViewModel>>(customers);
                response = request.CreateResponse<IEnumerable<ProductUIDetail>>(HttpStatusCode.OK, products);
                return response;
            });
        }

        [Route("details/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var product = _productService.GetProductById(id);
                //CustomerViewModel customerVm = Mapper.Map<Customer, CustomerViewModel>(customer);
                response = request.CreateResponse<Product>(HttpStatusCode.OK, product);
                return response;
            });
        }

        [HttpPost]
        [Route("SaveProduct")]
        public HttpResponseMessage SaveProduct(HttpRequestMessage request, Product product)
        {
            
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    if (_productService.GetProductByName(product.ProductName).Count()>0) //(customer.Email, customer.IdentityCard))
                    {
                        //ModelState.AddModelError("Invalid Product", "Product  already exists");
                        //response = request.CreateResponse(HttpStatusCode.BadRequest,
                        //ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                        //      .Select(m => m.ErrorMessage).ToArray());
                    }
                    else
                    {
                        //Product newCustomer = new Customer();
                        //newCustomer.UpdateCustomer(customer);
                        _productService.Insert(product);
                        _unitOfWorkAsync.SaveChangesAsync();//
                        // Update view model
                        //customer = Mapper.Map<Customer, CustomerViewModel>(newCustomer);
                        response = request.CreateResponse<Product>(HttpStatusCode.Created, product);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("update")]
        public HttpResponseMessage Update(HttpRequestMessage request, Product product)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                        ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                              .Select(m => m.ErrorMessage).ToArray());
                }
                else
                {
                    product.ObjectState = ObjectState.Modified;
                   _productService.Update(product);               
                    _unitOfWorkAsync.SaveChangesAsync();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }

        [HttpGet]
        [Route("search/{page:int=0}/{pageSize=4}/{filter?}")]
        public HttpResponseMessage Search(HttpRequestMessage request, int? page, int? pageSize, string filter = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                List<Product> products = null;
                int totalProducts = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    filter = filter.Trim().ToLower();
                    products = _productService.Queryable().Where(c => c.ProductName.ToLower().Contains(filter)// ||
                           // c.IdentityCard.ToLower().Contains(filter) ||
                            //c.FirstName.ToLower().Contains(filter))
                            )
                        .OrderBy(c => c.ProductName)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                        .ToList();

                    totalProducts  = _productService.Queryable().Where(c => c.ProductName.ToLower().Contains(filter)// ||
                        // c.IdentityCard.ToLower().Contains(filter) ||
                        //c.FirstName.ToLower().Contains(filter))
                            )                        
                        .Count();
                }
                else
                {
                    products = _productService.Queryable()
                        .OrderBy(c => c.ProductName)
                        .Skip(currentPage * currentPageSize)
                        .Take(currentPageSize)
                    .ToList();

                    totalProducts = _productService.Queryable().Count();
                }

               // IEnumerable<Product> customersVM = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);

                PaginationSet<Product> pagedSet = new PaginationSet<Product>()
                {
                    Page = currentPage,
                    TotalCount = totalProducts,
                    TotalPages = (int)Math.Ceiling((decimal)totalProducts / currentPageSize),
                    Items = products
                };
                response = request.CreateResponse<PaginationSet<Product>>(HttpStatusCode.OK, pagedSet);
                return response;
            });
        }
    }
}
