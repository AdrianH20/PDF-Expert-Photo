using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.ComponentModel;
using System.Data;
using System.Drawing;


using System.Windows.Forms;

using iText.Layout;
using iText.Layout.Element;
using Image = iText.Layout.Element.Image;
using PageSize = iText.Kernel.Geom.PageSize;
using PdfWriter = iText.Kernel.Pdf.PdfWriter;
using PdfDocument = iText.Kernel.Pdf.PdfDocument;
using UnitValue = iText.Layout.Properties.UnitValue;

using HorizontalAlignment = iText.Layout.Properties.HorizontalAlignment;
using VerticalAlignment = iText.Layout.Properties.VerticalAlignment;


namespace JPEGtoPDF
{
    class Custom
    {


        static void sorting(List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            Image auxImg;
            ImageSelection auxImgSelection;
            bool isSorted = false;
            int N = currentImgs.Count();
            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < N - 1; i++)
                    if (currentImgsList.ElementAt(i).format == "portrait" && currentImgsList.ElementAt(i + 1).format == "landscape")
                    {
                        isSorted = false;

                        auxImg = currentImgs[i]; currentImgs[i] = currentImgs[i + 1]; currentImgs[i + 1] = auxImg;
                        auxImgSelection = currentImgsList[i]; currentImgsList[i] = currentImgsList[i + 1]; currentImgsList[i + 1] = auxImgSelection;
                    }
                N--;


            }
        }

        public static Table customTable1(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {



            float[] dim = appearance.getDimensions();
            foreach (float f in appearance.getDimensions())
                Console.WriteLine(f);
            Table table = new Table(dim, false);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            Cell cell1 = new Cell();
            Cell cell2 = new Cell(2, 1);
            Cell cell3 = new Cell();




            cell1.Add(currentImgs.ElementAt(0));
            cell1.SetHeight(table.GetHeight().GetValue() - 4.666f);
            cell1.SetPaddingTop(40);
            cell1.SetPaddingBottom(40);
            cell1.SetWidth(UnitValue.CreatePercentValue(40f));
            currentImgs.ElementAt(0).SetHorizontalAlignment(HorizontalAlignment.RIGHT);
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            cell2.SetHeight(table.GetHeight().GetValue() - 4.666f);
            cell2.SetWidth(UnitValue.CreatePercentValue(20f));

            Cell cell4 = new Cell();
            Cell cell5 = new Cell();

            cell4.SetHeight((table.GetHeight().GetValue() - 4.666f) / 2);
            cell4.SetWidth(UnitValue.CreatePercentValue(20f));

            cell5.SetHeight((table.GetHeight().GetValue() - 4.666f) / 2);
            cell5.SetWidth(UnitValue.CreatePercentValue(20f));


            cell4.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.BOTTOM);

            cell5.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.TOP);

            cell2.Add(cell4);
            cell2.Add(cell5);




            cell3.SetWidth(UnitValue.CreatePercentValue(40f));
            cell3.Add(currentImgs.ElementAt(3));
            cell3.SetHeight(table.GetHeight().GetValue() - 4.666f);
            cell3.SetPaddingTop(40);
            cell3.SetPaddingBottom(40);
            cell3.SetHorizontalAlignment(HorizontalAlignment.LEFT);
            currentImgs.ElementAt(3).SetHorizontalAlignment(HorizontalAlignment.LEFT);
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);




            table.AddCell(cell1);
            table.AddCell(cell2);
            table.AddCell(cell3);


            return table;
        }



        public static Table customTable2(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();
            foreach (float f in appearance.getDimensions())
                Console.WriteLine(f);
            Table table = new Table(dim, false);

            sorting(currentImgsList, currentImgs);


            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));




            Table table2 = new Table(new float[] { 1, 1 }, false);

            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));
            table2.UseAllAvailableWidth();
            Cell cell1 = new Cell(2, 1);
            cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));


            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));
            cell3.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));
            cell3.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);



            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));
            cell5.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 4));
            cell5.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));
            cell6.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 4));
            cell6.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            table2.AddCell(cell5);
            table2.AddCell(cell6);

            cell1.Add(cell3);
            cell1.Add(table2);

            Cell cell2 = new Cell();
            cell2.SetHeight(table.GetHeight());
            cell2.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));
            cell2.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);





            table.AddCell(cell1);
            table.AddCell(cell2);

            return table;

        }


        public static Table customTable3(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {

            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));

            for (int i = 0; i < appearance.getHeightRatio() + 1; i++)
            {
                for (int j = 0; j < appearance.getDimensions().Length; j++)
                {
                    Cell cell = new Cell();

                    cell.SetHeight(table.GetHeight().GetValue() / appearance.getHeightRatio() - 4.666f);



                    cell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                    cell.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                    cell.SetVerticalAlignment(VerticalAlignment.MIDDLE);

                    table.AddCell(cell);

                }
            }
            if (appearance.specialCond == "21x15_2P2L")
            {
                table.GetCell(0, 0).Add(currentImgs.ElementAt(2).SetAutoScale(true));
                table.GetCell(0, 1).Add(currentImgs.ElementAt(3).SetAutoScale(true));
                table.GetCell(1, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                table.GetCell(1, 1).Add(currentImgs.ElementAt(1).SetAutoScale(true));


            }
            if (appearance.specialCond == "21x15_1P3L")
            {
                table.GetCell(0, 0).Add(currentImgs.ElementAt(3).SetAutoScale(true));
                table.GetCell(0, 1).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                table.GetCell(1, 0).Add(currentImgs.ElementAt(1).SetAutoScale(true));
                table.GetCell(1, 1).Add(currentImgs.ElementAt(2).SetAutoScale(true));


            }
            if (appearance.specialCond == "21x15_0P4L")
            {
                table.GetCell(0, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                table.GetCell(0, 1).Add(currentImgs.ElementAt(1).SetAutoScale(true));
                table.GetCell(1, 0).Add(currentImgs.ElementAt(2).SetAutoScale(true));
                table.GetCell(1, 1).Add(currentImgs.ElementAt(3).SetAutoScale(true));


            }

            if(appearance.specialCond == "reminder")
            {
                if(appearance.getImgNumber() != 6)
                {
                    switch (currentImgs.Count)
                    {
                        case 1: table.GetCell(0, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true)); break;
                        case 2:
                            table.GetCell(0, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                            table.GetCell(0, 1).Add(currentImgs.ElementAt(1).SetAutoScale(true)); break;
                        case 3:
                            table.GetCell(0, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                            table.GetCell(0, 1).Add(currentImgs.ElementAt(1).SetAutoScale(true));
                            table.GetCell(1, 0).Add(currentImgs.ElementAt(2).SetAutoScale(true)); break;
                        default: break;
                    }
                }
                else
                {
                    switch (currentImgs.Count)
                    {
                        case 1: table.GetCell(0, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true)); break;
                        case 2:
                            table.GetCell(0, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                            table.GetCell(0, 1).Add(currentImgs.ElementAt(1).SetAutoScale(true)); break;
                        case 3:
                            table.GetCell(0, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                            table.GetCell(0, 1).Add(currentImgs.ElementAt(1).SetAutoScale(true));
                            table.GetCell(1, 0).Add(currentImgs.ElementAt(2).SetAutoScale(true)); break;
                        case 4:
                            table.GetCell(0, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                            table.GetCell(0, 1).Add(currentImgs.ElementAt(1).SetAutoScale(true));
                            table.GetCell(1, 0).Add(currentImgs.ElementAt(2).SetAutoScale(true));
                            table.GetCell(1, 1).Add(currentImgs.ElementAt(3).SetAutoScale(true)); break;
                        case 5:
                            table.GetCell(0, 0).Add(currentImgs.ElementAt(0).SetAutoScale(true));
                            table.GetCell(0, 1).Add(currentImgs.ElementAt(1).SetAutoScale(true));
                            table.GetCell(1, 0).Add(currentImgs.ElementAt(2).SetAutoScale(true));
                            table.GetCell(1, 1).Add(currentImgs.ElementAt(3).SetAutoScale(true));
                            pdoc.Add(table);
                            pdoc.Add(new AreaBreak(iText.Layout.Properties.AreaBreakType.NEXT_PAGE));

                            table = new Table(dim, true);
                            table.UseAllAvailableWidth().SetDocument(pdoc);
                            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));

                            for (int i = 0; i < appearance.getHeightRatio() + 1; i++)
                            {
                                for (int j = 0; j < appearance.getDimensions().Length; j++)
                                {
                                    Cell cell = new Cell();

                                    cell.SetHeight(table.GetHeight().GetValue() / appearance.getHeightRatio() - 4.666f);



                                    cell.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
                                    cell.SetHorizontalAlignment(HorizontalAlignment.CENTER);
                                    cell.SetVerticalAlignment(VerticalAlignment.MIDDLE);

                                    table.AddCell(cell);

                                }
                            }

                            table.GetCell(0, 0).Add(currentImgs.ElementAt(4).SetAutoScale(true));break;



                        default: break;
                    }
                    
                }

                
            }

            return table;
        }

        public static Table customTable4(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));


            Cell cell1 = new Cell(2, 1);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue()));
            Table table2 = new Table(new float[] { 1, 1 }, false);

            table2.SetHeight(UnitValue.CreatePercentValue(40f));
            table2.UseAllAvailableWidth();

            Cell cell3 = new Cell();
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell3.SetWidth(UnitValue.CreatePercentValue(75f));
            cell3.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell cell4 = new Cell();
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell4.SetWidth(UnitValue.CreatePercentValue(25f));
            cell4.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            table2.AddCell(cell3);
            table2.AddCell(cell4);

            cell1.Add(table2);

            Cell cell2 = new Cell();
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell2.SetHeight(UnitValue.CreatePercentValue(60f));
            cell2.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue()));

            cell2.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            cell2.SetPaddingLeft(30f);
            cell2.SetPaddingRight(30f);

            cell1.Add(cell2);

            table.AddCell(cell1);



            return table;
        }


        public static Table customTable5(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));



            Cell cell1 = new Cell(2, 1);
            Cell cell2 = new Cell();
            Cell cell3 = new Cell();
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue()));
            Table table2 = new Table(new float[] { 1, 1 }, false);

            table2.SetHeight(UnitValue.CreatePercentValue(70f));
            table2.UseAllAvailableWidth();

            cell2.SetWidth(UnitValue.CreatePercentValue(50f));
            cell2.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            cell3.SetWidth(UnitValue.CreatePercentValue(50f));
            cell3.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            table2.AddCell(cell2);
            table2.AddCell(cell3);


            Cell cell4 = new Cell();

            cell4.SetHeight(UnitValue.CreatePercentValue(30f));
            cell4.SetPaddingLeft(60f);
            cell4.SetPaddingRight(60f);
            cell4.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            cell1.Add(table2);
            cell1.Add(cell4);

            table.AddCell(cell1);

            return table;
        }

        public static Table customTable6(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));



            Cell cell1 = new Cell(2, 1);
            Cell cell2 = new Cell();
            Cell cell3 = new Cell();
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue()));
            Table table2 = new Table(new float[] { 1, 1 }, false);

            table2.SetHeight(UnitValue.CreatePercentValue(30f));
            table2.UseAllAvailableWidth();

            cell2.SetWidth(UnitValue.CreatePercentValue(30f));
            cell2.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            cell3.SetWidth(UnitValue.CreatePercentValue(30f));
            cell3.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            table2.AddCell(cell2);
            table2.AddCell(cell3);

            Cell cell4 = new Cell();
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.SetHeight(UnitValue.CreatePercentValue(70f));
            cell4.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            cell1.Add(cell4);
            cell1.Add(table2);

            table.AddCell(cell1);


            return table;
        }

        public static Table customTable7(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));


            Cell cell1 = new Cell();
            cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePercentValue(72.72f));

            currentImgs.ElementAt(0).SetAutoScale(true);
            cell1.Add(currentImgs.ElementAt(0));
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell cell2 = new Cell();
            cell2.SetHeight(table.GetHeight());
            cell2.SetWidth(UnitValue.CreatePercentValue(27.27f));

            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));
            cell3.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));
            cell4.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            cell3.SetVerticalAlignment(VerticalAlignment.BOTTOM);
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            cell2.Add(cell3);
            cell2.Add(cell4);

            table.AddCell(cell1);
            table.AddCell(cell2);

            return table;
        }

        public static Table customTable8(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));


            Cell cell1 = new Cell();
            cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePercentValue(50f));

            Cell cell2 = new Cell();
            cell2.SetHeight(table.GetHeight());
            cell2.SetWidth(UnitValue.CreatePercentValue(50f));


            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.66f));
            cell3.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.33f));
            cell4.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.66f));
            cell5.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.33f));
            cell6.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell1.Add(cell3);
            cell1.Add(cell4);

            cell2.Add(cell5);
            cell2.Add(cell6);

            table.AddCell(cell1);
            table.AddCell(cell2);

            return table;
        }

        public static Table customTable9(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
        float[] dim = appearance.getDimensions();

        Table table = new Table(dim, true);

        sorting(currentImgsList, currentImgs);
        table.UseAllAvailableWidth().SetDocument(pdoc);

        table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));


        Cell cell1 = new Cell();
        cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePercentValue(50f));

            Cell cell2 = new Cell();
        cell2.SetHeight(table.GetHeight());
            cell2.SetWidth(UnitValue.CreatePercentValue(50f));


            Cell cell3 = new Cell();
        cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() *0.66f));
            cell3.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            Cell cell4 = new Cell();
        cell4.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() *0.33f));
            cell4.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell cell5 = new Cell();
        cell5.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() *0.66f));
            cell5.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            
            Cell cell6 = new Cell();
        cell6.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() *0.33f));
            cell6.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell1.Add(cell3);
            cell1.Add(cell4);
            
            cell2.Add(cell5);
            cell2.Add(cell6);

            table.AddCell(cell1);
            table.AddCell(cell2);

            return table;

        }

        public static Table customTable10(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));


            Cell cell1 = new Cell();
            cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePercentValue(50f));

            Cell cell2 = new Cell();
            cell2.SetHeight(table.GetHeight());
            cell2.SetWidth(UnitValue.CreatePercentValue(50f));


            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.45f));
            cell3.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.TOP);

            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.55f));
            cell4.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.TOP);

            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.55f));
            cell5.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.BOTTOM);

            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.45f));
            cell6.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell6.SetVerticalAlignment(VerticalAlignment.BOTTOM);


            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell1.Add(cell3);
            cell1.Add(cell4);

            cell2.Add(cell5);
            cell2.Add(cell6);

            table.AddCell(cell1);
            table.AddCell(cell2);

            return table;
        }

        public static Table customTable11(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));


            Cell cell1 = new Cell();
            cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePercentValue(50f));

            Cell cell2 = new Cell();
            cell2.SetHeight(table.GetHeight());
            cell2.SetWidth(UnitValue.CreatePercentValue(50f));


            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.3f));
            cell3.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.7f));
            cell4.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.7f));
            cell5.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.3f));
            cell6.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);


            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell1.Add(cell3);
            cell1.Add(cell4);

            cell2.Add(cell5);
            cell2.Add(cell6);

            table.AddCell(cell1);
            table.AddCell(cell2);

            return table;
        }

        public static Table customTable12(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);
            table.UseAllAvailableWidth().SetDocument(pdoc);

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));

            sorting(currentImgsList, currentImgs);

            Cell cell1 = new Cell();
            cell1.SetHeight(table.GetHeight());
            cell1.SetWidth(UnitValue.CreatePercentValue(50f));

            Cell cell2 = new Cell();
            cell2.SetHeight(table.GetHeight());
            cell2.SetWidth(UnitValue.CreatePercentValue(50f));


            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.3f));
            cell3.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            

            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.7f));
            cell4.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.7f));
            cell5.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);

            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.3f));
            cell6.Add(currentImgs.ElementAt(3).SetAutoScale(true));

            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell1.Add(cell3);
            cell1.Add(cell4);

            cell2.Add(cell5);
            cell2.Add(cell6);

            table.AddCell(cell1);
            table.AddCell(cell2);

            return table;
        }

        public static Table customTable13(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table2 = new Table(new float[] {1,1 }, true );

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);
           

            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()/2));

            Cell cell1 = new Cell();
            cell1.SetHeight(table2.GetHeight());
            cell1.SetWidth(table2.GetWidth().GetValue()/2);
            cell1.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell1.SetPaddingTop(25f);
            cell1.SetPaddingBottom(25f);

            Cell cell2 = new Cell();
            cell2.SetHeight(table2.GetHeight().GetValue() / 2);
            cell2.SetWidth(table2.GetWidth().GetValue() / 2);
            cell2.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell3 = new Cell();
            cell3.SetHeight(table2.GetHeight().GetValue() / 2);
            cell3.SetWidth(table2.GetWidth().GetValue() / 2);
            cell3.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            
            Cell cell4 = new Cell();
            cell4.SetHeight(table.GetHeight().GetValue() / 2);
            cell4.SetWidth(table.GetWidth().GetValue() / 2);

            cell4.Add(cell2);
            cell4.Add(cell3);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            table2.AddCell(cell1);
            table2.AddCell(cell4);
            table2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell5 = new Cell();
            cell5.SetHeight(table2.GetHeight().GetValue());
            cell5.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell6 = new Cell();
            cell6.SetHeight(table2.GetHeight().GetValue());
            cell6.Add(table2);
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            
            table.AddCell(cell6);

            table.AddCell(cell5);



            return table;
        }

        public static Table customTable14(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table2 = new Table(new float[] { 1, 1 }, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));

            Cell cell1 = new Cell();
            cell1.SetHeight(table2.GetHeight());
            cell1.SetWidth(table2.GetWidth().GetValue() / 2);
            cell1.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            

            Cell cell2 = new Cell();
            cell2.SetHeight(table2.GetHeight().GetValue() *0.35f);
            cell2.SetWidth(table2.GetWidth().GetValue() / 2);
            cell2.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell3 = new Cell();
            cell3.SetHeight(table2.GetHeight().GetValue() * 0.65f);
            cell3.SetWidth(table2.GetWidth().GetValue() / 2);
            cell3.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell4 = new Cell();
            cell4.SetHeight(table.GetHeight().GetValue() / 2);
            cell4.SetWidth(table.GetWidth().GetValue() / 2);

            cell4.Add(cell2);
            cell4.Add(cell3);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            table2.AddCell(cell1);
            table2.AddCell(cell4);
            table2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell5 = new Cell();
            cell5.SetHeight(table2.GetHeight().GetValue());
            cell5.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell6 = new Cell();
            cell6.SetHeight(table2.GetHeight().GetValue());
            cell6.Add(table2);
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            

            table.AddCell(cell5);
            table.AddCell(cell6);


            return table;
        }

        public static Table customTable15(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table2 = new Table(new float[] { 1, 1, 1}, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() / 2));

            Cell cell1 = new Cell();
            cell1.SetHeight(table2.GetHeight());
            cell1.SetWidth(table2.GetWidth().GetValue() / 3);
            cell1.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell1.SetVerticalAlignment(VerticalAlignment.TOP);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell2 = new Cell();
            cell2.SetHeight(table2.GetHeight().GetValue());
            cell2.SetWidth(table2.GetWidth().GetValue() / 3);
            cell2.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell3 = new Cell();
            cell3.SetHeight(table2.GetHeight().GetValue());
            cell3.SetWidth(table2.GetWidth().GetValue() / 3);
            cell3.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.BOTTOM);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

           

            table2.AddCell(cell1);
            table2.AddCell(cell2);
            table2.AddCell(cell3);
            table2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell5 = new Cell();
            cell5.SetHeight(table2.GetHeight().GetValue());
            cell5.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell6 = new Cell();
            cell6.SetHeight(table2.GetHeight().GetValue());
            cell6.Add(table2);
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);



            table.AddCell(cell6);
            table.AddCell(cell5);


            return table;
        }
        public static Table customTable16(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table2 = new Table(new float[] { 1, 1}, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.2f) );

            Cell cell1 = new Cell();
            cell1.SetHeight(table.GetHeight().GetValue() * 0.3f);
            cell1.SetWidth(table2.GetWidth().GetValue());
            cell1.SetPaddingLeft(30);
            cell1.SetPaddingRight(30);
            cell1.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell2 = new Cell();
            cell2.SetHeight(table2.GetHeight().GetValue());
            cell2.SetWidth(table2.GetWidth().GetValue() / 2);
            cell2.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell3 = new Cell();
            cell3.SetHeight(table2.GetHeight().GetValue());
            cell3.SetWidth(table2.GetWidth().GetValue() / 2);
            cell3.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);



            table2.AddCell(cell2);
            table2.AddCell(cell3);
            table2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell5 = new Cell();
            cell5.SetHeight(table.GetHeight().GetValue() * 0.5f);
            cell5.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.SetPaddingLeft(15);
            cell5.SetPaddingRight(15);
            Cell cell6 = new Cell();
            cell6.SetHeight(table2.GetHeight().GetValue());
            cell6.Add(table2);
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);



            table.AddCell(cell1);
            table.AddCell(cell5);
            table.AddCell(cell6);


            return table;
        }

        public static Table customTable17(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table2 = new Table(new float[] { 1, 1 }, true);
            Table table3 = new Table(new float[] { 1, 1 }, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.5f));
            table3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.5f));

            Cell cell1 = new Cell();
            cell1.SetHeight(table2.GetHeight().GetValue());
            cell1.SetWidth(table2.GetWidth().GetValue()/2);
            cell1.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell2 = new Cell();
            cell2.SetHeight(table2.GetHeight().GetValue());
            cell2.SetWidth(table2.GetWidth().GetValue() / 2);
            cell2.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

        
            table2.AddCell(cell1);
            table2.AddCell(cell2);
            table2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);




            Cell cell3 = new Cell();
            cell3.SetHeight(table2.GetHeight().GetValue());
            cell3.SetWidth(table2.GetWidth().GetValue() / 2);
            cell3.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell4 = new Cell();
            cell4.SetHeight(table2.GetHeight().GetValue());
            cell4.SetWidth(table2.GetWidth().GetValue() / 2);
            cell4.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            table3.AddCell(cell3);
            table3.AddCell(cell4);
            table3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell6 = new Cell();
            cell6.SetHeight(table2.GetHeight().GetValue());
            cell6.Add(table2);
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.SetPaddingTop(15);
            cell6.SetPaddingBottom(15);


            Cell cell7 = new Cell();
            cell7.SetHeight(table2.GetHeight().GetValue());
            cell7.Add(table3);
            cell7.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell7.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell7.SetPaddingTop(15);
            cell7.SetPaddingBottom(15);


            table.AddCell(cell6);
            table.AddCell(cell7);


            return table;
        }

        public static Table customTable18(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table2 = new Table(new float[] { 3, 1 }, true);
            Table table3 = new Table(new float[] { 1, 1 }, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.5f));
            table3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.5f));


            Cell cell1 = new Cell();
            cell1.SetHeight(table2.GetHeight().GetValue());
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell2 = new Cell();
            cell2.SetHeight(table2.GetHeight().GetValue());
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell3 = new Cell();
            cell3.SetHeight(table2.GetHeight().GetValue()*0.4f);
            cell3.SetWidth(table2.GetWidth().GetValue() );
            cell3.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell4 = new Cell();
            cell4.SetHeight(table2.GetHeight().GetValue() * 0.6f);
            cell4.SetWidth(table2.GetWidth().GetValue());
            cell4.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            cell1.Add(cell3);
            cell1.Add(cell4);


            Cell cell5 = new Cell();
            cell5.SetHeight(table2.GetHeight().GetValue() *0.45f);
            cell5.SetWidth(table2.GetWidth().GetValue());
            cell5.Add(currentImgs.ElementAt(2).SetAutoScale(true));
            cell5.SetVerticalAlignment(VerticalAlignment.BOTTOM);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.SetPaddingTop(10);


            Cell cell6 = new Cell();
            cell6.SetHeight(table2.GetHeight().GetValue() * 0.45f);
            cell6.SetWidth(table2.GetWidth().GetValue());
            cell6.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell6.SetVerticalAlignment(VerticalAlignment.BOTTOM);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.SetPaddingTop(10);


            cell2.Add(cell5);
            cell2.Add(cell6);

            table2.AddCell(cell1);
            table2.AddCell(cell2);
            table2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);





            Cell cell7 = new Cell();
            cell7.SetHeight(table3.GetHeight().GetValue());
            cell7.SetWidth(table3.GetWidth().GetValue() / 2);
            cell7.Add(currentImgs.ElementAt(4).SetAutoScale(true));
            cell7.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell7.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell8 = new Cell();
            cell8.SetHeight(table3.GetHeight().GetValue());
            cell8.SetWidth(table3.GetWidth().GetValue() / 2);
            cell8.Add(currentImgs.ElementAt(5).SetAutoScale(true));
            cell8.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell8.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            table3.AddCell(cell7);
            table3.AddCell(cell8);
            table3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            Cell cell9 = new Cell();
            cell9.SetHeight(table.GetHeight().GetValue()/2);
            cell9.Add(table2);
            cell9.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell9.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            


            Cell cell10 = new Cell();
            cell10.SetHeight(table.GetHeight().GetValue()/2);
            cell10.Add(table3);
            cell10.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell10.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
           


            table.AddCell(cell9);
            table.AddCell(cell10);


            return table;
        }


        public static Table customTable19(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table2 = new Table(new float[] { 1 }, true);
            Table table3 = new Table(new float[] { 1 }, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            table3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));


            Cell cell1 = new Cell();
            cell1.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue()*0.27f));
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell1.Add(currentImgs.ElementAt(0).SetAutoScale(true));

            Cell cell2 = new Cell();
            cell2.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.46f)); 
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.Add(currentImgs.ElementAt(5).SetAutoScale(true));

            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.27f));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.Add(currentImgs.ElementAt(3).SetAutoScale(true));

            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.30f));
            cell4.SetVerticalAlignment(VerticalAlignment.BOTTOM);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.Add(currentImgs.ElementAt(1).SetAutoScale(true));

            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.40f));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.Add(currentImgs.ElementAt(2).SetAutoScale(true));

            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.30f));
            cell6.SetVerticalAlignment(VerticalAlignment.TOP);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.Add(currentImgs.ElementAt(4).SetAutoScale(true));

            table2.AddCell(cell1);
            table2.AddCell(cell2);
            table2.AddCell(cell3);


            table3.AddCell(cell4);
            table3.AddCell(cell5);
            table3.AddCell(cell6);


            Cell cell7 = new Cell();
            cell7.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            cell7.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue()/2));
            cell7.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell8 = new Cell();
            cell8.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            cell8.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));
            cell8.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            table2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            table3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell7.Add(table2);
            cell8.Add(table3);


            table.AddCell(cell7);
            table.AddCell(cell8);


            return table;
        }

        public static Table customTable20(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table2 = new Table(new float[] { 1 }, true);
            Table table3 = new Table(new float[] { 1 }, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            table3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));


            Cell cell1 = new Cell();
            cell1.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.40f));
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell1.Add(currentImgs.ElementAt(4).SetAutoScale(true));

            Cell cell2 = new Cell();
            cell2.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.30f));
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.Add(currentImgs.ElementAt(0).SetAutoScale(true));

            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.30f));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.Add(currentImgs.ElementAt(1).SetAutoScale(true));

            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.40f));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.Add(currentImgs.ElementAt(5).SetAutoScale(true));

            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.30f));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.Add(currentImgs.ElementAt(2).SetAutoScale(true));

            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.30f));
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.Add(currentImgs.ElementAt(3).SetAutoScale(true));

            table2.AddCell(cell1);
            table2.AddCell(cell2);
            table2.AddCell(cell3);


            table3.AddCell(cell4);
            table3.AddCell(cell5);
            table3.AddCell(cell6);


            Cell cell7 = new Cell();
            cell7.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            cell7.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));
            cell7.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell8 = new Cell();
            cell8.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            cell8.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));
            cell8.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            table2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            table3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell7.Add(table2);
            cell8.Add(table3);


            table.AddCell(cell7);
            table.AddCell(cell8);


            return table;
        }

        public static Table customTable21(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table2 = new Table(new float[] { 1.15f,0.85f }, true);
            Table table3 = new Table(new float[] { 1,1 }, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.75f));
            table3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.25f));


            Cell cell1 = new Cell();
            cell1.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.5f));
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell1.Add(currentImgs.ElementAt(3).SetAutoScale(true));

            Cell cell2 = new Cell();
            cell2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.25f));
            cell2.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));
            cell2.SetPaddingRight(45);
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            currentImgs.ElementAt(0).SetHorizontalAlignment(HorizontalAlignment.LEFT);
            cell2.Add(currentImgs.ElementAt(0).SetAutoScale(true));

            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.25f));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.Add(currentImgs.ElementAt(1).SetAutoScale(true));

            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.5f));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.Add(currentImgs.ElementAt(4).SetAutoScale(true));

            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() * 0.5f));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.Add(currentImgs.ElementAt(5).SetAutoScale(true));

            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.25f));
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.Add(currentImgs.ElementAt(2).SetAutoScale(true));

          
            Cell cell7 = new Cell();
            cell7.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue()));
            cell7.SetWidth(UnitValue.CreatePointValue(table2.GetWidth().GetValue()));
            cell7.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            cell7.Add(cell1);
            cell7.Add(cell2);

            Cell cell8 = new Cell();
            cell8.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue()));
            cell8.SetWidth(UnitValue.CreatePointValue(table2.GetWidth().GetValue()));
            cell8.SetBorder(iText.Layout.Borders.Border.NO_BORDER);


            cell8.Add(cell4);
            cell8.Add(cell5);


            table2.AddCell(cell7);
            table2.AddCell(cell8);
            table2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell9 = new Cell();
            cell9.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue()));
            cell9.SetWidth(UnitValue.CreatePointValue(table2.GetWidth().GetValue()));
            cell9.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell9.Add(table2);

            Cell cell10 = new Cell();
            cell10.SetHeight(UnitValue.CreatePointValue(table3.GetHeight().GetValue()));
            cell10.SetWidth(UnitValue.CreatePointValue(table3.GetWidth().GetValue()));
            cell10.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            table3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            table3.AddCell(cell3);
            table3.AddCell(cell6);

            cell10.Add(table3);

            table.AddCell(cell9);
            table.AddCell(cell10);


            return table;
        }

        public static Table customTable22(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));


            Cell cell1 = new Cell();
            cell1.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.35f));
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell1.Add(currentImgs.ElementAt(2).SetAutoScale(true));

            Cell cell2 = new Cell();
            cell2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.35f));
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.Add(currentImgs.ElementAt(3).SetAutoScale(true));

            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.30f));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.Add(currentImgs.ElementAt(0).SetAutoScale(true));


            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell4.Add(cell1);
            cell4.Add(cell2);
            cell4.Add(cell3);


            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.35f));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.Add(currentImgs.ElementAt(4).SetAutoScale(true));

            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.35f));
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.Add(currentImgs.ElementAt(5).SetAutoScale(true));

            Cell cell7 = new Cell();
            cell7.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.30f));
            cell7.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell7.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell7.Add(currentImgs.ElementAt(1).SetAutoScale(true));


            Cell cell8 = new Cell();
            cell8.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            cell8.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell8.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell8.Add(cell5);
            cell8.Add(cell6);
            cell8.Add(cell7);



            table.AddCell(cell4);
            table.AddCell(cell8);


            return table;
        }

        public static Table customTable23(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);
            Table table2 = new Table(new float[] { 1 }, true);
            Table table3 = new Table(new float[] { 1 }, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));
            table2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            table3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));

            Cell cell1 = new Cell();
            cell1.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() /3));
            cell1.SetVerticalAlignment(VerticalAlignment.TOP);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell1.Add(currentImgs.ElementAt(0).SetAutoScale(true));

            Cell cell2 = new Cell();
            cell2.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() / 3));
            cell2.SetVerticalAlignment(VerticalAlignment.TOP);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.Add(currentImgs.ElementAt(1).SetAutoScale(true));

            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() / 3));
            cell3.SetVerticalAlignment(VerticalAlignment.TOP);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.Add(currentImgs.ElementAt(2).SetAutoScale(true));


            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() / 3));
            cell4.SetVerticalAlignment(VerticalAlignment.BOTTOM);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell4.Add(currentImgs.ElementAt(3).SetAutoScale(true));

            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() / 3));
            cell5.SetVerticalAlignment(VerticalAlignment.BOTTOM);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.Add(currentImgs.ElementAt(4).SetAutoScale(true));

            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table2.GetHeight().GetValue() / 3));
            cell6.SetVerticalAlignment(VerticalAlignment.BOTTOM);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.Add(currentImgs.ElementAt(5).SetAutoScale(true));

            table2.AddCell(cell1);
            table2.AddCell(cell2);
            table2.AddCell(cell3);


            table3.AddCell(cell4);
            table3.AddCell(cell5);
            table3.AddCell(cell6);


            Cell cell7 = new Cell();
            cell7.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            cell7.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));
            cell7.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            Cell cell8 = new Cell();
            cell8.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            cell8.SetWidth(UnitValue.CreatePointValue(table.GetWidth().GetValue() / 2));
            cell8.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            table2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            table3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell7.Add(table2);
            cell8.Add(table3);


            table.AddCell(cell7);
            table.AddCell(cell8);


            return table;
        }
        public static Table customTable24(Appearance appearance, PageSize pageSize, Document pdoc, List<ImageSelection> currentImgsList, List<Image> currentImgs)
        {
            float[] dim = appearance.getDimensions();

            Table table = new Table(dim, true);

            sorting(currentImgsList, currentImgs);

            table.UseAllAvailableWidth().SetDocument(pdoc);


            table.SetHeight(UnitValue.CreatePointValue(pageSize.GetHeight() - 17f));


            Cell cell1 = new Cell();
            cell1.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.28f));
            cell1.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell1.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell1.Add(currentImgs.ElementAt(0).SetAutoScale(true));
            cell1.SetPaddingLeft(20);
            cell1.SetPaddingRight(20);

            Cell cell2 = new Cell();
            cell2.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.28f));
            cell2.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell2.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell2.Add(currentImgs.ElementAt(1).SetAutoScale(true));
            cell2.SetPaddingLeft(20);
            cell2.SetPaddingRight(20);

            Cell cell3 = new Cell();
            cell3.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.44f));
            cell3.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell3.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell3.Add(currentImgs.ElementAt(2).SetAutoScale(true));


            Cell cell4 = new Cell();
            cell4.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            cell4.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell4.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell4.Add(cell1);
            cell4.Add(cell2);
            cell4.Add(cell3);


            Cell cell5 = new Cell();
            cell5.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.28f));
            cell5.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell5.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell5.Add(currentImgs.ElementAt(3).SetAutoScale(true));
            cell5.SetPaddingLeft(20);
            cell5.SetPaddingRight(20);


            Cell cell6 = new Cell();
            cell6.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.28f));
            cell6.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell6.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell6.Add(currentImgs.ElementAt(4).SetAutoScale(true));
            cell6.SetPaddingLeft(20);
            cell6.SetPaddingRight(20);


            Cell cell7 = new Cell();
            cell7.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue() * 0.44f));
            cell7.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell7.SetBorder(iText.Layout.Borders.Border.NO_BORDER);
            cell7.Add(currentImgs.ElementAt(5).SetAutoScale(true));


            Cell cell8 = new Cell();
            cell8.SetHeight(UnitValue.CreatePointValue(table.GetHeight().GetValue()));
            cell8.SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell8.SetBorder(iText.Layout.Borders.Border.NO_BORDER);

            cell8.Add(cell5);
            cell8.Add(cell6);
            cell8.Add(cell7);



            table.AddCell(cell4);
            table.AddCell(cell8);


            return table;
        }
    }
    
    }
