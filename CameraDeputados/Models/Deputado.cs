namespace CameraDeputados.Models
{
    public class Deputado
    {
        public Deputado(string nome, string uf, string cpf, string partido)
        {
            Nome = nome;
            Uf = uf;
            Cpf = cpf;
            Partido = partido;
        }

        private Deputado()
        {

        }

        public int Id { get; init; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public string Cpf { get; set; }

        public string Partido { get; set; }

        public ICollection<Despesa> Despesas { get; set; }
    }
}
