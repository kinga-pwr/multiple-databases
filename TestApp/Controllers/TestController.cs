using Microsoft.AspNetCore.Mvc;
using MultipleDatabases.DAL;
using MultipleDatabases.DAL.Models;
using System;
using System.Collections.Generic;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private TestDbContext _context;

        public TestController(TestDbContext context)
        {
            _context = context;
        }

        // GET: api/test
        [HttpGet]
        public IActionResult Get()
        {
            var two = new TestTwo()
            {
                Id = Guid.NewGuid(),
                Test = "some text 2"
            };

            var one = new TestOne()
            {
                Id = Guid.NewGuid(),
                Number = 2,
                Condition = true,
                Text = "some text 1",
                Elems = new List<TestTwo>() { two }
            };

            _context.TestOnes.Add(one);
            _context.SaveChanges();

            return Ok("Successfully inserted data to db");
        }

        // GET api/test/isalive
        [HttpGet]
        [Route("IsAlive")]
        public IActionResult IsAlive()
        {
            return Ok("Test App is working. To insert data use path: /api/test");
        }
    }
}
