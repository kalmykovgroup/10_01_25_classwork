using _26_01_25.Constants;
using _26_01_25.DTOs.Product;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using _26_01_25.DTOs.Category;
using _26_01_25.DTOs.Supplier;
using _26_01_25.Helpers.Interfaces;
using _26_01_25.DTOs;
using _26_01_25.Entities;

namespace _26_01_25.Components.Pages.Admin.Components.Dialogs.Product
{
    public class CommonProductFormBaseComponent : ComponentBase
    {
        protected CancellationTokenSource? _cts;

        [Inject] protected IJavaScriptMethods JavaScriptMethods { get; set; }

        [Inject] private IHttpClientFactory ClientFactory { get; set; }

        [Inject] protected ISnackbar Snackbar { get; set; }

        [CascadingParameter] protected MudDialogInstance MudDialog { get; set; }
        protected MudForm form;

        [Parameter] public List<CategoryDto> Categories { get; set; }  // Список категорий
        [Parameter] public List<SupplierDto> Suppliers { get; set; }  // Список поставщиков

        protected string? ErrorMessage { get; set; } = null;

        protected bool IsLoad { get; set; } = false;


        protected void Cancel()
        {
            _cts?.Cancel();
            MudDialog.Cancel();
        }

        protected async Task SubmitForm(Func<HttpClient, CancellationToken, Task<HttpResponseMessage>> request)
        {
            _cts = new CancellationTokenSource();

            ErrorMessage = null;
            IsLoad = true;

            StateHasChanged();// Обновление UI

            await form.Validate();

            if (form.IsValid)
            {
                try
                {
                    HttpClient? client = ClientFactory.CreateClient(HttpClientNames.APIClient);
                    // Обновление
                    // HttpResponseMessage response = await client.PutAsJsonAsync($"product/update/{UpdateProductDto.Id}", UpdateProductDto);
                    HttpResponseMessage response = await request.Invoke(client, _cts.Token);

                    if (response.IsSuccessStatusCode)
                    {
                        var updateResponse = await response.Content.ReadFromJsonAsync<ProductResponseDto>();

                        if (updateResponse != null && updateResponse.ProductDto != null && updateResponse.Message != null)
                        {
                            if(updateResponse.ProductDto.Category == null)
                            {
                                var category = Categories.Where(c => c.Id == updateResponse.ProductDto.CategoryId).FirstOrDefault();
                                if (category != null) {
                                    updateResponse.ProductDto.Category = category;
                                }
                            }
                            if(updateResponse.ProductDto.Supplier == null)
                            {
                                var supplier = Suppliers.Where(s => s.Id == updateResponse.ProductDto.SupplierId).FirstOrDefault();
                                if (supplier != null) {
                                    updateResponse.ProductDto.Supplier = supplier;
                                }
                            }

                            // Отображаем уведомление об успешном обновлении с сообщением от сервера
                            Snackbar.Add(updateResponse.Message, Severity.Success);
                            MudDialog.Close(DialogResult.Ok(updateResponse.ProductDto));
                        }
                        else
                        {
                            ErrorMessage = $"Ошибка при получении ответа от сервера.{(updateResponse?.ProductDto == null ? " ProductDto is null" : null)}{(updateResponse?.Message == null ? " Message is null" : null)}";

                            Snackbar.Add("Ошибка при получении ответа от сервера", Severity.Error);
                        }

                    }
                    else
                    {
                        ServerErrorResponse? model = await response.Content.ReadFromJsonAsync<ServerErrorResponse>();

                        if (model != null)
                        {
                            ErrorMessage = $"{model.Message}: {response.StatusCode}";
                            Snackbar.Add($"{model.Message}", Severity.Error);
                        }
                        else
                        {
                            ErrorMessage = $"Ошибка при обновлении товара: {response.StatusCode}";
                            Snackbar.Add("Ошибка при обновлении товара.", Severity.Error);
                        }
                    }

                }
                catch (OperationCanceledException)
                {
                    Snackbar.Add("Отмена, данные не были сохранены!", Severity.Warning);
                }
                catch (Exception ex)
                {
                    ErrorMessage = $"Ошибка сохранения товара: {ex.Message}";
                    Snackbar.Add("Ошибка при сохранении товара.", Severity.Error);
                }
                finally
                {
                    _cts = null;
                    IsLoad = false; // Сбрасываем флаг загрузки независимо от результата
                    StateHasChanged();// Обновление UI
                }
            }
            else
            {
                ErrorMessage = "Пожалуйста, исправьте ошибки в форме.";
                IsLoad = false; // Сбрасываем флаг загрузки независимо от результата
                StateHasChanged();// Обновление UI
            }

        }
    }
}
