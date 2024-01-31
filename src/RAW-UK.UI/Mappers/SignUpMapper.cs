using MudBlazor;
using RAW_UK.Model;

namespace RAW_UK.UI;

public static class SignUpMapper
{   
    public static SignUp ToModel(this SignUpViewModel viewModel, SignUp? model = null)
    {
        if (model == null) { model = new(); }
        model.Id = viewModel.Id;
        model.FirstName = viewModel.FirstName;
        model.LastName = viewModel.LastName;
        model.Email = viewModel.Email;
        model.Mobile = viewModel.Mobile;
        model.IsArchived = viewModel.IsArchived;
        model.ArchivedDate = viewModel.ArchivedDate;
        return model;
    }
}
