using System;
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
            // X Y
            // X - wiersze Y- kolumny
            workSheet.Cells[1, 1] = "Ilosc wierzchołków";
            workSheet.Cells[1, 2] = "Brute Force";
            workSheet.Cells[1, 3] = "DynamicProgrammin";
            workSheet.Cells[1, 4] = "B&B";
            workSheet.Cells[2, 1] = "4";
            workSheet.Cells[3, 1] = "5";
            workSheet.Cells[4, 1] = "6";
            workSheet.Cells[5, 1] = "7";
            workSheet.Cells[6, 1] = "8";
            workSheet.Cells[7, 1] = "9";
            workSheet.Cells[8, 1] = "10";
            workSheet.Cells[9, 1] = "11";
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
            workSheet.Cells[x, y] = Double.Parse(change);

        }
    }
}

