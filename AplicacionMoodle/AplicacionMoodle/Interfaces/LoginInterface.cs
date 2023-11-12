using AplicacionMoodle.Modelos;

namespace AplicacionMoodle.Interfaces
{
    public interface LoginInterface
    {

        public Task<object> Login(LoginModelo datos);

        public Task<object> GenerateToken();

        public Task<object> CambiarPlan(int idUser, int idPlan);
    }
}
