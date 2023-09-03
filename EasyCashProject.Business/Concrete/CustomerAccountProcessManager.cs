using EasyCashProject.Business.Abstract;
using EasyCashProject.DataAccess.Abstract;
using EasyCashProject.Entities.Concrete;

namespace EasyCashProject.Business.Concrete;

public class CustomerAccountProcessManager : ICustomerAccountProcessService
{
    private readonly ICustomerAccountProcessDal _customerAccountProcessDal;

    public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
    {
        _customerAccountProcessDal = customerAccountProcessDal;
    }

    public void Add(CustomerAccountProcess entity)
    {
        _customerAccountProcessDal.Add(entity);
    }

    public void Delete(CustomerAccountProcess entity)
    {
        _customerAccountProcessDal.Delete(entity);
    }

    public void Update(CustomerAccountProcess entity)
    {
        _customerAccountProcessDal.Update(entity);
    }

    public CustomerAccountProcess? GetById(int id)
    {
        return _customerAccountProcessDal.GetById(id);
    }

    public List<CustomerAccountProcess> GetAll()
    {
        return _customerAccountProcessDal.GetAll();
    }
}