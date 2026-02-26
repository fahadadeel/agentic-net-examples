using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        string inputFile = "sample.pptx";
        string outputFile = "updated.pptx";

        // Retrieve presentation information and document properties
        Aspose.Slides.IPresentationInfo presInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputFile);
        Aspose.Slides.IDocumentProperties docProps = presInfo.ReadDocumentProperties();

        Console.WriteLine("Title: " + docProps.Title);
        Console.WriteLine("Author: " + docProps.Author);
        Console.WriteLine("Created: " + docProps.CreatedTime);

        // Update some built‑in properties
        docProps.Title = "Updated Presentation Title";
        docProps.Author = "John Doe";

        // Apply the updated properties to the binded presentation
        presInfo.UpdateDocumentProperties(docProps);
        // Write the updated presentation to a new file
        presInfo.WriteBindedPresentation(outputFile);

        // Load the updated presentation to modify additional settings
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(outputFile))
        {
            // Retrieve slide count
            int slideCount = presentation.Slides.Count;
            Console.WriteLine("Slide count: " + slideCount);

            // Change the first slide number
            presentation.FirstSlideNumber = 5;

            // Save the final changes
            presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}