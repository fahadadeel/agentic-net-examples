using System;
using System.Drawing;
using Aspose.Words;
using Aspose.Words.Drawing;

class StyleSeparatorExample
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();

        // Initialize DocumentBuilder for the document.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // -----------------------------------------------------------------
        // Define two custom paragraph styles that will be separated.
        // -----------------------------------------------------------------
        Style style1 = doc.Styles.Add(StyleType.Paragraph, "MyStyle1");
        style1.Font.Name = "Arial";
        style1.Font.Size = 16;
        style1.Font.Color = Color.Blue;

        Style style2 = doc.Styles.Add(StyleType.Paragraph, "MyStyle2");
        style2.Font.Name = "Times New Roman";
        style2.Font.Size = 12;
        style2.Font.Color = Color.Green;

        // -----------------------------------------------------------------
        // Write the first part of the paragraph using the first style.
        // -----------------------------------------------------------------
        builder.ParagraphFormat.Style = style1;
        builder.Write("First part ");

        // -----------------------------------------------------------------
        // Insert a style separator. This allows the same paragraph to have
        // a different style after the separator.
        // -----------------------------------------------------------------
        builder.InsertStyleSeparator();

        // -----------------------------------------------------------------
        // Write the second part of the paragraph using the second style.
        // -----------------------------------------------------------------
        builder.ParagraphFormat.Style = style2;
        builder.Write("Second part");

        // Finish the paragraph.
        builder.Writeln();

        // -----------------------------------------------------------------
        // Save the document to a DOCX file.
        // -----------------------------------------------------------------
        doc.Save("StyleSeparator.docx");
    }
}
