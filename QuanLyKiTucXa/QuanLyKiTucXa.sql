create database QuanLyKiTucXa
go
use QuanLyKiTucXa

--create table CHUCVU
--(
--	MaCV char(5) primary key(MaCV),
--	TenCV nvarchar(50) not null,
--	GhiChu nvarchar(200)
--) 

create table TAIKHOAN
(
	--MaTK int identity primary key(MaTK),
	TaiKhoan char(50) primary key not null,
	MatKhau char(50) not null,
	LoaiTK nvarchar(20) not null,
	Email char(100) ,
	Ghichu nvarchar(200) 
)

create table SINHVIEN
(
  	MaSV char(5) primary key(MaSV),
	TenSV nvarchar(100) not null,
	Ngaysinh datetime not null,
	Gioitinh nvarchar(20) not null,
	Khoa nvarchar(50) not null,
	Lop nvarchar(50) not null,
	SDT char(15) not null,
	Diachi nvarchar(200) not null,
	Ghichu nvarchar(200),
	TaiKhoan char(50) unique,
	
	CONSTRAINT FK_SinhVien1 FOREIGN KEY (TaiKhoan) REFERENCES  TAIKHOAN(TaiKhoan)
)


create table NHANVIEN
(
	MaNV char(5) primary key(Manv),
	TenNV nvarchar(100) not null,
	Ngaysinh datetime not null,
	Gioitinh nvarchar(20) not null,
	SDT char(15) not null,
	--MaCV char(5) not null,
	ChucVu nvarchar(50) not null,
	Ghichu nvarchar(100),
	TaiKhoan char(50) unique,
	--CONSTRAINT FK_nhanvien1 FOREIGN KEY (MaCV) REFERENCES  CHUCVU(MaCV),
	CONSTRAINT FK_nhanvien2 FOREIGN KEY (TaiKhoan) REFERENCES  TAIKHOAN(TaiKhoan)
	
)

create table KHU
(
	MaKhu char(5) primary key(MaKhu),
	TenKhu nvarchar(30) not null,
	Vitri nvarchar(200)not null,
	Ghichu nvarchar(100)
)  

create table TOANHA
(
	MaTN char(5) primary key(MaTN),
	TenTN nvarchar(30) not null,
	MaKhu char(5) not null,
	Ghichu nvarchar(200),
	CONSTRAINT FK_ToaNha1 FOREIGN KEY (MaKhu) REFERENCES  KHU(MaKhu )
)
 create table LOAIPHONG
(
	MaLoaiPhong char(5) primary key(MaLoaiPhong),
	TenLoaiPhong nvarchar(30) not null,
	SoNguoi int not null,
	DienTich decimal(12,2) not null,
	GiaPhong decimal(12,2) not null,
	Ghichu nvarchar(200) 
	
	
)
create table PHONG
(
	MaPhong char(5) primary key(MaPhong),
	TongSoHD int default 0,
	Ghichu nvarchar(200),
	MaTN char(5) not null,
	MaLoaiPhong char(5) not null,
	CONSTRAINT FK_phong1 FOREIGN KEY (MaTN) REFERENCES  TOANHA(MaTN ),
	CONSTRAINT FK_phong2 FOREIGN KEY (MaLoaiPhong) REFERENCES  LOAIPHONG(MaLoaiPhong),
)

create table THIETBI
(
	MaTB char(5) primary key(MaTB),
	TenTB nvarchar(100) not null,
	GhiChu nvarchar(100),
)

create table THIETBIPHONG
(
	ID int identity primary key,
	SoLuong int default 1,
	TrangThai nvarchar(50),
	MaTB char(5) not null,
	MaPhong char(5) not null,
	constraint fk_ThietBiPhong1 foreign key(MaPhong) references PHONG(MaPhong),
	constraint fk_ThietBiPhong2 foreign key(MaTB) references THIETBI(MaTB)
)

