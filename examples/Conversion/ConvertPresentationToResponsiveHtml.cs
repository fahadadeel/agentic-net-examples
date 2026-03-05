using System;

namespace PresentationToResponsiveHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";
            // Path to the generated HTML file
            string outputPath = "output.html";

            // Load the presentation from file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Set up HTML5 export options for a responsive layout
            Aspose.Slides.Export.Html5Options htmlOptions = new Aspose.Slides.Export.Html5Options();
            Aspose.Slides.Export.HandoutLayoutingOptions layoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions();
            layoutOptions.Handout = Aspose.Slides.Export.HandoutType.Handouts4Horizontal;
            htmlOptions.SlidesLayoutOptions = layoutOptions;

            // Save the presentation as responsive HTML5
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Html5, htmlOptions);

            // Release resources
            presentation.Dispose();
        }
    }
}