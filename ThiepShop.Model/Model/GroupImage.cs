using ThiepShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblGroupImage")]
    public class GroupImage : Auditable
    {
        public virtual IEnumerable<Images> Images { set; get; }
    }
}