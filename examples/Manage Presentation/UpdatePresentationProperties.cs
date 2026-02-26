using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string sourcePath = "input.pptx";
        // Path where the updated presentation will be saved
        string outputPath = "output.pptx";

        // Load presentation information and bind it to the file
        Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(sourcePath);

        // Retrieve the current document properties
        Aspose.Slides.IDocumentProperties docProps = presentationInfo.ReadDocumentProperties();

        // Update desired properties
        docProps.Title = "Updated Title";
        docProps.Subject = "Updated Subject";
        docProps.Author = "Aspose.Slides Example";

        // Apply the updated properties back to the binded presentation
        presentationInfo.UpdateDocumentProperties(docProps);

        // Save the modified presentation to a new file
        presentationInfo.WriteBindedPresentation(outputPath);
    }
}