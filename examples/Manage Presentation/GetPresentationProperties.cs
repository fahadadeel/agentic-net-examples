using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationPropertiesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation file
            string sourcePath = "sample.pptx";

            // Get presentation info using PresentationFactory
            IPresentationInfo presentationInfo = PresentationFactory.Instance.GetPresentationInfo(sourcePath);

            // Read document properties from the bound presentation
            IDocumentProperties documentProperties = presentationInfo.ReadDocumentProperties();

            // Display some built‑in properties
            Console.WriteLine("Title: " + documentProperties.Title);
            Console.WriteLine("Author: " + documentProperties.Author);
            Console.WriteLine("Created Time (UTC): " + documentProperties.CreatedTime);
            Console.WriteLine("Subject: " + documentProperties.Subject);

            // Load the presentation to ensure it is saved before exit
            using (Presentation presentation = new Presentation(sourcePath))
            {
                // Save the presentation (can be the same file or a new one)
                presentation.Save("sample_saved.pptx", SaveFormat.Pptx);
            }
        }
    }
}