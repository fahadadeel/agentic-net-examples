using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.html";
            string cssUrl = "styles/custom.css";

            using (Presentation presentation = new Presentation(inputPath))
            {
                HtmlOptions options = new HtmlOptions();
                options.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(cssUrl, true);
                presentation.Save(outputPath, SaveFormat.Html, options);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}