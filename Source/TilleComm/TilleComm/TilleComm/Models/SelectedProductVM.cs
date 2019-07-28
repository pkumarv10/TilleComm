using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TilleCommModels;

namespace TilleComm.Models
{
    public class SelectedProductVM
    {
        public SelectedOrder MyProduct { get; set; }

        public static implicit operator SelectedProductVM(SelectedOrder v)
        {
            throw new NotImplementedException();
        }
    }
}