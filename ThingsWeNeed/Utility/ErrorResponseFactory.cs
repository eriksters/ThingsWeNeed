using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace ThingsWeNeed.Utility
{
    /// <summary>
    /// Utility class for formatting error responses
    /// </summary>
    public static class ErrorResponseFactory
    {
        public class Error {
            public string ErrorMessage { get; set; }
            public string InternalErrorMessage { get; set; }
        }

        public static IEnumerable<Error> BadRequest(ModelStateDictionary stateDic) {

            List<Error> errors = new List<Error>();

            foreach (ModelState state in stateDic.Values) {
                foreach (ModelError error in state.Errors) {
                    Error retError = new Error();

                    retError.ErrorMessage = error.ErrorMessage;
                    if (error.Exception != null) {
                        retError.InternalErrorMessage = error.Exception.Message;
                    }

                    errors.Add(retError);
                }
            }

            return errors;
        }
    }
}