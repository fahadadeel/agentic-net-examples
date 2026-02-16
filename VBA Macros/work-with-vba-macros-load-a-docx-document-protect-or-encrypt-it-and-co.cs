using System;
using Aspose.Words;
using Aspose.Words.Loading;
using Aspose.Words.Saving;
using Aspose.Words.Vba;

class Program
{
    static void Main()
    {
        // Paths to the source documents.
        const string docPath1 = @"C:\Docs\DocumentWithMacros.docm";
        const string docPath2 = @"C:\Docs\DocumentToCompare.docx";

        // Load the first document (may contain VBA macros).
        Document doc1 = new Document(docPath1);

        // Load the second document for comparison.
        Document doc2 = new Document(docPath2);

        // -------------------------------------------------
        // 1. Work with VBA macros (if present in doc1).
        // -------------------------------------------------
        if (doc1.HasMacros)
        {
            // Access the VBA project.
            VbaProject vbaProject = doc1.VbaProject;

            Console.WriteLine($"VBA Project Name: {vbaProject.Name}");
            Console.WriteLine($"Is Signed: {vbaProject.IsSigned}");
            Console.WriteLine($"Modules Count: {vbaProject.Modules.Count}");

            // Iterate through modules and output their names.
            foreach (VbaModule module in vbaProject.Modules)
            {
                Console.WriteLine($"Module: {module.Name}, Type: {module.Type}");
                // Example: modify source code of the first module.
                // (Uncomment to apply changes)
                // if (module == vbaProject.Modules[0])
                //     module.SourceCode = "' Updated VBA code\nSub Hello()\n    MsgBox \"Hello\"\nEnd Sub";
            }
        }

        // -------------------------------------------------
        // 2. Protect the document (write protection) and encrypt it.
        // -------------------------------------------------
        // Apply write protection with a password.
        const string writeProtectionPassword = "WriteProtect123";
        doc1.WriteProtection.SetPassword(writeProtectionPassword);
        doc1.WriteProtection.ReadOnlyRecommended = true; // Suggest read‑only opening.

        // Encrypt the document when saving using OoxmlSaveOptions.
        const string encryptionPassword = "EncryptMe!";
        OoxmlSaveOptions saveOptions = new OoxmlSaveOptions(SaveFormat.Docx)
        {
            Password = encryptionPassword
        };

        // Save the protected and encrypted document.
        const string protectedEncryptedPath = @"C:\Docs\DocumentWithMacros_Protected.docx";
        doc1.Save(protectedEncryptedPath, saveOptions);

        // -------------------------------------------------
        // 3. Verify protection/encryption status using FileFormatUtil.
        // -------------------------------------------------
        FileFormatInfo info = FileFormatUtil.DetectFileFormat(protectedEncryptedPath);
        Console.WriteLine($"Is Encrypted: {info.IsEncrypted}");
        Console.WriteLine($"Has Macros: {info.HasMacros}");
        Console.WriteLine($"Load Format: {info.LoadFormat}");

        // -------------------------------------------------
        // 4. Compare the two documents.
        // -------------------------------------------------
        // Load the protected/encrypted document with the password.
        LoadOptions loadOptions = new LoadOptions(encryptionPassword);
        Document protectedDoc = new Document(protectedEncryptedPath, loadOptions);

        // Perform comparison. Use the overload that expects a DateTime for the comparison date.
        // The third argument is the comparison date; we use DateTime.Now.
        protectedDoc.Compare(doc2, "Comparer", DateTime.Now);

        // Save the comparison result.
        const string comparisonResultPath = @"C:\Docs\ComparisonResult.docx";
        protectedDoc.Save(comparisonResultPath);

        // -------------------------------------------------
        // 5. Simple textual comparison (optional).
        // -------------------------------------------------
        bool textsAreEqual = protectedDoc.GetText() == doc2.GetText();
        Console.WriteLine($"Documents have identical text: {textsAreEqual}");
    }
}
