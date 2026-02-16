using System;
using Aspose.Words;
using Aspose.Words.Fields;

class InsertFormFields
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();
        DocumentBuilder builder = new DocumentBuilder(doc);

        // Insert a combo box form field.
        builder.Write("Choose a value from this combo box: ");
        FormField comboBox = builder.InsertComboBox(
            "MyComboBox",                     // field name
            new[] { "One", "Two", "Three" }, // list items
            0);                               // default selected index
        comboBox.CalculateOnExit = true;      // optional: recalculate when the field loses focus

        // Insert a paragraph break between fields.
        builder.InsertBreak(BreakType.ParagraphBreak);

        // Insert a check box form field.
        builder.Write("Click this check box to tick/untick it: ");
        FormField checkBox = builder.InsertCheckBox(
            "MyCheckBox", // field name
            false,        // default state (unchecked)
            50);          // size in points
        checkBox.IsCheckBoxExactSize = true;
        checkBox.HelpText = "Right click to check this box";
        checkBox.OwnHelp = true;
        checkBox.StatusText = "Checkbox status text";
        checkBox.OwnStatus = true;

        // Insert another paragraph break.
        builder.InsertBreak(BreakType.ParagraphBreak);

        // Insert a text input form field.
        builder.Write("Enter text here: ");
        FormField textInput = builder.InsertTextInput(
            "MyTextInput",               // field name
            TextFormFieldType.Regular,   // type of text field
            "",                          // format (none)
            "Placeholder text",          // default display text
            50);                         // maximum length
        textInput.EntryMacro = "EntryMacro";
        textInput.ExitMacro = "ExitMacro";
        textInput.TextInputDefault = "Regular";
        textInput.TextInputFormat = "FIRST CAPITAL";

        // Optional: iterate over all form fields and output their names.
        FormFieldCollection formFields = doc.Range.FormFields;
        Console.WriteLine($"Total form fields: {formFields.Count}");
        foreach (FormField field in formFields)
        {
            Console.WriteLine($"- {field.Type}: {field.Name}");
        }

        // Save the document to a DOC file.
        doc.Save("FormFields.doc");
    }
}
