using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TecnologiasProyect.Model;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace TecnologiasProyect
{
    public class PdfPrueba
    {
        public static void GenerarPdfMateria(List<Materia> materia)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filepath = System.IO.Path.Combine(desktopPath, "prueba.pdf");

            PdfDocument pdf = new PdfDocument(new PdfWriter(filepath));
            Document document = new Document(pdf);

            Table table = new Table(3);

            table.AddCell(new Cell().Add(new Paragraph("ID")));
            table.AddCell(new Cell().Add(new Paragraph("Nombre")));
            table.AddCell(new Cell().Add(new Paragraph("Créditos")));

            foreach (var item in materia)
            {
                table.AddCell(new Cell().Add(new Paragraph(item.IdMateria.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(item.nombre)));
                table.AddCell(new Cell().Add(new Paragraph(item.creditos.ToString())));
            }
            document.Add(table);
            document.Close();

        }
        public static void GenerarPdfProblematica(List<Problematica> problematica)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filepath = System.IO.Path.Combine(desktopPath, "prueba.pdf");

            PdfDocument pdf = new PdfDocument(new PdfWriter(filepath));
            Document document = new Document(pdf);

            Table table = new Table(3);

            table.AddCell(new Cell().Add(new Paragraph("ID")));
            table.AddCell(new Cell().Add(new Paragraph("Nombre")));
            table.AddCell(new Cell().Add(new Paragraph("Descripción")));

            foreach (var item in problematica)
            {
                table.AddCell(new Cell().Add(new Paragraph(item.IdProblematica.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(item.titulo)));
                table.AddCell(new Cell().Add(new Paragraph(item.descripcion)));
            }
            document.Add(table);
            document.Close();

        }   
    }
}