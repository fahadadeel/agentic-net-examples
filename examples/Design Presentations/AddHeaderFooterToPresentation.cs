using System;

namespace AddHeaderFooter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "HeaderFooterPresentation.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set footer text and make it visible for all slides
            presentation.HeaderFooterManager.SetAllFootersText("Sample Footer");
            presentation.HeaderFooterManager.SetAllFootersVisibility(true);

            // Set header text via master notes slide if available
            Aspose.Slides.IMasterNotesSlide masterNotes = presentation.MasterNotesSlideManager.MasterNotesSlide;
            if (masterNotes != null)
            {
                foreach (Aspose.Slides.IShape shape in masterNotes.Shapes)
                {
                    if (shape.Placeholder != null && shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Header)
                    {
                        ((Aspose.Slides.IAutoShape)shape).TextFrame.Text = "Sample Header";
                    }
                }
            }

            // Ensure slide-level footer, date-time, and slide number are visible and set text
            Aspose.Slides.IBaseSlideHeaderFooterManager slideHeaderFooter = presentation.Slides[0].HeaderFooterManager;
            if (!slideHeaderFooter.IsFooterVisible)
            {
                slideHeaderFooter.SetFooterVisibility(true);
            }
            if (!slideHeaderFooter.IsSlideNumberVisible)
            {
                slideHeaderFooter.SetSlideNumberVisibility(true);
            }
            if (!slideHeaderFooter.IsDateTimeVisible)
            {
                slideHeaderFooter.SetDateTimeVisibility(true);
            }
            slideHeaderFooter.SetFooterText("Sample Footer");
            slideHeaderFooter.SetDateTimeText("01/01/2023");

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}