using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Create HtmlOptions for conversion
        Aspose.Slides.Export.HtmlOptions htmlOptions = new Aspose.Slides.Export.HtmlOptions();

        // Example: include hidden slides in the output
        htmlOptions.ShowHiddenSlides = true;

        // Save the presentation as HTML using the specified options
        presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, htmlOptions);
    }
}