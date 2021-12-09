using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practih8
{
    interface ISeries
    {
        double Next { get; }
        double GetNext();
        void Reset();
        void SetStart(int startValue);
    }
}
