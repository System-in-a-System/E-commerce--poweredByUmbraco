using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace FreakyFashionPoweredByUmbraco.Models.ViewModels
{
    public class CheckOutPageViewModel : CheckOutPage
    {
        public CheckOutPageViewModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) 
            : base(content, publishedValueFallback)
        {
        }
    }
}
