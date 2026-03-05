using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the hyperlink of the first shape on the slide
        Aspose.Slides.IHyperlink link = slide.Shapes[0].HyperlinkClick;

        // If the hyperlink has an associated sound, extract it
        if (link != null && link.Sound != null)
        {
            byte[] audioData = link.Sound.BinaryData;
            // Save the extracted sound to a file
            File.WriteAllBytes("hyperlinkSound.mp3", audioData);
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}