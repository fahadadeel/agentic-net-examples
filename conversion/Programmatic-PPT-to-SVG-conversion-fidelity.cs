using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToSvgConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath;
                if (args.Length > 0)
                {
                    inputPath = args[0];
                }
                else
                {
                    inputPath = "input.pptx";
                }

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    int slideCount = pres.Slides.Count;
                    for (int i = 0; i < slideCount; i++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[i];
                        string outputSvgPath = $"slide_{i + 1}.svg";

                        using (FileStream fileStream = new FileStream(outputSvgPath, FileMode.Create, FileAccess.Write))
                        {
                            slide.WriteAsSvg(fileStream);
                        }
                    }

                    // Save the presentation before exiting
                    pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}