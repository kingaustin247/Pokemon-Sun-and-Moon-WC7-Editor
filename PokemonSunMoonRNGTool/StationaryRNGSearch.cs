using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSunMoonRNGTool
{
    class StationaryRNGSearch
    {
        // Search Settings
        public int TSV;
        public bool AlwaysSynchro;
        public int Synchro_Stat;
        public int Valid_Blink;
        public bool Blink_Only;
        public int UB_Value;
        public bool UB_Checked;

        public class StationaryRNGResult
        {
            public readonly int[] BaseIV = new int[3];
            public uint[] InheritStats = new uint[3];
            public int Nature;
            public int Clock;
            public uint PID, EC, PSV;
            public UInt64 row_r;
            public int[] IVs;
            public int[] p_Status;
            public bool Shiny;
            public bool Synchronize;
            public bool Blink_Check;
            public string UB;
        }

        public StationaryRNGResult Generate()
        {
            StationaryRNGResult st = new StationaryRNGResult();
            index = 0;

            //まばたき判定 -- Blink Check
            if (Blink_Only)
            {
                if ((int)(getRand() & 0x7F) == 0)
                {
                    st.Blink_Check = true;
                }
                index = 2;
            }

            //UB
            if (UB_Checked)
            {
                if (UB_Value < 0)
                    st.UB = ((int)(getRand() % 100)).ToString();
                else
                    st.UB = (int)(getRand() % 100) < UB_Value ? "o" : "-";
            }

            //シンクロ -- Synchronize
            st.row_r = getRand();

            if (st.row_r % 100 >= 50)
                st.Synchronize = true;

            if (AlwaysSynchro)
                st.Synchronize = true;

            st.Clock = (int)(st.row_r % 17);

            //まばたき消費契機 -- maybe blinking process occurs 2 times for each character
            Advance(Valid_Blink);

            //謎の消費 -- Something
            Advance(60);

            //暗号化定数 -- Encryption Constant
            st.EC = (uint)(getRand() & 0xFFFFFFFF);

            //性格値 -- PID
            st.PID = (uint)(getRand() & 0xFFFFFFFF);
            st.PSV = ((st.PID >> 16) ^ (st.PID & 0xFFFF)) >> 4;

            if (st.PSV == TSV)
                st.Shiny = true;

            //V箇所 -- IV-31 Inheritance
            for (int i = 0; i < 3; i++)
            {
            repeat:
                st.InheritStats[i] = (uint)(getRand() % 6);

                // Scan for duplicate IV
                for (int k = 0; k < i; k++)
                    if (st.InheritStats[k] == st.InheritStats[i])
                        goto repeat;
            }

            //基礎個体値 -- Base IVs
            for (int j = 0; j < 3; j++)
                st.BaseIV[j] = (int)(getRand() & 0x1F);

            //個体値処理
            int[] IV = new int[6] { 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 3; i++)
                IV[st.InheritStats[i]] = 31;

            for (int i = 0, k = 0; i < 6; i++)
            {
                if (IV[i] != 31)
                {
                    IV[i] = st.BaseIV[k];
                    k++;
                    if (k == 3) break;
                }
            }
            st.IVs = (int[])IV.Clone();

            //謎消費 -- Something
            if (AlwaysSynchro)
                getRand();

            //性格 -- Nature
            st.Nature = (int)(getRand() % 25);
            if (Synchro_Stat >= 0 && st.Synchronize)
            {
                st.Nature = Synchro_Stat;
            }

            return st;
        }

        public static List<ulong> RandList;
        private int index;
        private ulong getRand()
        {
            return RandList[index++];
        }
        private void Advance(int d)
        {
            index += d;
        }
    }
}
