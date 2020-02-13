using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Api.App.modules.PayuControllers
{
    public class RemotePostvm
    {
        public string FormName { get; internal set; }
        public string Method { get; internal set; }
        public string Url { get; internal set; }
        public List<DataViewObj> valpair { get; internal set; }
    }
}