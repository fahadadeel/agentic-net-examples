using System;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Configure HTML export options to remove cropped picture areas
        Aspose.Slides.Export.HtmlOptions options = new Aspose.Slides.Export.HtmlOptions();
        options.DeletePicturesCroppedAreas = true;

        // Save the presentation as HTML with the specified options
        pres.Save("output.html", Aspose.Slides.Export.SaveFormat.Html, options);

        // Release resources
        pres.Dispose();
    }
}