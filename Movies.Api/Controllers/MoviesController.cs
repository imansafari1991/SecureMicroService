using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Model;
using Movies.Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieDBContext _context;

        public MoviesController(MovieDBContext context)
        {
            _context = context;
        }
        // GET: api/<MoviesController>
        [HttpGet]

       [Authorize("ClientIdPolicy")]
        public  Task<List<Movie>> Get()
        {
            return  _context.Movies.ToListAsync();
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public async Task<Movie> Get(int id)
        {
            return await  _context.Movies.FindAsync(id);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public async Task Post(Movie model)
        {

         await   _context.Movies.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
