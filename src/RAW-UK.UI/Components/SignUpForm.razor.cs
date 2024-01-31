using Microsoft.AspNetCore.Components;
using MudBlazor;
using RAW_UK.Model;
using RAW_UK.Repository;

namespace RAW_UK.UI.Components;

public partial class SignUpForm
{
    [Inject] private ISnackbar? snackbar { get; set; }
    [Inject] private SignUpDataService? signUpDataService { get; set; }
    private SignUpViewModel InputViewModel = new SignUpViewModel();
    public async Task OnHandleValidSubmit()
    {
        SignUp model = InputViewModel.ToModel();
        if (signUpDataService != null) await signUpDataService.InsertAsync(model);
        snackbar?.Add($"{InputViewModel.FirstName} {InputViewModel.LastName} has signed up for RAW updates");
        InputViewModel = new();
        StateHasChanged();
    }
}
