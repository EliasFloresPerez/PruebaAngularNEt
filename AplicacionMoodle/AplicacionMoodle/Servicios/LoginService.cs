
using AplicacionMoodle.Interfaces;
using AplicacionMoodle.Modelos;
using AplicacionMoodle.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Formats.Asn1;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AplicacionMoodle.Servicios
{


    public class LoginService: LoginInterface
    {
        private readonly Data.AppContexto _contexto;

        public IConfiguration Configuration;
        public LoginService(Data.AppContexto contexto, IConfiguration configuration)
        {
            _contexto = contexto;
            Configuration = configuration;
        }

        public async Task<object> Login(LoginModelo datos)
        {
            try
            {
                var usuario = await _contexto.Usuario.FirstOrDefaultAsync(x => x.Email == datos.Email);

                if (usuario == null || datos.Password != usuario.Password)
                {
                    return new { status = false, message = "Usuario o contraseña incorrectos" };
                }

                //Retornamos el json necesario

                return new
                {
                    status = true,
                    usuario = new
                    {
                        id = usuario.Id,
                        email = usuario.Email,
                        nombre = usuario.NombreUsuario,
                        plan = "6"
                    },
                    token = await GenerateToken()
                };
            }
            catch (Exception ex)
            {
                
                return new { status = false, message = "Error en el proceso de inicio de sesión", error = ex.Message };
            }
        }

        public async  Task<object> GenerateToken()
        {
            var jwt = Configuration.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),


            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                               jwt.Issuer,
                               jwt.Audience,
                               claims,
                               expires: DateTime.UtcNow.AddMinutes(60),
                               signingCredentials: singIn
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return await Task.FromResult(tokenHandler.WriteToken(token));
            

        }

        
        public async Task<object> CambiarPlan(int idUser, int idPlan)
        {
            try
            {
                var usuario = await _contexto.Usuario.FirstOrDefaultAsync(x => x.Id == idUser);

                if (usuario == null)
                {
                    return new { status = false, message = "Usuario no encontrado" };
                }

                usuario.Plan = idPlan;
                _contexto.Usuario.Update(usuario);
                await _contexto.SaveChangesAsync();

                return new { status = true, message = "Plan cambiado correctamente" };
            }
            catch (Exception ex)
            {

                return new { status = false, message = "Error en el proceso de cambio de plan", error = ex.Message };
            }
        }


    }
  
}
