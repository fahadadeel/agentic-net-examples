using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InspectPresentationDataStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            System.String inputPath = "input.pptx";

            // Load options (no password, load full content)
            Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.Password = "";
            loadOptions.OnlyLoadDocumentProperties = false;

            // Open the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions);

            // Iterate through all custom XML parts
            Aspose.Slides.ICustomXmlPart[] customParts = presentation.AllCustomXmlParts;
            for (System.Int32 i = 0; i < customParts.Length; i++)
            {
                Aspose.Slides.ICustomXmlPart part = customParts[i];
                System.Console.WriteLine("Custom XML Part " + i + " ItemId: " + part.ItemId);
                System.Console.WriteLine("XML Content: " + part.XmlAsString);
            }

            // Save the presentation (even if unchanged) before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}