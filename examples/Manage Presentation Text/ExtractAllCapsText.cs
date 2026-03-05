using System;
using System.Text;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Retrieve all text frames (including master slides)
        Aspose.Slides.ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

        // StringBuilder to collect all-caps text
        StringBuilder allCapsBuilder = new StringBuilder();

        foreach (Aspose.Slides.ITextFrame textFrame in textFrames)
        {
            foreach (Aspose.Slides.IParagraph paragraph in textFrame.Paragraphs)
            {
                foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                {
                    if (portion.PortionFormat.TextCapType == Aspose.Slides.TextCapType.All)
                    {
                        allCapsBuilder.Append(portion.Text);
                    }
                }
            }
        }

        // Display the extracted all-caps text
        Console.WriteLine("All-Caps text:");
        Console.WriteLine(allCapsBuilder.ToString());

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}