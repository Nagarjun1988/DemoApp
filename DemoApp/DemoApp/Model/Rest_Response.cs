using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Model
{
    public class Rest_Response
    {
        public string content_type { get; set; }
        public long content_length { get; set; }
        public int status_code { get; set; }
        public string response_body { get; set; }
        public string ErrorMessage { get; set; }
    }
}
