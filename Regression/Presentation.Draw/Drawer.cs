using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presentation.Draw
{
    public class Drawer : IDrawer
    {
        private readonly PictureBox canvas;
        private readonly CoordinatePlane coordinateOptions;
        private Point center;

        public Drawer(PictureBox canvas, CoordinatePlane coordinateOptions = CoordinatePlane.WholePlane)
        {
            if(canvas == null)
            {
                throw new ArgumentNullException(nameof(canvas));
            }

            this.canvas = canvas;
            this.coordinateOptions = coordinateOptions;
        }

        public void InitializeCoordinatePlane()
        {
            const int padding = 10;
            int x0;
            int y0;
            switch(coordinateOptions)
            {
                case CoordinatePlane.FirstQuaterOnly:
                    x0 = padding;
                    y0 = canvas.Height - padding;
                    break;
                case CoordinatePlane.FirstAndSecondQuaterOnly:
                    x0 = canvas.Width / 2;
                    y0 = canvas.Height - padding;
                    break;
                case CoordinatePlane.FirstAndFourthQuaterOnly:
                    x0 = padding;
                    y0 = canvas.Height / 2;
                    break;
                default:
                    x0 = canvas.Width / 2;
                    y0 = canvas.Height / 2;
                    break;
            }
            using(var graphic = canvas.CreateGraphics())
            {
                graphic.DrawLine(Pens.Black, new Point(x0, 0), new Point(x0, canvas.Height));
                graphic.DrawLine(Pens.Black, new Point(0, y0), new Point(canvas.Width, y0));
            }

            center = new Point(x0, y0);
        }

        public void DrawPoint(double x, double y, int size = 4)
        {
            DrawPoint(x, y, Color.Black, size);
        }

        public void DrawPoint(double x, double y, Color color, int size = 4)
        {
            using(var graphic = canvas.CreateGraphics())
            {
                var pt = new Point((int)x + center.X, -(int)y + center.Y);
                using(Brush b = new SolidBrush(color))
                {
                    graphic.FillEllipse(b, pt.X - size / 2, pt.Y - size / 2, size, size);
                }
            }
        }

        public void DrawLine(double p1x, double p1y, double p2x, double p2y)
        {
            using(var graphic = canvas.CreateGraphics())
            {
                var p1 = new Point((int)p1x + center.X, -(int)p1y + center.Y);
                var p2 = new Point((int)p2x * 100 + center.X, -(int)p2y * 100 + center.Y);
                graphic.DrawLine(Pens.Black, p1, p2);
            }
        }

        public void WipeLine(Point p1, Point p2)
        {
            using (var graphic = canvas.CreateGraphics())
            {
                graphic.DrawLine(Pens.White, p1, p2);
            }
        }
    }
}