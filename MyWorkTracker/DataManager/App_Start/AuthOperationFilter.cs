using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace DataManager.App_Start
{
    // this class adds an authorization parameter to every api method so that we can plug in our access token if we have one and
    // get access to certain endpoints

    public class AuthOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in  = "header",
                description = "access token",
                required = false,
                type = "string"
            });
        }
    }
}