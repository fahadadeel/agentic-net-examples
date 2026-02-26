using System;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Util;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input presentation
        var inputPath = "input.pptx";

        // Load the presentation
        var pres = new Aspose.Slides.Presentation(inputPath);

        // Retrieve all text frames, including those on master slides
        var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(pres, true);

        var sb = new StringBuilder();

        // Iterate through each text frame and extract portions with All-Caps effect
        foreach (var frame in textFrames)
        {
            foreach (var paragraph in frame.Paragraphs)
            {
                foreach (var portion in paragraph.Portions)
                {
                    if (portion.PortionFormat.TextCapType == Aspose.Slides.TextCapType.All)
                    {
                        sb.AppendLine(portion.Text);
                    }
                }
            }
        }

        // Display the extracted All-Caps text
        Console.WriteLine("All-Caps Text:");
        Console.WriteLine(sb.ToString());

        // Save the presentation (required before exit)
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}