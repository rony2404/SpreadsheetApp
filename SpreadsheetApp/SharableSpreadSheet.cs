using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SpreadsheetApp
{
    class SharableSpreadSheet
    {
        public List<List<String>> sheet;
        public int rows;
        public int columns;
        Semaphore readersLimit;
        bool isThereReadersLimit;
        Mutex sheetLock;
        List<Semaphore> rowMutexs;
        List<Semaphore> colMutexs;
        List<int> rowCounters;
        List<int> colCounters;
        List<Mutex> rowCountersLock;
        List<Mutex> colCountersLock;
        bool doessheetlock = false;
        Mutex atumic;

        public SharableSpreadSheet(int nRows, int nCols, int nUsers = -1)
        {
            if (nRows <= 0 || nCols <= 0)
                throw new ArgumentOutOfRangeException("Rows and columns needs to be greater than 0.");
            else
            {
                sheet = new List<List<string>>();
                for (int i = 0; i < nRows; i++)
                {
                    sheet.Add(new List<string>());
                    for (int j = 0; j < nCols; j++)
                    {
                        sheet[i].Add(String.Empty);
                    }

                }
                rows = nRows;
                columns = nCols;
                setConcurrentSearchLimit(nUsers);
                rowMutexs = new List<Semaphore>();
                for (int i = 0; i < nRows; i++)
                    rowMutexs.Add(new Semaphore(1, 1));
                colMutexs = new List<Semaphore>();
                for (int i = 0; i < nCols; i++)
                    colMutexs.Add(new Semaphore(1, 1));

                rowCounters = new List<int>();
                for (int i = 0; i < nRows; i++)
                    rowCounters.Add(0);
                colCounters = new List<int>();
                for (int i = 0; i < nCols; i++)
                    colCounters.Add(0);

                rowCountersLock = new List<Mutex>();
                for (int i = 0; i < nRows; i++)
                    rowCountersLock.Add(new Mutex());
                colCountersLock = new List<Mutex>();
                for (int i = 0; i < nCols; i++)
                    colCountersLock.Add(new Mutex());

                sheetLock = new Mutex();
                atumic = new Mutex();
                doessheetlock = false;
            }
        }

        private void inRange(int i, int j)
        {
            if ((i >= rows || i < 0) && (j < 0 || j >= columns))
                throw new ArgumentOutOfRangeException("The indexes are out of range." + i + j);
            else if (i >= rows || i < 0)
                throw new ArgumentOutOfRangeException("The first index is out of range." + i);
            else if (j >= columns || j < 0)
                throw new ArgumentOutOfRangeException("The second index is out of range." + j);
        }
        public String getCell(int row, int col)
        {
            inRange(row, col);
            string ans = String.Empty;
            while (doessheetlock) ;
            rowCountersLock[row].WaitOne();
            rowCounters[row]++;
            if (rowCounters[row] == 1)
            {
                rowMutexs[row].WaitOne();
            }
            rowCountersLock[row].ReleaseMutex();
            ans = sheet[row][col];
            rowCountersLock[row].WaitOne();
            rowCounters[row]--;
            if (rowCounters[row] == 0)
            {
                rowMutexs[row].Release();
            }
            rowCountersLock[row].ReleaseMutex();
            return ans;

        }
        public void setCell(int row, int col, String str)
        {
            inRange(row, col);
            while (doessheetlock) ;
            rowMutexs[row].WaitOne();
            sheet[row][col] = str;
            rowMutexs[row].Release();

        }
        public Tuple<int, int> searchString(String str)
        {
            Tuple<int, int> answer = new Tuple<int, int>(-1, -1);
            bool flag = false;
            while (doessheetlock) ;
            if (isThereReadersLimit == true)
                readersLimit.WaitOne();
            for (int i = 0; i < rows; i++)
            {
                rowCountersLock[i].WaitOne();
                rowCounters[i]++;
                if (rowCounters[i] == 1)
                {
                    rowMutexs[i].WaitOne();
                }
                rowCountersLock[i].ReleaseMutex();
                for (int j = 0; j < columns; j++)
                {
                    if (sheet[i][j] == str)
                    {
                        answer = new Tuple<int, int>(i, j);
                        flag = true;
                        break;
                    }

                }
                rowCountersLock[i].WaitOne();
                rowCounters[i]--;
                if (rowCounters[i] == 0)
                {
                    rowMutexs[i].Release();
                }
                rowCountersLock[i].ReleaseMutex();
                if (flag)
                    break;

            }
            if (isThereReadersLimit == true)
                readersLimit.Release();
            return answer;
        }
        public void exchangeRows(int row1, int row2)
        {
            if (row1 != row2)
            {
                if ((row1 >= rows || row1 < 0) || (row2 < 0 || row2 >= rows))
                    throw new ArgumentOutOfRangeException("index out of range.");
                while (doessheetlock) ;
                atumic.WaitOne();
                rowMutexs[row1].WaitOne();
                rowMutexs[row2].WaitOne();
                atumic.ReleaseMutex();
                string temp;
                for (int i = 0; i < columns; i++)
                {
                    temp = sheet[row1][i];
                    sheet[row1][i] = sheet[row2][i];
                    sheet[row2][i] = temp;
                }
                rowMutexs[row1].Release();
                rowMutexs[row2].Release();

            }

        }
        public void exchangeCols(int col1, int col2)
        {
            if (col1 != col2)
            {
                if ((col1 >= columns || col1 < 0) || (col2 < 0 || col2 >= columns))
                    throw new ArgumentOutOfRangeException("index out of range.");
                while (doessheetlock) ;
                atumic.WaitOne();
                colMutexs[col1].WaitOne();
                colMutexs[col2].WaitOne();
                atumic.ReleaseMutex();
                string temp;
                for (int i = 0; i < rows; i++)
                {
                    rowMutexs[i].WaitOne();
                    temp = sheet[i][col1];
                    sheet[i][col1] = sheet[i][col2];
                    sheet[i][col2] = temp;
                    rowMutexs[i].Release();
                }
                colMutexs[col1].Release();
                colMutexs[col2].Release();

            }



        }
        public int searchInRow(int row, String str)
        {
            if (row < 0 || row >= rows)
                throw new ArgumentOutOfRangeException("Rows index is out of range.");
            int answer = -1;
            while (doessheetlock) ;
            if (isThereReadersLimit)
                readersLimit.WaitOne();
            rowCountersLock[row].WaitOne();
            rowCounters[row]++;
            if (rowCounters[row] == 1)
            {
                rowMutexs[row].WaitOne();
            }
            rowCountersLock[row].ReleaseMutex();
            for (int i = 0; i < columns; i++)
            {
                if (sheet[row][i] == str)
                {
                    answer = i;
                    break;
                }
            }
            rowCountersLock[row].WaitOne();
            rowCounters[row]--;
            if (rowCounters[row] == 0)
            {
                rowMutexs[row].Release();
            }
            rowCountersLock[row].ReleaseMutex();
            if (isThereReadersLimit)
                readersLimit.Release();

            return answer;
        }
        public int searchInCol(int col, String str)
        {
            if (col < 0 || col >= columns)
                throw new ArgumentOutOfRangeException("Column index is out of range.");
            int answer = -1;
            while (doessheetlock) ;

            if (isThereReadersLimit)
                readersLimit.WaitOne();
            colCountersLock[col].WaitOne();
            colCounters[col]++;
            if (colCounters[col] == 1)
                colMutexs[col].WaitOne();
            colCountersLock[col].ReleaseMutex();
            for (int i = 0; i < rows; i++)
            {
                rowCountersLock[i].WaitOne();
                rowCounters[i]++;
                if (rowCounters[i] == 1)
                    rowMutexs[i].WaitOne();
                rowCountersLock[i].ReleaseMutex();
                if (sheet[i][col] == str)
                {
                    answer = i;
                    rowCountersLock[i].WaitOne();
                    rowCounters[i]--;
                    if (rowCounters[i] == 0)
                        rowMutexs[i].Release();
                    rowCountersLock[i].ReleaseMutex();
                    break;
                }
                rowCountersLock[i].WaitOne();
                rowCounters[i]--;
                if (rowCounters[i] == 0)
                    rowMutexs[i].Release();
                rowCountersLock[i].ReleaseMutex();
            }
            colCountersLock[col].WaitOne();
            colCounters[col]--;
            if (colCounters[col] == 0)
                colMutexs[col].Release();
            colCountersLock[col].ReleaseMutex();
            if (isThereReadersLimit)
                readersLimit.Release();



            return answer;
        }
        public Tuple<int, int> searchInRange(int col1, int col2, int row1, int row2, String str)
        {

            if (col1 < 0 || col1 >= columns || col2 < 0 || col2 >= columns || row1 < 0 || row1 >= rows || row2 < 0 || row2 >= rows)
                throw new ArgumentOutOfRangeException("One or more of the indexes are out of range.");
            Tuple<int, int> answer = new Tuple<int, int>(-1, -1);
            bool flag = false;
            while (doessheetlock) ;
            if (isThereReadersLimit)
                readersLimit.WaitOne();
            for (int i = row1; i <= row2; i++)
            {
                rowCountersLock[i].WaitOne();
                rowCounters[i]++;
                if (rowCounters[i] == 1)
                {
                    rowMutexs[i].WaitOne();
                }
                rowCountersLock[i].ReleaseMutex();
                for (int j = col1; j <= col2; j++)
                {
                    if (sheet[i][j] == str)
                    {
                        answer = new Tuple<int, int>(i, j);
                        flag = true;

                        break;
                    }
                }
                rowCountersLock[i].WaitOne();
                rowCounters[i]--;
                if (rowCounters[i] == 0)
                {
                    rowMutexs[i].Release();
                }
                rowCountersLock[i].ReleaseMutex();
                if (flag)
                    break;

            }
            if (isThereReadersLimit)
                readersLimit.Release();
            return answer;
        }
        public void addRow(int row1)
        {
            if (row1 < 0 || row1 > rows - 1)
                throw new ArgumentOutOfRangeException("The indexe are out of range.");
            sheetLock.WaitOne();
            doessheetlock = true;
            sheet.Add(new List<string>());
            atumic.WaitOne();
            for (int i = row1 + 1; i < rows; i++)
            {
                rowMutexs[i].WaitOne();
            }
            atumic.ReleaseMutex();
            for (int j = 0; j < columns; j++)
            {
                sheet[rows].Add(String.Empty);
            }
            rows++;
            rowMutexs.Add(new Semaphore(1, 1));
            rowMutexs[rows - 1].WaitOne();
            for (int i = rows - 1; i > row1; i--)
            {
                for (int j = 0; j < columns; j++)
                {
                    sheet[i][j] = sheet[i - 1][j];
                }
            }

            for (int j = 0; j < columns; j++)
            {
                sheet[row1 + 1][j] = String.Empty;
            }
            rowCounters.Add(0);
            rowCountersLock.Add(new Mutex());

            for (int i = row1 + 1; i < rows; i++)
            {
                rowMutexs[i].Release();
            }
            doessheetlock = false;
            sheetLock.ReleaseMutex();

        }
        public void addCol(int col1)
        {
            if (col1 < 0 || col1 > columns - 1)
                throw new ArgumentOutOfRangeException("The indexe are out of range.");
            sheetLock.WaitOne();
            doessheetlock = true;
            atumic.WaitOne();
            for (int i = col1; i < columns; i++)
                colMutexs[i].WaitOne();
            for (int i = 0; i < rows; i++)
                rowMutexs[i].WaitOne();
            atumic.ReleaseMutex();
            for (int j = 0; j < rows; j++)
            {
                sheet[j].Add(String.Empty);
            }
            columns++;
            colMutexs.Add(new Semaphore(1, 1));
            colMutexs[columns - 1].WaitOne();
            for (int i = 0; i < rows; i++)
            {
                for (int j = columns - 1; j > col1; j--)
                {
                    sheet[i][j] = sheet[i][j - 1];
                }
            }
            for (int j = 0; j < rows; j++)
            {
                sheet[j][col1 + 1] = String.Empty;
            }
            colCounters.Add(0);
            colCountersLock.Add(new Mutex());
            for (int i = col1; i < columns; i++)
                colMutexs[i].Release();
            for (int i = 0; i < rows; i++)
                rowMutexs[i].Release();
            doessheetlock = false;
            sheetLock.ReleaseMutex();
        }
        public Tuple<int, int>[] findAll(String str, bool caseSensitive)
        {

            List<Tuple<int, int>> answer = new List<Tuple<int, int>>();
            while (doessheetlock) ;
            for (int i = 0; i < rows; i++)
            {
                rowCountersLock[i].WaitOne();
                rowCounters[i]++;
                if (rowCounters[i] == 1)
                {
                    rowMutexs[i].WaitOne();
                }

                rowCountersLock[i].ReleaseMutex();
                for (int j = 0; j < columns; j++)
                {
                    if (caseSensitive == true)
                    {
                        if (sheet[i][j] == str)
                            answer.Add(new Tuple<int, int>(i, j));
                    }
                    else
                    {
                        if (sheet[i][j].ToLower() == str.ToLower())
                            answer.Add(new Tuple<int, int>(i, j));
                    }

                }
                rowCountersLock[i].WaitOne();
                rowCounters[i]--;
                if (rowCounters[i] == 0)
                    rowMutexs[i].Release();
                rowCountersLock[i].ReleaseMutex();

            }

            Tuple<int, int>[] finalAnswer = new Tuple<int, int>[answer.Count];
            for (int i = 0; i < answer.Count; i++)
            {
                finalAnswer[i] = answer[i];
            }

            return finalAnswer;
        }
        public void setAll(String oldStr, String newStr, bool caseSensitive)
        {

            if (oldStr == null || newStr == null)
                throw new ArgumentNullException("one of the string is null");
            int count = 0;
            if (caseSensitive)
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {
                        if (sheet[i][j] == oldStr)
                            setCell(i, j, newStr);
                    }
            }
            else
            {
                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < columns; j++)
                    {
                        if (sheet[i][j].ToLower() == oldStr.ToLower())
                        {
                            setCell(i, j, newStr);
                            count++;
                        }
                    }
            }
            if (count == 0)
                throw new Exception("The old string wasnt foumd in the spread sheet.");

        }
        public Tuple<int, int> getSize()
        {
            return new Tuple<int, int>(rows, columns);
        }
        public void setConcurrentSearchLimit(int nUsers)
        {
            if (nUsers == -1)
                isThereReadersLimit = false;
            else
            {
                isThereReadersLimit = true;
                readersLimit = new Semaphore(nUsers, nUsers);
            }
        }
        public void save(String fileName)
        {
            if (fileName == null)
                throw new System.IO.InvalidDataException("The file path can't be null");
            sheetLock.WaitOne();
            doessheetlock = true;
            atumic.WaitOne();
            for (int i = 0; i < rows; i++)
                rowMutexs[i].WaitOne();
            for (int i = 0; i < columns; i++)
                colMutexs[i].WaitOne();
            atumic.ReleaseMutex();
            System.IO.File.WriteAllText(fileName, String.Empty);
            System.IO.File.AppendAllText(fileName, "#&#\n");
            System.IO.File.AppendAllText(fileName, String.Format("{0},{1}\n", rows, columns));
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    System.IO.File.AppendAllText(fileName, sheet[i][j] + "\n");
                }
            }
            System.IO.File.AppendAllText(fileName, "#&#");
            for (int i = 0; i < rows; i++)
                rowMutexs[i].Release();
            for (int i = 0; i < columns; i++)
                colMutexs[i].Release();
            doessheetlock = false;
            sheetLock.ReleaseMutex();
        }
        public void load(String fileName)
        {
            sheetLock.WaitOne();
            doessheetlock = true;
            atumic.WaitOne();
            for (int i = 0; i < rows; i++)
                rowMutexs[i].WaitOne();
            for (int i = 0; i < columns; i++)
                colMutexs[i].WaitOne();
            atumic.ReleaseMutex();
            int rowhoder;
            int colholder;
            if (fileName == null)
                throw new ArgumentNullException("miss filename");
            String[] text = System.IO.File.ReadAllLines(fileName);
            if (text == null || text.Length == 0)
                throw new Exception("empty file");
            if (text[0] != "#&#" || text[text.Length - 1] != "#&#")
                throw new Exception("text not in spreadsheet format");
            if (text[1].Contains(','))
            {
                string[] temp = text[1].Split(',');
                if (temp.Length > 2)
                    throw new Exception("not in the format");
                if (Int32.TryParse(temp[0], out int value) && Int32.TryParse(temp[1], out int value1))
                {
                    rowhoder = value;
                    colholder = value1;
                }
                else
                    throw new Exception("the values are not a number");
            }
            else
                throw new Exception("not in the format");
            if (rowhoder > rows) //bigger row size
            {
                for (int i = rows; i < rowhoder; i++)
                {
                    sheet.Add(new List<string>());
                    for (int j = 0; j < columns; j++)
                    {
                        sheet[i].Add(String.Empty);
                    }
                    rowCounters.Add(0);
                    rowCountersLock.Add(new Mutex());
                    rowMutexs.Add(new Semaphore(1, 1));
                    rowMutexs[i].WaitOne();
                }

            }
            if (rowhoder < rows) //bigger row size
            {
                for (int i = rows - 1; i >= rowhoder; i--)
                {
                    sheet.RemoveAt(i);
                    rowCounters.RemoveAt(i);
                    rowCountersLock.RemoveAt(i);
                    rowMutexs.RemoveAt(i);
                }

            }
            rows = rowhoder;
            if (colholder > columns) //bigger column size
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = columns; j < colholder; j++)
                    {
                        sheet[i].Add(String.Empty);
                    }

                }
                for (int j = columns; j < colholder; j++)
                {
                    colCounters.Add(0);
                    colCountersLock.Add(new Mutex());
                    colMutexs.Add(new Semaphore(1, 1));
                    colMutexs[j].WaitOne();
                }
            }
            if (colholder < columns) //smaller amout of colums
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = columns - 1; j >= colholder; j--)
                    {
                        sheet[i].RemoveAt(j);
                    }
                    for (int j = columns; j > colholder; j--)
                    {
                        colCounters.RemoveAt(j);
                        colCountersLock.RemoveAt(j);
                        colMutexs.RemoveAt(j);
                    }

                }
            }
            columns = colholder;
            int runner = 2;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    sheet[i][j] = text[runner];
                    runner++;
                }
            }
            for (int i = 0; i < columns; i++)
                colMutexs[i].Release();
            for (int i = 0; i < rows; i++)
                rowMutexs[i].Release();
            doessheetlock = false;
            sheetLock.ReleaseMutex();

        }
        public void Print()
        {
            string row = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (sheet[i][j] == "")
                        row += "0";
                    row += sheet[i][j].ToString();
                }
                Console.WriteLine(row);


                row = "";
            }

        }
    }
}
