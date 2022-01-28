using System;
using System.Runtime.Serialization;

namespace DesafioProwayFinancas.CrossCutting.Exceptions
{
    [Serializable]
    public class ObjetoNaoEncontradoException : Exception
    {
        public ObjetoNaoEncontradoException(
            string mensagem): base(mensagem)
        {
        }

        protected ObjetoNaoEncontradoException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) 
        { 
        }
    }
}
