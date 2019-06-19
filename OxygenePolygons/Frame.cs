using System.Collections.Generic;

namespace OxygenePolygons
{
    public class Frame
    {
        public Frame()
        {
            Palette = new System.Drawing.Color[16];
            Polygons = new List<Polygon>();
        }

        public bool ClearScreen { get; set; }

        public bool ContainsPalette { get; set; }

        public bool IndexedMode { get; set; }

        public System.Drawing.Color[] Palette { get; set; }

        public System.Drawing.Point[] Vertexs;

        public List<Polygon> Polygons { get; set; }
    }
}
