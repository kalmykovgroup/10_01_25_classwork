using BlazorApp.Components.Pages.Admin.Components.Dialogs;
using BlazorApp.Components.Pages.Admin.Components.Dialogs.Product;
using BlazorApp.Constants;
using BlazorApp.DTOs.Category;
using BlazorApp.DTOs.Product;
using BlazorApp.DTOs.Supplier;
using BlazorApp.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BlazorApp.Components.Pages.Admin
{
    public partial class ProductManagement
    {

        [Inject] ISnackbar Snackbar { get; set; } = null!;
        [Inject] IDialogService DialogService { get; set; } = null!;
        [Inject] IHttpClientFactory ClientFactory { get; set; } = null!;

        private string errorMessage = string.Empty; 

        private List<CategoryDto> categories = [];
        private List<SupplierDto> suppliers = [];
        private List<ProductDto> products = [];

        DialogOptions options = new() {
            MaxWidth = MaxWidth.Medium,
            FullWidth = true ,
            NoHeader = true
        };

        protected override async Task OnInitializedAsync()
        {

            await LoadProducts();

            try
            {
                var client = ClientFactory.CreateClient(HttpClientNames.APIClient);
                products = await client.GetFromJsonAsync<List<ProductDto>>("product/get-all-with-link") ?? products;
                categories = await client.GetFromJsonAsync<List<CategoryDto>>("category") ?? categories;
                suppliers = await client.GetFromJsonAsync<List<SupplierDto>>("supplier") ?? suppliers;

            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка загрузки данных: {ex.Message}";
                Console.WriteLine($"{ex.Message}");
            }
        }

        private async Task LoadProducts()
        {
            try
            {
                var client = ClientFactory.CreateClient(HttpClientNames.APIClient);
                products = await client.GetFromJsonAsync<List<ProductDto>>("product/get-all-with-link") ?? products; 

            }
            catch (Exception ex)
            {
                errorMessage = $"Ошибка загрузки данных: {ex.Message}";
                Console.WriteLine($"{ex.Message}");
            }
        }
 

        private async void CreateProduct()
        {
            var parameters = new DialogParameters<CreateProductFormDialog> { 
                { x => x.Categories, categories },
                { x => x.Suppliers, suppliers },
            };

            var dialog = await DialogService.ShowAsync<CreateProductFormDialog>("Create product", parameters, options);
            var result = await dialog.Result;

            if (!result!.Canceled)
            {
                ProductDto productDto = (ProductDto)result.Data!;
                products.Add(productDto);           
                StateHasChanged();// Обновление UI
            }

        }

        private async Task UpdateProduct(ProductDto product)
        {
            var parameters = new DialogParameters<UpdateProductFormDialog> {
                { x => x.ProductDto, product },
                { x => x.Categories, categories },
                { x => x.Suppliers, suppliers },

            };

            var dialog = await DialogService.ShowAsync<UpdateProductFormDialog>("Update product", parameters, options);
            var result = await dialog.Result;

            if (!result!.Canceled)
            {
                ProductDto productDto = (ProductDto)result.Data!;
               
                int index = products.FindIndex(p => p.Id == productDto.Id); // Найти индекс элемента, который нужно заменить

                if (index != -1)
                {          
                    products[index] = productDto;// Заменить элемент
                }
               
                StateHasChanged();  // Обновление UI
            }
        } 
          

        private async Task DeleteProduct(Guid productId)
        {
           Console.WriteLine("Click DeleteProduct");

            bool? result = await DialogService.ShowMessageBox(
                "Подтверждение удаления",
                "Вы уверены, что хотите удалить этот товар?",
                yesText: "Да",
                noText: "Нет");

            if (result == true)
            {
                try
                {
                    var client = ClientFactory.CreateClient(HttpClientNames.APIClient);
                    var response = await client.DeleteAsync($"product/{productId}");

                    if (response.IsSuccessStatusCode)
                    {
                        products = products?.Where(p => p.Id != productId).ToList();
                    }
                    else
                    {
                        errorMessage = $"Ошибка при удалении товара (код: {response.StatusCode})";
                    }
                }
                catch (Exception ex)
                {
                    errorMessage = $"Ошибка при удалении товара: {ex.Message}";
                }
            }
        }
    }
}
