using netschool.Context;
using netschool.Models;

namespace netschool.Services;

public class TeacherService
{
    private DatabaseContext.SchoolContext _context;

    public TeacherService()
    {
        _context = new DatabaseContext.SchoolContext();
    }
    
    public List<Teacher> getAll()
    {
        List<Teacher> teachers = _context.Teachers.ToList();
        return teachers;
    }

    public Teacher FindById(int id)
    {
        Teacher teacher = _context.Teachers.Find(id);
        return teacher;
    }

    public void Store(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        _context.SaveChanges();
    }
    
    public void Update(Teacher teacher)
    {
        _context.Teachers.Update(teacher);
        _context.SaveChanges();
    }

    public void Delete(Teacher teacher)
    {
        _context.Teachers.Remove(teacher);
        _context.SaveChanges();
    }
}