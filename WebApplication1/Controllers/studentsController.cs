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
    public class studentsController : ApiController
    {



        private StudentContext db = new StudentContext();

        // GET: api/Products
        public IHttpActionResult GetStudents()
        {
            var response = db.students.Select(e => new studentContract() { studentID = e.studentID, studentName = e.studentName }).ToList();

            //return db.courses;
            return Ok(response);
        }


        // GET: api/Products/5
        [ResponseType(typeof(student))]
        public IHttpActionResult GetStudents(int id)
        {
            student students = db.students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }




        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, student students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != students.studentID)
            {
                return BadRequest();
            }

            db.Entry(students).State = EntityState.Modified;
            //db.Edit(product);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(student))]
        public IHttpActionResult PostStudents(student students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.students.Add(students);

            return CreatedAtRoute("DefaultApi", new { id = students.studentID }, students);
        }


        // DELETE: api/Products/5
        [ResponseType(typeof(student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            student students = db.students.Find(id);
            if (students == null)
            {
                return NotFound();
            }

            db.students.Remove(students);
            return Ok(students);
        }


    }
}
