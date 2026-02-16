using System;
using Aspose.Words;

class Program
{
    static void Main()
    {
        // Create a new blank document.
        Document doc = new Document();

        // Add some text to the document.
        DocumentBuilder builder = new DocumentBuilder(doc);
        builder.Writeln("Hello world! This document is write‑protected.");

        // Apply write protection with a password and recommend read‑only opening.
        doc.WriteProtection.SetPassword("MyPassword");
        doc.WriteProtection.ReadOnlyRecommended = true;

        // Verify that the document is write‑protected and that the password is correct.
        Console.WriteLine($"IsWriteProtected: {doc.WriteProtection.IsWriteProtected}");
        Console.WriteLine($"Password valid: {doc.WriteProtection.ValidatePassword("MyPassword")}");

        // Save the protected document.
        const string protectedPath = "WriteProtected.docx";
        doc.Save(protectedPath);

        // Load the document back (write protection does not encrypt the file, so no password needed).
        Document loadedDoc = new Document(protectedPath);

        // Programmatic changes are still allowed.
        DocumentBuilder loadedBuilder = new DocumentBuilder(loadedDoc);
        loadedBuilder.MoveToDocumentEnd();
        loadedBuilder.Writeln("Additional text added programmatically.");

        // Save the modified document.
        const string modifiedPath = "WriteProtected_Modified.docx";
        loadedDoc.Save(modifiedPath);
    }
}
