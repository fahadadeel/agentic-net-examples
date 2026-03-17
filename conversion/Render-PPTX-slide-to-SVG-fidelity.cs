using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputSvgPath = "slide_1.svg";
                string outputPresPath = "output.pptx";

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.Export.SVGOptions options = new Aspose.Slides.Export.SVGOptions();
                    options.VectorizeText = true;

                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    using (FileStream fileStream = File.Create(outputSvgPath))
                    {
                        slide.WriteAsSvg(fileStream, options);
                    }

                    pres.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}