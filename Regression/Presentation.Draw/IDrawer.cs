using System.Drawing;

namespace Presentation.Draw
{
    public interface IDrawer
    {
        void DrawPoint(double x, double y, int size = 4);

        void DrawPoint(double x, double y, Color color, int size = 4);

        void DrawLine(double p1x, double p1y, double p2x, double p2y);

        void WipeLine(Point p1, Point p2);

        void InitializeCoordinatePlane();
    }
}