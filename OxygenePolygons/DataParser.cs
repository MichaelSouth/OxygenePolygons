using System.Collections.Generic;
using System.Drawing;

namespace OxygenePolygons
{
    public class DataParser
    {
        public static List<Frame> Parse(string fileName)
        {
            var frames = new List<Frame>();
            var bytes = System.IO.File.ReadAllBytes(fileName);
            long streamIndex = 0;
            var endOfStream = false;
            var endOfBlock = false;
            var index = 1;

            while (!endOfStream)
            {
                if (endOfBlock)
                {
                    var remainder = streamIndex / 65536;
                    var delta = ((remainder+1) * 65536)- streamIndex;
                    streamIndex += delta;
                    endOfBlock = false;
                }

                var controlByte = bytes[streamIndex++];
                var frame = new Frame(index++)
                {
                    ClearScreen = (controlByte & (1 << 0)) != 0,
                    ContainsPalette = (controlByte & (1 << 1)) != 0,
                    IndexedMode = (controlByte & (1 << 2)) != 0
                };

                if (frame.ContainsPalette)
                {
                    streamIndex = ParsePalette(bytes, streamIndex, frame);
                }

                if (frame.IndexedMode)
                {
                     var numberOfVertices = bytes[streamIndex++];
                    frame.Vertexs = new Point[numberOfVertices];

                    for (int i = 0; i < numberOfVertices; i++)
                    {
                        var xposition = bytes[streamIndex++];
                        var yPosition = bytes[streamIndex++];
                        frame.Vertexs[i] = new Point(xposition, yPosition);
                    }

                    while (1 == 1)
                    {
                        // 1 byte Poly-descriptor Contains: hi - nibble – 4 bits color-index lo - nibble – 4 bits number of polygon vertices
                        var polygon = new Polygon();
                        var polyDescriptor = bytes[streamIndex++];

                        //End of frame 
                        if (polyDescriptor == 255)
                        {
                            break;
                        }

                        //End of frame and skip to next block
                        if (polyDescriptor == 254)
                        {
                            endOfBlock = true;
                            break;
                        }

                        //End of stream;
                        if (polyDescriptor == 253)
                        {
                            endOfStream = true;
                            break;
                        }

                        polygon.ColourIndex = ((polyDescriptor & 0b11110000) >> 4);
                        polygon.NumberOfVertexs = polyDescriptor & 0b00001111;
                        polygon.VertexIds = new byte[polygon.NumberOfVertexs];

                        for (int i = 0; i < polygon.NumberOfVertexs; i++)
                        {
                            var vertexId = bytes[streamIndex++];
                            polygon.VertexIds[i] = vertexId;
                        }

                        frame.Polygons.Add(polygon);
                    }
                }
                else
                {
                    while (1 == 1)
                    {
                        // 1 byte Poly-descriptor Contains: hi - nibble – 4 bits color-index lo - nibble – 4 bits number of polygon vertices
                        var polygon = new Polygon();
                        var polyDescriptor = bytes[streamIndex++];

                        //End of frame 
                        if (polyDescriptor == 255)
                        {
                            break;
                        }

                        //End of frame and skip to next block
                        if (polyDescriptor == 254)
                        {
                            endOfBlock = true;
                            break;
                        }

                        //End of stream;
                        if (polyDescriptor == 253)
                        {
                            endOfStream = true;
                            break;
                        }

                        polygon.ColourIndex = ((polyDescriptor & 0b11110000) >> 4);
                        polygon.NumberOfVertexs = polyDescriptor & 0b00001111;
                        polygon.Vertexs = new Point[polygon.NumberOfVertexs];

                        for (int i = 0; i < polygon.NumberOfVertexs; i++)
                        {
                            var xposition = bytes[streamIndex++];
                            var yPosition = bytes[streamIndex++];
                            polygon.Vertexs[i] = new System.Drawing.Point(xposition, yPosition);
                        }

                        frame.Polygons.Add(polygon);
                    }
                }

                frames.Add(frame);
            }

            return frames;
        }

        private static long ParsePalette(byte[] bytes, long streamIndex, Frame frame)
        {
            //Read 1 word bitmask
            var bitmask1 = bytes[streamIndex++];
            var bitmask2 = bytes[streamIndex++];
            var wordBitMask = System.BitConverter.ToUInt16(new byte[2] { bitmask2, bitmask1 }, 0);

            for (int i = 15; i >= 0; i--)
            {
                if ((wordBitMask & (1 << i)) != 0)
                {
                    // Documentation says colors are stored as words in Atari-ST format 00000RRR0GGG0BBB (512 possible colors).
                    // But data looks like STE format 4 bits per colour so 0000RRRRGGGGBBBB (4096 possible colors).
                    var colour1 = bytes[streamIndex++]; //0000RRRR
                    var colour2 = bytes[streamIndex++]; //GGGGBBBB

                    var red = (colour1 << 4);
                    var green = (colour2 & 0b11110000);
                    var blue = ((colour2 & 0b00001111) << 4);

                    //Convert to colour
                    var colour = Color.FromArgb(red, green, blue);

                    //store palette entry in reverse order
                    frame.Palette[15-i] = colour;
                }
            }

            return streamIndex;
        }
    }
}