create table HOPDONG
(
	MaHD int identity primary key,
	NgayLap datetime not null,
	NgayBatDau datetime not null,
	NgayHetHan datetime not null,
	TrangThai nvarchar(50) not null,  
  	MaNV char(5) not null,
	MaSV char(5) not null,
	MaPhong char(5) not null,
	GhiChu nvarchar(200) ,
	CONSTRAINT FK_hopdong1 FOREIGN KEY (MaNV ) REFERENCES  NHANVIEN(MaNV ),
	CONSTRAINT FK_hopdong2 FOREIGN KEY (MaSV) REFERENCES  SINHVIEN(MaSV ),
	CONSTRAINT FK_hopdong3 FOREIGN KEY (MaPhong) REFERENCES PHONG(MaPhong)
)

create table HOADON
(
	MaHoaDon int identity primary key,
	NgayLap datetime not null,
	HanThu datetime not null,
	TuNgay datetime not null,
	DenNgay datetime not null,
	TongTien decimal(12,2) not null,	
	TienDaNop decimal(12,2) not null,
	TrangThai nvarchar(30) not null,
  	MaHD int not null,
	GhiChu nvarchar(200),
	CONSTRAINT FK_hoadon1 FOREIGN KEY (MaHD ) REFERENCES  HOPDONG(MaHD ),
	
)

create table CHITIETHOADON
(
	ID int identity primary key,
	LoaiTien nvarchar(30) not null,
	SoCu int default 0,
	SoMoi int default 0,
	DonGia decimal(12,2) not null,
	DonViTinh nvarchar(30),
	SoTien decimal(12,2) not null,
	MaHoaDon int not null,
	GhiChu nvarchar(100) not null

	CONSTRAINT FK_CTHoaDon1 FOREIGN KEY (MaHoaDon ) REFERENCES  HOADON(MaHoaDon ),
)


-----------------------------------------
if exists (select name from sysobjects
where name = 't_TinhTongHD' and type = 'TR')
drop trigger t_TinhTongHD
go
create trigger t_TinhTongHD
on HOPDONG for insert, update, delete
as
begin
declare @MaPhong char(5)
set @MaPhong = ''
select @MaPhong = MaPhong from Inserted
update PHONG set TongSoHD=Coalesce((Select count(*) from HOPDONG where @MaPhong=MaPhong and TrangThai = 1),0)
where MaPhong = @MaPhong

select @MaPhong = MaPhong from Deleted
update PHONG set TongSoHD=Coalesce((Select count(*) from HOPDONG where @MaPhong=MaPhong and TrangThai = 1),0)
where MaPhong = @MaPhong
end
-------------------------------------------------
if exists (select name from sysobjects
where name = 't_TinhTongTienHoaDong' and type = 'TR')
drop trigger t_TinhTongTienHoaDong
go
create trigger t_TinhTongTienHoaDong
on CHITIETHOADON for insert, update, delete
as
begin
declare @MaHoaDon int
set @MaHoaDon = 0
select @MaHoaDon = MaHoaDon from Inserted
update HOADON set TongTien=Coalesce((Select sum(SoTien) from CHITIETHOADON where @MaHoaDon=MaHoaDon ),0)
where MaHoaDon = @MaHoaDon

select @MaHoaDon = MaHoaDon from Deleted
update HOADON set TongTien=Coalesce((Select sum(SoTien) from CHITIETHOADON where @MaHoaDon=MaHoaDon ),0)
where MaHoaDon = @MaHoaDon
end

