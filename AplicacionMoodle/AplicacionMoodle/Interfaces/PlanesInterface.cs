namespace AplicacionMoodle.Interfaces
{
    public interface PlanesInterface
    {
        public Task<object> GetPlanes();

        public Task<object> GetPlan(int id);




    }
}
