---
name: Facades - Extract Images and Text
description: C# examples for Facades - Extract Images and Text using Aspose.PDF for .NET
language: csharp
framework: net10.0
parent: ../agents.md
---

# AGENTS - Facades - Extract Images and Text

## Persona

You are a C# developer specializing in PDF processing using Aspose.PDF for .NET,
working within the **Facades - Extract Images and Text** category.
This folder contains standalone C# examples for Facades - Extract Images and Text operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Scope
- This folder contains examples for **Facades - Extract Images and Text**.
- Files are standalone `.cs` examples stored directly in this folder.

## Files in this folder
- [determine-if-a-pdf-document-includes-any-images-or-textual-content-using-the-facade-api](./determine-if-a-pdf-document-includes-any-images-or-textual-content-using-the-facade-api.cs)
- [extract-attachments-from-a-pdf-document-using-the-facade-api-for-image-and-text-extraction](./extract-attachments-from-a-pdf-document-using-the-facade-api-for-image-and-text-extraction.cs)
- [extract-images-and-text-from-a-pdf-utilizing-the-facade-api-with-the-extractimagemode-setting](./extract-images-and-text-from-a-pdf-utilizing-the-facade-api-with-the-extractimagemode-setting.cs)
- [extract-images-and-text-from-an-entire-pdf-into-streams-utilizing-the-facade-abstraction](./extract-images-and-text-from-an-entire-pdf-into-streams-utilizing-the-facade-abstraction.cs)
- [extract-images-and-text-from-pdf-files-using-the-facade-api-employing-the-text-extraction-mode-as-d](./extract-images-and-text-from-pdf-files-using-the-facade-api-employing-the-text-extraction-mode-as-d.cs)
- [extract-images-from-a-defined-page-range-of-a-pdf-using-the-facades-library](./extract-images-from-a-defined-page-range-of-a-pdf-using-the-facades-library.cs)
- [extract-text-content-from-a-pdf-document-using-the-facade-api-while-preserving-layout-and-formatting](./extract-text-content-from-a-pdf-document-using-the-facade-api-while-preserving-layout-and-formatting.cs)
- [use-the-facade-api-to-extract-both-images-and-text-from-a-pdf-document-while-handling-background-pro](./use-the-facade-api-to-extract-both-images-and-text-from-a-pdf-document-while-handling-background-pro.cs)
- [utilize-the-facades-api-in-image-extraction-mode-to-retrieve-images-and-associated-text-from-pdf-fil](./utilize-the-facades-api-in-image-extraction-mode-to-retrieve-images-and-associated-text-from-pdf-fil.cs)
- [utilize-the-facades-api-to-extract-all-images-from-a-pdf-document-and-save-each-to-separate-files](./utilize-the-facades-api-to-extract-all-images-from-a-pdf-document-and-save-each-to-separate-files.cs)
- [utilize-the-facades-api-to-extract-all-images-from-a-specified-page-of-a-pdf-document](./utilize-the-facades-api-to-extract-all-images-from-a-specified-page-of-a-pdf-document.cs)
- [utilize-the-pdfextractor-fa-ade-to-retrieve-images-from-a-pdf-document-while-maintaining-original-qu](./utilize-the-pdfextractor-fa-ade-to-retrieve-images-from-a-pdf-document-while-maintaining-original-qu.cs)

## Category Statistics
- Total examples: 12

## Category-Specific Tips

### Key API Surface
- `Aspose.Pdf.Facades.ExtractImageMode`
- `Aspose.Pdf.Facades.PdfContentEditor`
- `Aspose.Pdf.Facades.PdfConverter`
- `Aspose.Pdf.Facades.PdfExtractor`
- `Aspose.Pdf.Facades.PdfExtractor.BindPdf`
- `Aspose.Pdf.Facades.PdfExtractor.ExtractText`
- `Aspose.Pdf.Facades.PdfExtractor.GetNextPageText`
- `Aspose.Pdf.Facades.PdfExtractor.HasNextPageText`
- `Aspose.Pdf.Facades.PdfFileEditor`
- `Aspose.Pdf.Facades.PdfFileEditor.Extract`

### Rules
- BindPdf({input_pdf}) must be called on a PdfContentEditor instance before any editing methods such as ReplaceText.
- ReplaceText({text_fragment}, {page}, {text_fragment}) replaces all occurrences of the first text fragment on the specified 1‑based page with the second text fragment.
- Save({output_pdf}) persists the edited PDF; it should be invoked after all edit operations are completed.
- Use PdfFileEditor.Extract({input_pdf}, new int[] {{int}, {int}, ...}, {output_pdf}) to create a new PDF containing only the listed pages.
- Page numbers supplied in the int array are 1‑based and must exist in {input_pdf}.

### Warnings
- Page numbers are 1‑based; passing 0 will cause an error.
- ReplaceText operates only on the specified page and replaces every matching occurrence on that page.
- The output file will be created or overwritten; ensure the path is correct.
- The example assumes the input PDF exists at the specified location.
- The example does not explicitly dispose the FileStream objects; callers should ensure streams are closed or wrapped in using statements.

## General Tips
- See parent [agents.md](../agents.md) for:
  - **Boundaries** — Always / Ask First / Never rules for all examples
  - **Common Mistakes** — verified anti-patterns that cause build failures
  - **Domain Knowledge** — cross-cutting API-specific gotchas
  - **Testing Guide** — build and run verification steps
- Review code examples in this folder for Facades - Extract Images and Text patterns

<!-- AUTOGENERATED:START -->
Updated: 2026-03-10 | Run: `20260310_163421_7d7524`
<!-- AUTOGENERATED:END -->
