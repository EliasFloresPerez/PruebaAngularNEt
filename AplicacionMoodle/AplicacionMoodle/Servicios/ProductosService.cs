using AplicacionMoodle.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace AplicacionMoodle.Servicios
{

    public class ProductosService: ProductosInterface
    {

        private readonly Data.AppContexto _contexto;

        public ProductosService(Data.AppContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<object> GetProductos()
        {
            var productos = await _contexto.Productos.ToListAsync();
            return productos;
        }

        public async Task<object> GetProductoTipo(int id)
        {
            //Buscamos por el tipo todos los productos
            
            var productos = await _contexto.Productos.Where(x => x.Tipo == id).ToListAsync();
            return productos;
        }

        public async Task<object> GetProductoId(int id)
        {
            var producto = await _contexto.Productos.FindAsync(id);
            return producto;
        }

    }
    
}
