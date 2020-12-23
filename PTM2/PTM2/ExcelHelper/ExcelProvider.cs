using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;

namespace PTM2.ExcelHelper
{
    class ExcelProvider
    {
        //ПОЛЯ
        #region
        Regex intPattern = new Regex(@"\d+");
        Regex datepattern = new Regex(@"\d{1,2}\.\d{1,2}\.\d{2,4}$");

        public Excel.Application EXapp = new Excel.Application();
        public Excel.Range EXcells;
        public Excel.Workbooks EXappworkbooks;
        public Excel.Workbook EXappworkbook;
        public Excel.Worksheet EXworksheet;
        public Excel.Sheets EXsheets;
        #endregion

        /// <summary>
        /// Открываем файл в разных режимах
        /// </summary>
        /// <param name="o"></param>
        public void OpenExcelFile(string fileName, bool visible)
        {


            if (File.Exists(fileName))
            {
                bool retry = true;      //своебразный костыль     
                do                      //при открытии разных версий эксель
                {                       //разними версимя офиса
                    try                 //возможно возникновение ошибки из-за предложения сохранить формулы
                    {               //этот костыль это перекрывает
                        //открытие в видимом режиме
                        EXapp.Visible = visible;
                        EXappworkbooks = EXapp.Workbooks;
                        retry = false;
                    }
                    catch
                    {
                        Thread.Sleep(10);
                    }
                } while (retry);
                //пробуем отрыть файл
                try
                {
                    EXappworkbook = EXapp.Workbooks.Open(fileName,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                    EXsheets = EXappworkbook.Worksheets;
                    EXworksheet = (Excel.Worksheet)EXsheets.get_Item(1);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Не удалось открыть файл: " + fileName+"\n"+e.Message);
                }
            }
            else
            {
                MessageBox.Show("Неверное имя файла:  " + fileName, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                throw new FileNotFoundException();
            }
        }

        /// <ОТКРЫТЬ INVIS READ>
        /// Открываем файл в невидимом режиме только для чтения
        /// </summary>
        /// <param name="o"></param>
        public void OpenExcelFileInvisibleReadOnly(string fileName)
        {
            //string INfileName="";
            try
            {
                //INfileName = o as string;
                if (File.Exists(fileName))
                {

                    //открытие в невидимом режиме
                    EXapp.Visible = false;
                    EXappworkbooks = EXapp.Workbooks;

                    //пробуем отрыть файл
                    EXappworkbook = EXapp.Workbooks.Open(fileName,
                    Type.Missing, true, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);

                    EXsheets = EXappworkbook.Worksheets;
                    EXworksheet = (Excel.Worksheet)EXsheets.get_Item(1);
                }

                else
                {

                    throw new FileNotFoundException();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии файла:" + fileName, "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void WriteTOcell(string CellNumber, string value, int Fsize = 10, string Fname = "Arial", bool FBold = false, bool borders = false)
        {

            EXcells = EXworksheet.get_Range(CellNumber, Type.Missing);
            EXcells.Font.Size = Fsize;
            EXcells.Font.Name = Fname;
            EXcells.Font.Bold = FBold;
            if (borders)
            {
                EXcells.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous; // внутренние вертикальные
                EXcells.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous; // внутренние горизонтальные            
                EXcells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                EXcells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                EXcells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                EXcells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            EXcells.Value2 = value;
        }

        public void WriteTOcell(string CellNumber, string collNumber2, string value, int Fsize, string Fname, bool FBold, bool borders)
        {

            EXcells = EXworksheet.get_Range(CellNumber, collNumber2);
            EXcells.Merge(Type.Missing);
            if (borders)
            {
                EXcells.Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlContinuous; // внутренние вертикальные
                EXcells.Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlContinuous; // внутренние горизонтальные            
                EXcells.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous; // верхняя внешняя
                EXcells.Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlContinuous; // правая внешняя
                EXcells.Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlContinuous; // левая внешняя
                EXcells.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            EXcells.Font.Size = Fsize;
            EXcells.Font.Name = Fname;
            EXcells.Font.Bold = FBold;
            EXcells.Value2 = value;
        }
        public void WriteTOcell(string CellNumber, string value, string note)
        {

            EXcells = EXworksheet.get_Range(CellNumber, Type.Missing);
            EXcells.Font.Size = 10;
            EXcells.Font.Name = "Arial";
            EXcells.Font.Bold = false;
            EXcells.Value2 = value;
            EXcells.NoteText(note);
        }

        /// <Читаем данные ячейки>
        /// Чтение из ячейки
        ///  Принимает номер ячейки CellNumber"
        public string ReadCell(string CellNumber)
        {
            EXcells = EXworksheet.get_Range(CellNumber, Type.Missing);
            if (EXcells.Value2 != null)
                return Convert.ToString(EXcells.Value2);
            else return "";
        }


        /// <СОХРАНИТЬ и ЗАКРЫТЬ>
        /// Сохраняем и закрываем файл 
        /// </summary>
        public void Save_Close()
        {
            try
            {
                EXappworkbooks = EXapp.Workbooks;
                EXappworkbook = EXapp.Workbooks[1];
                EXappworkbook.Save();
                EXapp.Quit();
            }
            catch
            {
                MessageBox.Show("НЕ УДАЛОСЬ СОХРАНИТЬ И ЗАКРЫТЬ ФАЙЛ!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <ЗАКРЫТЬ ТОЛЬКО>
        /// Закрываем файл без сохранения 
        /// </summary>
        public void CloseWithoutSaving()
        {
            try
            {
                EXappworkbooks = EXapp.Workbooks;
                EXappworkbook = EXapp.Workbooks[1];
                EXapp.Quit();
            }
            catch
            {
                MessageBox.Show("НЕ УДАЛОСЬ ЗАКРЫТЬ ФАЙЛ!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Вставка строки
        /// </summary>
        /// <param name="rowNum"></param>
        public void InsertRow(int rowNum)
        {
            Excel.Range cellRange = (Excel.Range)EXworksheet.Cells[rowNum, 1];
            Excel.Range rowRange = cellRange.EntireRow;
            rowRange.Insert(Excel.XlInsertShiftDirection.xlShiftDown, false);
        }

        /// <ЕХ->DATE>
        /// Возвращает дату полученную из ячейки 
        /// Приенимает строку-номер ячейки
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public DateTime ExcelCellToDate(string cell)
        {
            string tempStr = "";
            try
            {
                object t = ReadCell(cell);
                if (t != null)
                    tempStr = t.ToString();
                if (!string.IsNullOrEmpty(tempStr))
                    return new DateTime(1899, 12, 30).AddDays(int.Parse(tempStr));
                else
                    return new DateTime(1899, 12, 30);
            }
            catch
            {
                string[] split = tempStr.Split(new char[] { ' ', '\t', '\n', ';', ',', '(', ')', '-', '_' });
                foreach (string s in split)
                {
                    Match match = datepattern.Match(s);
                    if (match.Success)
                    {
                        try
                        {
                            return Convert.ToDateTime(s);
                        }
                        catch (Exception)
                        {
                            return new DateTime(1899, 12, 31);
                        }

                    }
                }
            }
            return new DateTime(1899, 12, 30);
        }

        /// <Преобразование данных получаемых из ячейки в INT>
        /// Возвращает ЦЕЛОЕ из ячейки
        /// По сути проверяет не пуста ли ячейка
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public int ExcelCellToINT(string cell)
        {
            string cellValue = ReadCell(cell);
            if (!string.IsNullOrEmpty(cellValue))
            {
                try
                {
                    return Convert.ToInt32(cellValue);
                }
                catch (Exception)
                {

                    return 0;
                }
            }
            else
                return 0;
        }

        /// <Преобразование данных получаемых из ячейки в DOUBLE>
        /// Возвращает ЦЕЛОЕ из ячейки
        /// По сути проверяет не пуста ли ячейка
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public double ExcelCellToDouble(string cell)
        {
            string cellValue = ReadCell(cell);
            if (!string.IsNullOrEmpty(cellValue))
                try
                {
                    return Convert.ToDouble(cellValue);
                }
                catch
                {
                    return 0;
                }
            return 0;
        }

        /// <summary>
        /// Запись формулы в ячейку
        /// </summary>
        /// <param name="CellNumber"></param>
        /// <param name="formula"></param>
        public void WriteTOcellFormula(string CellNumber, string formula)
        {
            EXcells = EXworksheet.get_Range(CellNumber, Type.Missing);
            EXcells.Select();
            EXcells.Font.Size = 12;
            EXcells.Font.Name = "Arial";
            EXcells.Font.Bold = false;
            EXcells.Formula = formula;
        }

        public bool IsLastLine(int row)
        {
            return row == GetLastLine();
        }

        public long GetLastLine()
        {

            return EXworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
        }

        public long GetLastCollumn()
        {
            return EXworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Column;
        }
    }
}
