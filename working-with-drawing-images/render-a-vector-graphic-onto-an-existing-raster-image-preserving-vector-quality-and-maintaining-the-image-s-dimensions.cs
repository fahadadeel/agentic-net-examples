using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.Brushes;

namespace VectorOnRaster
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the existing raster image
            string inputPath = "input.png";
            // Path for the output image
            string outputPath = "output.png";

            // Load the raster image
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Create a Graphics instance for vector drawing
                Graphics graphics = new Graphics(raster);

                // Draw a red rectangle
                Pen redPen = new Pen(Color.Red, 3);
                graphics.DrawRectangle(redPen, new Rectangle(50, 50, 200, 150));

                // Draw a blue ellipse
                Pen bluePen = new Pen(Color.Blue, 2);
                graphics.DrawEllipse(bluePen, new Rectangle(300, 100, 120, 80));

                // Draw a green diagonal line
                Pen greenPen = new Pen(Color.Green, 4);
                graphics.DrawLine(greenPen, new Point(0, 0), new Point(raster.Width, raster.Height));

                // Draw text using a font and solid brush
                Font font = new Font("Arial", 24);
                using (SolidBrush textBrush = new SolidBrush(Color.Black))
                {
                    graphics.DrawString("Vector overlay", font, textBrush, new PointF(100, 300));
                }

                // Save the modified image, preserving its original format
                raster.Save(outputPath);
            }
        }
    }
}