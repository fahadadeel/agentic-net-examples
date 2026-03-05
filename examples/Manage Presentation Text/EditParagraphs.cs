using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve all text frames, including those on master slides
        Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

        // Iterate through each text frame
        foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
        {
            // Iterate through each paragraph in the text frame
            foreach (Aspose.Slides.IParagraph paragraph in textFrame.Paragraphs)
            {
                // Update the paragraph text
                paragraph.Text = "Updated paragraph text";

                // Center align the paragraph
                paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
            }
        }

        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}