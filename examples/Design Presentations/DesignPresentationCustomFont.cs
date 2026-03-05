using System;

class Program
{
    static void Main()
    {
        // Load custom fonts from a folder
        string[] fontFolders = new string[] { "C:\\MyFonts" };
        Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with a text frame
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        autoShape.AddTextFrame("Sample text with custom font");

        // Set a custom font for the text
        Aspose.Slides.IFontData customFont = new Aspose.Slides.FontData("MyCustomFont");
        autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = customFont;

        // Save the presentation
        presentation.Save("CustomFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}