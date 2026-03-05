using System;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToJpg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the PowerPoint presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Iterate through all slides and save each as a JPEG image
                for (int index = 0; index < pres.Slides.Count; index++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[index];
                    Aspose.Slides.IImage image = slide.GetImage(1f, 1f);
                    image.Save($"slide_{index + 1}.jpg", ImageFormat.Jpeg);
                }

                // Save the presentation before exiting (no modifications made)
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}