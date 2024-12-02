using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using _DailyTimeRecord_Payroll.UC_Forms;

namespace _DailyTimeRecord_Payroll
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        public static void Main()
        {
            // Initialize users in the database
            InitializeUsers();
            
        }
        public static void InitializeUsers()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm1());
        }
    }
}
