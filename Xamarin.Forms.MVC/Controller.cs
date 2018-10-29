using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.DependencyInjection;
using Apps.Unified;
using NetCore.Apis.Client.UI;
using Xamarin.Forms.MVC.Templates;

namespace Xamarin.Forms.MVC
{
    public class Controller
    { 

        protected string ProgressMessage
        {
            set => Services.Get<ILoadingPage>().DisplayMessage = value;
        }

        protected async Task PreLoad(Func<Task> toRun) => await toRun();

        protected async Task LoadingPage() => await Services.Get<TemplateUtilities>().StartLoading();

        protected async Task<PageActionResponse> ViewAsync<TPage>() where TPage : Page
            => await Services.NavigateAsync<TPage>();

        protected async Task<PageActionResponse> ViewAsync<TPage, TModel>(TModel model)
            where TPage : Page, IAccepting<TModel>
                => await Services.NavigateAsync<TPage, TModel>(model);

        public FailedActionResponse Failed(string errorMessage = null)
            => new FailedActionResponse(errorMessage);
        
    }

    public class Controller<TModel>
        where TModel : class, new()
    {

        public DataControl<TModel> Control { get; set; }

        public ModelHandler<TModel> ModelHandler => Control.GetModelHandler();

    }
}
