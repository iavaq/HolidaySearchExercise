using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HolidaySearch.Models
{
    public enum Airports
    {
        //decorators for future UI

        [Display(Name="Any Airport")]
        AnyAirport,

        [Display(Name = "Any London Airport")]
        AnyLondonAirport,

        [Display(Name = "Manchester Airport (MAN)")]
        MAN,

        [Display(Name = "Malaga Airport (AGP)")]
        AGP,

        [Display(Name = "Mallorca Airport (PMI)")]
        PMI,

        [Display(Name = "Gran Canaria Airport (LPA)")]
        LPA,

        [Display(Name = "Tenerife South Airport (TFS)")]
        TFS,

        [Display(Name = "London Luton Airport (LTN)")]
        LTN,

        [Display(Name = "London Gatwick Airport (LGW)")]
        LGW,
    }
}
