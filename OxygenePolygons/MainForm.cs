using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace OxygenePolygons
{
    public partial class MainForm : Form
    {
        private int _currentFrame = 0;
        private readonly List<Frame> _frames;
        private readonly Color[] _palette;
        private readonly Font _font;
        private readonly Brush _brush;

        public MainForm()
        {
            InitializeComponent();

            _frames = DataParser.Parse("scene1.bin");
            _font = new Font(FontFamily.GenericSerif, 12);
            _brush = Brushes.WhiteSmoke;
            UpdateFrameNumber();
            _palette = new Color[16];
        }

        private void UpdateFrameNumber()
        {
            labelFrameNumber.Text = $"Frame {_currentFrame}";
        }
    
        public void DrawFrame()
        {
            var backBuffer = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format32bppRgb);
            var backGroundGraphics = Graphics.FromImage(backBuffer);
            var sizeXDelta = pictureBox1.Width / 256;
            var sizeYDelta = pictureBox1.Height / 200;
            var frame = _frames[_currentFrame];

            if (frame.ContainsPalette)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (frame.Palette[i] != null)
                    {
                        _palette[i] = frame.Palette[i].Value;
                    }                 
                }
            }

            if (frame.ClearScreen)
            {
                backGroundGraphics.Clear(_palette[0]);
            }

            if (frame.IndexedMode)
            {
                foreach(var polygon in frame.Polygons)
                {
                    var points = new Point[polygon.NumberOfVertexs];

                    for (int i= 0; i < polygon.NumberOfVertexs; i++)
                    {
                        var tempPoint = frame.Vertexs[polygon.VertexIds[i]];
                        tempPoint.X *= sizeXDelta;
                        tempPoint.Y *= sizeYDelta;
                        points[i] = tempPoint;
                    }

                    backGroundGraphics.FillPolygon(new SolidBrush(_palette[polygon.ColourIndex]), points);
                }
            }
            else
            {
                foreach (var polygon in frame.Polygons)
                {
                    var points = new Point[polygon.NumberOfVertexs];

                    for (int i = 0; i < polygon.NumberOfVertexs; i++)
                    {
                        var tempPoint = polygon.Vertexs[i];
                        tempPoint.X *= sizeXDelta;
                        tempPoint.Y *= sizeYDelta;
                        points[i] = tempPoint;
                    }

                    backGroundGraphics.FillPolygon(new SolidBrush(_palette[polygon.ColourIndex]), points);
                }
            }

            //graphics.DrawString($"Frame {_currentFrame}", _font, _brush, new Point(0,0));
            UpdateFrameNumber();

            backGroundGraphics.Dispose();

            var graphics = pictureBox1.CreateGraphics();
            graphics.DrawImageUnscaled(backBuffer, new Point(0, 0));
            graphics.Dispose();

        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            DrawFrame();

            if (_currentFrame + 1 >= _frames.Count)
            {
                _currentFrame = 0;
            }
            else
            {
                _currentFrame++;
            }

        }

        private void ButPlay_Click(object sender, System.EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Enabled = false;
                butPlay.Text = ">";
            }
            else
            {
                timer.Enabled = true;
                butPlay.Text = "||";
            }           
        }

        private void ButStepBack_Click(object sender, System.EventArgs e)
        {
            if (_currentFrame> 0)
            {
                _currentFrame--;
                DrawFrame();
            }
        }

        private void ButStepForward_Click(object sender, System.EventArgs e)
        {
            if (_currentFrame < _frames.Count)
            {
                _currentFrame++;
                DrawFrame();
            }
        }
    }
}
