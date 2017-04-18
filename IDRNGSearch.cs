using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSunMoonRNGTool
{
    class IDRNGSearch
    {
        // Search Settings
        public int Clock_CorrectionValue;

        public class IDRNGResult
        {
            public int Clock;
            public uint TID, SID, ID, TSV;
            public UInt64 row_r;
            public bool Shiny;
        }

        public IDRNGResult Generate(SFMT sfmt)
        {
            IDRNGResult id = new IDRNGResult();

            //乱数 -- Rand
            id.row_r = sfmt.NextUInt64();

            id.Clock = (int)(id.row_r % 17) + Clock_CorrectionValue;
            if (id.Clock > 16)
                id.Clock -= 17;

            uint temp = (uint)(id.row_r & 0xFFFFFFFF);
            id.ID = temp % 1000000;
            
            id.TID = temp & 0xFFFF;
            id.SID = temp >> 16;

            id.TSV = (id.TID ^ id.SID) >> 4;

            return id;
        }
    }
}
