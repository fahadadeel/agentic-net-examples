using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideComparisonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the source presentations
            string presentationPath1 = "Presentation1.pptx";
            string presentationPath2 = "Presentation2.pptx";

            // Load the first presentation
            using (Aspose.Slides.Presentation presentation1 = new Aspose.Slides.Presentation(presentationPath1))
            {
                // Load the second presentation
                using (Aspose.Slides.Presentation presentation2 = new Aspose.Slides.Presentation(presentationPath2))
                {
                    // Get the first slide from each presentation
                    Aspose.Slides.ISlide slide1 = presentation1.Slides[0];
                    Aspose.Slides.ISlide slide2 = presentation2.Slides[0];

                    // Compare the two slides using BaseSlide.Equals
                    bool slidesAreEqual = slide1.Equals(slide2);

                    // Create a new presentation to hold the comparison report
                    using (Aspose.Slides.Presentation reportPresentation = new Aspose.Slides.Presentation())
                    {
                        // Add clones of the compared slides to the report presentation
                        reportPresentation.Slides.AddClone(slide1);
                        reportPresentation.Slides.AddClone(slide2);

                        // Add a text box on the first slide indicating the comparison result
                        Aspose.Slides.IAutoShape resultShape = reportPresentation.Slides[0].Shapes.AddAutoShape(
                            Aspose.Slides.ShapeType.Rectangle, 10, 10, 400, 50);
                        resultShape.TextFrame.Text = slidesAreEqual ? "Slides are equal" : "Slides differ";

                        // Save the report as a PDF file
                        reportPresentation.Save("SlideComparisonReport.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
                    }
                }
            }
        }
    }
}