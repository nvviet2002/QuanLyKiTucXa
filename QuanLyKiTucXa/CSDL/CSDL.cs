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
                MetroMessageBox.Show(tempForm, "Không thể kết nối cơ sở dữ liệu !", "Lỗi kết nối", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error, 14);
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
                MetroMessageBox.Show(tempForm, "Không thể kết nối cơ sở dữ liệu !", "Lỗi kết nối", MessageBoxButtons.OK,
                    MessageBoxIcon.Error, 14);
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

        public bool AddAccount(TAIKHOAN _TK)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"insert into TAIKHOAN values(@tk, @mk, @loaitk, @email, @ghichu)", connect);
                    command.Parameters.Add("@tk", SqlDbType.Char).Value = _TK.TaiKhoan;
                    command.Parameters.Add("@mk", SqlDbType.Char).Value = _TK.MatKhau;
                    command.Parameters.Add("@loaitk", SqlDbType.NVarChar).Value = _TK.LoaiTK;
                    command.Parameters.Add("@email", SqlDbType.Char).Value = _TK.Email;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _TK.Ghichu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateAccount(TAIKHOAN _TK)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"update TAIKHOAN set MatKhau = @mk,LoaiTK = @loaiTK,Email = @email, Ghichu = @ghichu
                    where TaiKhoan = @tk", connect);
                    command.Parameters.Add("@tk", SqlDbType.Char).Value = _TK.TaiKhoan;
                    command.Parameters.Add("@mk", SqlDbType.Char).Value = _TK.MatKhau;
                    command.Parameters.Add("@loaitk", SqlDbType.NVarChar).Value = _TK.LoaiTK;
                    command.Parameters.Add("@email", SqlDbType.Char).Value = _TK.Email;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _TK.Ghichu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteAccount(string _maTK)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"delete from TAIKHOAN where TaiKhoan = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _maTK;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool AddStaff(NHANVIEN _staff)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"insert into NHANVIEN values(@ma, @ten, @ngaysinh,@gioitinh,@sdt, @chucvu,@ghichu,@matk)", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _staff.MaNV;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _staff.TenNV;
                    command.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = _staff.Ngaysinh.ToShortTimeString();
                    command.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = _staff.Gioitinh;
                    command.Parameters.Add("@sdt", SqlDbType.Char).Value = _staff.SDT;
                    command.Parameters.Add("@chucvu", SqlDbType.NVarChar).Value = _staff.ChucVu;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _staff.Ghichu;
                    command.Parameters.Add("@matk", SqlDbType.Char).Value = _staff.TaiKhoan;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateStaff(NHANVIEN _staff)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"update NHANVIEN set TenNV = @ten,Ngaysinh = @ngaysinh,Gioitinh = @gioitinh,
                    SDT = @sdt,ChucVu = @chucvu,Ghichu = @ghichu, TaiKhoan = @matk where MaNV = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _staff.MaNV;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _staff.TenNV;
                    command.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = _staff.Ngaysinh.ToShortTimeString();
                    command.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = _staff.Gioitinh;
                    command.Parameters.Add("@sdt", SqlDbType.NVarChar).Value = _staff.SDT;
                    command.Parameters.Add("@chucvu", SqlDbType.NVarChar).Value = _staff.ChucVu;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _staff.Ghichu;
                    command.Parameters.Add("@matk", SqlDbType.Char).Value = _staff.TaiKhoan;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteStaff(string _maNV)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"delete from NHANVIEN where MaNV = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _maNV;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool AddStudent(SINHVIEN _student)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"insert into SINHVIEN values(@ma, @ten, @ngaysinh,@gioitinh,@khoa,@lop,@sdt, @diachi,@ghichu,@matk)", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _student.MaSV;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _student.TenSV;
                    command.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = _student.Ngaysinh.ToShortTimeString();
                    command.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = _student.Gioitinh;
                    command.Parameters.Add("@khoa", SqlDbType.NVarChar).Value = _student.Khoa;
                    command.Parameters.Add("@lop", SqlDbType.NVarChar).Value = _student.Lop;
                    command.Parameters.Add("@sdt", SqlDbType.Char).Value = _student.SDT;
                    command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = _student.Diachi;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _student.Ghichu;
                    command.Parameters.Add("@matk", SqlDbType.Char).Value = _student.TaiKhoan;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateStudent(SINHVIEN _student)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"update SINHVIEN set TenSV = @ten,Ngaysinh = @ngaysinh,Gioitinh = @gioitinh,
                    Khoa = @khoa, Lop = @lop,SDT = @sdt,DiaChi = @diachi,Ghichu = @ghichu, TaiKhoan = @matk where MaSV = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _student.MaSV;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _student.TenSV;
                    command.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = _student.Ngaysinh.ToShortTimeString();
                    command.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = _student.Gioitinh;
                    command.Parameters.Add("@khoa", SqlDbType.NVarChar).Value = _student.Khoa;
                    command.Parameters.Add("@lop", SqlDbType.NVarChar).Value = _student.Lop;
                    command.Parameters.Add("@sdt", SqlDbType.Char).Value = _student.SDT;
                    command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = _student.Diachi;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _student.Ghichu;
                    command.Parameters.Add("@matk", SqlDbType.Char).Value = _student.TaiKhoan;
                    
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteStudent(string _maSV)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"delete from SINHVIEN where MaSV = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _maSV;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool AddArea(KHU _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"insert into KHU values(@ma, @ten, @vitri, @ghichu)", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value.MaKhu;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _value.TenKhu;
                    command.Parameters.Add("@vitri", SqlDbType.NVarChar).Value = _value.Vitri;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.Ghichu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateArea(KHU _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"update KHU set TenKhu = @ten,ViTri = @vitri, Ghichu = @ghichu
                    where MaKhu = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value.MaKhu;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _value.TenKhu;
                    command.Parameters.Add("@vitri", SqlDbType.NVarChar).Value = _value.Vitri;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.Ghichu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteArea(string _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"delete from KHU where MaKhu = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }


        public bool AddBuilding(TOANHA _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"insert into TOANHA values(@ma, @ten, @khu, @ghichu)", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value.MaTN;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _value.TenTN;
                    command.Parameters.Add("@khu", SqlDbType.Char).Value = _value.MaKhu;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.Ghichu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateBuilding(TOANHA _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"update TOANHA set TenTN = @ten,MaKhu = @makhu, Ghichu = @ghichu
                    where MaTN = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value.MaTN;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _value.TenTN;
                    command.Parameters.Add("@makhu", SqlDbType.NVarChar).Value = _value.MaKhu;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.Ghichu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteBuilding(string _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"delete from TOANHA where MaTN = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool AddRoomType(LOAIPHONG _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"insert into LOAIPHONG values(@ma, @ten, @sn,@dientich,@gia, @ghichu)", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value.MaLoaiPhong;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _value.TenLoaiPhong;
                    command.Parameters.Add("@sn", SqlDbType.Int).Value = _value.SoNguoi;
                    command.Parameters.Add("@dientich", SqlDbType.Decimal).Value = _value.DienTich;
                    command.Parameters.Add("@gia", SqlDbType.Decimal).Value = _value.GiaPhong;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.Ghichu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateRoomType(LOAIPHONG _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"update LOAIPHONG set TenLoaiPhong = @ten,SoNguoi = @sn
                    ,DienTich = @dientich , GiaPhong = @gia,Ghichu = @ghichu where MaLoaiPhong = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value.MaLoaiPhong;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _value.TenLoaiPhong;
                    command.Parameters.Add("@sn", SqlDbType.Int).Value = _value.SoNguoi;
                    command.Parameters.Add("@dientich", SqlDbType.Decimal).Value = _value.DienTich;
                    command.Parameters.Add("@gia", SqlDbType.Decimal).Value = _value.GiaPhong;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.Ghichu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteRoomType(string _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"delete from LOAIPHONG where MaLoaiPhong = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool AddDevice(THIETBI _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"insert into THIETBI values(@ma, @ten, @ghichu)", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value.MaTB;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _value.TenTB;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.Ghichu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateDevice(THIETBI _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"update THIETBI set TenTB = @ten,Ghichu = @ghichu
                    where MaTB = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value.MaTB;
                    command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = _value.TenTB;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.Ghichu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteDevice(string _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"delete from THIETBI where MaTB = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool AddRoom(PHONG _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"insert into PHONG values(@ma,0, @ghichu,@matn,@maloaiphong)", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value.MaPhong;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.Ghichu;
                    command.Parameters.Add("@matn", SqlDbType.Char).Value = _value.MaTN;
                    command.Parameters.Add("@maloaiphong", SqlDbType.Char).Value = _value.MaLoaiPhong;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateRoom(PHONG _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"update PHONG set MaTN = @matn,Ghichu = @ghichu,
                    MaLoaiPhong = @maloaiphong where MaPhong = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value.MaPhong;
                    command.Parameters.Add("@matn", SqlDbType.Char).Value = _value.MaTN;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.Ghichu;
                    command.Parameters.Add("@maloaiphong", SqlDbType.Char).Value = _value.MaLoaiPhong;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteRoom(string _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"delete from PHONG where MaPhong = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteRoomDevice(string _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"delete from THIETBIPHONG where MaPhong = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Char).Value = _value;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }


        public bool AddContract(HOPDONG _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"insert into HOPDONG values(@ngaylap,@ngaybd,@ngayhh,@trangthai
                    ,@manv,@masv,@maphong, @ghichu)", connect);
                    command.Parameters.Add("@ngaylap", SqlDbType.Date).Value = _value.NgayLap.ToShortDateString();
                    command.Parameters.Add("@ngaybd", SqlDbType.Date).Value = _value.NgayBatDau.ToShortDateString();
                    command.Parameters.Add("@ngayhh", SqlDbType.Date).Value = _value.NgayHetHan.ToShortDateString();
                    command.Parameters.Add("@trangthai", SqlDbType.NVarChar).Value = _value.TrangThai;
                    command.Parameters.Add("@manv", SqlDbType.Char).Value = _value.MaNV;
                    command.Parameters.Add("@masv", SqlDbType.Char).Value = _value.MaSV;
                    command.Parameters.Add("@maphong", SqlDbType.Char).Value = _value.MaPhong;
                    command.Parameters.Add("@ghichu", SqlDbType.NVarChar).Value = _value.GhiChu;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteContract(int _value)
        {
            using (SqlConnection connect = new SqlConnection(connectionStr))
            {
                try
                {
                    connect.Open();
                    SqlCommand command = new SqlCommand(@"update HOPDONG set TrangThai = N'Ngừng' where MaHD = @ma", connect);
                    command.Parameters.Add("@ma", SqlDbType.Int).Value = _value;
                    command.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connect.Close();
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
    }
}

