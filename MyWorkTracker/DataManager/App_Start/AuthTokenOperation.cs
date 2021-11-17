using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace DataManager.App_Start
{

    // this class allows us to get an access token using the username and password that we register for an account with

    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            swaggerDoc.paths.Add("/token", new PathItem
            {
                post = new Operation
                {
                    tags = new List<string> { "auth" },
                    consumes = new List<string>
                    {
                        "application/x-www-form-endcoded"
                    },
                    parameters = new List<Parameter>{
                            new Parameter
                            {
                                type = "string",
                                name  ="grant_type",
                                required = true,
                                @in = "formData",
                                @default = "password"
                            },
                            new Parameter
                            {
                                type = "string",
                                name = "username",
                                required = true,
                                @in = "formData"
                            },
                            new Parameter
                            {
                                type = "string",
                                name  = "password",
                                required =  true,
                                @in  = "formData"
                            }
                        }
                }
            });
        }
    }
}