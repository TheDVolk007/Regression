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
        private DataNormalizer dataNormalizer;

        public MainForm()
        {
            InitializeComponent();

            drawer = new Drawer(canvas, CoordinatePlane.FirstQuaterOnly);
        }

        private void initilizationButton_Click(object sender, EventArgs e)
        {
            drawer.InitializeCoordinatePlane();
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            var dataInitializer = new DataInitializer();
            data = dataInitializer.Initialize();
            //dataNormalizer = new DataNormalizer();        //there is no need to use feature scaling in linear regression
            //dataNormalizer.PerformFeatureScaling(data);

            foreach (var entity in data)
            {
                drawer.DrawPoint(entity.Data["size"], entity.Data["price"] / 1000);
                //drawer.DrawPoint(entity.Data["size"] * 930, entity.Data["price"] * 930);
            }
        }
    }
}
