//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INNIM_1._2.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class programmisti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public programmisti()
        {
            this.zakazi_programista = new HashSet<zakazi_programista>();
        }
    
        public int id_programmista { get; set; }
        public string name_programmista { get; set; }
        public string xp_work { get; set; }
        public string specialist { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zakazi_programista> zakazi_programista { get; set; }
    }
}
