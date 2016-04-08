using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Presentation.Draw;
using Regression.Domain;


namespace Regression.Presentation
{
    public partial class MainForm : Form
    {
        private readonly IDrawer drawer;
        private List<ExternalEntityWithResult> data;
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
                drawer.DrawPoint(entity.Data["size"], entity.Result["price"] / 1000);
                //drawer.DrawPoint(entity.Data["size"] * 930, entity.Data["price"] * 930);
            }
        }

        private void performButton_Click(object sender, EventArgs e)
        {
            var linReg = new LinearRegression(1);
            var mapper = new ExternalEntityWithResultToRegressionEntityWithResultMapper();

            var mappedEntities = mapper.Map(data);
            linReg.Train(mappedEntities);

            var x1 = 0d;
            var y1 = linReg.ComputeHypothesis(new RegressionEntity
            {
                Arguments = new List<double>(new[] {x1})
            });

            var x2 = 250d;
            var y2 = linReg.ComputeHypothesis(new RegressionEntity
            {
                Arguments = new List<double>(new[] { x2 })
            });

            drawer.DrawLine(x1, y1, x2, y2);
        }
    }
}
