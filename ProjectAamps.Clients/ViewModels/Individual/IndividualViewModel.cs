using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAMPS.Clients.ViewModels.Individual
{
    public class IndividualViewModel
    {
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
    }
}
