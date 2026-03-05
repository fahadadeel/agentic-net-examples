using System;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "sample.pptx";
        string outputPath = "updated.pptx";

        // Load presentation information using PresentationFactory
        Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(inputPath);

        // Retrieve current document properties
        Aspose.Slides.IDocumentProperties documentProperties = presentationInfo.ReadDocumentProperties();

        // Update desired properties
        documentProperties.Title = "Updated Presentation Title";
        documentProperties.Author = "John Doe";
        documentProperties.Subject = "Demo Subject";

        // Apply the updated properties back to the presentation
        presentationInfo.UpdateDocumentProperties(documentProperties);

        // Save the updated presentation to a new file
        presentationInfo.WriteBindedPresentation(outputPath);
    }
}