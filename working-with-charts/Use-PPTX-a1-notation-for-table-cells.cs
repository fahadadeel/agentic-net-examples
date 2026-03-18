using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableA1ReferenceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Define column widths and row heights
                double[] cols = new double[] { 100, 100, 100 };
                double[] rows = new double[] { 50, 50, 50, 50 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

                // Example: set text in cell using A1 notation ("B2")
                SetCellTextByA1(table, "B2", "Hello from B2");

                // Example: set text in another cell ("C4")
                SetCellTextByA1(table, "C4", "Data at C4");

                // Save the presentation
                string outPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "TableA1Reference.pptx");
                pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Converts an A1 cell reference (e.g., "B2") to zero‑based column and row indexes
        private static void ConvertA1ToIndexes(string a1, out int columnIndex, out int rowIndex)
        {
            if (string.IsNullOrEmpty(a1))
                throw new ArgumentException("A1 reference cannot be null or empty.");

            // Separate letters and digits
            int i = 0;
            while (i < a1.Length && Char.IsLetter(a1[i]))
                i++;

            string columnPart = a1.Substring(0, i).ToUpperInvariant();
            string rowPart = a1.Substring(i);

            // Convert column letters to number (A=0, B=1, ..., Z=25, AA=26, etc.)
            columnIndex = 0;
            foreach (char c in columnPart)
            {
                if (c < 'A' || c > 'Z')
                    throw new ArgumentException("Invalid column part in A1 reference.");

                columnIndex = columnIndex * 26 + (c - 'A' + 1);
            }
            columnIndex--; // zero‑based

            // Convert row number to zero‑based index
            if (!int.TryParse(rowPart, out int rowNumber) || rowNumber <= 0)
                throw new ArgumentException("Invalid row part in A1 reference.");

            rowIndex = rowNumber - 1; // zero‑based
        }

        // Sets the text of a table cell identified by an A1 reference
        private static void SetCellTextByA1(Aspose.Slides.ITable table, string a1Reference, string text)
        {
            int col, row;
            ConvertA1ToIndexes(a1Reference, out col, out row);

            // Validate indexes against table dimensions
            if (col < 0 || col >= table.Columns.Count)
                throw new ArgumentOutOfRangeException("Column index out of range for table.");
            if (row < 0 || row >= table.Rows.Count)
                throw new ArgumentOutOfRangeException("Row index out of range for table.");

            Aspose.Slides.ICell cell = table[col, row];
            Aspose.Slides.ITextFrame tf = cell.TextFrame;
            tf.Text = text;
        }
    }
}