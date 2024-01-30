using RAW_UK.Model;

namespace RAW_UK.Repository;

public class SignUpDataService : SimpleDataService<SignUp>
{
    public SignUpDataService(UnitOfWork unitOfWork, GenericRepository<SignUp> repository) : base(unitOfWork, repository)
    {
    }
}
