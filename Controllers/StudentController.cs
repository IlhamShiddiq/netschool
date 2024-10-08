﻿namespace netschool.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using netschool.Models;
using netschool.Services;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private StudentService _studentService;

    public StudentController()
    {
        _studentService = new StudentService();
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Student>> GetAll()
    {
        List<Student> students = _studentService.getAll();
            
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
        Student student = _studentService.FindById(id);
            
        return new JsonResult(
            new {
                success = true,
                message = "Get Data Success",
                data = new {
                    student
                }
            }
        );
    }
    
    [HttpPost]
    public ActionResult Create(Student student)
    {
        _studentService.Store(student);
        
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
        _studentService.Update(updatedStudent);
        
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
        Student student = _studentService.FindById(id);
        _studentService.Delete(student);
        
        return new JsonResult(
            new {
                success = true,
                message = "Delete Data Success"
            }
        );
    }
}