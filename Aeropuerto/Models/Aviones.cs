using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Aeropuerto.models
{
    public partial class Aviones
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Tamano { get; set; }
        public int IdLinea { get; set; }

        public virtual LineaAerea IdLineaNavigation { get; set; }
    }
}
