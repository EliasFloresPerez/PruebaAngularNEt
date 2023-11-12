using AplicacionMoodle.Interfaces;
using AplicacionMoodle.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionMoodle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController: ControllerBase
    {
        private  PlanesInterface PlanesInterface;

        public PlanesController(PlanesInterface _PlanesInterface)
        {

            this.PlanesInterface =  _PlanesInterface;
        }

        [HttpGet]
        [Route("getPlanes")]
        public async Task<IActionResult> GetPlanes()
        {
            var resultado =  await PlanesInterface.GetPlanes();
            return Ok(resultado);
        }

        [HttpGet]
        [Route("getPlan/{id}")]
        public async Task<IActionResult> GetPlan(int id)
        {
            var resultado =  await PlanesInterface.GetPlan(id);
            return Ok(resultado);
        }

    }
}
