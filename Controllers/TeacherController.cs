using netschool.Models;

namespace netschool.Controllers;

using Microsoft.AspNetCore.Mvc;

using netschool.Services;

[ApiController]
[Route("api/teachers")]
public class TeacherController : ControllerBase
{
    private TeacherService _teacherService;

    public TeacherController()
    {
        _teacherService = new TeacherService();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Teacher>> GetAll()
    {
        List<Teacher> teachers = _teacherService.getAll();
        
        return new JsonResult(
            new {
                success = true,
                message = "Get Data Success",
                data = new {
                    teachers
                }
            }
        );
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Teacher>> GetById(int id)
    {
        Teacher teacher = _teacherService.FindById(id);
        
        return new JsonResult(
            new {
                success = true,
                message = "Get Data Success",
                data = new {
                    teacher
                }
            }
        );
    }

    [HttpPost]
    public ActionResult Create(Teacher teacher)
    {
        _teacherService.Store(teacher);
        
        return new JsonResult(
            new {
                success = true,
                message = "Create Data Success"
            }
        ) { StatusCode = StatusCodes.Status201Created };
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Teacher updatedTeacher)
    {
        updatedTeacher.Id = id;
        _teacherService.Update(updatedTeacher);
        
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
        Teacher teacher = _teacherService.FindById(id);
        _teacherService.Delete(teacher);
        
        return new JsonResult(
            new {
                success = true,
                message = "Delete Data Success"
            }
        );
    }
}