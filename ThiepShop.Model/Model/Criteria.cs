using ThiepShop.Model.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThiepShop.Model.Model
{
    [Table("tblCriteria")]
    public class Criteria : Auditable
    {
        public int idCate { set; get; }
        public bool Priority { set; get; }
        public bool Style { set; get; }
        [Column(TypeName = "xml")]
        
        public virtual IEnumerable<ConnectCriteria> ConnectCriterias { set; get; }
    }
}