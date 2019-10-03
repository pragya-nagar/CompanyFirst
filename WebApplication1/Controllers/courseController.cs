using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Data_Contracts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class courseController : ApiController
    {



        private StudentContext db = new StudentContext();
        
        

        // GET: api/Products
        [HttpGet]
        public IHttpActionResult GetCourse()
        {
            var response = db.courses.Select(e => new courseContract() { courseID = e.courseID, courseName = e.courseName }).ToList();

            //return db.courses;
            return Ok(response);
        }

        // GET: api/Products/5
        [ResponseType(typeof(course))]
        public IHttpActionResult GetCourse(int id)
        {
            course courses = db.courses.Find(id);
            if (courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }




        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcourse(int id, course courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courses.courseID)
            {
                return BadRequest();
            }

            db.Entry(courses).State = EntityState.Modified;
            //db.Edit(product);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(course))]
        public IHttpActionResult PostStudents(course courses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.courses.Add(courses);

            return CreatedAtRoute("DefaultApi", new { id = courses.courseID }, courses);
        }


        // DELETE: api/Products/5
        [ResponseType(typeof(course))]
        public IHttpActionResult DeleteCourse(int id)
        {
            course courses = db.courses.Find(id);
            if (courses == null)
            {
                return NotFound();
            }

            db.courses.Remove(courses);
            return Ok(courses);
        }


    }
}
