using System;
using System.Windows.Forms;

namespace OxygenePolygons
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            //Instead I do this
            //var mainForm = new MainForm(); //create window
            //mainForm.Show(); //display it
            //while (mainForm.Created) //while it exists 
            //{
            //    mainForm.DrawFrame(); //draw frame
            //    System.Threading.Thread.Sleep(20);
            //    Application.DoEvents(); //run messages for this thread
            //}
        }
    }
}
