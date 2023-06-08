using DatabaseFirstProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DatabaseFirstProject.Controllers.api
{
    public class TestController : ApiController
    {
        private BookEntities _db;
        public TestController()
        {
            _db = new BookEntities();
        }
        // GET: api/Test
        public IEnumerable<string> Get()
        {
            return new string[] { "Aziz", "Students" };
        }


        public IEnumerable<Users> GetUsers()
        {
            var result = _db.Users.ToList();
            return result;
        }

        public IQueryable<Book> GetBooks()
        {
            return _db.Book;
        }

        // GET: api/Test/5
        public Auther GetAuther(int id)
        {
            var auther = _db.Auther.SingleOrDefault(x => x.Id == id);
            if(auther == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return auther;
        }

        // POST: api/Test
        public Auther PostAuther(Auther auther)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _db.Auther.Add(auther);
            _db.SaveChanges();

            return auther;
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
