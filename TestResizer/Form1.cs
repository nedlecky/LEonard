namespace TestResizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FontFamily fontFamily;
        Font bigButtonFont;
        Font smallButtonFont;
        private void Form1_Load(object sender, EventArgs e)
        {
            fontFamily = new FontFamily("Arial");
            bigButtonFont = new Font(
               fontFamily,
               24,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
            smallButtonFont = new Font(
               fontFamily,
               12,
               FontStyle.Regular,
               GraphicsUnit.Pixel);

        }

        bool fBig = false;

        private void button1_Click(object sender, EventArgs e)
        {
            fBig = !fBig;

            if (fBig)
            {
                button4.Width = 200;
                tableLayoutPanel3.Width = 400;
                tableLayoutPanel3.Font = bigButtonFont;
            }
            else
            {
                button4.Width = 100;
                tableLayoutPanel3.Width = 300;
                tableLayoutPanel3.Font = smallButtonFont;
            }

        }
    }
}