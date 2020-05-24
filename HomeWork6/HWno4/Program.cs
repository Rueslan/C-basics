using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Козлов Руслан
    4)**Считайте файл различными способами. Смотрите “Пример записи файла различными способами”. 
    Создайте методы, которые возвращают массив byte (FileStream, BufferedStream), строку для StreamReader и массив int для BinaryReader.*/

namespace HWno4
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytestring = BuffStr();
            foreach (var item in bytestring)
            {
                Console.WriteLine(bytestring);
            }
            int[] intstring = BinRead();
            foreach (var item in intstring)
            {
                Console.WriteLine(intstring);
            }
            Console.WriteLine(StrRead());

            Console.ReadKey();
        }

        public static byte[] BuffStr()
        {
            try
            {
                using (FileStream f = new FileStream("data.dat", FileMode.Open))
                {
                    using (BufferedStream fIn = new BufferedStream(f))
                    {
                        long n = f.Length / 4;
                        byte[] arr = new byte[n];
                        for (int i = 0; i < n; i++)
                        {
                            arr[i] = (byte)fIn.ReadByte();
                        }
                        return arr;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }
        public static string StrRead()
        {
            try
            {
                using (FileStream f = new FileStream("data.txt", FileMode.Open))
                {
                    using (StreamReader fIn = new StreamReader(f))
                    {
                        string result = fIn.ReadToEnd();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            
        }
        public static int[] BinRead()
        {
            try
            {
                using (FileStream f = new FileStream("data.bin", FileMode.Open))
                {
                    using (BinaryReader fIn = new BinaryReader(f))
                    {
                        long n = f.Length / 4;
                        int[] arr = new int[n];
                        for (int i = 0; i < n; i++)
                        {
                            arr[i] = fIn.ReadInt32();
                        }
                        return arr;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
                
        }
    }
}
