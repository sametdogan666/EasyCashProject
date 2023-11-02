using EasyCashProject.DataAccess.Abstract;
using EasyCashProject.DataAccess.Concrete;
using EasyCashProject.DataAccess.Repositories;
using EasyCashProject.Entities.Concrete;

namespace EasyCashProject.DataAccess.EntityFramework;

public class EfCustomerAccountDal:GenericRepository<CustomerAccount>, ICustomerAccountDal
{
    public EfCustomerAccountDal(Context context) : base(context)
    {
    }
}