using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using IDocumentFilter = Swashbuckle.AspNetCore.SwaggerGen.IDocumentFilter;

namespace dotnet_vite_react.Helper.Swagger
{
    public class SwaggerPathPrefixInsertDocumentFilter : IDocumentFilter
    {
        private string _prefix;
        public SwaggerPathPrefixInsertDocumentFilter(string prefix) {
            _prefix = prefix;
        }
        public void Apply(OpenApiDocument document, DocumentFilterContext context)
        {
            var paths = document.Paths.Keys.ToList();
            foreach (var path in paths)
            {
                var pathToChange = document.Paths[path];
                document.Paths.Remove(path);
                if(pathToChange != null) document.Paths.Add("/" + _prefix + path, pathToChange);
            }
        }
    }
}
