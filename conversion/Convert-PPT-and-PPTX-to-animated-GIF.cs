using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationToGif
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = args.Length > 0 ? args[0] : "input.pptx";
                string outputPath = args.Length > 1 ? args[1] : "output.gif";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.Export.GifOptions options = new Aspose.Slides.Export.GifOptions
                    {
                        FrameSize = new Size(960, 720),
                        DefaultDelay = 2000,
                        TransitionFps = 35
                    };

                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, options);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}