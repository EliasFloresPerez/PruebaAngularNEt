using AplicacionMoodle.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AplicacionMoodle.Servicios
{
    public class PlanesServicio: PlanesInterface
    {

        private readonly Data.AppContexto _contexto;

        public PlanesServicio(Data.AppContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<object> GetPlanes()
        {
            var planes = await _contexto.Planes.ToListAsync();
            return planes;
        }

        public async Task<object> GetPlan(int id)
        {
            var plan = await _contexto.Planes.FindAsync(id);
            return plan;
        }

    }
}
