using _26_01_25.Constants;
using _26_01_25.Helpers.Interfaces;
using Microsoft.JSInterop;

namespace _26_01_25.Helpers
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
