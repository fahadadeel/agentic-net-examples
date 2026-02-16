using System;
using Aspose.Words;

class Program
{
    static void Main()
    {
        // Load the existing DOCX file.
        Document doc = new Document("Input.docx");

        // Stop tracking revisions (turn off "Track Changes").
        doc.StopTrackRevisions();

        // Save the modified document.
        doc.Save("Output.docx");
    }
}