-------------------------------------------
if exists (select name from sysobjects
where name = 't_ThemThietBiPhong' and type = 'TR')
drop trigger t_ThemThietBiPhong
go
create trigger t_ThemThietBiPhong
on PHONG for insert
as
begin
declare @MaPhong char(5)
declare @MaLoaiPhong char(5)
set @MaPhong = ''
set @MaLoaiPhong = ''
select @MaPhong = MaPhong,@MaLoaiPhong = MaLoaiPhong from Inserted
	if (@MaLoaiPhong = 'L1')
	begin
	insert into THIETBIPHONG values (4,N'Tốt','TB003',@MaPhong)
	end
	if (@MaLoaiPhong = 'L2')
	begin
	insert into THIETBIPHONG values (4,N'Tốt','TB003',@MaPhong)
	insert into THIETBIPHONG values (1,N'Tốt','TB001',@MaPhong)
	insert into THIETBIPHONG values (1,N'Tốt','TB002',@MaPhong)
	end
	if (@MaLoaiPhong = 'L3')
	begin
	insert into THIETBIPHONG values (6,N'Tốt','TB003',@MaPhong)
	end
	if (@MaLoaiPhong = 'L4')
	begin
	insert into THIETBIPHONG values (6,N'Tốt','TB003',@MaPhong)
	insert into THIETBIPHONG values (1,N'Tốt','TB001',@MaPhong)
	insert into THIETBIPHONG values (1,N'Tốt','TB002',@MaPhong)
	end
end

-----------------------------------
go
--insert into CHUCVU values('NV',N'Nhân viên',null)
--insert into CHUCVU values('QTV',N'Quản trị viên',null)
--insert into CHUCVU values('GD',N'Giám đốc',null)

insert into KHU values('KC',N'Khu C',N'Khu C/Trường Đại học Hàng Hải Việt Nam/484 Lạch Tray/Kênh Dương/Hải Phòng',null)
insert into KHU values('KD',N'Khu D',N'Khu D/Trường Đại học Hàng Hải Việt Nam/484 Lạch Tray/Kênh Dương/Hải Phòng',null)

insert into TOANHA values('C3',N'Nhà C3','KC',null)
insert into TOANHA values('C4',N'Nhà C4','KC',null)
insert into TOANHA values('C5',N'Nhà C5','KC',null)
insert into TOANHA values('D1',N'Nhà D1','KD',null)
insert into TOANHA values('D2',N'Nhà D2','KD',null)
insert into TOANHA values('D3',N'Nhà D3','KD',null)
insert into TOANHA values('D4',N'Nhà D4','KD',null)

insert into LOAIPHONG values('L1',N'Phòng 4 thường',4,15,200000,N'200.000VND/người/tháng')
insert into LOAIPHONG values('L2',N'Phòng 4 VIP',4,15,250000,N'250.000VND/người/tháng (Có điều hòa, nóng lạnh)')
insert into LOAIPHONG values('L3',N'Phòng 6 thường',6,20,180000,N'180.000VND/người/tháng')
insert into LOAIPHONG values('L4',N'Phòng 6 VIP',6,20,230000,N'230.000VND/người/tháng (Có điều hòa, nóng lạnh)')

insert into THIETBI values('TB001',N'Điều hòa',null)
insert into THIETBI values('TB002',N'Bình nóng lạnh',null)
insert into THIETBI values('TB003',N'Giường',null)

---------------------------------------------------- C3
insert into PHONG values('C3101',0,null,'C3','L1')
insert into PHONG values('C3102',0,null,'C3','L1')
insert into PHONG values('C3103',0,null,'C3','L1')
insert into PHONG values('C3104',0,null,'C3','L1')
insert into PHONG values('C3105',0,null,'C3','L1')

insert into PHONG values('C3201',0,null,'C3','L1')
insert into PHONG values('C3202',0,null,'C3','L1')
insert into PHONG values('C3203',0,null,'C3','L1')
insert into PHONG values('C3204',0,null,'C3','L1')
insert into PHONG values('C3205',0,null,'C3','L1')

insert into PHONG values('C3301',0,null,'C3','L1')
insert into PHONG values('C3302',0,null,'C3','L1')
insert into PHONG values('C3303',0,null,'C3','L1')
insert into PHONG values('C3304',0,null,'C3','L1')
insert into PHONG values('C3305',0,null,'C3','L1')

