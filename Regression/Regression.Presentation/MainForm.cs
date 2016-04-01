using System;
using System.Windows.Forms;
using Presentation.Draw;


namespace Regression.Presentation
{
    public partial class MainForm : Form
    {
        private IDrawer drawer;

        public MainForm()
        {
            InitializeComponent();

            drawer = new Drawer(canvas);
        }

        private void initilizationButton_Click(object sender, EventArgs e)
        {
            drawer.InitializeCoordinatePlane();

        }
    }
}
