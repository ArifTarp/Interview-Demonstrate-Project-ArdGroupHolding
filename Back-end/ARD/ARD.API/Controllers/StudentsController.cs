﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARD.Entity.DTOs;
using ARD.Business.Abstract;
using ARD.Entity.Concrete;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ARD.API.Controllers
{
    [Route("api/students")]
    [Produces("application/json")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var result = await _studentService.GetAllAsync();
            return StatusCode(result.HttpStatusCode, result.Data);
        }

        [HttpGet("getAllWithAddress")]
        public async Task<IActionResult> GetAllWithAddress()
        {
            var result = await _studentService.GetStudentsWithAddressAsync();
            return StatusCode(result.HttpStatusCode, result.Data);
        }

        [HttpGet("getStudentWithAddressById/{id}")]
        public async Task<IActionResult> GetStudentWithAddressById(int id)
        {
            var result = await _studentService.GetStudentWithAddressByIdAsync(id);
            return StatusCode(result.HttpStatusCode, result.Data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _studentService.GetStudentByIdAsync(id);
            return StatusCode(result.HttpStatusCode,result.Data);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return StatusCode((await _studentService.DeleteStudentWithAddressAsync(id)).HttpStatusCode);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] StudentAddDto studentAddDto)
        {
            var result = await _studentService.AddStudentWithAddressAsync(studentAddDto);
            return StatusCode(result.HttpStatusCode, result.Data);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(StudentUpdateDto studentUpdateDto)
        {
            var result = await _studentService.UpdateStudentWithAddressAsync(studentUpdateDto);
            return StatusCode(result.HttpStatusCode, result.Data);
        }
    }
}
