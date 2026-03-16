using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf.Graphics;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.Shapes;

// Define output directory and image dimensions
string outputDir = @"c:\temp\";
int deviceWidth = 600;
int deviceHeight = 400;

// Convert pixel dimensions to millimeters (1 mm ≈ 100 pixels at 96 DPI)
int deviceWidthMm = (int)(deviceWidth / 100f);
int deviceHeightMm = (int)(deviceHeight / 100f);

// Create the EMF recording canvas
Rectangle frame = new Rectangle(0, 0, deviceWidth, deviceHeight);
EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
    frame,
    new Size(deviceWidth, deviceHeight),
    new Size(deviceWidthMm, deviceHeightMm));

// Build a vector path (a closed triangle)
Figure triangleFigure = new Figure { IsClosed = true };
GraphicsPath trianglePath = new GraphicsPath();
trianglePath.AddFigure(triangleFigure);
triangleFigure.AddShapes(new Shape[]
{
    new PolygonShape(new PointF[]
    {
        new PointF(100, 300),   // Bottom‑left
        new PointF(300, 50),    // Top‑center
        new PointF(500, 300)    // Bottom‑right
    })
});

// Draw the path using a 5‑pixel orange pen
Pen orangePen = new Pen(Color.Orange, 5);
graphics.DrawPath(orangePen, trianglePath);

// End recording and obtain the EMF image
using (EmfImage emfImage = graphics.EndRecording())
{
    // Save the vector image; the drawing remains fully vectorial
    emfImage.Save(outputDir + "vectorPath.emf");
}