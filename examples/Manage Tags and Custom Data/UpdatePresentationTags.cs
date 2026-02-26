using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the tags collection from the presentation's custom data
        Aspose.Slides.ITagCollection presentationTags = presentation.CustomData.Tags;

        // Add tags to the collection
        presentationTags.Add("AuthorTag", "John Doe");
        presentationTags.Add("ProjectTag", "AsposeDemo");

        // Access a tag using the indexer
        presentationTags["StatusTag"] = "Completed";

        // Iterate over all tags and display them
        for (int i = 0; i < presentationTags.Count; i++)
        {
            string tagName = presentationTags.GetNameByIndex(i);
            string tagValue = presentationTags.GetValueByIndex(i);
            Console.WriteLine($"{tagName} : {tagValue}");
        }

        // Save the presentation
        presentation.Save("TaggedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}