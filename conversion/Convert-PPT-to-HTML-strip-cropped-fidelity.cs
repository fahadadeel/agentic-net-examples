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
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Configure HTML export options to delete cropped picture areas
                HtmlOptions htmlOptions = new HtmlOptions();
                htmlOptions.DeletePicturesCroppedAreas = true;

                // Save the presentation as HTML
                presentation.Save("output.html", SaveFormat.Html, htmlOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}