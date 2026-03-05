using System;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Assume the first shape on the slide is a table and cast it
        Aspose.Slides.ITable table = (Aspose.Slides.ITable)slide.Shapes[0];

        // Get the cell at row 0, column 0
        Aspose.Slides.ICell cell = table[0, 0];

        // Retrieve the text from the cell's text frame
        Aspose.Slides.ITextFrame textFrame = cell.TextFrame;
        string cellText = textFrame.Text;

        // Output the cell content
        Console.WriteLine("Cell text: " + cellText);

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}