using System.Drawing;

namespace Presentation.Draw
{
    public interface IDrawer
    {
        void DrawPoint(double x, double y, int size = 4);

        void DrawPoint(double x, double y, Color color, int size = 4);

        void InitializeCoordinatePlane();
    }
}