insert into PHONG values('C3401',0,null,'C3','L1')
insert into PHONG values('C3402',0,null,'C3','L1')
insert into PHONG values('C3403',0,null,'C3','L1')
insert into PHONG values('C3404',0,null,'C3','L1')
insert into PHONG values('C3405',0,null,'C3','L1')

insert into PHONG values('C3501',0,null,'C3','L1')
insert into PHONG values('C3502',0,null,'C3','L1')
insert into PHONG values('C3503',0,null,'C3','L1')
insert into PHONG values('C3504',0,null,'C3','L1')
insert into PHONG values('C3505',0,null,'C3','L1')
------------------------------------------------- C4
insert into PHONG values('C4101',0,null,'C4','L1')
insert into PHONG values('C4102',0,null,'C4','L1')
insert into PHONG values('C4103',0,null,'C4','L1')
insert into PHONG values('C4104',0,null,'C4','L1')
insert into PHONG values('C4105',0,null,'C4','L1')

insert into PHONG values('C4201',0,null,'C4','L1')
insert into PHONG values('C4202',0,null,'C4','L1')
insert into PHONG values('C4203',0,null,'C4','L1')
insert into PHONG values('C4204',0,null,'C4','L1')
insert into PHONG values('C4205',0,null,'C4','L1')

insert into PHONG values('C4301',0,null,'C4','L1')
insert into PHONG values('C4302',0,null,'C4','L1')
insert into PHONG values('C4303',0,null,'C4','L1')
insert into PHONG values('C4304',0,null,'C4','L1')
insert into PHONG values('C4305',0,null,'C4','L1')

insert into PHONG values('C4401',0,null,'C4','L1')
insert into PHONG values('C4402',0,null,'C4','L1')
insert into PHONG values('C4403',0,null,'C4','L1')
insert into PHONG values('C4404',0,null,'C4','L1')
insert into PHONG values('C4405',0,null,'C4','L1')

insert into PHONG values('C4501',0,null,'C4','L1')
insert into PHONG values('C4502',0,null,'C4','L1')
insert into PHONG values('C4503',0,null,'C4','L1')
insert into PHONG values('C4504',0,null,'C4','L1')
insert into PHONG values('C4505',0,null,'C4','L1')
---------------------------------------------- C5
insert into PHONG values('C5101',0,null,'C5','L2')
insert into PHONG values('C5102',0,null,'C5','L2')
insert into PHONG values('C5103',0,null,'C5','L2')
insert into PHONG values('C5104',0,null,'C5','L2')
insert into PHONG values('C5105',0,null,'C5','L2')

insert into PHONG values('C5201',0,null,'C5','L2')
insert into PHONG values('C5202',0,null,'C5','L2')
insert into PHONG values('C5203',0,null,'C5','L2')
insert into PHONG values('C5204',0,null,'C5','L2')
insert into PHONG values('C5205',0,null,'C5','L2')

insert into PHONG values('C5301',0,null,'C5','L2')
insert into PHONG values('C5302',0,null,'C5','L2')
insert into PHONG values('C5303',0,null,'C5','L2')
insert into PHONG values('C5304',0,null,'C5','L2')
insert into PHONG values('C5305',0,null,'C5','L2')

insert into PHONG values('C5401',0,null,'C5','L2')
insert into PHONG values('C5402',0,null,'C5','L2')
insert into PHONG values('C5403',0,null,'C5','L2')
insert into PHONG values('C5404',0,null,'C5','L2')
insert into PHONG values('C5405',0,null,'C5','L2')

insert into PHONG values('C5501',0,null,'C5','L2')
insert into PHONG values('C5502',0,null,'C5','L2')
insert into PHONG values('C5503',0,null,'C5','L2')
insert into PHONG values('C5504',0,null,'C5','L2')
insert into PHONG values('C5505',0,null,'C5','L2')
------------------------------------------------- D1
insert into PHONG values('D1101',0,null,'D1','L3')
insert into PHONG values('D1102',0,null,'D1','L3')
insert into PHONG values('D1103',0,null,'D1','L3')
insert into PHONG values('D1104',0,null,'D1','L3')
insert into PHONG values('D1105',0,null,'D1','L3')

