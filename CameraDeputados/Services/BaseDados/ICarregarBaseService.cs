namespace CameraDeputados.Services.BaseDados
{
    public interface ICarregarBaseService
    {
        Task CarregarBaseDados(string path, string uf);
    }
}
