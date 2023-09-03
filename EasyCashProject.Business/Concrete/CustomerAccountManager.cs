using EasyCashProject.Business.Abstract;
using EasyCashProject.DataAccess.Abstract;
using EasyCashProject.Entities.Concrete;

namespace EasyCashProject.Business.Concrete;

public class CustomerAccountManager : ICustomerAccountService
{
    private readonly ICustomerAccountDal _customerAccountDal;

    public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
    {
        _customerAccountDal = customerAccountDal;
    }

    public void Add(CustomerAccount entity)
    {
        _customerAccountDal.Add(entity);
    }

    public void Delete(CustomerAccount entity)
    {
       _customerAccountDal.Delete(entity);
    }

    public void Update(CustomerAccount entity)
    {
        _customerAccountDal.Update(entity);
    }

    public CustomerAccount? GetById(int id)
    {
        return _customerAccountDal.GetById(id);
    }

    public List<CustomerAccount> GetAll()
    {
        return _customerAccountDal.GetAll();
    }
}