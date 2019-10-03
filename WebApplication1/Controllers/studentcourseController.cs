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
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class studentcourseController : ApiController
    {
        


        private StudentContext db = new StudentContext();

        // GET: api/Products
        // public IEnumerable<studentcourse> GetStudentCourse()
        //{
        //     return db.studentcourses;
        // }
        
        // public IEnumerable<studentcourse> GetStudents()
        //{
        //   return db.studentcourses.Include(b => b.student);
        // return _context.students.Include(c => c.School);
        //}
        [HttpGet]
        public IHttpActionResult GetStudentCourse()
        {
            var response = (from ep in db.students
                            join e in db.studentcourses on ep.studentID equals e.studentID
                            join t in db.courses on e.courseID equals t.courseID
                            select new
                            {

                                ID = e.ID,
                                studentID = ep.studentID,
                                studentName = ep.studentName,
                                courseID = t.courseID,
                                courseName = t.courseName

                            }).ToList();
            return Ok(response);
           // int studentId = 1;
            //return db.studentcourses.Where(e => e.studentID == e.studentID ).Include(e => e.student).ToList();
                //.Include(students => students.student)
                //.ToList();
        }
       

        // GET: api/Products/5
        [ResponseType(typeof(studentcourse))]
        public IHttpActionResult GetStudents(int id)
        {
            studentcourse studentcourses = db.studentcourses.Find(id);
            if (studentcourses == null)
            {
                return NotFound();
            }

            return Ok(studentcourses);
        }




        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentCourse(int id, studentcourse studentcourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentcourses.studentID)
            {
                return BadRequest();
            }

            db.Entry(studentcourses).State = EntityState.Modified;
            //db.Edit(product);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(studentcourse))]
        public IHttpActionResult PostStudentCourse(studentcourse studentcourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.studentcourses.Add(studentcourses);

            return CreatedAtRoute("DefaultApi", new { id = studentcourses.studentID }, studentcourses);
        }


        // DELETE: api/Products/5
        [ResponseType(typeof(studentcourse))]
        public IHttpActionResult DeleteProduct(int id)
        {
            studentcourse studentcourses = db.studentcourses.Find(id);
            if (studentcourses == null)
            {
                return NotFound();
            }

            db.studentcourses.Remove(studentcourses);
            return Ok(studentcourses);
        }


    }
}
