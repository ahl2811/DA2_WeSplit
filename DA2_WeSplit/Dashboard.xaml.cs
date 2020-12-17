using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DA2_WeSplit.Database;
using DA2_WeSplit.Paging;
using DA2_WeSplit.Screens;

namespace DA2_WeSplit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            createDatabaseIfNotExist();
            UpdateTripScreen(0);

        }

        private void insertDefaultDatabase()
        {
            String query = "insert into CHUYENDI values ('001', N'Biển Vũng Tàu', '0', N'Vũng Tàu',  N'Từ lâu Vũng tàu đã nổi tiếng với các bãi biển trải dài tuyệt đẹp của mình, tuy nhiên người ta thường chỉ nhớ tới Bãi trước và Bãi Sau mà quên rằng Vũng Tàu còn rất nhiều bãi biển đẹp khác.', '1.png')," +
                "('002', N'Rạn Nam Ô', '0', N'Đã Nẵng', N'Có về Đà Nẵng, có qua hết các danh thắng quen mặt thì hãy dành thời gian cho bãi Rạn Nam Ô. Đến Rạn Nam Ô rồi, du khách không khỏi phải hồ hởi bất ngờ bởi bức họa muôn màu đến kỳ ảo mà bãi biển này mang lại. Nhất định, sẽ yêu ngay từ cái nhìn đầu tiên.', '4.jpg')," +
                "('003', N'Mũi Né 4N3Đ', '0', N'Phan Thiết', N'Mũi Né là trung tâm du lịch của thành phố phan thiết, nổi tiếng với những đồi cát rộng mênh mang, bãi biển tuyệt đẹp và những hàng dừa cao vút bao quanh bao biển quanh năm tràn ngập ánh nắng.', '7.jpg')," +
                "('004', N'Rừng Dừa 7 Mẫu', '0', N'Hội An', N'Du lịch Hội An chưa bao giờ hết hot với nhiều địa điểm lưu giữ lịch sử, không thể không kể đến Rừng dừa Bảy Mẫu, một nơi mà bạn chắc chắn sẽ thích thú khi được khám phá cảnh quan tuyệt đẹp và còn được chèo thuyền thúng để thử cái cảm giác lâng lâng khi lênh đênh trên sông nước nữa đấy.','10.jpg')," +
                "('005', N'Vịnh Hạ Long', '0', N'Hạ Long', N'Vịnh Hạ Long được Unesco nhiều lần công nhận là di sản thiên nhiên của thế giới với hàng nghìn hòn đảo được làm nên bởi tạo hoá kỳ vĩ và sống động. Vịnh Hạ Long có phong cảnh tuyệt đẹp nên nơi đây là một điểm du lịch rất hấp dẫn với du khách trong nước và quốc tế.','13.jpg'),"+
                "('006', N'Phượt Mù Cang Chải', '0', N'Yên Bái', N'Du lịch Mù Cang Chải mùa lúa chín là một trong những trải nghiệm tuyệt vời mà bạn không nên bỏ lỡ.','16.jpg')," +
                "('007', N'Đón Mùa Đông Sa Pa', '0', N'Sa Pa', N'Thời tiết Sapa tháng 11 vẫn có nắng vào ban ngày, đủ để mang lại cảm giác thoải mái cho du khách. Nhiệt độ xuống thấp vào buổi tối nhưng cũng không đến mức lạnh cóng mà chỉ man mát vừa đủ.','19.jpg')," +
                "('008', N'Du Lịch Đà Nẵng', '0', N'Đà Nẵng', N'Đà Nẵng một trong những trung tâm du lịch hàng đầu miền trung là địa điểm du lịch mà bạn không thể bỏ qua. Với những bãi biển dài, xanh trong, không khí trong lành và những món ăn ngon lành. Check ngay 47 địa điểm du lịch Đà Nẵng đẹp đến quên lối về ngay và lên đường khám phá thành phố đáng sống nhất Việt Nam.','22.jpg')," +
                "('009', N'Đà Lạt Trip', '0', N'Đà Lạt', N'Bạn sẽ phải lòng Đà Lạt ngay từ lần đầu tiên đặt chân tới bởi vùng đất ấy bình yên như hơi thở, bởi những cái tên mà vùng đất ấy mang trong mình như thành phố ngàn hoa, xứ sở tình yêu, thành phố đượm buồn, thành phố mộng mơ…','25.jpg')," +
                "('010', N'Du Lịch Phú Quốc', '0', N'Phú Quốc', N'Phú Quốc còn có tên gọi khác là đảo Ngọc hòn đảo lớn nhất nước ta thuộc Vịnh Thái Lan. Hằng năm, nơi đây đón hàng triệu lượt khách du lịch trong và nước bởi vẻ đẹp hoang sơ, quyến rũ và các khách sạn rất đẹp.','28.jpg')";
            DatabaseHelper.executeQuery(query);


            query = "insert into THANHVIEN values ('00101', N'Lê Anh Hào')," +
                "('00102', N'Đào Văn Hiếu')," +
                "('00103', N'Nguyễn Minh Hiếu')," +
                "('00202', N'Lý Đông Triệu')," +
                "('00203', N'Nguyễn Văn Hiển')," +
                "('00204', N'Đỗ Minh Tiến')," +
                "('00301', N'Nhậm Thanh Du')," +
                "('00302', N'Bùi Giang Lương')," +
                "('00401', N'Tống Mỹ Duyên')," +
                "('00402', N'Tống Anh Hiếu')," +
                "('00403', N'Lương Thị Bích Xuân')," +
                "('00404', N'Tống Nghĩa Hợp')";
            DatabaseHelper.executeQuery(query);




            query = "insert into HINHANHCHUYENDI values	('001', '1.png')," +
                "('001', '2.png')," +
                "('001', '3.png')," +
                "('002', '4.jpg')," +
                "('002', '5.jpg')," +
                "('002', '6.jpg')," +
                "('003', '7.jpg')," +
                "('003', '8.jpg')," +
                "('003', '9.jpg')," +
                "('004', '10.jpg')," +
                "('004', '11.jpg')," +
                "('004', '12.jpg')," +
                "('005', '13.jpg')," +
                "('005', '14.jpg')," +
                "('005', '15.jpg')," +
                "('006', '16.jpg')," +
                "('006', '17.jpg')," +
                "('006', '18.jpg')," +
                "('007', '19.jpg')," +
                "('007', '20.png')," +
                "('007', '21.jpg')," +
                "('008', '22.jpg')," +
                "('008', '23.jpg')," +
                "('008', '24.jpg')," +
                "('009', '25.jpg')," +
                "('009', '26.png')," +
                "('009', '27.jpg')," +
                "('010', '28.jpg')," +
                "('010', '29.jpg')," +
                "('010', '30.jpg')";
           DatabaseHelper.executeQuery(query);

            query = "insert into CACMOCLOTRINH values ('001', N'Bãi Trước')," +
                "('001', N'Bãi Sau')," +
                "('001', N'Mũi Nghinh Phong')," +
                "('002', N'Ghềnh Bàng')," +
                "('002', N'Bãi Tắm Nam Ô')," +
                "('002', N'Rạn Nam Ô')," +
                "('003', N'Đồi Cát Đỏ')," +
                "('003', N'Làng Chài Phan Thiết')," +
                "('003', N'Biển Mũi Né')," +
                "('004', N'Chùa Cầu')," +
                "('004', N'Bán Đảo Sơn Trà')," +
                "('004', N'Rừng Dừa 7 Mẫu')," +
                "('005', N'Thành Phố Hạ Long')," +
                "('005', N'Quần Đảo Cát Bà')," +
                "('005', N'Vịnh Hạ Long'),"+
                "('006', N'Đèo Khau Pạ')," +
                "('006', N'Đồi La Phán Tẩn')," +
                "('006', N'Mù Cang Chải')," +
                "('007', N'Thung Lũng Mường Hoa')," +
                "('007', N'Thác Tình Yêu')," +
                "('007', N'Thung Lũng Hao Hồng')," +
                "('008', N'Bà Nà Hill')," +
                "('008', N'Asia Park')," +
                "('008', N'Bảo Tàng 3D TrickEye')," +
                "('009', N'Hồ Xuân Hương')," +
                "('009', N'Thung Lũng Tình Yêu')," +
                "('009', N'Trường Đại Học Đà Lạt')," +
                "('010', N'Chợ Phú Quốc')," +
                "('010', N'Ẩm Thực Ven Biển Bãi Khem')," +
                "('010', N'Quán Hải Sản Ngân Hà')";

            DatabaseHelper.executeQuery(query);

            query = "insert into MUCCHI values ('00101', '001',  N'Đồ Ăn', 5000000)," +
                "(00102, '001', N'Du Lịch', 4000000)," +
                "(00103, '001', N'Thuê Nhà', 3000000)," +
                "(00201, '002', N'Đồ Ăn', 5000000)," +
                "(00202, '002', N'Du Lịch', 4000000)," +
                "(00203, '002', N'Thuê Nhà', 3000000)," +
                "(00301, '003', N'Đồ Ăn', 5000000)," +
                "(00302, '003', N'Du Lịch', 4000000)," +
                "(00303, '003', N'Thuê Nhà', 3000000)," +
                "(00401, '004', N'Đồ Ăn', 5000000)," +
                "(00402, '004', N'Du Lịch', 4000000)," +
                "(00403, '005', N'Thuê Nhà', 3000000),"+
                "(00601, '006', N'Đồ Ăn', 5000000)," +
                "(00602, '006', N'Du Lịch', 4000000)," +
                "(00603, '006', N'Thuê Nhà', 3000000)," +
                "(00701, '007', N'Đồ Ăn', 5000000)," +
                "(00702, '007', N'Du Lịch', 4000000)," +
                "(00703, '007', N'Thuê Nhà', 3000000)," +
                "(00801, '008', N'Đồ Ăn', 5000000)," +
                "(00802, '008', N'Du Lịch', 4000000)," +
                "(00803, '008', N'Thuê Nhà', 3000000)," +
                "(00901, '009', N'Đồ Ăn', 5000000)," +
                "(00902, '009', N'Du Lịch', 4000000)," +
                "(00903, '009', N'Thuê Nhà', 3000000)," +
                "(01001, '010', N'Đồ Ăn', 5000000)," +
                "(01002, '010', N'Du Lịch', 4000000)," +
                "(01003, '010', N'Thuê Nhà', 3000000)," +
                "(00501, '005', N'Đồ Ăn', 5000000)," +
                "(00502, '005', N'Du Lịch', 4000000)," +
                "(00503, '005', N'Thuê Nhà', 3000000)";
            DatabaseHelper.executeQuery(query);

            query = "insert into CHUYENDI_THANHVIEN values('001', '00101', 5000000)," +
               "('001', '00102', 1000000)," +
               "('001', '00103', 1000000)," +
               "('002', '00101', 10000000)," +
               "('002', '00202', 2000000)," +
               "('002', '00203', 2000000)," +
               "('002', '00204', 2000000)," +
               "('003', '00301', 5000000)," +
               "('003', '00302', 5000000)," +
               "('004', '00401', 4000000)," +
               "('004', '00402', 4000000)," +
               "('004', '00403', 2000000)," +
               "('004', '00404', 2000000)," +
               "('005', '00101', 5000000)," +
               "('005', '00202', 1000000)," +
               "('005', '00203', 1000000)," +
               "('006', '00101', 10000000)," +
               "('006', '00102', 2000000)," +
               "('006', '00203', 2000000)," +
               "('006', '00204', 2000000)," +
               "('007', '00301', 10000000)," +
               "('007', '00402', 2000000)," +
               "('007', '00103', 2000000)," +
               "('007', '00204', 2000000)," +
               "('008', '00101', 10000000)," +
               "('008', '00202', 2000000)," +
               "('008', '00203', 2000000)," +
               "('008', '00204', 2000000)," +
               "('009', '00301', 10000000)," +
               "('009', '00202', 2000000)," +
               "('009', '00203', 2000000)," +
               "('009', '00204', 2000000)," +
               "('010', '00102', 2000000)," +
               "('010', '00103', 2000000)," +
               "('010', '00204', 2000000)";
            DatabaseHelper.executeQuery(query);

        }

        private void createDatabaseIfNotExist()
        {

            DatabaseHelper.Database = "master";
            String db = "QLChuyenDi";
            String query = "";
            String con = $"Server=localhost; Database= master; Trusted_Connection=True;";
            //query = "drop database QLChuyenDi";
            //DatabaseHelper.executeQuery(query);
            bool isCreated = DatabaseHelper.isDatabaseExists(con, db);

            if (!isCreated)
            {
                query = "create database QLChuyenDi";
                DatabaseHelper.executeQuery(query);

                DatabaseHelper.Database = db;

                query = "use QLChuyenDi";
                DatabaseHelper.executeQuery(query);

                createDefaultTable();
                addForeignKey();
                insertDefaultDatabase();
            }

            DatabaseHelper.Database = db;
        }



        private void addForeignKey()
        {
            String query = "";

            query = "alter table CHUYENDI_THANHVIEN add constraint fk_MACHUYENDI10 foreign key(MACHUYENDI) references CHUYENDI(MACHUYENDI)";
            DatabaseHelper.executeQuery(query);

            query = "alter table CHUYENDI_THANHVIEN add constraint fk_MATHANHVIEN10 foreign key(MATHANHVIEN) references THANHVIEN(MATHANHVIEN)";
            DatabaseHelper.executeQuery(query);

            query = "alter table HINHANHCHUYENDI add constraint fk_MACHUYENDI2 foreign key(MACHUYENDI) references CHUYENDI(MACHUYENDI)";
            DatabaseHelper.executeQuery(query);

            query = "alter table CACMOCLOTRINH add constraint fk_MACHUYENDI3 foreign key(MACHUYENDI) references CHUYENDI(MACHUYENDI)";
            DatabaseHelper.executeQuery(query);

            query = "alter table MUCCHI add constraint fk_MACHUYENDI4 foreign key(MACHUYENDI) references CHUYENDI(MACHUYENDI)";
            DatabaseHelper.executeQuery(query);

            query = "alter table MUCUNGTRUOC add constraint fk_MACHUYENDI5 foreign key(MACHUYENDI) references CHUYENDI(MACHUYENDI)";
            DatabaseHelper.executeQuery(query);

            query = "alter table MUCUNGTRUOC add constraint fk_MANGUOIUNG foreign key(MANGUOIUNG) references THANHVIEN(MATHANHVIEN)";
            DatabaseHelper.executeQuery(query);

            query = "alter table MUCTRALAI add constraint fk_MACHUYENDI6 foreign key(MACHUYENDI) references CHUYENDI(MACHUYENDI)";
            DatabaseHelper.executeQuery(query);

            query = "alter table MUCTRALAI add constraint fk_MANGUOITRA foreign key(MANGUOITRA) references THANHVIEN(MATHANHVIEN)";
            DatabaseHelper.executeQuery(query);

            query = "alter table MUCTRALAI add constraint fk_STTUNGTRUOC foreign key(STTUNGTRUOC) references MUCTRALAI(STT)";
            DatabaseHelper.executeQuery(query);
        }

        private void createDefaultTable()
        {
            String query = "";

            query = "create table CHUYENDI(" +
                                "MACHUYENDI varchar(6)," +
                                "TENCHUYENDI nvarchar(30)," +
                                "TRANGTHAI int," +
                                "DIADIEM nvarchar(50)," +
                                "MOTA nvarchar(1000)," +
                                "ANHBIA varchar(200)," +
                                "primary key(MACHUYENDI))";
            DatabaseHelper.executeQuery(query);

            query = "create table THANHVIEN(" +
                "MATHANHVIEN varchar(6)," +
                "TENTHANHVIEN nvarchar(30)," +
                "primary key(MATHANHVIEN))";
            DatabaseHelper.executeQuery(query);

            query = "create table CHUYENDI_THANHVIEN(" +
                "MACHUYENDI varchar(6)," +
                "MATHANHVIEN varchar(6)," +
                "TIENTHU int," +
                "primary key(MACHUYENDI, MATHANHVIEN))";
            DatabaseHelper.executeQuery(query);

            query = "create table HINHANHCHUYENDI(" +
                "MACHUYENDI varchar(6)," +
                "HINHANH varchar(200)," +
                "primary key(MACHUYENDI, HINHANH))";
            DatabaseHelper.executeQuery(query);

            query = "create table CACMOCLOTRINH(" +
                "MACHUYENDI varchar(6)," +
                "MOCLOTRINH nvarchar(100)," +
                "primary key(MACHUYENDI, MOCLOTRINH))";
            DatabaseHelper.executeQuery(query);

            query = "create table MUCCHI(" +
                "STT int," +
                "MACHUYENDI varchar(6)," +
                "NDCHI nvarchar(100)," +
                "SOTIEN int," +
                "primary key(STT, MACHUYENDI))";
            DatabaseHelper.executeQuery(query);

            query = "create table MUCUNGTRUOC(" +
                "STT int," +
                "MACHUYENDI varchar(6)," +
                "MANGUOIUNG varchar(6)," +
                "SOTIEN int," +
                "primary key(STT))";
            DatabaseHelper.executeQuery(query);

            query = "create table MUCTRALAI(" +
                "STT int," +
                "MACHUYENDI varchar(6)," +
                "STTUNGTRUOC int," +
                "MANGUOITRA varchar(6)," +
                "SOTIEN int," +
                "primary key(STT))";
            DatabaseHelper.executeQuery(query);
        }

        private void AddNewTripClick(int type)
        {
            var newTrip = new NewTripScreen(type);
            MainScreen.Children.Clear();
            MainScreen.Children.Add(newTrip);
            newTrip.ExitHandler += exitDetailTripScreenButton_Click;
        }

        private void RowDefinition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState != WindowState.Maximized)
            {
                this.WindowState = WindowState.Maximized;
                
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AllTripButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateTripScreen(0);
        }

        private void LearnMoreButtonClick(int type, string maChuyenDi)
        {
            MainScreen.Children.Clear();
            var tripDetailScreen = new TripDetailScreen(type, maChuyenDi);
            MainScreen.Children.Add(tripDetailScreen);
            tripDetailScreen.ExitHandler += exitDetailTripScreenButton_Click;
        }

        private void exitDetailTripScreenButton_Click(int type)
        {
            MainScreen.Children.Clear();
            UpdateTripScreen(type);
        }

        private void UpdateTripScreen(int type)//0 la All, 1 la Current, 2 la Passed
        {
            MainScreen.Children.Clear();
            TripScreen tripScreen = new TripScreen(type);
            MainScreen.Children.Add(tripScreen);
            tripScreen.LearnMoreHandler += LearnMoreButtonClick;
            tripScreen.AddNewTripHandler += AddNewTripClick;
        }

        private void CurrentTripButton_Click(object sender, RoutedEventArgs e)
        {

            UpdateTripScreen(1);
        }

        private void PassedTripButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateTripScreen(2);
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            UIElementCollection child = MainScreen.Children;
            MainScreen.Children.Clear();
            MainScreen.Children.Add(new SettingScreen());
        }

        private void SupportButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen.Children.Clear();
            MainScreen.Children.Add(new SupportScreen());
        }
    }

}
