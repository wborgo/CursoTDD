using System;

namespace CursoXUnity.Domain.Cursos
{
    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            if (!Enum.TryParse<PublicoAlvo>(cursoDto.PublicoAlvoId, out var publicoAlvo))
                throw new ArgumentException("publico alvo invalido");

            var cursoJaSalvo = _cursoRepositorio.ObterPeloNome(cursoDto.Nome);
            if (cursoJaSalvo != null)
                throw new ArgumentException("ja existe um curso com este nome");

            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, publicoAlvo, cursoDto.Valor);

            _cursoRepositorio.Adicionar(curso);
        }
    }
}
