using Microsoft.EntityFrameworkCore;
using netschool.Context;
using netschool.Models;

namespace netschool.Services;

public class ClassService
{
    private DatabaseContext.SchoolContext _context;

    public ClassService()
    {
        _context = new DatabaseContext.SchoolContext();
    }

    public List<Class> GetAll()
    {
        List<Class> classes = _context.Classes.ToList();
        return classes;
    }

    public Class FindById(int id)
    {
        Class classData = _context.Classes.Find(id);
        return classData;
    }

    public void Store(Class classData)
    {
        _context.Classes.Add(classData);
        _context.SaveChanges();
    }
    
    public void Update(Class classData)
    {
        _context.Classes.Update(classData);
        _context.SaveChanges();
    }
    
    public void Delete(Class classData)
    {
        _context.Classes.Remove(classData);
        _context.SaveChanges();
    }
}