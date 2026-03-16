using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main()
    {
        // Image dimensions in pixels
        int deviceWidth = 600;
        int deviceHeight = 400;

        // Approximate size in millimeters (1 pixel ≈ 0.01 mm)
        int deviceWidthMm = (int)(deviceWidth / 100f);
        int deviceHeightMm = (int)(deviceHeight / 100f);

        // Define the drawing frame
        Aspose.Imaging.Rectangle frame = new Aspose.Imaging.Rectangle(0, 0, deviceWidth, deviceHeight);

        // Create a recorder graphics object for EMF output
        EmfRecorderGraphics2D graphics = new EmfRecorderGraphics2D(
            frame,
            new Aspose.Imaging.Size(deviceWidth, deviceHeight),
            new Aspose.Imaging.Size(deviceWidthMm, deviceHeightMm));

        // Draw a cubic Bezier curve using a red pen of width 2
        graphics.DrawCubicBezier(
            new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2),
            new Aspose.Imaging.Point(0, 0),          // start point
            new Aspose.Imaging.Point(200, 133),      // first control point
            new Aspose.Imaging.Point(400, 166),      // second control point
            new Aspose.Imaging.Point(600, 400));     // end point

        // Finalize the recording and obtain the EMF image
        using (EmfImage emfImage = graphics.EndRecording())
        {
            // Save the EMF image to disk
            emfImage.Save("bezier.emf");
        }
    }
}