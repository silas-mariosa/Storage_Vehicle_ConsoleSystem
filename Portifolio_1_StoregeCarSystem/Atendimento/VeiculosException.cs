using System.Runtime.Serialization;

namespace Portifolio_1_StoregeCarSystem.Atendimento
{
    [Serializable]
    internal class VeiculosException : Exception
    {
        public VeiculosException()
        {
        }

        public VeiculosException(string? message) : base(message)
        {
        }

        public VeiculosException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected VeiculosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}