using System;
using System.Runtime.Serialization;

namespace DesafioProwayFinancas.CrossCutting.Exceptions
{
    [Serializable]
    public class RegraInvalidaException: Exception
    {
        public RegraInvalidaException(string mensagem)
            : base(mensagem)
        {
        }

        protected RegraInvalidaException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
