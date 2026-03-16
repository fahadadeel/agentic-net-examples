using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output JPEG file path
        string outputPath = "output.jpg";

        // Desired canvas size
        int canvasWidth = 800;
        int canvasHeight = 600;

        // Create a file source bound to the output path
        Source fileSource = new FileCreateSource(outputPath, false);

        // Configure JPEG options (high quality)
        JpegOptions jpegOptions = new JpegOptions
        {
            Source = fileSource,
            Quality = 100
        };

        // Create a JPEG canvas bound to the file source
        using (Aspose.Imaging.FileFormats.Jpeg.JpegImage canvas =
            (Aspose.Imaging.FileFormats.Jpeg.JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(canvas);

            // Clear background to white
            graphics.Clear(Color.White);

            // Prepare a black pen for drawing shapes
            Pen blackPen = new Pen(Color.Black, 2);

            // Draw a rectangle
            graphics.DrawRectangle(blackPen, new Rectangle(50, 50, 200, 150));

            // Draw an ellipse inside the rectangle
            graphics.DrawEllipse(blackPen, new Rectangle(300, 100, 150, 150));

            // Draw a diagonal line
            graphics.DrawLine(blackPen, new Point(100, 300), new Point(400, 350));

            // Draw a text string using a solid brush and a font
            using (SolidBrush textBrush = new SolidBrush())
            {
                textBrush.Color = Color.DarkBlue;
                textBrush.Opacity = 100;

                Font textFont = new Font("Arial", 24);
                graphics.DrawString("Vector on JPEG", textFont, textBrush, new Point(50, 500));
            }

            // Save the JPEG image (source is already bound, so just call Save)
            canvas.Save();
        }
    }
}