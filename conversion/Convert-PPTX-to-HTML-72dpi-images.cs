using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the PowerPoint presentation
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Configure HTML export options with default 72 DPI for slide images
                HtmlOptions options = new HtmlOptions();
                options.SlideImageFormat = SlideImageFormat.Bitmap(72f, Aspose.Slides.ImageFormat.Png);

                // Save the presentation as HTML
                presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}