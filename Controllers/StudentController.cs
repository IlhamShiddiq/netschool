using netschool.Services;

namespace netschool.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using netschool.Context;
using netschool.Models;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private StudentService _service;

    public StudentController()
    {
        _service = new StudentService();
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        List<Student> students = _service.getAll();
            
        return new JsonResult(
            new {
                success = true,
                message = "Get Data Success",
                data = new {
                    students = students 
                }
            }
        );
    }
    
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Student>> GetById(int id)
    {
        Student student = _service.FindById(id);
            
        return new JsonResult(
            new {
                success = true,
                message = "Get Data Success",
                data = student
            }
        );
    }
    
    [HttpPost]
    public ActionResult Create(Student student)
    {
        _service.Store(student);
        
        return new JsonResult(
            new {
                success = true,
                message = "Create Data Success"
            }
        ) { StatusCode = StatusCodes.Status201Created };
    }
    
    [HttpPut("{id}")]
    public ActionResult Update(int id, Student updatedStudent)
    {
        updatedStudent.Id = id;
        _service.Update(updatedStudent);
        
        return new JsonResult(
            new {
                success = true,
                message = "Update Data Success"
            }
        );
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        Student student = _service.FindById(id);
        _service.Delete(student);
        
        return new JsonResult(
            new {
                success = true,
                message = "Delete Data Success"
            }
        );
    }
}