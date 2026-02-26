using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the folder containing the custom TrueType font
        string dataDir = "C:\\Data\\";
        // Path to the font file
        string fontPath = Path.Combine(dataDir, "CustomFont.ttf");
        // Load font bytes
        byte[] fontBytes = File.ReadAllBytes(fontPath);
        // Register the font folder so the font can be used in the presentation
        string[] fontFolders = new string[] { dataDir };
        Aspose.Slides.FontsLoader.LoadExternalFonts(fontFolders);
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Add a rectangle shape with a text frame
        Aspose.Slides.IShape shape = presentation.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
        autoShape.AddTextFrame("Sample text");
        // Set font properties for the text
        autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 24;
        autoShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new Aspose.Slides.FontData("CustomFont");
        // Embed the custom font into the presentation
        presentation.FontsManager.AddEmbeddedFont(fontBytes, Aspose.Slides.Export.EmbedFontCharacters.All);
        // Save the presentation
        presentation.Save(Path.Combine(dataDir, "EmbeddedFontPresentation.pptx"), Aspose.Slides.Export.SaveFormat.Pptx);
    }
}