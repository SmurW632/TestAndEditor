using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsEditTests.Forms;

namespace WinFormsEditTests
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // логируем работу приложения в файл
            // в случае запуска из VS файл можно найти в TestAndEditor\WinFormsEditTests\bin\Debug
            var path = Path.Combine(Application.StartupPath, "log.txt");
            Trace.Listeners.Add(new TextWriterTraceListener(File.CreateText(path)));
            // т.к. запись происходит через буфер
            // нужно вызывать Flush() чтоб сбросить из буфера в файл
            Trace.AutoFlush = true;


            Application.Run(new WelcomForm());
        }
    }
}
