namespace AplicacionMoodle.Interfaces
{
    public interface ProductosInterface
    {

        Task<object> GetProductos();
        Task<object> GetProductoTipo(int id);

        Task<object> GetProductoId(int id);

    }
}
