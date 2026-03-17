using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputSvgPath = "slide_1.svg";

            using (Presentation pres = new Presentation(inputPath))
            {
                using (FileStream svgStream = File.Create(outputSvgPath))
                {
                    pres.Slides[0].WriteAsSvg(svgStream);
                }

                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}