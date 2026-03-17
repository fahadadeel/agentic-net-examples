using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

            // Configure HTML export options for a responsive layout
            Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();
            options.SvgResponsiveLayout = true;

            // Save the presentation as responsive HTML
            pres.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}