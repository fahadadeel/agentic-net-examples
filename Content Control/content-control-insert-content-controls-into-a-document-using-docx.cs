using System;
using Aspose.Words;
using Aspose.Words.Markup;

class Program
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();

        // Initialize a DocumentBuilder for the document.
        DocumentBuilder builder = new DocumentBuilder(doc);

        // ----- Insert a block‑level Rich Text content control -----
        StructuredDocumentTag richTextControl = new StructuredDocumentTag(doc, SdtType.RichText, MarkupLevel.Block);
        richTextControl.Title = "RichTextControl"; // optional title
        builder.InsertNode(richTextControl);       // place the control in the document

        // Move the cursor inside the newly created control and add text.
        builder.MoveTo(richTextControl);
        builder.Writeln("This text is inside a rich‑text content control.");

        // ----- Insert an inline Plain Text content control -----
        StructuredDocumentTag plainTextControl = new StructuredDocumentTag(doc, SdtType.PlainText, MarkupLevel.Inline);
        plainTextControl.Title = "PlainTextControl"; // optional title
        builder.InsertNode(plainTextControl);        // place the control after the previous paragraph

        // Move the cursor inside the inline control and add text.
        builder.MoveTo(plainTextControl);
        builder.Write("Inline plain‑text control content.");

        // Save the document as a DOCX file.
        doc.Save("ContentControls.docx");
    }
}
