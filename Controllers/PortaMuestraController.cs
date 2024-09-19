using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SEROTECA_WEB_BACK.DataAccess;
using SEROTECA_WEB_BACK.Services;

namespace SEROTECA_WEB_BACK.Controllers
{
    [Route("[controller]")]
    public class PortaMuestraController : Controller
    {

       private readonly IPortaMuestraService _portaMuestraService;
       public PortaMuestraController(IPortaMuestraService portaMuestraService, IMapper mapper) {

            _portaMuestraService = portaMuestraService;
          
        }


        [HttpGet]
        public async Task<ActionResult> GetLimits(string id)
        {
            var result = await _portaMuestraService.GetLimits(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PortaMuestraCommandDA command)
        {
            var portamuestra =_portaMuestraService.Post(command);
            return Ok(portamuestra);
        }

    }
}
