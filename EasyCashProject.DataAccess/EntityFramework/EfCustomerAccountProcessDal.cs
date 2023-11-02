using EasyCashProject.DataAccess.Abstract;
using EasyCashProject.DataAccess.Concrete;
using EasyCashProject.DataAccess.Repositories;
using EasyCashProject.Entities.Concrete;

namespace EasyCashProject.DataAccess.EntityFramework;

public class EfCustomerAccountProcessDal:GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
{
    public EfCustomerAccountProcessDal(Context context) : base(context)
    {
    }
}