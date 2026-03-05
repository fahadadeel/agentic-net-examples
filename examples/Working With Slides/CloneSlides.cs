using System;
using Aspose.Slides;

namespace SlideCloner
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "source.pptx";
            // Path to the target presentation (will be created)
            string targetPath = "target.pptx";

            // Load the source presentation
            using (Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath))
            {
                // Create a new (empty) destination presentation
                using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
                {
                    // Get the slide collections
                    Aspose.Slides.ISlideCollection srcSlides = srcPres.Slides;
                    Aspose.Slides.ISlideCollection destSlides = destPres.Slides;

                    // Clone each slide from source to destination
                    for (int i = 0; i < srcSlides.Count; i++)
                    {
                        Aspose.Slides.ISlide srcSlide = srcSlides[i];
                        // AddClone clones the slide and its master if needed
                        destSlides.AddClone(srcSlide);
                    }

                    // Save the destination presentation
                    destPres.Save(targetPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
    }
}