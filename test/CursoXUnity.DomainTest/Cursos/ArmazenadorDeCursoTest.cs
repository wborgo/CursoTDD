using Bogus;
using CursoXUnity.Domain.Cursos;
using CursoXUnity.DomainTest._Builders;
using CursoXUnity.DomainTest._Util;
using Moq;
using System;
using Xunit;

namespace CursoXUnity.DomainTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        Faker faker = new Faker();
        private CursoDto _cursoDto;
        private Mock<ICursoRepositorio> _cursoRepositorioMock;
        private ArmazenadorDeCurso _armazenadorDeCurso;

        public ArmazenadorDeCursoTest()
        {
            _cursoDto = new CursoDto
            {
                Nome = faker.Random.Words(),
                CargaHoraria = faker.Random.Double(50, 1000),
                PublicoAlvoId = "Estudante",
                Valor = faker.Random.Double(100, 1000),
                Descricao = faker.Lorem.Paragraph()
            };

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();

            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDto);

            _cursoRepositorioMock.Verify(x => x.Adicionar(It.Is<Curso>(
                    c => c.Nome == _cursoDto.Nome &&
                    c.Descricao == _cursoDto.Descricao
                )), Times.Once);
        }

        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            var publicoAlvoInvalido = "Medico";
            _cursoDto.PublicoAlvoId = publicoAlvoInvalido;

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto))
                .ComMensagem("publico alvo invalido");

            _cursoRepositorioMock.Verify(x => x.Adicionar(It.IsAny<Curso>()), 
                Times.Never);
        }

        [Fact]
        public void NaoDeveAdicionarCursoComNomeJaExistente()
        {
            var cursoJaSalvo = CursoBuilder.Instance.ComNome(_cursoDto.Nome).Build();

            _cursoRepositorioMock.Setup(x => x.ObterPeloNome(_cursoDto.Nome)).Returns(cursoJaSalvo);

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto))
                .ComMensagem("ja existe um curso com este nome");
        }
    }
}
