using Kalmykov_mag.Constants;
using Kalmykov_mag.Helpers.Interfaces;
using Microsoft.JSInterop;

namespace Kalmykov_mag.Helpers
{
    public class JavaScript : IJavaScriptMethods
    {
        private readonly IJSRuntime _JSRuntime;

        public JavaScript(IJSRuntime JSRuntime)
        {
            _JSRuntime = JSRuntime;
        }

        public async Task Log(string message)
        {
            await _JSRuntime.InvokeVoidAsync(JavaScriptMethodNames.Log, message);
        }
    }
}
