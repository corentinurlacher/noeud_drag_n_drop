using static BlazorDraggableDemo.Components.Connector;

namespace BlazorDraggableDemo.Components
{
    public class Noeud
    {
        public int IdNoeud;
        public Noeud? Parent;
        public double X = 50;
        public double Y = 50;
        public double R = 40;
        public Direction Dir;
        public double RootX;
        public double RootY;
        public string Link = @"/";
        public string Name = @"Noeud";

        public string Fill = "#333";
        public double ConnectY => Dir == Direction.Top ? Y - R : Y + R;

    }
}
