using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.MVC
{
    public interface IActionResponse
    {

        bool IsSuccessful { get; }

        bool IsUI { get; }

    }

    public class PageActionResponse : IActionResponse
    {
        public bool IsUI => true;

        public Page Page { get; set; }

        public bool IsSuccessful => true;

        PageActionResponse(Page page)
        {
            Page = page;
        }

        public static implicit operator PageActionResponse(Page page)
            => new PageActionResponse(page);

    }

    public class FailedActionResponse : IActionResponse
    {
        public bool IsSuccessful => false;

        public bool IsUI => false;

        public string ErrorMessage { get; }

        public FailedActionResponse(string errorMessage = null)
        {
            ErrorMessage = errorMessage;
        }

    }
}
