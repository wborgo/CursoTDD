using CursoXUnity.Domain.Cursos;

namespace CursoXUnity.DomainTest._Builders
{
    public class CursoBuilder
    {
        private string _nome = "informatica";
        private double _cargaHoraria = 80d;
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Estudante;
        private double _valor = 950d;
        private string _descricao = "Uma descricao";

        public static CursoBuilder Instance
        {
            get
            {
                return new CursoBuilder();
            }
        }

        public Curso Build()
        {
            return new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);
        }

        public CursoBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }
    }
}
