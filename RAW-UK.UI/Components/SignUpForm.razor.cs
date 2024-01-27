using Microsoft.AspNetCore.Components;
using MudBlazor;
using RAW_UK.Model;

namespace RAW_UK.UI.Components;

public partial class SignUpForm
{
    [Inject] private ISnackbar snackbar { get; set; }
    private SignUpViewModel InputViewModel = new SignUpViewModel();
    public void OnHandleValidSubmit()
    {
        SignUp model = InputViewModel.ToModel();
        // await the data service 
        // add snackbar registration succesful message
        snackbar.Add($"{InputViewModel.FirstName} {InputViewModel.LastName} has signed up for RAW updates");
        InputViewModel = new();
        StateHasChanged();
    }
}
