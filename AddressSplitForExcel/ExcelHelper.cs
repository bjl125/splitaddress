using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;


namespace AddressSplitForExcel
{
    public class ExcelHelper : IDisposable
    {
        private string fileName = string.Empty;
        private IWorkbook wookbook = null;
        private FileStream fs = null;
        public bool disposed = false;


        public ExcelHelper(string fileName)
        {
            this.fileName = fileName;
            disposed = false;
        }

        public List<string> GetSheetFields(string sheetName)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            List<string> list = new List<string>();
            
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0)
                    wookbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0)
                    wookbook = new HSSFWorkbook(fs);

                if (!String.IsNullOrEmpty(sheetName))
                {
                    sheet = wookbook.GetSheet(sheetName);
                    if (sheet == null)
                    {
                        sheet = wookbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = wookbook.GetSheetAt(0);

                }
                if (sheet != null)
                {
                    IRow firstrow = sheet.GetRow(0);
                    int cellCount = firstrow.LastCellNum;

                    for (int i = firstrow.FirstCellNum; i < cellCount; i++)
                    {
                        ICell cell = firstrow.GetCell(i);
                        if (cell != null)
                        {
                            string cellValue = cell.StringCellValue;
                            if (cellValue != null)
                            {
                                list.Add(cellValue);
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();

            int startrow = 0;
            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                if (fileName.IndexOf(".xlsx") > 0)
                    wookbook = new XSSFWorkbook(fs);
                else if (fileName.IndexOf(".xls") > 0)
                    wookbook = new HSSFWorkbook(fs);

                if (!String.IsNullOrEmpty(sheetName))
                {
                    sheet = wookbook.GetSheet(sheetName);
                    if (sheet == null)
                    {
                        sheet = wookbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = wookbook.GetSheetAt(0);

                }
                if (sheet != null)
                {
                    IRow firstrow = sheet.GetRow(0);
                    int cellCount = firstrow.LastCellNum;

                    if (isFirstRowColumn)
                    {
                        for (int i = firstrow.FirstCellNum; i < cellCount; i++)
                        {
                            ICell cell = firstrow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }

                            }
                        }
                        startrow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startrow = sheet.FirstRowNum;

                    }
                    int rowCount = sheet.LastRowNum;

                    for (int i = startrow; i < rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);

                        if (row == null)
                            continue;

                        DataRow datarow = data.NewRow();

                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null)
                            {
                                datarow[j] = row.GetCell(j).ToString();
                            }
                        }
                        data.Rows.Add(datarow);
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (fs != null)
                        fs.Close();
                }

                fs = null;
                disposed = true;
            }
        }
    }
}
