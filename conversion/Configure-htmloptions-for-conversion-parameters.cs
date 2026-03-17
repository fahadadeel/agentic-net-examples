using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            HtmlOptions htmlOptions = new HtmlOptions();

            // Use a slide show formatter with external CSS and slide titles
            htmlOptions.HtmlFormatter = HtmlFormatter.CreateSlideShowFormatter("styles.css", true);

            // Set slide images to be JPEG bitmaps with 150 DPI
            htmlOptions.SlideImageFormat = SlideImageFormat.Bitmap(150f, Aspose.Slides.ImageFormat.Jpeg);

            // Additional rendering options
            htmlOptions.ShowHiddenSlides = true;
            htmlOptions.DisableFontLigatures = false;
            htmlOptions.SvgResponsiveLayout = true;

            // Save the presentation as a single HTML file
            presentation.Save("output.html", SaveFormat.Html, htmlOptions);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}