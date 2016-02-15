using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebAuthForm
{
    public class JsonErrorResult : JsonResult
    {
        public JsonErrorResult(ModelStateDictionary modelStates)
        {
            _modelStates = modelStates;
        }

        private ModelStateDictionary _modelStates = null;

        private const string JSONREQUEST_GETNOTALLOWED = "This request has been blocked because this is used in a GET request.";

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(JSONREQUEST_GETNOTALLOWED);
            }

            HttpResponseBase response = context.HttpContext.Response;

            response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (!String.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            var errors = new Dictionary<string,string>();
            foreach (var keyValue in _modelStates)
            {
                errors[keyValue.Key] = keyValue.Value.Errors.Select(e => e.ErrorMessage).FirstOrDefault();
            }

            response.Write(new JavaScriptSerializer().Serialize(errors));
        }
    }
}