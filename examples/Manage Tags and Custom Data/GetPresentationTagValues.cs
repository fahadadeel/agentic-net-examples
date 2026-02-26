using System;

namespace AsposeSlidesTagExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input PPTX file
            string inputPath = "input.pptx";

            // Path to the output PPTX file (presentation will be saved before exit)
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the tag collection
            Aspose.Slides.ITagCollection tags = presentation.CustomData.Tags;

            // Iterate through all tags and print their names and values
            for (int index = 0; index < tags.Count; index++)
            {
                string tagName = tags.GetNameByIndex(index);
                string tagValue = tags.GetValueByIndex(index);
                Console.WriteLine($"Tag: {tagName} = {tagValue}");
            }

            // Save the presentation (required by authoring rules)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}