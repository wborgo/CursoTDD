using System;
using Xunit;

namespace CursoXUnity.DomainTest._Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this Exception exception, string mensagem)
        {
            Assert.Equal(mensagem, exception.Message);
        }
    }
}
