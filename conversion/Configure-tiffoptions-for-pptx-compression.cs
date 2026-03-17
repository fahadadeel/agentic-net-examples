using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentationPath = "input.pptx";
            var outputPath = "output.tiff";

            using (var presentation = new Aspose.Slides.Presentation(presentationPath))
            {
                var tiffOptions = new Aspose.Slides.Export.TiffOptions();
                tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.CCITT4;
                tiffOptions.DpiX = 200;
                tiffOptions.DpiY = 200;

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}