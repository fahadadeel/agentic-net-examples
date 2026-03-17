using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputImagePath = "slide_0.png";
            using (Presentation pres = new Presentation(inputPath))
            {
                ISlide slide = pres.Slides[0];
                using (IImage image = slide.GetImage())
                {
                    image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
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