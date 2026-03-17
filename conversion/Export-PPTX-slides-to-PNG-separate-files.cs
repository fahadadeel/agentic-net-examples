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
            string outputFolder = "output";
            System.IO.Directory.CreateDirectory(outputFolder);

            using (Presentation presentation = new Presentation(inputPath))
            {
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    using (IImage image = slide.GetImage())
                    {
                        string outputPath = System.IO.Path.Combine(outputFolder, $"slide_{index}.png");
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                string presOutput = System.IO.Path.Combine(outputFolder, "output.pptx");
                presentation.Save(presOutput, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}