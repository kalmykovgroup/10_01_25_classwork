using BlazorApp.Constants;
using BlazorApp.Helpers.Interfaces;
using Microsoft.JSInterop;

namespace BlazorApp.Helpers
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
