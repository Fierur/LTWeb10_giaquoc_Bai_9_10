create database sach
go
use sach
go
--DROP TABLE IF EXISTS chitietdonhang;
--DROP TABLE IF EXISTS donhang;
--DROP TABLE IF EXISTS thamgia;
--DROP TABLE IF EXISTS sach;
--DROP TABLE IF EXISTS nhaxuatban;
--DROP TABLE IF EXISTS khachhang;
--DROP TABLE IF EXISTS chude;
--DROP TABLE IF EXISTS tacgia;
--go
create table tacgia
(
	matg int primary key,
	tentg nvarchar(50),
	diachi nvarchar(200),
	tieusu nvarchar(500),
	dienthoai varchar(15)
)

create table chude
(
	macd int primary key,
	tencd nvarchar(200)
)

create table khachhang
(
	makh int primary key,
	hoten nvarchar(200),
	ngaysinh date,
	gioitinh nvarchar(3),
	dienthoai varchar(15),
	taikhoan varchar(200),
	matkhau varchar(500),
	email varchar(100),
	diachi nvarchar(200)
)

create table nhaxuatban
(
	manxb int primary key,
	tennxb nvarchar(50),
	diachi nvarchar(200),
	dienthoai varchar(15)
)

create table donhang
(
	madh int primary key,
	ngaygiao date,
	ngaydat date,
	dathanhtoan bit default 0, --0: chua thanh toan, 1: da thanh toan
	tinhtranggiaohang nvarchar(20), --chua giao, da giao
	makh int,
	foreign key(madh) references khachhang(makh)
)

create table sach
(
	masach int primary key,
	tensach nvarchar(50),
	giaban decimal(20,2),
	mota nvarchar(200),
	ngaycapnhat date,
	anhbia varchar(200),
	soluongton int,
	macd int,
	manxb int,
	moi bit, --0: cu, 1: moi
	foreign key(macd) references chude(macd),
	foreign key(manxb) references nhaxuatban(manxb),
)


create table thamgia
(
	masach int,
	matg int,
	vaitro nvarchar(50),
	vitri nvarchar(50)
	primary key(masach, matg),
	foreign key(matg) references tacgia(matg),
	foreign key(masach) references sach(masach)
)

create table chitietdonhang
(
	madh int,
	masach int,
	soluong int,
	dongia decimal(20,2)
	primary key(madh, masach),
	foreign key(madh) references donhang(madh),
	foreign key(masach) references sach(masach),
)


-- Bảng tác giả
INSERT INTO tacgia VALUES 
(1, N'Nguyễn Nhật Ánh', N'TP.HCM', N'Tác giả nổi tiếng viết sách cho thiếu nhi', '0909123456'),
(2, N'Trần Đăng Khoa', N'Hà Nội', N'Nhà thơ, nhà văn Việt Nam', '0912345678');

-- Bảng chủ đề
INSERT INTO chude VALUES
(1, N'Thiếu nhi'),
(2, N'Văn học Việt Nam');

-- Bảng khách hàng
INSERT INTO khachhang VALUES
(1, N'Lê Văn A', '1995-05-10', N'Nam', '0905123456', 'levana', '123456', 'vana@gmail.com', N'Hà Nội'),
(2, N'Trần Thị B', '2000-08-15', N'Nữ', '0906789123', 'tranb', 'abcdef', 'tranb@gmail.com', N'Hồ Chí Minh');

-- Bảng nhà xuất bản
INSERT INTO nhaxuatban VALUES
(1, N'NXB Trẻ', N'60-62 Lê Lợi, Quận 1, TP.HCM', '02838290230'),
(2, N'NXB Kim Đồng', N'55 Quang Trung, Hà Nội', '02439422100');

-- Bảng sách
INSERT INTO sach VALUES
(1, N'Mắt Biếc', 85000, N'Tiểu thuyết nổi tiếng của Nguyễn Nhật Ánh', '2023-05-10', 'matbiec.jpg', 100, 2, 2, 1),
(2, N'Cho Tôi Xin Một Vé Đi Tuổi Thơ', 65000, N'Sách thiếu nhi nổi tiếng', '2023-06-01', 'vetuoitho.jpg', 150, 1, 1, 1);
INSERT INTO sach VALUES
(3, N'Đảo Mộng Mơ', 72000, N'Truyện dành cho thiếu nhi', '2023-07-12', 'daomongmo.jpg', 80, 1, 1, 1),
(4, N'Tôi Thấy Hoa Vàng Trên Cỏ Xanh', 90000, N'Tác phẩm nổi tiếng của Nguyễn Nhật Ánh', '2023-07-20', 'hoavang.jpg', 120, 2, 2, 1),
(5, N'Còn Chút Gì Để Nhớ', 78000, N'Tiểu thuyết nhẹ nhàng, cảm xúc', '2023-07-30', 'conchutgidn.jpg', 60, 2, 1, 1);

-- Bảng tham gia
INSERT INTO thamgia VALUES
(1, 1, N'Tác giả chính', N'Tác giả'),
(2, 1, N'Tác giả chính', N'Tác giả');

-- Bảng đơn hàng
INSERT INTO donhang VALUES
(1, '2023-10-20', '2023-10-15', 1, N'Đã giao', 1),
(2, '2023-10-25', '2023-10-18', 0, N'Chưa giao', 2);

-- Bảng chi tiết đơn hàng
INSERT INTO chitietdonhang VALUES
(1, 1, 2, 85000),
(1, 2, 1, 65000),
(2, 2, 3, 65000);
SELECT * FROM tacgia;
SELECT * FROM chude;
SELECT * FROM sach;
SELECT * FROM donhang;
SELECT * FROM chitietdonhang;
