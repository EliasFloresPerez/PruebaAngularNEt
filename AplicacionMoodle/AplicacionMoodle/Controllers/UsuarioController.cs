using AplicacionMoodle.Interfaces;
using AplicacionMoodle.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AplicacionMoodle.Controllers
{

    [Route("api/[controller]")]
    [EnableCors("NuevaPolitica")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private LoginInterface LoginInterface;

        public UsuarioController(LoginInterface LoginInterface)
        {

            this.LoginInterface = LoginInterface;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Modelos.LoginModelo datos)
        {
            var resultado =  await LoginInterface.Login(datos);
            return Ok(resultado);
        }


        [HttpPost]
        
        [Route("cambiarPlan")]
        public async Task<IActionResult> CambiarPlan(int idUser, int idPlan)
        {
            //Validar si el token es valido

            var identity  = HttpContext.User.Identity as ClaimsIdentity;

            var resultadoToken = Security.Jwt.validarToken(identity);

            if (resultadoToken.success == false)
            {
                return Ok(resultadoToken);
            }


            var resultado = await LoginInterface.CambiarPlan(idUser, idPlan);
            return Ok(resultado);
        }





    }
}
