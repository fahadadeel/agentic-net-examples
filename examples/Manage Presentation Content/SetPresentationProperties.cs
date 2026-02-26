using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the folder containing presentations
            System.String dataDir = "C:\\Data\\";
            // Path to the template presentation
            System.String templatePath = dataDir + "Template.pptx";

            // Load template presentation info
            Aspose.Slides.IPresentationInfo templateInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(templatePath);
            Aspose.Slides.IDocumentProperties templateProps = templateInfo.ReadDocumentProperties();

            // Set desired properties on the template
            templateProps.Author = "John Doe";
            templateProps.Title = "Sample Title";
            templateProps.Category = "Category";
            templateProps.Keywords = "keyword1, keyword2";
            templateProps.Company = "MyCompany";
            templateProps.Comments = "Some comments";
            templateProps.ContentType = "application/vnd.ms-powerpoint";
            templateProps.Subject = "Subject";

            // List of target presentations to update
            System.String[] targetFiles = new System.String[]
            {
                dataDir + "Doc1.ppt",
                dataDir + "Doc2.ppt",
                dataDir + "Doc3.ppt"
            };

            // Update each target presentation with the template properties and save
            foreach (System.String targetPath in targetFiles)
            {
                Aspose.Slides.IPresentationInfo targetInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(targetPath);
                targetInfo.UpdateDocumentProperties(templateProps);
                targetInfo.WriteBindedPresentation(targetPath);
            }
        }
    }
}