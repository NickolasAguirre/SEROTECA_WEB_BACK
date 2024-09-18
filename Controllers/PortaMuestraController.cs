using Microsoft.AspNetCore.Mvc;
using SEROTECA_WEB_BACK.Services;

namespace SEROTECA_WEB_BACK.Controllers
{
    public class PortaMuestraController : Controller
    {
       private readonly IPortaMuestraService _portaMuestraService;
       public PortaMuestraController(IPortaMuestraService portaMuestraService) {

            _portaMuestraService = portaMuestraService;
        }


        public async Task<ActionResult> GetLimits(int id)
        {
            var result = await _portaMuestraService.GetLimits(id);
            return Ok(result);
        }

    }
}
