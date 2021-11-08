using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using static FreakyFashionPoweredByUmbraco.Migrations.AddCheckOutFormsTable;

namespace FreakyFashionPoweredByUmbraco.Controllers
{
    public class CheckOutPageSurfaceController : SurfaceController
    {
        private readonly IScopeProvider scopeProvider;
        
        public CheckOutPageSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, 
                                            IUmbracoDatabaseFactory databaseFactory, 
                                            ServiceContext services, 
                                            AppCaches appCaches, 
                                            IProfilingLogger profilingLogger, 
                                            IPublishedUrlProvider publishedUrlProvider,
                                            IScopeProvider scopeProvider) 
                                                : base(umbracoContextAccessor, 
                                                      databaseFactory, 
                                                      services, 
                                                      appCaches, 
                                                      profilingLogger, 
                                                      publishedUrlProvider)
        {
            this.scopeProvider = scopeProvider;
        }

        // /umbraco/surface/{Controller}/{Action method}
        public IActionResult Index()
        {
            return Content("Hello from Surface Controller");
        }

        [HttpPost]
        public IActionResult HandleSubmit(CheckOutInput input)
        {
            using var scope = scopeProvider.CreateScope(autoComplete: true);
            var database = scope.Database;

            var checkOutForm = new CheckOutFormsSchema 
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                Password = input.Password
            };

            database.Insert(checkOutForm);

            scope.Complete();

            return Content("Thank you!");
        }
    }

    public class CheckOutInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