insert into PHONG values('D1201',0,null,'D1','L3')
insert into PHONG values('D1202',0,null,'D1','L3')
insert into PHONG values('D1203',0,null,'D1','L3')
insert into PHONG values('D1204',0,null,'D1','L3')
insert into PHONG values('D1205',0,null,'D1','L3')

insert into PHONG values('D1301',0,null,'D1','L3')
insert into PHONG values('D1302',0,null,'D1','L3')
insert into PHONG values('D1303',0,null,'D1','L3')
insert into PHONG values('D1304',0,null,'D1','L3')
insert into PHONG values('D1305',0,null,'D1','L3')

insert into PHONG values('D1401',0,null,'D1','L3')
insert into PHONG values('D1402',0,null,'D1','L3')
insert into PHONG values('D1403',0,null,'D1','L3')
insert into PHONG values('D1404',0,null,'D1','L3')
insert into PHONG values('D1405',0,null,'D1','L3')

insert into PHONG values('D1501',0,null,'D1','L3')
insert into PHONG values('D1502',0,null,'D1','L3')
insert into PHONG values('D1503',0,null,'D1','L3')
insert into PHONG values('D1504',0,null,'D1','L3')
insert into PHONG values('D1505',0,null,'D1','L3')
------------------------------------------------- D2
insert into PHONG values('D2101',0,null,'D2','L4')
insert into PHONG values('D2102',0,null,'D2','L4')
insert into PHONG values('D2103',0,null,'D2','L4')
insert into PHONG values('D2104',0,null,'D2','L4')
insert into PHONG values('D2105',0,null,'D2','L4')

insert into PHONG values('D2201',0,null,'D2','L4')
insert into PHONG values('D2202',0,null,'D2','L4')
insert into PHONG values('D2203',0,null,'D2','L4')
insert into PHONG values('D2204',0,null,'D2','L4')
insert into PHONG values('D2205',0,null,'D2','L4')

insert into PHONG values('D2301',0,null,'D2','L4')
insert into PHONG values('D2302',0,null,'D2','L4')
insert into PHONG values('D2303',0,null,'D2','L4')
insert into PHONG values('D2304',0,null,'D2','L4')
insert into PHONG values('D2305',0,null,'D2','L4')

insert into PHONG values('D2401',0,null,'D2','L4')
insert into PHONG values('D2402',0,null,'D2','L4')
insert into PHONG values('D2403',0,null,'D2','L4')
insert into PHONG values('D2404',0,null,'D2','L4')
insert into PHONG values('D2405',0,null,'D2','L4')

insert into PHONG values('D2501',0,null,'D2','L4')
insert into PHONG values('D2502',0,null,'D2','L4')
insert into PHONG values('D2503',0,null,'D2','L4')
insert into PHONG values('D2504',0,null,'D2','L4')
insert into PHONG values('D2505',0,null,'D2','L4')

---------------------------------------------- TaiKhoan
insert into TAIKHOAN values('admin','admin',N'Quản trị viên',null,null)
insert into TAIKHOAN values('nhanvien1','nhanvien1',N'Nhân viên',null,null)
insert into TAIKHOAN values('viet86710','matkhaus2',N'Sinh viên',null,null)
---------------------------------------------- Nhân viên
insert into NHANVIEN values('NV001',N'Nguyễn Văn Việt','10-15-2002',N'Nam','0766479036',N'Quản trị viên',null,'admin')
insert into NHANVIEN values('NV002',N'Nguyễn Thi Ngân','4-20-2002',N'Nữ','0952737521',N'Nhân viên',null,'nhanvien1')
----------------------------------------------Sinh viên
insert into SINHVIEN values('SV001',N'Nguyễn Văn Việt','10-15-2002',N'Nam',N'Khoa CNTT','CNT61DH','0766479036',N'Số 4A2/173 Hoàng Công Khanh/Lãm Hà/Kiến An/Hải Phòng',null,'viet86710')
---------------------------------------------- Hợp đồng
insert into HOPDONG values('8-30-2022','9-1-2022','2-1-2022',N'Đang','NV002','SV001','C3101',null)


