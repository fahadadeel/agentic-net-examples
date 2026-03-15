using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Wmf.Graphics;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output WMF files
        string inputPath = "input.wmf";
        string outputPath = "output.wmf";

        // Load an existing WMF, apply edits, and save
        if (System.IO.File.Exists(inputPath))
        {
            using (WmfImage wmf = (WmfImage)Image.Load(inputPath))
            {
                // Crop 10 pixels from each side
                int margin = 10;
                Rectangle cropRect = new Rectangle(margin, margin, wmf.Width - 2 * margin, wmf.Height - 2 * margin);
                wmf.Crop(cropRect);

                // Resize to half of the current dimensions
                wmf.Resize(wmf.Width / 2, wmf.Height / 2);

                // Rotate 90 degrees clockwise without flipping
                wmf.RotateFlip(RotateFlipType.Rotate90FlipNone);

                // Save the modified WMF
                wmf.Save(outputPath);
            }
        }

        // Create a new WMF image using the recorder graphics API
        int width = 600;
        int height = 400;
        int dpi = 96;
        Rectangle frame = new Rectangle(0, 0, width, height);

        using (WmfRecorderGraphics2D recorder = new WmfRecorderGraphics2D(frame, dpi))
        {
            // Draw a black border
            recorder.DrawRectangle(new Pen(Color.Black, 2), 0, 0, width, height);

            // Fill an inner rectangle with light gray
            recorder.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(50, 50, width - 100, height - 100));

            // Add a text label
            recorder.DrawString("Sample WMF", new Font("Arial", 24, FontStyle.Regular), Color.Blue, 200, 180);

            // Finalize recording and obtain the WMF image
            using (WmfImage newWmf = recorder.EndRecording())
            {
                newWmf.Save("new_output.wmf");
            }
        }
    }
}