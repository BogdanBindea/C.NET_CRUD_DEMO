﻿using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Models;
using WebAPIDemo.Services;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeacherController : Controller
    {

        private readonly ITeacherService _service;

        public TeacherController(ITeacherService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult create([FromBody] Teacher teacher)
        {
            return Ok(_service.create(teacher));
        }

        [HttpGet]
        public ActionResult<List<Teacher>> getAll()
        {
            return Ok(_service.getAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Teacher> get(int id)
        {
            return Ok(_service.getOne(id));
        }

        [HttpPut("{id}")]
        public ActionResult<Teacher> update(int id, [FromBody] Teacher teacher)
        {
            if (id != teacher.TeacherId)
                return BadRequest("Path id does not match the body id");
            return Ok(_service.update(teacher));
        }

        [HttpDelete]
        public ActionResult<int> delete(int id)
        {
            return Ok(_service.delete(id));
        }


    }
}
