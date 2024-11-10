﻿using CameraDeputados.Models;

namespace CameraDeputados.Infra.Repositories.Interfaces
{
    public interface IDeputadoRepository
    {
        Task<List<Deputado>> ListarDeputadosPorEstadoAsync(string uf);
        Task CarregarBaseDeputado(List<Deputado> deputados);
        Task CarregarBaseDespesas(List<Despesa> despesas);
    }
}
