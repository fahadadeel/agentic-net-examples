using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Words;
using Aspose.Words.Tables;
using Aspose.Words.Reporting;

namespace AsposeWordsLinqReportingMerge
{
    // Simple data model for the report.
    public class Product
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
        // Directory where output files will be written.
        private static readonly string ArtifactsDir = Path.Combine(Environment.CurrentDirectory, "Output");

        static void Main()
        {
            // Ensure the output directory exists.
            Directory.CreateDirectory(ArtifactsDir);

            // 1. Create a template document with a table that contains merge fields.
            Document template = CreateTemplate();

            // 2. Prepare sample data.
            List<Product> products = new List<Product>
            {
                new Product { Category = "Beverages", Name = "Tea", Price = 1.5 },
                new Product { Category = "Beverages", Name = "Coffee", Price = 2.0 },
                new Product { Category = "Snacks", Name = "Cookies", Price = 3.0 },
                new Product { Category = "Snacks", Name = "Chips", Price = 2.5 },
                new Product { Category = "Snacks", Name = "Nuts", Price = 4.0 },
                new Product { Category = "Fruits", Name = "Apple", Price = 0.8 },
                new Product { Category = "Fruits", Name = "Banana", Price = 0.5 }
            };

            // 3. Use the LINQ Reporting Engine to populate the table.
            ReportingEngine engine = new ReportingEngine();
            engine.BuildReport(template, products);

            // 4. After the report is built, merge the Category cells vertically where the category repeats.
            MergeCategoryCellsVertically(template);

            // 5. Save the final document.
            string outputPath = Path.Combine(ArtifactsDir, "ProductsReport.docx");
            template.Save(outputPath);
        }

        // Creates a simple template with a table that has three columns:
        // Category, Name, Price. The Category column will be merged vertically later.
        private static Document CreateTemplate()
        {
            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);

            // Start a table.
            Table table = builder.StartTable();

            // Header row.
            builder.InsertCell();
            builder.Write("Category");
            builder.InsertCell();
            builder.Write("Product Name");
            builder.InsertCell();
            builder.Write("Price");
            builder.EndRow();

            // Data row – this row will be repeated by the ReportingEngine.
            // Use LINQ Reporting syntax to refer to the current item.
            builder.InsertCell();
            builder.Write("{{Category}}");
            builder.InsertCell();
            builder.Write("{{Name}}");
            builder.InsertCell();
            builder.Write("{{Price}}");
            builder.EndRow();

            // End the table.
            builder.EndTable();

            return doc;
        }

        // Merges cells in the first column (Category) vertically when consecutive rows share the same value.
        private static void MergeCategoryCellsVertically(Document doc)
        {
            // Locate the first table in the document.
            Table table = doc.FirstSection.Body.Tables[0];

            // Keep track of the previous category value and the cell that started the merge range.
            string previousCategory = null;
            Cell mergeStartCell = null;

            // Iterate over rows, skipping the header row (row index 0).
            for (int rowIndex = 1; rowIndex < table.Rows.Count; rowIndex++)
            {
                Row row = table.Rows[rowIndex];
                Cell categoryCell = row.Cells[0];
                string currentCategory = categoryCell.GetText().Trim();

                if (currentCategory == previousCategory)
                {
                    // This cell should be merged with the cell above.
                    categoryCell.CellFormat.VerticalMerge = CellMerge.Previous;
                }
                else
                {
                    // Start a new merge range.
                    categoryCell.CellFormat.VerticalMerge = CellMerge.First;
                    mergeStartCell = categoryCell;
                }

                previousCategory = currentCategory;
            }
        }
    }
}
