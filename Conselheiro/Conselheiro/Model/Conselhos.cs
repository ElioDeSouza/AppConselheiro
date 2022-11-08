using System;
using System.Collections.Generic;
using System.Text;

namespace Conselheiro.Model
{
    internal class Conselhos
    {
        public string Slip_ID { get; set; }
        public string Conselho { get; set; }

        public Conselhos()
        {
            this.Slip_ID = " ";
            this.Conselho = " ";
        }
    }
}
