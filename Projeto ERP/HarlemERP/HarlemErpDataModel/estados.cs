//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HarlemErpDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class estados
    {
        public estados()
        {
            this.municipios = new HashSet<municipios>();
        }
    
        public int id { get; set; }
        public string sigla { get; set; }
        public string nome { get; set; }
    
        public virtual ICollection<municipios> municipios { get; set; }
    }
}
