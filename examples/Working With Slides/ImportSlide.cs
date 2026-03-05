using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideImportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation from which a slide will be imported
            string sourcePath = "source.pptx";

            // Path to the destination presentation that will receive the imported slide
            string destinationPath = "output.pptx";

            // Load the source presentation
            using (Aspose.Slides.Presentation sourcePresentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Load (or create) the destination presentation
                using (Aspose.Slides.Presentation destinationPresentation = new Aspose.Slides.Presentation())
                {
                    // Get the first slide from the source presentation
                    Aspose.Slides.ISlide sourceSlide = sourcePresentation.Slides[0];

                    // Get the master slide associated with the source slide
                    Aspose.Slides.IMasterSlide sourceMaster = sourceSlide.LayoutSlide.MasterSlide;

                    // Clone the source master slide into the destination presentation
                    Aspose.Slides.IMasterSlide clonedMaster = destinationPresentation.Masters.AddClone(sourceMaster);

                    // Clone the source slide into the destination presentation using the cloned master
                    destinationPresentation.Slides.AddClone(sourceSlide, clonedMaster, true);

                    // Save the destination presentation
                    destinationPresentation.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
    }
}