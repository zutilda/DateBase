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
    
    public partial class Photos
    {
        public int id_photo { get; set; }
        public string path_photo { get; set; }
        public byte[] binary_photo { get; set; }
        public Nullable<int> id_sites { get; set; }
        public Nullable<int> id_employee { get; set; }
    
        public virtual Employe Employe { get; set; }
        public virtual Sites Sites { get; set; }
    }
}