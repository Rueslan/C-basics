using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class Matrix
    {
        int[,] arr;
        int cols;
        int rows;
        string configpath = AppDomain.CurrentDomain.BaseDirectory + "config.txt";
        string datapath = AppDomain.CurrentDomain.BaseDirectory + "data.txt";
        public string MaxValueIndex;
        public int Min { get => GetMin(); }
        public int Max { get => GetMax(out MaxValueIndex); }
        public int Sum { get => GetSum(); }
        public Matrix(int cols, int rows)
        {
            this.cols = cols;
            this.rows = rows;
            Random rnd = new Random();
            arr = new int[cols, rows];
            for (cols = 0; cols < arr.GetLength(0); cols++)
            {                
                for (rows = 0; rows < arr.GetLength(1); rows++)
                {                    
                    arr[cols, rows] = rnd.Next(0,100);
                }

            }
        }

        public Matrix(bool LoadFromFile)
        {
            GetDataFromFile();
        }
        public int GetLength(int dimention)
        {
            return arr.GetLength(dimention);
        }
        public int this[int i,int j]
        {
            get { return arr[i,j]; }
            set { arr[i,j] = value; }
        }

        int GetSum()
        {
            int sum = 0;
            for (int cols = 0; cols < arr.GetLength(0); cols++)
            {
                for (int rows = 0; rows < arr.GetLength(1); rows++)
                {
                    sum += arr[cols, rows];
                }

            }
            return sum;
        }
        public int GetSumOverValue(int startValue)
        {
            int sum = 0;
            for (int cols = 0; cols < arr.GetLength(0); cols++)
            {
                for (int rows = 0; rows < arr.GetLength(1); rows++)
                {
                    if (arr[cols,rows]>= startValue)                    
                        sum += arr[cols, rows];
                }

            }
            return sum;
        }
        int GetMin()
        {
            int min = arr[0, 0];
            for (int cols = 0; cols < arr.GetLength(0); cols++)
            {
                for (int rows = 0; rows < arr.GetLength(1); rows++)
                {
                    if (min > arr[cols, rows])
                        min = arr[cols,rows];
                }

            }
            return min;
        }
        int GetMax(out string IndexOfMaxValue)
        {
            int max = arr[0, 0];
            IndexOfMaxValue = "0,0";
            for (int cols = 0; cols < arr.GetLength(0); cols++)
            {
                for (int rows = 0; rows < arr.GetLength(1); rows++)
                {
                    if (max < arr[cols, rows])
                    {
                        max = arr[cols, rows];
                        IndexOfMaxValue = $"{cols},{rows}";
                    }
                }

            }
            return max;
        }
        public void WriteDataToFile()
        {
            using (StreamWriter sr = new StreamWriter(configpath))
            {
                sr.WriteLine(arr.GetLength(0));
                sr.WriteLine(arr.GetLength(1));
            }
            using (StreamWriter sr2 = new StreamWriter(datapath))
            {
                for (int cols = 0; cols < arr.GetLength(0); cols++)
                {
                    for (int rows = 0; rows < arr.GetLength(1); rows++)
                    {
                        sr2.WriteLine(arr[cols,rows]);
                    }

                }
            }
        }
        public void GetDataFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(configpath))
                {
                    this.cols = Int32.Parse(sr.ReadLine());
                    this.rows = Int32.Parse(sr.ReadLine());
                    arr = new int[cols, rows];
                }
                using (StreamReader sr2 = new StreamReader(datapath))
                {
                    for (int cols = 0; cols < arr.GetLength(0); cols++)
                    {
                        if (sr2.EndOfStream)
                            break;
                        for (int rows = 0; rows < arr.GetLength(1); rows++)
                        {
                            if (!sr2.EndOfStream)
                            {
                                arr[cols, rows] = Int32.Parse(sr2.ReadLine());
                            }
                            else break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения: {ex}");
            }
            
        }
        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                result += "\n";
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    result += $"{arr[i, j]} ";
                }
            }
            return result;
        }
       
    }
}
