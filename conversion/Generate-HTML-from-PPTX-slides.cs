using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation file
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Create HTML export options
                Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();

                // Export the presentation to HTML
                presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, options);

                // Ensure the presentation is closed before exiting
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}