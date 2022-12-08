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

        public int ChangeStudentInfomation(SINHVIEN _student)
        {
            return ExcuteNonQuery($@"update SINHVIEN set SDT = '{_student.SDT
                }', DiaChi = N'{_student.Diachi}', GhiChu = N'{_student.Ghichu
                }' where MaSV = '{_student.MaSV}' ");
        }

        public int ExcuteNonQuery(string query)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    int temp = command.ExecuteNonQuery();
                    connection.Close();
                    return temp;
                }
            }
            catch (Exception ex)
            {
                MetroFramework.Forms.MetroForm tempForm = new MetroFramework.Forms.MetroForm();
                MetroMessageBox.Show(tempForm, "Không thể kết nối cơ sở dữ liệu !", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error, 14);
                return 0;
            }
        }

        public DataTable Search(string _searchType, string _searchIn, string _searchTablePosition,bool _nvarchar)
        {
            if (_nvarchar)
            {
                DataTable temp = ExecuteQuery($@"Select * from {_searchTablePosition} where
                {_searchType} like N'%{_searchIn}%'");
                return temp;
            }
            else
            {
                DataTable temp = ExecuteQuery($@"Select * from {_searchTablePosition} where
                {_searchType} like '%{_searchIn}%'");
                return temp;
            }
            return null;
            
        }
    }
}
