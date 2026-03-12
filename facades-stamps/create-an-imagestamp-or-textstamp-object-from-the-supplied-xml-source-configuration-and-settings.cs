using System;
using System.IO;
using System.Xml.Linq;
using Aspose.Pdf;
using Aspose.Pdf.Facades;
using Aspose.Pdf.Text; // for EncodingType and FormattedText

class Program
{
    static void Main()
    {
        const string configPath = "stampConfig.xml";

        if (!File.Exists(configPath))
        {
            Console.Error.WriteLine($"Configuration file not found: {configPath}");
            return;
        }

        // Load and parse the XML configuration
        XDocument cfg = XDocument.Load(configPath);
        XElement stampElem = cfg.Root.Element("Stamp");
        if (stampElem == null)
        {
            Console.Error.WriteLine("Invalid configuration: missing <Stamp> element.");
            return;
        }

        // Common attributes
        string inputPdf = (string)stampElem.Element("InputPdf");
        string outputPdf = (string)stampElem.Element("OutputPdf");
        string type = (string)stampElem.Attribute("type"); // "Image" or "Text"

        if (string.IsNullOrWhiteSpace(inputPdf) || string.IsNullOrWhiteSpace(outputPdf) || string.IsNullOrWhiteSpace(type))
        {
            Console.Error.WriteLine("Invalid configuration: missing required elements/attributes.");
            return;
        }

        // Initialize the PdfFileStamp facade using the non‑obsolete API
        Aspose.Pdf.Facades.PdfFileStamp fileStamp = new Aspose.Pdf.Facades.PdfFileStamp();
        fileStamp.BindPdf(inputPdf);

        // Create a Stamp object from the Facades namespace (fully qualified to avoid ambiguity)
        Aspose.Pdf.Facades.Stamp stamp = new Aspose.Pdf.Facades.Stamp();

        // Optional common settings
        if (float.TryParse((string)stampElem.Element("Opacity"), out float opacity))
            stamp.Opacity = opacity; // value between 0.0 and 1.0

        if (bool.TryParse((string)stampElem.Element("IsBackground"), out bool isBg))
            stamp.IsBackground = isBg;

        // Positioning (origin) – defaults to (0,0) if not provided
        float originX = float.TryParse((string)stampElem.Element("OriginX"), out float ox) ? ox : 0f;
        float originY = float.TryParse((string)stampElem.Element("OriginY"), out float oy) ? oy : 0f;
        stamp.SetOrigin(originX, originY);

        // Process based on stamp type
        if (type.Equals("Image", StringComparison.OrdinalIgnoreCase))
        {
            // Image stamp specific settings
            string imagePath = (string)stampElem.Element("ImagePath");
            if (string.IsNullOrWhiteSpace(imagePath) || !File.Exists(imagePath))
            {
                Console.Error.WriteLine("Invalid configuration: image file not found.");
                return;
            }

            // Bind the image to the stamp
            stamp.BindImage(imagePath);

            // Optional size settings
            if (float.TryParse((string)stampElem.Element("Width"), out float width) &&
                float.TryParse((string)stampElem.Element("Height"), out float height))
            {
                stamp.SetImageSize(width, height);
            }
        }
        else if (type.Equals("Text", StringComparison.OrdinalIgnoreCase))
        {
            // Text stamp specific settings
            string text = (string)stampElem.Element("Text");
            string fontName = (string)stampElem.Element("Font") ?? "Helvetica";
            float fontSize = float.TryParse((string)stampElem.Element("FontSize"), out float fs) ? fs : 12f;
            string colorHex = (string)stampElem.Element("Color") ?? "#000000";

            // Convert hex color to System.Drawing.Color (fully qualified to avoid ambiguity)
            System.Drawing.Color sysColor = System.Drawing.ColorTranslator.FromHtml(colorHex);

            // Create FormattedText (requires System.Drawing.Color)
            FormattedText formatted = new FormattedText(
                text ?? string.Empty,
                sysColor,
                fontName,
                EncodingType.Winansi,
                false,
                fontSize);

            // Bind the formatted text to the stamp
            stamp.BindLogo(formatted);
        }
        else
        {
            Console.Error.WriteLine($"Unsupported stamp type: {type}");
            return;
        }

        // Add the stamp to the PDF and finalize
        fileStamp.AddStamp(stamp);
        fileStamp.Save(outputPdf);
        fileStamp.Close();

        Console.WriteLine($"Stamp applied successfully. Output saved to '{outputPdf}'.");
    }
}
