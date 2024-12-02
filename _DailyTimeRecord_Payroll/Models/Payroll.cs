using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace _DailyTimeRecord_Payroll.Models
{
    internal class Payroll
    {
        public static void InsertPayroll(TextBox txtPAssignCode, TextBox txtPNoDays, TextBox txtPrateWage,
           TextBox txtPregOt, TextBox txtPholPay, TextBox txtpgincome, TextBox txtpcadvance,TextBox txtpphic,TextBox txtsss,TextBox txtppagibig
            ,TextBox txtpnetincome,string txtpremarks,DateTime dtissued,string strtranid)
        {
            SqlCommand command = new SqlCommand();
            
            globalnames.con.Open();
            command.Connection = globalnames.con;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "Insert_Payroll";
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@emp_code", txtPAssignCode.Text.Trim()));
            command.Parameters.Add(new SqlParameter("@num_days", Convert.ToDouble(txtPNoDays.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@r_wage", Convert.ToDouble(txtPrateWage.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@overtime", Convert.ToInt32(txtPregOt.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@hol_pay", Convert.ToDouble(txtPholPay.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@gross_salary", Convert.ToDouble(txtpgincome.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@cash_advance", Convert.ToDouble(txtpcadvance.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@philhealth", Convert.ToDouble(txtpphic.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@sss", Convert.ToDouble(txtsss.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@pagibig", Convert.ToDouble(txtppagibig.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@net_income", Convert.ToDouble(txtpnetincome.Text.Trim())));
            command.Parameters.Add(new SqlParameter("@remarks", txtpremarks.Trim()));
            command.Parameters.Add(new SqlParameter("@dateissued", dtissued));
            command.Parameters.Add(new SqlParameter("@trans_id", strtranid));
            command.ExecuteNonQuery();
            globalnames.con.Close();
        }

    }
}
