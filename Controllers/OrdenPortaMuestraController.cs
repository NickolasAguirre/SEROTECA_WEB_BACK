using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEROTECA_WEB_BACK.DataAccess;
using SEROTECA_WEB_BACK.Services;

namespace SEROTECA_WEB_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenPortaMuestraController : ControllerBase
    {

        private readonly IOrdenPortaMuestraService _ordenPortaMuestraService;
        public OrdenPortaMuestraController(IOrdenPortaMuestraService ordenPortaMuestraService)
        {
            _ordenPortaMuestraService = ordenPortaMuestraService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await _ordenPortaMuestraService.GetAll();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrdenPortaMuestraDA command)
        {
            var response = await _ordenPortaMuestraService.Post(command);
            return Ok(response);
        }




    }
}
