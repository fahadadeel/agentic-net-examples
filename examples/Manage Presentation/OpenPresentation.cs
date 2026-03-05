using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPTX file
        string sourcePath = "input.pptx";

        // Open the presentation using the fully-qualified Aspose.Slides type
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Save the presentation (can be the same file or a new one)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}