using System.Drawing;

namespace OxygenePolygons
{
    public class Polygon
    {
        public int NumberOfVertexs { get; set; }
        public int ColourIndex { get; set;  }

        public byte[] VertexIds;

        public Point[] Vertexs;
    }
}
