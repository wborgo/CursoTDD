using System;

namespace CursoXUnity.Domain.Cursos
{
    public class Curso
    {
        public string Nome { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }
        public string Descricao { get; private set; }

        public Curso(string nome, string descricao, double cargaHoraria, PublicoAlvo publicoAlvo, double valor)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("nome invalido");
            if (cargaHoraria < 1) throw new ArgumentException("carga horaria invalida");
            if (valor < 1) throw new ArgumentException("valor invalido");

            Nome = nome;
            CargaHoraria = cargaHoraria;
            PublicoAlvo = publicoAlvo;
            Valor = valor;
            Descricao = descricao;
        }
    }
}
