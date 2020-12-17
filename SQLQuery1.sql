use master
go

create database QLChuyenDi
go

use QLChuyenDi

create table CHUYENDI
(
	MACHUYENDI varchar(6), 
	TENCHUYENDI nvarchar(30),
	TRANGTHAI char(7),
	DIADIEM nvarchar(50), 
	KHOANGCHI int,
	MOTA ntext,
	primary key (MACHUYENDI)
)

create table THANHVIEN
(
	MATHANHVIEN varchar(6),
	TENTHANHVIEN nvarchar(30),
	MACHUYENDI varchar(6),
	TIENTHU int,
	primary key (MATHANHVIEN)
)

create table HINHANHCHUYENDI
(
	MACHUYENDI varchar(6),
	HINHANH varchar(50),
	primary key (MACHUYENDI, HINHANH)
)

create table CACMOCLOTRINH
(
	MACHUYENDI varchar(6), 
	MOCLOTRINH nvarchar(50),
	primary key (MACHUYENDI, MOCLOTRINH)
)

create table MUCCHI
(
	STT int,
	MACHUYENDI varchar(6),
	NDCHI text,
	SOTIEN int,
	primary key (STT)
)

create table MUCUNGTRUOC
(
	STT int,
	MACHUYENDI varchar(6),
	MANGUOIUNG varchar(6),
	SOTIEN int,
	primary key (STT)
)

create table MUCTRALAI
(
	STT int,
	MACHUYENDI varchar(6),
	STTUNGTRUOC int,
	MANGUOITRA varchar(6),
	SOTIEN int,
	primary key (STT)
)

alter table THANHVIEN add constraint fk_MACHUYENDI1
foreign key (MACHUYENDI) references CHUYENDI(MACHUYENDI)

alter table HINHANHCHUYENDI add constraint fk_MACHUYENDI2
foreign key (MACHUYENDI) references CHUYENDI(MACHUYENDI)

alter table CACMOCLOTRINH add constraint fk_MACHUYENDI3
foreign key (MACHUYENDI) references CHUYENDI(MACHUYENDI)

alter table MUCCHI add constraint fk_MACHUYENDI4
foreign key (MACHUYENDI) references CHUYENDI(MACHUYENDI)

alter table MUCUNGTRUOC add constraint fk_MACHUYENDI5
foreign key (MACHUYENDI) references CHUYENDI(MACHUYENDI)

alter table MUCUNGTRUOC add constraint fk_MANGUOIUNG
foreign key (MANGUOIUNG) references THANHVIEN(MATHANHVIEN)

alter table MUCTRALAI add constraint fk_MACHUYENDI6
foreign key (MACHUYENDI) references CHUYENDI(MACHUYENDI)

alter table MUCTRALAI add constraint fk_MANGUOITRA
foreign key (MANGUOITRA) references THANHVIEN(MATHANHVIEN)

alter table MUCTRALAI add constraint fk_STTUNGTRUOC
foreign key (STTUNGTRUOC) references MUCTRALAI(STT)

drop database QLChuyenDi

insert into CHUYENDI values ('001', N'Biển Vũng Tàu', N'Đã Đi', N'Vũng Tàu', '7000000', N'Từ lâu Vũng tàu đã nổi tiếng với các bãi biển trải dài tuyệt đẹp của mình, tuy nhiên người ta thường chỉ nhớ tới Bãi trước và Bãi Sau mà quên rằng Vũng Tàu còn rất nhiều bãi biển đẹp khác.'),
							('002', N'Rạn Nam Ô',  N'Đang Đi', N'Đã Nẵng', '14000000', N'Có về Đà Nẵng, có qua hết các danh thắng quen mặt thì hãy dành thời gian cho bãi Rạn Nam Ô. Đến Rạn Nam Ô rồi, du khách không khỏi phải hồ hởi bất ngờ bởi bức họa muôn màu đến kỳ ảo mà bãi biển này mang lại. Nhất định, sẽ yêu ngay từ cái nhìn đầu tiên.'),
							('003', N'Mũi Né 4N3Đ', N'Đã Đi', N'Phan Thiết', '10000000', N'Mũi Né là trung tâm du lịch của thành phố phan thiết, nổi tiếng với những đồi cát rộng mênh mang, bãi biển tuyệt đẹp và những hàng dừa cao vút bao quanh bao biển quanh năm tràn ngập ánh nắng.'),
							('004', N'Rừng Dừa 7 Mẫu', N'Đang Đi', N'Hội An', '11000000', N'Du lịch Hội An chưa bao giờ hết hot với nhiều địa điểm lưu giữ lịch sử, không thể không kể đến Rừng dừa Bảy Mẫu, một nơi mà bạn chắc chắn sẽ thích thú khi được khám phá cảnh quan tuyệt đẹp và còn được chèo thuyền thúng để thử cái cảm giác lâng lâng khi lênh đênh trên sông nước nữa đấy.')

insert into THANHVIEN values	('00101', N'Lê Anh Hào', '001', '5000000'),
								('00102', N'Đào Văn Hiếu', '001', '1000000'),
								('00103', N'Nguyễn Minh Hiếu', '001', '1000000'),
								('00201', N'Lê Anh Hào', '002', '10000000'),
								('00202', N'Lý Đông Triệu', '002', '2000000'),
								('00203', N'Nguyễn Văn Hiển', '002', '2000000'),
								('00204', N'Đỗ Minh Tiến', '002', '2000000'),
								('00301', N'Nhậm Thanh Du', '003', '5000000'),
								('00302', N'Bùi Giang Lương', '003', '5000000'),
								('00401', N'Tống Mỹ Duyên', '004', '4000000'),
								('00402', N'Tống Anh Hiếu', '004', '4000000'),
								('00403', N'Lương Thị Bích Xuân', '004', '2000000'),
								('00404', N'Tống Nghĩa Hợp', '004', '2000000')

insert into HINHANHCHUYENDI values	('001', '1.png'),
									('001', '2.png'),
									('001', '3.png'),
									('002', '4.jpg'),
									('002', '5.jpg'),
									('002', '6.jpg'),
									('003', '7.jpg'),
									('003', '8.jpg'),
									('003', '9.jpg'),
									('004', '10.jpg'),
									('004', '11.jpg'),
									('004', '12.jpg')


insert into CACMOCLOTRINH values	('001', N'Bãi Trước'),
									('001', N'Bãi Sau'),
									('001', N'Mũi Nghinh Phong'),
									('002', N'Ghềnh Bàng'),
									('002', N'Bãi Tắm Nam Ô'),
									('002', N'Rạn Nam Ô'),
									('003', N'Đồi Cát Đỏ'),
									('003', N'Làng Chài Phan Thiết'),
									('003', N'Biển Mũi Né'),
									('004', N'Chùa Cầu'),
									('004', N'Bán Đảo Sơn Trà'),
									('004', N'Rừng Dừa 7 Mẫu')





select *
from CHUYENDI