using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Ecommerce.API.Filter
{
    public class RemovePropSwaggerSchemaFilter : ISchemaFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RemovePropSwaggerSchemaFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            var method = _httpContextAccessor.HttpContext.Request.Method;
            
            if (method == HttpMethods.Post)
            {
                var ignoreDataMemberProperties = context.Type.GetProperties()
                    .Where(t => t.GetCustomAttribute<IgnoreDataMemberAttribute>() != null);

                foreach (var ignoreDataMemberProperty in ignoreDataMemberProperties)
                {
                    var propertyToHide = schema.Properties.Keys
                        .SingleOrDefault(x => x.ToLower() == ignoreDataMemberProperty.Name.ToLower());

                    if (propertyToHide != null)
                    {
                        schema.Properties.Remove(propertyToHide);
                    }
                }
            }
        }
    }
}
