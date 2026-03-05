using System;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the collection of custom tags
        Aspose.Slides.ITagCollection tags = presentation.CustomData.Tags;

        // Iterate through all tags and print their names and values
        int tagCount = tags.Count;
        for (int i = 0; i < tagCount; i++)
        {
            string tagName = tags.GetNameByIndex(i);
            string tagValue = tags.GetValueByIndex(i);
            Console.WriteLine("Tag: " + tagName + " = " + tagValue);
        }

        // Save the presentation (even if unchanged) before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}