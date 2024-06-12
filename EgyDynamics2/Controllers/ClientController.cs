using AutoMapper;
using EgyDynamics2.DTO;
using EgyDynamics2.Models;
using EgyDynamics2.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace EgyDynamics2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        UnitOf_Work UOF;
        IMapper Mapper;
        public ClientController(UnitOf_Work UOF, IMapper mapper)
        {
            this.UOF = UOF;
            this.Mapper = mapper;
        }

        [HttpGet]

        public IActionResult GetClients(int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var clients = UOF.CustomerRepository.SelectAllIncludePagination(pageNumber, pageSize,
                    c => c.ادخالبواسطةNavigation, c => c.اخرتعديلNavigation);

                if (clients == null || clients.Count == 0)
                {
                    return NotFound();
                }

                var totalClients = UOF.CustomerRepository.Count();

                var clientsDto = Mapper.Map<List<العميلDTO>>(clients);

                var response = new
                {
                    Data = clientsDto,
                    TotalItems = totalClients
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }


       
        [HttpPost]
        public IActionResult AddNewClient(العميلDTO newClient)
        {
            try
            {
                if (newClient == null)
                {
                    return BadRequest();
                }
                العميل client = Mapper.Map<العميل>(newClient);
                UOF.CustomerRepository.Add(client);
                UOF.SaveChanges();
                return Ok();
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request");
            }

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                var calls = UOF.CallRepository.GetEntitiesByForeignKey<مكالمهالعميل>(id, "كودالعميل");
                if (calls.Count != 0)
                {
                    UOF.CallRepository.DeleteEntities(calls);
                }
                UOF.CustomerRepository.delete(id);
                UOF.SaveChanges();

            return Ok();
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request");
            }
        }

        [HttpPut]
        public IActionResult EditClient(العميلDTO edited)
        {
            if (edited == null)
            {
                return BadRequest("Please enter the required data");
            }
            العميل client = Mapper.Map<العميل>(edited);
            UOF.CustomerRepository.update(client);
            UOF.SaveChanges();

            return Ok();
        }
    }
}
