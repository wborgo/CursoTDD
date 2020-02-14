using Bogus;
using CursoXUnity.Domain.Cursos;
using CursoXUnity.DomainTest._Builders;
using CursoXUnity.DomainTest._Util;
using ExpectedObjects;
using System;
using Xunit;

namespace CursoXUnity.DomainTest.Cursos
{
    public class CursoTeste
    {
        Faker faker = new Faker();
        private readonly string _nome;
        private readonly double _cargaHoraria;
        private readonly PublicoAlvo _publicoAlvo;
        private readonly double _valor;
        private readonly string _descricao;

        public CursoTeste()
        {
            _nome = faker.Random.Words();
            _cargaHoraria = faker.Random.Double(50,1000);
            _publicoAlvo = faker.PickRandom<PublicoAlvo>();
            _valor = faker.Random.Double(100, 1000);
            _descricao = faker.Lorem.Paragraph();
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
                Descricao = _descricao
            };

            var curso = new Curso(_nome, _descricao, _cargaHoraria, _publicoAlvo, _valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerNomeInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
            CursoBuilder.Instance.ComNome(nomeInvalido).Build())
                .ComMensagem("nome invalido");
        }

        [Theory]
        [InlineData(0d)]
        [InlineData(-2d)]
        [InlineData(-100d)]
        public void NaoDeveCursoTerCargaHorariaMenorQue1(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
            CursoBuilder.Instance.ComCargaHoraria(cargaHorariaInvalida).Build())
                .ComMensagem("carga horaria invalida");
        }

        [Theory]
        [InlineData(0d)]
        [InlineData(-2d)]
        [InlineData(-100d)]
        public void NaoDeveCursoTerValorMenorQue1(double valorInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
            CursoBuilder.Instance.ComValor(valorInvalida).Build())
                .ComMensagem("valor invalido");
        }
    }
}