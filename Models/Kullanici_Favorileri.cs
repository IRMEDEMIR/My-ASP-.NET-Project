//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Film.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kullanici_Favorileri
    {
        public int favori_id { get; set; }
        public Nullable<int> kullanici_id { get; set; }
        public Nullable<int> film_id { get; set; }
    
        public virtual Filmler Filmler { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}