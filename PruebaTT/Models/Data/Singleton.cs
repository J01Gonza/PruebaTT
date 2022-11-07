using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaTT.Models.Data
{
    public class Singleton
    {
        public readonly static Singleton Instance = new Singleton();
        public List<Factura> facturaList;

        private Singleton()
        {
            facturaList = new List<Factura>();
        }

        public static Singleton instance
        {
            get { return Instance; }
        }
    }
}