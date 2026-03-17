using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "slide.html";

            using (var sourcePres = new Aspose.Slides.Presentation(inputPath))
            {
                using (var singlePres = new Aspose.Slides.Presentation())
                {
                    // Remove the default empty slide
                    singlePres.Slides.RemoveAt(0);
                    // Clone the first slide from the source presentation
                    singlePres.Slides.AddClone(sourcePres.Slides[0]);

                    var options = new HtmlOptions();
                    // Save the single slide as an HTML document
                    singlePres.Save(outputPath, SaveFormat.Html, options);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}