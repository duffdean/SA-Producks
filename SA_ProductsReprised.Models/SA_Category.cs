﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SA_ProductsReprised.Models
{
    public class SA_Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SA_Category()
        {
            //SA_Product = new HashSet<SA_Product>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Active { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SA_Product> SA_Product { get; set; }
    }
}
