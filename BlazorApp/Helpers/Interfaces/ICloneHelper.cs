namespace BlazorApp.Helpers.Interfaces
{
    public interface ICloneHelper
    {
        public T Clone<T>(T source);
    }
}
