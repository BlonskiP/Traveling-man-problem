﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Traveling_salesman_problem
{
    class ExcelManager
    {
        ~ExcelManager(){
         
        }
        public ExcelManager(string filename)
        {
            this.filename = filename;
            this.location = AppDomain.CurrentDomain.BaseDirectory;
        }

        private string location;
        private string filename;
        public Excel.Application ExcelApp;
        public Workbook workbook;
        public Worksheet workSheet;
        public object misValue = System.Reflection.Missing.Value;
        public void createNewFile()
        {
            ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            if (ExcelApp == null) //check if Excel is installed
            {
                Console.WriteLine("You should install excel");
                return;
            }

            
            workbook = ExcelApp.Workbooks.Add(misValue);
            workSheet = (Worksheet) workbook.Worksheets.get_Item(1);
            setup(workSheet);
            try
            {
                workbook.SaveAs(AppDomain.CurrentDomain.BaseDirectory + filename + ".xls",
                    XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,
                    Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }
            catch (Exception e)
            {
                MessageBox.Show("Zamknij Plik excel / brak dostepu do pliku ");
            }


        }

        private void setup(Worksheet workSheet)
        {
            // y x 
           
            workSheet.Cells[2, 1] = "nazwa pliku";
            workSheet.Cells[3, 1] = "20";
            workSheet.Cells[4, 1] = "40";
            workSheet.Cells[5, 1] = "60";
           
            for(int i=2;i<33;i+=3)
            {
                workSheet.Cells[2, i] = " ftv47.xml";
                workSheet.Cells[2, i + 1] = "bays29.xml";
                workSheet.Cells[2, i + 2] = "ftv170.xml.xml";
            }
           
           
            workSheet.Cells[1, 2] = " tabu 2or";
            workSheet.Cells[1, 5] = " tabu 3or";
            workSheet.Cells[1, 8] = " tabu 1switch";

            workSheet.Cells[1, 11] = " tabu sąsiedzi 2or bez";
            workSheet.Cells[1, 14] = " tabu 3or bez";
            workSheet.Cells[1, 17] = " tabu 1switch bez";


            workSheet.Cells[1, 20] = " Sa 0.9996";
            workSheet.Cells[1, 23] = " sa 0.9997";
            workSheet.Cells[1, 26] = " sa 0.9998";
        }

        public void open() {
            object misValue = System.Reflection.Missing.Value;
            workbook = ExcelApp.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + filename + ".xls", 0, true, 5, "", "", true,
                Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            workSheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
        }
        public void close() {
            workbook.Close(true, misValue, misValue);
            ExcelApp.Quit();
            Marshal.ReleaseComObject(workSheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(ExcelApp);
        }
        public void changeCell(int x, int y, string change)
        {
            workSheet.Cells[y, x] = Double.Parse(change);

        }
    }
}

