using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Orbit.Data.Entities;
using Orbit.Services.Core;

namespace Orbit.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IEntityService<Student> _service;

        public StudentController(IEntityService<Student> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _service.GetAllAsync().Result;
        }

        [HttpPost]
        public Student Save(Student student)
        {
            return _service.CreateAsync(student).Result;
        }

        [HttpPut]
        public Student Update(Student student)
        {
            return _service.UpdateAsync(student).Result;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var student = _service.GetByIdAsync(id).Result;
            if(student != null)
                _service.DeleteAsync(student);
        }
    }
}
