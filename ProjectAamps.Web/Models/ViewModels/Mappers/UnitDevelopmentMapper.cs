using AAMPS.Clients.AampService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels.Mappers
{
    public class UnitDevelopmentMapper
    {
        public UnitDevelopmentMapper(List<Unit> units)
        {
            Units = units;
            Map(Units);
        }
        
        public List<Unit> Units { get; set; }
        public List<DevelopmentViewModel> Map(List<Unit> units)
        {
            if (units != null)
            {
                List<DevelopmentViewModel> list = new List<DevelopmentViewModel>();

                foreach (var item in units)
                {
                    DevelopmentViewModel viewModel = new DevelopmentViewModel()
                    {
                        UnitNumber = item.UnitNumber,
                        UnitSize = item.UnitSize,
                        UnitPriceIncluding = item.UnitPriceIncluding,
                        UnitActiveDate = item.UnitActiveDate,

                    };

                    list.Add(viewModel);


                }

                return list;
            }

            return null;

        }

    }


}