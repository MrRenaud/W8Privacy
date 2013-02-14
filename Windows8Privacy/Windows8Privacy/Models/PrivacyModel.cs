using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Windows8Privacy.Models
{
    public class PrivacyModel
    {
        public string Dev { get; set; }
        public string App { get; set; }

        public object Mail { get; set; }

        public Controllers.Language Lng { get; set; }
    }
}