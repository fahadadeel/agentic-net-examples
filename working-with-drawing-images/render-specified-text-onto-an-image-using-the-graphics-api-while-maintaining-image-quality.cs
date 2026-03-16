using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class TextOnImageExample
{
    static void Main()
    {
        // Define output path
        string outputPath = Path.Combine(Environment.CurrentDirectory, "text_output.png");

        // Create PNG options (no source needed for creation)
        PngOptions pngOptions = new PngOptions();

        // Create a new image with desired dimensions (e.g., 800x200)
        using (Image image = Image.Create(pngOptions, 800, 200))
        {
            // Initialize Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Set high‑quality text rendering (ClearTypeGridFit gives the best quality)
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            // Optional: clear background with a solid color
            graphics.Clear(Color.White);

            // Create a solid brush for the text color
            SolidBrush textBrush = new SolidBrush();
            textBrush.Color = Color.DarkBlue;
            textBrush.Opacity = 100; // fully opaque

            // Define the font (family, size, style)
            Font textFont = new Font("Arial", 48, FontStyle.Bold);

            // The text to render
            string text = "Aspose.Imaging Text Rendering";

            // Draw the string at a specific location (x=50, y=70)
            graphics.DrawString(text, textFont, textBrush, 50f, 70f);

            // Save the image to the specified file
            image.Save(outputPath);
        }

        Console.WriteLine($"Image saved to: {outputPath}");
    }
}