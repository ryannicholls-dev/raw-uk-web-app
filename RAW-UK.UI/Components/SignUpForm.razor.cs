using RAW_UK.Model;

namespace RAW_UK.UI.Components;

public partial class SignUpForm
{
    SignUpViewModel InputViewModel = new SignUpViewModel();
    public async Task OnHandleValidSubmit()
    {
        SignUp model = InputViewModel.ToModel();
        // await the data service 
        // add snackbar registration succesful message
    }
}
