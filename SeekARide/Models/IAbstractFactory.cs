using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeekARide.Models
{
    interface IAbstractFactory
    {
        IMatchAdapter getMatchAdapter(DateTime departureTime, int type);
    }
}
