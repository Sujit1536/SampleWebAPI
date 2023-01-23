using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebServices1.DTO;
using WebServices1.Entities;

namespace WebServices1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TestDbContext TestDbContext;
        public UserController(TestDbContext TestDbContext)
        {
            this.TestDbContext = TestDbContext;
        }


        //Step A
        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDTO>>> Get()
        {
            var List = await TestDbContext.Persons.Select(
                s => new UserDTO
                { 
                    PersonID = s.PersonID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Address = s.Address,
                    City = s.City
                }
            ).ToListAsync();
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            if (List.Count < 0)
            {
                return NotFound();
            }
            else
            {
                return List;
            }
        }


        //////Step B
        //[HttpGet("GetUserById")]
        //public async Task<ActionResult<UserDTO>> GetUserById(int PersonID)
        //{
        //    UserDTO User = await TestDbContext.Persons.Select(s => new UserDTO
        //    {
        //        PersonID = s.PersonID,
        //        FirstName = s.FirstName,
        //        LastName = s.LastName,
        //        Address = s.Address,
        //        City = s.City
        //    }).FirstOrDefaultAsync(s => s.PersonID == PersonID);
        //    if (User == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return User;
        //    }
        //}


        //////Step C
        //[HttpPost("InsertUser")]
        //public async Task<HttpStatusCode> InsertUser(UserDTO Person)
        //{
        //    var entity = new Person()
        //    {
        //        FirstName = Person.FirstName,
        //        LastName = Person.LastName,
        //        Address = Person.Address,
        //        City = Person.City
        //    };
        //    TestDbContext.Persons.Add(entity);         //Persons is database   and     Person is class
        //    await TestDbContext.SaveChangesAsync();
        //    return HttpStatusCode.Created;
        //}



        //////Step D
        //[HttpPut("UpdateUser")]
        //public async Task<HttpStatusCode> UpdateUser(UserDTO Person)
        //{
        //    var entity = await TestDbContext.Persons.FirstOrDefaultAsync(s => s.PersonID == Person.PersonID);
        //    entity.FirstName = Person.FirstName;
        //    entity.LastName = Person.LastName;
        //    entity.Address = Person.Address;
        //    entity.City = Person.City;
        //    await TestDbContext.SaveChangesAsync();
        //    return HttpStatusCode.OK;
        //}



        //////Step E
        //[HttpDelete("DeleteUser/{Id}")]
        //public async Task<HttpStatusCode> DeleteUser(int PersonID)
        //{
        //    var entity = new Person()
        //    {
        //        PersonID = PersonID
        //    };
        //    TestDbContext.Persons.Attach(entity);
        //    TestDbContext.Persons.Remove(entity);
        //    await TestDbContext.SaveChangesAsync();
        //    return HttpStatusCode.OK;
        //}

    }
}
