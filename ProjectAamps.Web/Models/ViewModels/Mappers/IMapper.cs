using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AAMPS.Web.Models.ViewModels.Mappers
{
    abstract public class IMapper
    {
       abstract public void OnLoad();
    }
}