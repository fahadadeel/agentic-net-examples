using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Paths
        string existingHtmlPath = "page.html";
        string canvasHtmlPath = "canvas.html";
        string outputHtmlPath = "output.html";

        // Canvas dimensions
        int width = 400;
        int height = 300;

        // Create a PNG canvas
        PngOptions pngOptions = new PngOptions();
        using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pngOptions, width, height))
        {
            // Draw on the canvas
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
            graphics.Clear(Aspose.Imaging.Color.LightGray);
            graphics.DrawRectangle(new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2), new Aspose.Imaging.Rectangle(20, 20, width - 40, height - 40));

            // Save only the canvas tag (no full HTML page)
            canvas.Save(canvasHtmlPath, new Html5CanvasOptions
            {
                FullHtmlPage = false,
                CanvasTagId = "generatedCanvas"
            });
        }

        // Read the existing HTML page
        string htmlContent = File.ReadAllText(existingHtmlPath);

        // Read the generated canvas tag
        string canvasTag = File.ReadAllText(canvasHtmlPath);

        // Insert the canvas tag before the closing </body> tag if present
        int bodyCloseIndex = htmlContent.LastIndexOf("</body>", StringComparison.OrdinalIgnoreCase);
        if (bodyCloseIndex >= 0)
        {
            htmlContent = htmlContent.Insert(bodyCloseIndex, canvasTag + Environment.NewLine);
        }
        else
        {
            // Append at the end if </body> not found
            htmlContent += Environment.NewLine + canvasTag;
        }

        // Write the merged HTML to the output file
        File.WriteAllText(outputHtmlPath, htmlContent);
    }
}