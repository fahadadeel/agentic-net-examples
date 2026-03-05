using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the PPTX presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");
            // Create PPT save options
            Aspose.Slides.Export.PptOptions options = new Aspose.Slides.Export.PptOptions();
            // Save the presentation as PPT format
            pres.Save("output.ppt", Aspose.Slides.Export.SaveFormat.Ppt, options);
        }
    }
}