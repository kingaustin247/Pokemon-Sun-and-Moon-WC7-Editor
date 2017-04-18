using System;
using System.Windows.Forms;

namespace PokemonSunMoonRNGTool
{
    public partial class ParentsEntry : Form
    {
        public Form1 form1;
        public string[] parents;
        int[] IV = new int[6];

        public ParentsEntry(string[] parents_list)
        {
            InitializeComponent();
            parents = parents_list;
            for (int i = 0; i < parents_list.Length; i++)
                LB_Parents.Items.Add(parents_list[i]);
        }

        private void SetPre_Click(object sender, EventArgs e)
        {
            try
            {
                string[] Data = parents[LB_Parents.SelectedIndex].Split(',');
                for (int i = 1; i < Data.Length; i++)
                    IV[i - 1] = Convert.ToInt32(Data[i]);

                form1.pre_parent1.Value = IV[0];
                form1.pre_parent2.Value = IV[1];
                form1.pre_parent3.Value = IV[2];
                form1.pre_parent4.Value = IV[3];
                form1.pre_parent5.Value = IV[4];
                form1.pre_parent6.Value = IV[5];
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void SetPost_Click(object sender, EventArgs e)
        {
            try
            {
                string[] Data = parents[LB_Parents.SelectedIndex].Split(',');
                for (int i = 1; i < Data.Length; i++)
                    IV[i - 1] = Convert.ToInt32(Data[i]);

                form1.post_parent1.Value = IV[0];
                form1.post_parent2.Value = IV[1];
                form1.post_parent3.Value = IV[2];
                form1.post_parent4.Value = IV[3];
                form1.post_parent5.Value = IV[4];
                form1.post_parent6.Value = IV[5];
            }
            catch (IndexOutOfRangeException)
            {

            }
        }
    }
}
