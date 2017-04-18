using System;

namespace PokemonSunMoonRNGTool
{

    class StationarySearchSetting
    {
        #region pokedex
        public static string[,] pokedex =
        {
            { "カプ・コケコ", "70", "115", "85", "95", "75", "130"},
            { "カプ・テテフ", "70", "85", "75", "130", "115", "95"},
            { "カプ・ブルル", "70", "130", "115", "85", "95", "75"},
            { "カプ・レヒレ", "70", "75", "115", "95", "130", "85"},
            { "ソルガレオ", "137", "137", "107", "113", "89", "97"},
            { "ルナアーラ", "137", "113", "89", "137", "107", "97"},
            { "タイプ：ヌル", "95", "95", "95", "95", "95", "59"},
            { "マギアナ", "80", "95", "115", "130", "115", "65"},
            { "ジガルデ-10%", "54", "100", "71", "61", "85", "115"},
            { "ジガルデ-50%", "108", "100", "121", "81", "95", "95"},
        };

        #endregion
        #region calc_data
        public double[,] natures_mag =
        {
            { 1, 1, 1, 1, 1, 1 },
            { 1, 1.1, 0.9, 1, 1, 1 },
            { 1, 1.1, 1, 1, 1, 0.9 },
            { 1, 1.1, 1, 0.9, 1, 1 },
            { 1, 1.1, 1, 1, 0.9, 1 },
            { 1, 0.9, 1.1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1.1, 1, 1, 0.9 },
            { 1, 1, 1.1, 0.9, 1, 1 },
            { 1, 1, 1.1, 1, 0.9, 1 },
            { 1, 0.9, 1,1, 1, 1.1 },
            { 1, 1, 0.9, 1,1, 1.1 },
            { 1, 1,1, 1, 1, 1 },
            { 1, 1,1, 0.9, 1, 1.1 },
            { 1, 1,1, 1, 0.9, 1.1 },
            { 1, 0.9, 1, 1.1, 1,1 },
            { 1, 1, 0.9, 1.1, 1, 1 },
            { 1, 1, 1, 1.1, 1, 0.9 },
            { 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1.1, 0.9, 1 },
            { 1, 0.9, 1,1, 1.1, 1 },
            { 1, 1, 0.9, 1, 1.1, 1},
            { 1, 1, 1, 1, 1.1, 0.9 },
            { 1, 1, 1, 0.9, 1.1, 1 },
            { 1, 1, 1, 1, 1, 1}
        };
        #endregion

        public int Nature = -1;
        public int HPType = -1;
        public int[] IVup, IVlow, Status, p_Status;
        public bool Skip;
        public int Lv, Pokemon;

        public bool validIVs(int[] IV)
        {
            for (int i = 0; i < 6; i++)
                if (IVlow[i] > IV[i] || IV[i] > IVup[i])
                    return false;

            return true;
        }

        public bool validStatus(StationaryRNGSearch.StationaryRNGResult result, StationarySearchSetting setting)
        {
            int[] status = new int[6];

            for (int i = 0; i < 6; i++)
                status[i] = setting.Status[i];

            if (status[0] != p_Status[0]) return false;
            for (int i = 1; i < 6; i++)
                if (status[i] != p_Status[i]) return false;

            return true;
        }

        public void getStatus(StationaryRNGSearch.StationaryRNGResult result, StationarySearchSetting setting)
        {
            setting.p_Status = new int[6];
            int[] BS = new int[6];
            int[] IV = new int[6];

            for (int i = 0; i < 6; i++)
            {
                IV[i] = result.IVs[i];
                BS[i] = Convert.ToInt32(pokedex[setting.Pokemon, i + 1]);
            }

            p_Status[0] = (int)(((BS[0] * 2 + IV[0]) * Lv) / 100) + Lv + 10;
            for (int i = 1; i < 6; i++)
                p_Status[i] = (int)(((int)(((BS[i] * 2 + IV[i]) * Lv) / 100) + 5) * natures_mag[result.Nature, i]);

            result.p_Status = setting.p_Status;

            return;
        }


        public bool mezapa_check(int[] IV)
        {
            if (HPType == -1)
                return true;
            var val = 15 * ((IV[0] & 1) + 2 * (IV[1] & 1) + 4 * (IV[2] & 1) + 8 * (IV[5] & 1) + 16 * (IV[3] & 1) + 32 * (IV[4] & 1)) / 63;
            return val == HPType;
        }
    }
}
