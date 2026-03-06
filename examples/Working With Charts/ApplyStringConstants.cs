using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ApplyStringConstants
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation from the input file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Define the placeholder text to find and the constant text to replace it with
            string findText = "[Title]";
            string replaceText = "My Presentation Title";

            // Replace all occurrences of the placeholder with the constant text
            Aspose.Slides.Util.SlideUtil.FindAndReplaceText(presentation, true, findText, replaceText, null);

            // Save the modified presentation to the output file
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}