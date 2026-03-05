using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkSoundExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation from a PPTX file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Access the first shape on the slide
            Aspose.Slides.IShape shape = slide.Shapes[0];

            // Get the hyperlink associated with the shape click action
            Aspose.Slides.IHyperlink hyperlink = shape.HyperlinkClick;

            // Check if the hyperlink and its sound are present
            if (hyperlink != null && hyperlink.Sound != null)
            {
                // Extract the sound data as a byte array
                byte[] audioData = hyperlink.Sound.BinaryData;

                // Save the extracted sound to a file
                File.WriteAllBytes("hyperlink_sound.bin", audioData);
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}