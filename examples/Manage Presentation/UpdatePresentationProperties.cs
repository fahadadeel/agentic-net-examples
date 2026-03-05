using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string sourcePath = "input.pptx";
        // Path where the updated presentation will be saved
        string outputPath = "output.pptx";

        // Obtain presentation information using the factory
        Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(sourcePath);

        // Read the current document properties
        Aspose.Slides.IDocumentProperties documentProperties = presentationInfo.ReadDocumentProperties();

        // Update desired properties
        documentProperties.Title = "New Title";
        documentProperties.Subject = "Updated Subject";

        // Apply the updated properties back to the binded presentation
        presentationInfo.UpdateDocumentProperties(documentProperties);

        // Save the presentation before exiting
        presentationInfo.WriteBindedPresentation(outputPath);
    }
}