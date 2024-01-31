using RAW_UK.Model;

namespace RAW_UK.Repository;

public class SignUpDataService : SimpleDataService<SignUp>
{
    public SignUpDataService(IUnitOfWork _unitOfWork, IGenericRepository<SignUp> _repository) : base(_unitOfWork, _repository)
    {
    }
}
