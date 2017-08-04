using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CameraDataDive
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnUnhandledException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var ms = new MainScreen(); // publisher of NewColProp
            try
            {
                Application.Run(ms);
            }
            catch (Exception ex)
            {
                // call the exception handler
                HandleAllExceptions(ex);
            }
        }
        private static void HandleAllExceptions(Exception theException)
        {
            // post information regarding the crash
            MessageBox.Show("Unhandled Exception Caught!\n\n");
            MessageBox.Show("Message:\n\n" + theException.Message);
            MessageBox.Show("StackTrace:\n\n" + theException.StackTrace);
            MessageBox.Show("Source:\n\n" + theException.Source);
        }

        private static void OnUnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            // Get the exception
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                // call the exception handler
                HandleAllExceptions(ex);
            }
            else
            {
                // couldn't get an exception object, create a default one
                ex = new Exception("Unknown Exception Detected!");
                HandleAllExceptions(ex);
            }
        }
    }
}
