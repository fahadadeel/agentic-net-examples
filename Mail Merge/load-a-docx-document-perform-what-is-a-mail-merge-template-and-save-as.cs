using System;
using Aspose.Words;
using Aspose.Words.Saving;

class Program
{
    static void Main()
    {
        // Path to the source DOCX file (mail‑merge template).
        string inputPath = @"C:\Docs\Template.docx";

        // Load the DOCX document.
        Document doc = new Document(inputPath);

        // If the template contains MERGEFIELDs and you have data,
        // you could execute a mail merge here, e.g.:
        // doc.MailMerge.Execute(new[] { "FirstName", "LastName" },
        //     new object[] { "John", "Doe" });

        // Save the document as PDF.
        string outputPath = @"C:\Docs\Result.pdf";
        doc.Save(outputPath, SaveFormat.Pdf);
    }
}
