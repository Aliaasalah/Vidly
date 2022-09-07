using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;
using Vidly.DTO;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _contex;

        MoviesController()
        {
            _contex = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovie()
        {
            var q = _contex.Movies.Include(x => x.Genre);

            var MoviesDtos = q.ToList().Select(Mapper.Map<Movie, MovieDto>);
            return Ok(MoviesDtos);

        }


        public IHttpActionResult GetMovie(int id)
        {
            var Movie = _contex.Movies.SingleOrDefault(c => c.ID == id);
            if (Movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(Movie));
        }

        [HttpPost]
        public IHttpActionResult PostMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _contex.Movies.Add(movie);
            _contex.SaveChanges();

            movieDto.ID = movie.ID;
            return Created(new Uri(Request.RequestUri + "/" + movie.ID), movieDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var MovieInDB = _contex.Movies.SingleOrDefault(c => c.ID == id);

            if (MovieInDB == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, MovieInDB);

            _contex.SaveChanges();

            return Ok();
             
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var MovieInDB = _contex.Movies.SingleOrDefault(c => c.ID == id);

            if (MovieInDB == null)
            {
                return NotFound();
            }

            _contex.Movies.Remove(MovieInDB);
            _contex.SaveChanges();

            return Ok();

        }

    }
}
