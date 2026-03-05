using System;

namespace ReadCellText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the presentation file
            string inputPath = "input.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape is a table
                    Aspose.Slides.ITable table = shape as Aspose.Slides.ITable;
                    if (table != null)
                    {
                        // Iterate through rows and columns of the table
                        for (int row = 0; row < table.Rows.Count; row++)
                        {
                            for (int col = 0; col < table.Columns.Count; col++)
                            {
                                Aspose.Slides.ICell cell = table[row, col];
                                Aspose.Slides.ITextFrame textFrame = cell.TextFrame;
                                if (textFrame != null)
                                {
                                    string cellText = textFrame.Text;
                                    Console.WriteLine("Slide {0}, Table {1}, Cell[{2},{3}]: {4}",
                                        slideIndex + 1, shapeIndex + 1, row, col, cellText);
                                }
                            }
                        }
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}