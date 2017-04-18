using System.Linq;
using System.Windows.Forms;

namespace PokemonSunMoonRNGTool
{
    public partial class TSVEntry : Form
    {
        public int[] other_tsv;
        public TSVEntry(int[] tsvs)
        {
            other_tsv = tsvs;
            InitializeComponent();
            RTB_TSV.Lines = other_tsv.Select(tsv => tsv.ToString()).ToArray();
        }

        private void B_Save_Click(object sender, System.EventArgs e)
        {
            other_tsv = getTSV();
            Close();
        }
        private int[] getTSV()
        {
            string[] lines = RTB_TSV.Lines;
            int[] tsvs = new int[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                int val;
                if (!int.TryParse(lines[i], out val))
                    return other_tsv;

                if (0 > val || val > 4095)
                    return other_tsv;

                tsvs[i] = val;
            }
            return tsvs;
        }
    }
}
