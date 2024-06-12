using AutoMapper;
using EgyDynamics2.DTO;
using EgyDynamics2.Models;
using EgyDynamics2.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgyDynamics2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallController : ControllerBase
    {
        IMapper mapper;
        UnitOf_Work UOF;
        public CallController(UnitOf_Work UOF, IMapper mapper)
        {
            this.UOF = UOF;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult SelectAllCalls()
        {
            try
            {
                List<مكالمهالعميل> calls = UOF.CallRepository.SelectAllInclude(c => c.اخرتعديلNavigation, c => c.ادخالبواسطهNavigation, c => c.الموظفNavigation);
                if (calls.Count == 0)
                {
                    return NotFound();
                }
            List<المكالماتDTO> CallsDTO = mapper.Map<List<المكالماتDTO>>(calls);
            return Ok(CallsDTO);
        }
            catch
            {
                return StatusCode(500, "An error occurred while processing your request");
            }
        }
    }
}
