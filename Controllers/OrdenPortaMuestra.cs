using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEROTECA_WEB_BACK.DataAccess;
using SEROTECA_WEB_BACK.Services;

namespace SEROTECA_WEB_BACK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenPortaMuestra : ControllerBase
    {

        private readonly IOrdenPortaMuestraService _ordenPortaMuestraService;
        public OrdenPortaMuestra(IOrdenPortaMuestraService ordenPortaMuestraService)
        {
            _ordenPortaMuestraService = ordenPortaMuestraService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrdenPortaMuestraDA command)
        {
            var response = await _ordenPortaMuestraService.Post(command);
            return Ok(response);
        }


    }
}
