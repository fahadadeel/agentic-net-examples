using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Flag to indicate whether any text box shape was found
        bool textBoxFound = false;

        // Iterate through all slides in the presentation
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            // Get the current slide
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Retrieve all text box frames on the slide
            Aspose.Slides.ITextFrame[] textBoxes = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

            // If any text boxes are present, mark as found and optionally modify
            if (textBoxes != null && textBoxes.Length > 0)
            {
                textBoxFound = true;

                // Example modification: set text of the first text box
                Aspose.Slides.ITextFrame firstTextBox = textBoxes[0];
                firstTextBox.Text = "Checked TextBox";
            }
        }

        // Output the result of the check
        Console.WriteLine(textBoxFound ? "Text box found." : "No text box found.");

        // Save the (potentially modified) presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}