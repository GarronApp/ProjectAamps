using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aamps.Domain.Converters
{
    public static class UnitSaleStatusConverter
    {
        public static int UnitStatusConverter(Aamps.Domain.ValueObjects.UnitStatusType.GetUnitStatusType status)
        {
            return (int)status;
        }

        public static int SaleActiveStatusConverter(Aamps.Domain.ValueObjects.SaleActiveStatusType.GetSaleActiveStatusType status)
        {
            return (int)status;
        }

        public static int SaleStatusConverter(Aamps.Domain.ValueObjects.SaleActiveStatusType.GetSaleStatusType status)
        {
            return (int)status;
        }
    }
}
