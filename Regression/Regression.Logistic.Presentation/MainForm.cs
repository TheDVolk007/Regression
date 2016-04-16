using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Presentation.Draw;
using Regression.Domain;

namespace Regression.Logistic.Presentation
{
    public partial class MainForm : Form
    {
        private readonly Drawer drawer;
        private List<List<double>> data;

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
            var initialData = dataInitializer.Initialize();

            var mapper = new DataMapper();
            data = mapper.Map(initialData);
            var dataNormalizer = new GaussianNormalization();
            dataNormalizer.NormalizeData(data);

            foreach (var entry in data)
            {
                drawer.DrawPoint(entry[0] * 300, entry.Last() * 300, drawer.GetRandomColor(), 8);
            }
        }

        private void performButton_Click(object sender, EventArgs e)
        {

        }
    }
}
