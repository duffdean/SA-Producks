using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Brand
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool Active { get; set; }
    }
}
