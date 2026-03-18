using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "protected.pptx";
            var outputPath = "unlocked.pptx";
            var password = "myPassword";

            var loadOptions = new Aspose.Slides.LoadOptions();
            loadOptions.Password = password;

            using (var presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
            {
                // Perform any required operations on the presentation here

                // Save the decrypted presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}