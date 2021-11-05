using FreakyFashionPoweredByUmbraco.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace FreakyFashionPoweredByUmbraco.Controllers
{
    public class CheckOutPageController : RenderController
    {
        private readonly IVariationContextAccessor _variationContextAccessor;
        private readonly ServiceContext _serviceContext;
        
        public CheckOutPageController(ILogger<RenderController> logger, 
                                      ICompositeViewEngine compositeViewEngine, 
                                      IUmbracoContextAccessor umbracoContextAccessor,
                                      IVariationContextAccessor variationContextAccessor,
                                      ServiceContext serviceContext) 
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _variationContextAccessor = variationContextAccessor;
            _serviceContext = serviceContext;
        }

        public override IActionResult Index()
        {
            var viewModel = new CheckOutPageViewModel(CurrentPage, new PublishedValueFallback(_serviceContext, _variationContextAccessor));
            return CurrentTemplate(viewModel);
        }
    }
}
