using System;

class Program
{
    static void Main()
    {
        // Define the directory containing the presentations
        string dataDir = "C:\\Data\\";
        // Path to the template presentation
        string templatePath = dataDir + "template.pptx";

        // Load template presentation info
        Aspose.Slides.IPresentationInfo templateInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(templatePath);
        // Read its document properties
        Aspose.Slides.IDocumentProperties templateProps = templateInfo.ReadDocumentProperties();

        // Set desired properties on the template
        templateProps.Author = "John Doe";
        templateProps.Title = "Quarterly Report";
        templateProps.Category = "Business";
        templateProps.Keywords = "Finance, Q1, Report";
        templateProps.Company = "Acme Corp";
        templateProps.Comments = "Confidential";
        templateProps.ContentType = "Presentation";
        templateProps.Subject = "Financial Overview";

        // List of target presentations to update
        string[] targetFiles = new string[]
        {
            dataDir + "doc1.pptx",
            dataDir + "doc2.pptx",
            dataDir + "doc3.pptx"
        };

        // Update each target presentation with the template properties
        foreach (string targetPath in targetFiles)
        {
            Aspose.Slides.IPresentationInfo targetInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(targetPath);
            targetInfo.UpdateDocumentProperties(templateProps);
            targetInfo.WriteBindedPresentation(targetPath);
        }
    }
}