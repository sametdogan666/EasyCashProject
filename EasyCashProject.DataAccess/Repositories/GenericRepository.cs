﻿using EasyCashProject.DataAccess.Abstract;
using EasyCashProject.DataAccess.Concrete;

namespace EasyCashProject.DataAccess.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class
{
    private readonly Context _context;

    public GenericRepository(Context context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
       _context.Set<T>().Add(entity);
       _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);

    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
}