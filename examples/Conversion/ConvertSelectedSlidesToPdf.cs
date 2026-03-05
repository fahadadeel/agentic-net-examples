using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source PowerPoint presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Specify the slide numbers to export (1‑based indexing)
        int[] selectedSlides = new int[] { 1, 3, 5 };

        // Save the selected slides as a PDF file
        presentation.Save("selected_slides.pdf", selectedSlides, Aspose.Slides.Export.SaveFormat.Pdf);
    }
}