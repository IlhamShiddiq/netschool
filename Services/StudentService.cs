using netschool.Context;
using netschool.Models;

namespace netschool.Services;

public class StudentService
{
    private DatabaseContext.SchoolContext _context;

    public StudentService()
    {
        _context = new DatabaseContext.SchoolContext();
    }

    public List<Student> getAll()
    {
        List<Student> students = _context.Students.ToList();
        return students;
    }

    public Student FindById(int id)
    {
        Student student = _context.Students.Find(id);
        return student;
    }

    public void Store(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }
    
    public void Update(Student student)
    {
        _context.Students.Update(student);
        _context.SaveChanges();
    }

    public void Delete(Student student)
    {
        _context.Students.Remove(student);
        _context.SaveChanges();
    }
}