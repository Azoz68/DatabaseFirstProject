using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DatabaseFirstProject.Entities;

namespace DatabaseFirstProject.Controllers.api
{
    public class UsersController : ApiController
    {
        private BookEntities db = new BookEntities();

        // GET: api/Users
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers([FromUri]int id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var user = db.Users.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                {
                    return NotFound();
                }
                db.Users.AddOrUpdate(users);
            }
            catch (Exception)
            {
                
                throw new HttpResponseException(HttpStatusCode.Ambiguous);
            }
            return Json("تم التعديل بنجاح");
        }

            // PUT: api/Users/5
            //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUsers(int id, [FromBody] Users users)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != users.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(users).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UsersExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Users
        //[ResponseType(typeof(Users))]
        //public IHttpActionResult PostUsers(Users users)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Users.Add(users);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = users.Id }, users);
        //}

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public IHttpActionResult GetUserAndName(int id, string name)
        {
            var result = db.Users.FirstOrDefault(x => x.Id == id && x.UserName == name);
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult PostUserAndName([FromBody] Users user)
        {
            try
            {
                var result = db.Users.FirstOrDefault(x => x.UserName == user.UserName
                && x.Password == user.Password);
                if (result != null)
                {
                    return BadRequest();
                }
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            db.Users.Add(user);
            db.SaveChanges();
            return Ok("تم الاضافة بنجاح");
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}