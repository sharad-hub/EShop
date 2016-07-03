
using Shop.Entities;
using Shop.Services;
using System;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Api.Controllers
{
    
    public class ApiControllerBase : ApiController
    {
        protected readonly IErrorService _errorsRepository;


        public ApiControllerBase(IErrorService errorsRepository)
        {
            _errorsRepository = errorsRepository;            
        }
        public ApiControllerBase()
        {

        }
        //public ApiControllerBase(IErrorService errorsRepository)
        //{
        //    _errorsRepository = errorsRepository;
        //}

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
        private void LogError(Exception ex)
        {
            try
            {
                Error _error = new Error()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                };

                _errorsRepository.Insert(_error);
                
            }
            catch { }
        }
    }
}