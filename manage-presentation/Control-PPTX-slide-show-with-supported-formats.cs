using System;
using Aspose.Slides.Export;

namespace SlideShowControl
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "sample.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }
            string outputPath = "sample_out.pptx";

            try
            {
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.DeleteEmbeddedBinaryObjects = true;

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
                {
                    // Configure the slide show to be presented by a speaker (full screen)
                    presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

                    // Save the presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}