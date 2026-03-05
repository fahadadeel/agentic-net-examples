using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CompareSlidesPdfReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file paths
            string inputPath1 = "Presentation1.pptx";
            string inputPath2 = "Presentation2.pptx";

            // Output PDF report path
            string outputPath = "ComparisonReport.pdf";

            // Load the two presentations to be compared
            Aspose.Slides.Presentation pres1 = new Aspose.Slides.Presentation(inputPath1);
            Aspose.Slides.Presentation pres2 = new Aspose.Slides.Presentation(inputPath2);

            // Create a new presentation that will hold the comparison report
            Aspose.Slides.Presentation reportPres = new Aspose.Slides.Presentation();

            // Determine the number of slides to compare (use the smaller count)
            int slideCount = Math.Min(pres1.Slides.Count, pres2.Slides.Count);

            // Iterate through each slide pair and compare them
            for (int i = 0; i < slideCount; i++)
            {
                // Use BaseSlide.Equals to check visual equality of the two slides
                bool areEqual = pres1.Slides[i].Equals(pres2.Slides[i]);

                if (!areEqual)
                {
                    // If slides differ, add the slide from the first presentation to the report
                    reportPres.Slides.InsertClone(reportPres.Slides.Count, pres1.Slides[i]);

                    // Then add the corresponding slide from the second presentation
                    reportPres.Slides.InsertClone(reportPres.Slides.Count, pres2.Slides[i]);
                }
            }

            // If no differences were found, add a simple text slide indicating this
            if (reportPres.Slides.Count == 0)
            {
                Aspose.Slides.ISlide infoSlide = reportPres.Slides[0];
                Aspose.Slides.IShape txtShape = infoSlide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
                ((Aspose.Slides.AutoShape)txtShape).TextFrame.Text = "All compared slides are identical.";
            }

            // Configure PDF options (e.g., draw a frame around each slide)
            Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            pdfOptions.DrawSlidesFrame = true;

            // Save the report presentation as a PDF file
            reportPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Clean up resources
            pres1.Dispose();
            pres2.Dispose();
            reportPres.Dispose();
        }
    }
}