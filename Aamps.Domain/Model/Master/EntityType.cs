using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class EntityType
    {
        public EntityType()
        {
            this.Purchasers = new List<Purchaser>();
        }

        public int EntityTypeID { get; set; }
        public string EntityTypeDescription { get; set; }
        public virtual ICollection<Purchaser> Purchasers { get; set; }
    }
}
