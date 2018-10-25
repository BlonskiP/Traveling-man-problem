using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using System.Runtime.InteropServices;

namespace Traveling_salesman_problem
{
    class ExcelManager
    {
        ~ExcelManager(){
           close();
        }
        public ExcelManager(string filename)
        {
            this.filename = filename;
            this.location = AppDomain.CurrentDomain.BaseDirectory;
        }

        private string location;
        private string filename;
        public Application ExcelApp;
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

            workbook.SaveAs(AppDomain.CurrentDomain.BaseDirectory+filename+".xls" ,XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            


        }

        private void setup(Worksheet workSheet)
        {
            // X Y
            // X - wiersze Y- kolumny
            workSheet.Cells[1, 1] = "Ilosc wierzchołków";
            workSheet.Cells[1, 2] = "Brute Force";
            workSheet.Cells[1, 3] = "DynamicProgrammin";
            workSheet.Cells[1, 4] = "B&B";
            workSheet.Cells[2, 1] = "5";
            workSheet.Cells[3, 1] = "8";
            workSheet.Cells[4, 1] = "10";
            workSheet.Cells[5, 1] = "12";
            workSheet.Cells[6, 1] = "14";
            workSheet.Cells[7, 1] = "16";


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
            workSheet.Cells[x, y] = change.ToString();
        }
    }
}

