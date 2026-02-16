using System;
using Aspose.Words;
using Aspose.Words.Saving;

class MailMergeToPdf
{
    static void Main()
    {
        // Path to the source DOCX template.
        string templatePath = @"C:\Docs\Template.docx";

        // Path where the resulting PDF will be saved.
        string outputPdfPath = @"C:\Docs\Result.pdf";

        // Load the DOCX document.
        Document doc = new Document(templatePath);

        // Define the mail merge fields and corresponding values.
        // Adjust the field names and values to match those used in your template.
        string[] fieldNames = { "FirstName", "LastName", "Message" };
        object[] fieldValues = { "John", "Doe", "Hello! This message was created with Aspose.Words mail merge." };

        // Execute the mail merge operation.
        doc.MailMerge.Execute(fieldNames, fieldValues);

        // Save the merged document as PDF.
        doc.Save(outputPdfPath, SaveFormat.Pdf);
    }
}