select * from TAIKHOAN where TaiKhoan = '' and MatKhau = ''
select * from SINHVIEN where MaTK = 3
update SINHVIEN
set TenSV = {}, cot2 = gia_tri2...., cotN = gia_triN
where [DIEU_KIEN];

select NHANVIEN.TenNV,HOPDONG.*,SINHVIEN.TenSV,HOPDONG.MaPhong from NHANVIEN inner join HOPDONG on NHANVIEN.MaNV = HOPDONG.MaHD
inner join SINHVIEN on HOPDONG.MaSV = SINHVIEN.MaSV 

select NHANVIEN.TenNV,HOPDONG.*,SINHVIEN.TenSV,HOPDONG.MaPhong from 
                NHANVIEN inner join HOPDONG on NHANVIEN.MaNV = HOPDONG.MaNV
                inner join SINHVIEN on HOPDONG.MaSV = SINHVIEN.MaSV
                where HOPDONG.MaSV = 'SV001' and TrangThai = 1

select PHONG.*,LOAIPHONG.TenLoaiPhong,LOAIPHONG.SoNguoi,LOAIPHONG.GiaPhong,LOAIPHONG.DienTich
			,TenKhu,TenTN from LOAIPHONG inner join
            PHONG on LOAIPHONG.MaLoaiPhong = PHONG.MaLoaiPhong
            inner join TOANHA on TOANHA.MaTN = PHONG.MaTN
            inner join KHU on KHU.MaKhu = TOANHA.MaKhu
            where PHONG.MaPhong  = 'C3101'

select * from NHANVIEN inner join TAIKHOAN on NHANVIEN.MaTK = TAIKHOAN.MaTK
where MaNV = 'NV001'

select * from NHANVIEN inner join TAIKHOAN on NHANVIEN.TaiKhoan = TAIKHOAN.TaiKhoan where MaNV = 'NV001'

update NHANVIEN set TenNV = @ten,Ngaysinh = @ngaysinh,Gioitinh = @gioitinh,
SDT = @sdt,ChucVu = @chucvu,Ghichu = @ghichu, TaiKhoan = @matk where MaNV = @ma


values(@ma, @ten, @ngaysinh,@gioitinh,@sdt, @chucvu,@ghichu,@matk)

select TenTB,SoLuong,TrangThai from PHONG inner join THIETBIPHONG on PHONG.MaPhong
= THIETBIPHONG.MaPhong inner join THIETBI on THIETBI.MaTB = THIETBIPHONG.MaTB
where THIETBIPHONG.MaPhong = 'C3101'

select TenTB,SoLuong,TrangThai 
from PHONG inner join THIETBIPHONG on PHONG.MaPhong= THIETBIPHONG.MaPhong inner join
            THIETBI on THIETBI.MaTB = THIETBIPHONG.MaTB where THIETBIPHONG.MaPhong = 'C3102'

select MaPhong,MaTN,TenLoaiPhong,PHONG.TongSoHD,SoNguoi from PHONG inner join LOAIPHONG
on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong

 select MaPhong,TenLoaiPhong, CONCAT(CONVERT(char(1),TongSoHD),'/',CONVERT(char(1),SoNguoi))
  as SoNguoiO, MaTN,PHONG.Ghichu
  from PHONG inner join LOAIPHONG on PHONG.MaLoaiPhong = LOAIPHONG.MaLoaiPhong

use master
go
drop database QuanLyKiTucXa
