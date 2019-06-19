using System.Windows.Forms;

namespace OxygenePolygons
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var frames = DataParser.Parse("scene1.bin");
        }
    }
}
