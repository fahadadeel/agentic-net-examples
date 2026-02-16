using System;
using Aspose.Words;
using Aspose.Words.Fields;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Create a new blank document (or load an existing DOCM if needed)
        Document doc = new Document();

        // Initialize a DocumentBuilder to work with the document
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Write a prompt before the form field
        builder.Writeln("Please enter your name:");

        // Insert a text input form field
        // Parameters: field name, field type, text format, default text, maximum length
        FormField textInput = builder.InsertTextInput(
            "EmployeeName",                 // Name of the form field
            TextFormFieldType.Regular,      // Allows any text
            "",                             // No specific text format
            "John Doe",                     // Placeholder/default text
            50);                            // Maximum number of characters

        // Optional: configure additional properties
        textInput.EntryMacro = "OnEntry";
        textInput.ExitMacro = "OnExit";
        textInput.Enabled = true;

        // Save the document as a macro‑enabled DOCM file
        doc.Save("FormWithTextInput.docm", SaveFormat.Docm);
    }
}
