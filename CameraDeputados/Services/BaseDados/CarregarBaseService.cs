
using CameraDeputados.Infra.Repositories.Interfaces;
using CameraDeputados.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace CameraDeputados.Services.BaseDados
{
    public class CarregarBaseService : ICarregarBaseService
    {
        private readonly IDeputadoRepository _deputadoRepository;

        public CarregarBaseService(IDeputadoRepository deputadoRepository)
        {
            _deputadoRepository = deputadoRepository;
        }

        public async Task CarregarBaseDados(string path, string uf)
        {
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true
            });

            csv.Read();
            csv.ReadHeader();

            var despesas = new List<Despesa>();
            var deputados = new Dictionary<int, Deputado>();

            try
            {
                while (await csv.ReadAsync())
                {
                    if (string.IsNullOrWhiteSpace(csv.GetField("ideCadastro"))) continue;

                    int deputadoId = int.Parse(csv.GetField("ideCadastro"));

                    if (!deputados.ContainsKey(deputadoId))
                    {
                        var deputado = new Deputado(
                            csv.GetField("txNomeParlamentar"),
                            csv.GetField("sgUF"),
                            csv.GetField("cpf"),
                            csv.GetField("sgPartido"))
                        {
                            Id = deputadoId
                        };
                        deputados[deputadoId] = deputado;
                    }
                    despesas.Add(new Despesa(
                        deputadoId,
                        csv.GetField("datEmissao"),
                        csv.GetField("txtFornecedor"),
                        decimal.Parse(csv.GetField("vlrLiquido")),
                        csv.GetField("urlDocumento")
                    ));
                }

                await _deputadoRepository.CarregarBaseDeputado(deputados.Values.ToList());
                await _deputadoRepository.CarregarBaseDespesas(despesas);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
