//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DateBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Party
    {
        public int id_party { get; set; }
        public int id_type { get; set; }
        public int id_sites { get; set; }
        public int id_employment { get; set; }
        public System.DateTime date { get; set; }
        public int id_client { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Employment Employment { get; set; }
        public virtual Sites Sites { get; set; }
        public virtual Type_party Type_party { get; set; }
    }
}