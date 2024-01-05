using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.Domain.CustomException
{
    // Define a serializable derived exception class.
    [Serializable]
    public class ProductNotFoundException : Exception
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }

        private const string DefaultMessage = "Product does not exist.";
        public ProductNotFoundException(): base(DefaultMessage)
        {

        }
        public ProductNotFoundException(string message) : base(message)
        {

        }

        // This public constructor is used by class instantiators.
        public ProductNotFoundException(string message, Exception innerException): base(message, innerException)
        {

        }

        public ProductNotFoundException(long productId, string productName) : this($"Product does not exist with ID: '{productId}' and Name: '{productName}'.")
        {
            ProductId = productId;
            ProductName = productName;
        }

        // This protected constructor is used for deserialization.
        protected ProductNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ProductId = (long)info.GetValue(nameof(ProductId), typeof(long));
            ProductName = (string)info.GetValue(nameof(ProductName), typeof(string));
        }

        // GetObjectData performs a custom serialization.
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Change the case of two properties, and then use the
            // method of the base class.
            base.GetObjectData(info, context);
            info.AddValue(nameof(ProductId), ProductId, typeof(long));
            info.AddValue(nameof(ProductName), ProductName, typeof(string));
        }
    }
}
