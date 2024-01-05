using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Ecommerce.Domain.CustomException
{
    [Serializable]
    public class CategoryNotFoundException : Exception
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        private const string DefaultMessage = "Category does not exist.";
        public CategoryNotFoundException() : base(DefaultMessage)
        {

        }
        public CategoryNotFoundException(string message) : base(message)
        {

        }

        // This public constructor is used by class instantiators.
        public CategoryNotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public CategoryNotFoundException(Guid categoryId, string categoryName) : this($"Category does not exist with ID: '{categoryId}' and Name: '{categoryName}'.")
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        // This protected constructor is used for deserialization.
        protected CategoryNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            CategoryId = (Guid)info.GetValue(nameof(CategoryId), typeof(Guid));
            CategoryName = (string)info.GetValue(nameof(CategoryName), typeof(string));
        }

        // GetObjectData performs a custom serialization.
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Change the case of two properties, and then use the
            // method of the base class.
            base.GetObjectData(info, context);
            info.AddValue(nameof(CategoryId), CategoryId, typeof(Guid));
            info.AddValue(nameof(CategoryName), CategoryName, typeof(string));
        }
    }
}
