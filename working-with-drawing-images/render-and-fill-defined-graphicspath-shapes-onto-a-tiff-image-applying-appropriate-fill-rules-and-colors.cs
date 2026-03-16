using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        // Output file path and canvas dimensions
        string outputPath = "output.tif";
        int width = 800;
        int height = 600;

        // Configure TIFF options with a file create source
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);

        // Create the TIFF image canvas
        using (Image image = Image.Create(tiffOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Create a GraphicsPath with winding fill mode
            GraphicsPath path = new GraphicsPath(FillMode.Winding);

            // Rectangle figure
            Figure rectFigure = new Figure();
            rectFigure.AddShape(new RectangleShape(new RectangleF(100f, 100f, 300f, 200f)));

            // Ellipse figure
            Figure ellipseFigure = new Figure();
            ellipseFigure.AddShape(new EllipseShape(new RectangleF(250f, 250f, 300f, 200f)));

            // Add figures to the path
            path.AddFigure(rectFigure);
            path.AddFigure(ellipseFigure);

            // Fill the path with a semi‑transparent blue brush
            using (SolidBrush fillBrush = new SolidBrush(Color.FromArgb(128, Color.Blue)))
            {
                graphics.FillPath(fillBrush, path);
            }

            // Draw the outline with a red pen
            Pen outlinePen = new Pen(Color.Red, 3);
            graphics.DrawPath(outlinePen, path);

            // Save the image (output file is already bound)
            image.Save();
        }
    }
}