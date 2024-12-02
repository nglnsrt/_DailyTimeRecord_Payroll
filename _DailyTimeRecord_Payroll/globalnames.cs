using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _DailyTimeRecord_Payroll
{
    class globalnames
    {
        public static string GlobalConnection()
        {
            return "Data Source = LOCALHOST\\SQLEXPRESS;Initial Catalog=DTR;Integrated Security=True";
        }
        public static SqlConnection con = new SqlConnection(GlobalConnection());// Global Connection
        public static string gblusername = string.Empty;
        public static bool forEditEmployee = false;
        public static PictureBox pictureBox = new PictureBox();
        public static string SQLQuery = string.Empty;
        public static DataTable dt = new DataTable();
        public static SqlDataAdapter da = new SqlDataAdapter();
    }
}
