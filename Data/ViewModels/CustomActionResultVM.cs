using DotNet_Core_webApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet_Core_webApi.Data.ViewModels
{
    public class CustomActionResultVM
    {

        public Exception Exception { get; set; }
        public Publisher Publisher { get; set; }
    }
}
