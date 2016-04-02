using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Presentation.Draw;
using Regression.Domain;


namespace Regression.Presentation
{
    public partial class MainForm : Form
    {
        private readonly IDrawer drawer;
        private List<ExternalEntity> data;

        public MainForm()
        {
            InitializeComponent();

            drawer = new Drawer(canvas);
        }

        private void initilizationButton_Click(object sender, EventArgs e)
        {
            drawer.InitializeCoordinatePlane();
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            var dataInitializer = new DataInitializer();
            data = dataInitializer.Initialize();
            new DataNormalizer().PerformFeatureScaling(data);

            foreach(var entity in data)
            {
                drawer.DrawPoint(entity.Data["size"]*1000, entity.Data["price"]*1000);
            }
        }
    }
}
