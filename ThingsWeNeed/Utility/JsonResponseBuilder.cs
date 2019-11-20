using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ThingsWeNeed.Utility
{

    public class JsonResponseBuilder
    {
        private bool sendErrors;
        private bool sendData;

        public bool Success { get; set; }
        public bool SendErrors { get; set; }
        public bool SendData { get; set; }
        public ICollection<Error> Errors { get; set; }
        public object Data { get; set; }

        public class Error { 
            public string ErrorMessage { get; set; }
            public string StackTrace { get; set; }
            public string Source { get; set; }
        }

        public JsonResponseBuilder()
        {
            Errors = new List<Error>();
            Success = true;
            SendErrors = false;
            SendData = false;
        }

        public object Build() {
            var result = new Dictionary<string, object>();
            result.Add("success", true);

            if (SendErrors) {
                result.Add("errors", Errors);
            }
            if (SendData) {
                result.Add("data", Data);
            }

            return result;
        }
    }
}