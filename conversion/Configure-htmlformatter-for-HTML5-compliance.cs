using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using var presentation = new Aspose.Slides.Presentation();
            var options = new Aspose.Slides.Export.HtmlOptions();
            options.HtmlFormatter = Aspose.Slides.Export.HtmlFormatter.CreateDocumentFormatter("styles.css", true);
            presentation.Save("output.html", SaveFormat.Html, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}