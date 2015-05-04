using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Model.Master
{
    public partial class Individual
    {
        public Individual()
        {
            this.PurchaserIndividualLinks = new List<PurchaserIndividualLink>();
        }

        public int IndividualID { get; set; }
        public string IndividualName { get; set; }
        public string IndividualSurname { get; set; }
        public string IndividualIDNumber { get; set; }
        public string IndividualContactCell { get; set; }
        public string IndividualContactHome { get; set; }
        public string IndividualContactWork { get; set; }
        public string IndividualEmail { get; set; }
        public int PreferedContactMethodID { get; set; }
        public string IndividualCountryofOriginan { get; set; }
        public virtual PreferedContactMethod PreferedContactMethod { get; set; }
        public virtual ICollection<PurchaserIndividualLink> PurchaserIndividualLinks { get; set; }
    }
}
