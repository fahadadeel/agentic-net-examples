using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Load PPTX data from a file into a byte array (replace with actual BLOB source)
        byte[] pptxData = File.ReadAllBytes("input.pptx");

        // Create a presentation instance from the byte array (BLOB)
        Aspose.Slides.IPresentation presentation = Aspose.Slides.PresentationFactory.Instance.ReadPresentation(pptxData);

        // Save the presentation to a file in PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();
    }
}