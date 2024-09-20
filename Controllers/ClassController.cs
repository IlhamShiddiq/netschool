using Microsoft.AspNetCore.Mvc;
using netschool.Models;
using netschool.Services;

namespace netschool.Controllers;

[ApiController]
[Route("api/classes")]
public class ClassController
{
    private ClassService _classService;

    public ClassController()
    {
        _classService = new ClassService();
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Class>> GetAll()
    {
        List<Class> classes = _classService.GetAll();
        
        return new JsonResult(
            new {
                success = true,
                message = "Get Data Success",
                data = new {
                    classes
                }
            }
        );
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Class>> GetById(int id)
    {
        Class classData = _classService.FindById(id);
        
        return new JsonResult(
            new {
                success = true,
                message = "Get Data Success",
                data = new {
                    @class = classData
                }
            }
        );
    }
    
    [HttpPost]
    public ActionResult Create(Class classData)
    {
        _classService.Store(classData);
        
        return new JsonResult(
            new {
                success = true,
                message = "Create Data Success"
            }
        ) { StatusCode = StatusCodes.Status201Created };
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, Class classData)
    {
        classData.Id = id;
        _classService.Update(classData);
        
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
        Class data = _classService.FindById(id);
        _classService.Delete(data);
        
        return new JsonResult(
            new {
                success = true,
                message = "Delete Data Success"
            }
        );
    }
}