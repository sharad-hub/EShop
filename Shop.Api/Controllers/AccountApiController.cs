
using Repository.Pattern.UnitOfWork;
using Shop.Api.Controllers;
using Shop.Api.Models;
using Shop.Entities;
using Shop.Services;
using Shop.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shop.Api.Controllers
{
    [Authorize(Roles="Admin")]
    [RoutePrefix("api/AccountApi")]
    public class AccountApiController : ApiControllerBase
    {
        private readonly IMembershipService _membershipService;
        private readonly IErrorService _errorService;
        private readonly IUnitOfWorkAsync unitOfWorkAsync;
       

        public AccountApiController(IMembershipService membershipService,
            IErrorService errorService, IUnitOfWorkAsync unitOfWork)
            : base(errorService)
        {
            _membershipService = membershipService;
            unitOfWorkAsync = unitOfWork;
            _errorService = errorService;
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (ModelState.IsValid)
                {
                    MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);

                    if (_userContext.User != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }
                else
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });

                return response;
            });
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                else
                {
                    Shop.Entities.User _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });

                    if (_user != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }

                return response;
            });
        }
    }
}
