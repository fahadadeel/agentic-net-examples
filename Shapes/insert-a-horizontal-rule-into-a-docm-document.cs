using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Create a new DOCM document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a horizontal rule shape at the current cursor position.
        Shape horizontalRule = builder.InsertHorizontalRule();

        // Customize the appearance of the horizontal rule.
        HorizontalRuleFormat format = horizontalRule.HorizontalRuleFormat;
        format.Alignment = HorizontalRuleAlignment.Center; // Center the rule.
        format.WidthPercent = 80;                           // 80% of the page width.
        format.Height = 2;                                 // Height in points.
        format.Color = Color.DarkGray;                     // Gray color.
        format.NoShade = true;                             // Disable 3‑D shading.

        // Save the document as a macro‑enabled DOCM file.
        doc.Save("HorizontalRule.docm", SaveFormat.Docm);
    }
}
