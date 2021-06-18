using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistran.BusinessActions;
using Sistran.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistran.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly ILogger<PersonsController> _logger;
        private readonly PersonsActions _context;

        public PersonsController(PersonsActions context, ILogger<PersonsController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<Response<Person_Entity>> Create([FromBody] Person_Input param)
        {
            return await _context.CreatePerson(param);
        }


    }
}
