using System.Runtime.Serialization;

namespace CollectionDemo
{
    [Serializable]
    internal class BankAccountException : Exception
    {

        public BankAccountException(string message) : base(message)
        {
        }

    }
}