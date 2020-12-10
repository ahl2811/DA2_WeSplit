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
	MOTA text,
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