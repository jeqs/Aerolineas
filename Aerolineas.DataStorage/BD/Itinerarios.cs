//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aerolineas.DataStorage.BD
{
    using System;
    
    public partial class Itinerarios
    {
        public int Id { get; set; }
        public Nullable<int> IdAvion { get; set; }
        public string Nomre { get; set; }
        public Nullable<int> IdCiudad { get; set; }
        public string Nombre { get; set; }
        public Nullable<decimal> HorasVuelo { get; set; }
    }
}
