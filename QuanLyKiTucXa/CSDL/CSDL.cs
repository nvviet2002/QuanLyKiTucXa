using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MetroFramework;

namespace QuanLyKiTucXa.CSDL
{
    class CSDL
    {
        private static CSDL instance; // ctrl + R + E 

        public static CSDL Instance
        {
            get { if (instance == null) instance = new CSDL(); return CSDL.instance; }
            private set { CSDL.instance = value; }
        }

        private static string connectionStr = @"Data Source=.\sqlexpress;Initial Catalog=QuanLyKiTucXa;Integrated Security=True";

        public DataTable ExecuteQuery(string query)
        {
            try
            {
                DataTable data = new DataTable();
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
                    return data;
                }
            }
            catch (Exception ex)
            {
                MetroFramework.Forms.MetroForm tempForm = new MetroFramework.Forms.MetroForm();
                MetroMessageBox.Show(tempForm, "Không thể kết nối cơ sở dữ liệu !", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error, 14);
                return null;
            }
        }

        public void ChangeStudentInfomation()
        {

        }
    }
}
