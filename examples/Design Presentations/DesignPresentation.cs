using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace EmbeddedFontsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape with a text frame
            Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            Aspose.Slides.ITextFrame textFrame = ((Aspose.Slides.IAutoShape)shape).AddTextFrame("Sample text with custom font");

            // Set the font of the text
            textFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");

            // Embed all fonts used in the presentation that are not already embedded
            Aspose.Slides.IFontData[] allFonts = presentation.FontsManager.GetFonts();
            Aspose.Slides.IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();

            foreach (Aspose.Slides.IFontData font in allFonts)
            {
                bool alreadyEmbedded = false;
                foreach (Aspose.Slides.IFontData embedded in embeddedFonts)
                {
                    if (embedded.FontName == font.FontName)
                    {
                        alreadyEmbedded = true;
                        break;
                    }
                }

                if (!alreadyEmbedded)
                {
                    presentation.FontsManager.AddEmbeddedFont(font, Aspose.Slides.Export.EmbedFontCharacters.All);
                }
            }

            // Save the presentation
            presentation.Save("EmbeddedFontsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}