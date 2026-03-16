using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        // Define output directory and ensure it exists
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        Directory.CreateDirectory(outputDir);

        // Define EMF canvas size in pixels
        int deviceWidth = 800;
        int deviceHeight = 600;

        // Convert size to millimeters (1 pixel ≈ 0.01 mm)
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Create the frame rectangle for the EMF image
        Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);

        // Initialize the EMF recorder graphics (do NOT wrap in using)
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Size(deviceWidth, deviceHeight),
            new Size(deviceWidthMm, deviceHeightMm));

        // Draw a black border around the canvas
        graphics.DrawRectangle(new Pen(Color.Black, 1), 0, 0, deviceWidth, deviceHeight);

        // Fill the background with a light color
        graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), new Rectangle(10, 10, deviceWidth - 20, deviceHeight - 20));

        // Draw two diagonal lines
        graphics.DrawLine(new Pen(Color.DarkGreen, 1), 0, 0, deviceWidth, deviceHeight);
        graphics.DrawLine(new Pen(Color.DarkGreen, 1), 0, deviceHeight, deviceWidth, 0);

        // Draw an arc and fill a pie slice
        graphics.DrawArc(new Pen(Color.Blue, 2), new Rectangle(0, 0, 200, 200), 90, 270);
        graphics.FillPie(new SolidBrush(Color.LightSkyBlue), new Rectangle(0, 0, 150, 150), 90, 270);

        // Draw a cubic Bezier curve
        graphics.DrawCubicBezier(
            new Pen(Color.Red, 2),
            new Point(0, 0),
            new Point(200, 133),
            new Point(400, 166),
            new Point(600, 400));

        // Draw an external raster image onto the EMF canvas
        string sampleImagePath = Path.Combine(outputDir, "sample.bmp");
        // Ensure a sample bitmap exists; for demonstration we create a blank one if missing
        if (!File.Exists(sampleImagePath))
        {
            using (RasterImage placeholder = (RasterImage)Image.Create(new BmpOptions(), 100, 100))
            {
                placeholder.Save(sampleImagePath);
            }
        }

        using (RasterImage imageToDraw = (RasterImage)Image.Load(sampleImagePath))
        {
            graphics.DrawImage(
                imageToDraw,
                new Rectangle(400, 200, 100, 50),               // Destination rectangle
                new Rectangle(0, 0, deviceWidth, deviceHeight), // Source rectangle (full image)
                GraphicsUnit.Pixel);
        }

        // Draw a text string
        graphics.DrawString(
            "Hello Aspose.Imaging!",
            new Font("Arial", 36, FontStyle.Regular),
            Color.DarkRed,
            200,
            300);

        // Create a filled custom path (a simple triangle)
        Figure fillFigure = new Figure { IsClosed = true };
        GraphicsPath fillPath = new GraphicsPath();
        fillPath.AddFigure(fillFigure);
        fillFigure.AddShapes(new Shape[]
        {
            new PolygonShape(new PointF[]
            {
                new PointF(300, 400),
                new PointF(350, 350),
                new PointF(250, 350)
            })
        });
        graphics.FillPath(
            new Pen(Color.Green, 2),
            new SolidBrush(Color.Yellow),
            fillPath);

        // Create a stroked custom path (a circle)
        Figure drawFigure = new Figure { IsClosed = true };
        GraphicsPath drawPath = new GraphicsPath();
        drawPath.AddFigure(drawFigure);
        drawFigure.AddShapes(new Shape[]
        {
            new EllipseShape(new RectangleF(500, 100, 100, 100))
        });
        graphics.DrawPath(new Pen(Color.Orange, 5), drawPath);

        // Finalize recording and obtain the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            string outputPath = Path.Combine(outputDir, "result.emf");
            emfImage.Save(outputPath);
        }
    }
}