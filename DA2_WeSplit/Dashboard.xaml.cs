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
            String query = "insert into CHUYENDI values ('001', N'Biển Vũng Tàu', '0', N'Vũng Tàu',  N'Từ lâu Vũng tàu đã nổi tiếng với các bãi biển trải dài tuyệt đẹp của mình, tuy nhiên người ta thường chỉ nhớ tới Bãi trước và Bãi Sau mà quên rằng Vũng Tàu còn rất nhiều bãi biển đẹp khác.')," +
                "('002', N'Rạn Nam Ô', '0', N'Đã Nẵng', N'Có về Đà Nẵng, có qua hết các danh thắng quen mặt thì hãy dành thời gian cho bãi Rạn Nam Ô. Đến Rạn Nam Ô rồi, du khách không khỏi phải hồ hởi bất ngờ bởi bức họa muôn màu đến kỳ ảo mà bãi biển này mang lại. Nhất định, sẽ yêu ngay từ cái nhìn đầu tiên.')," +
                "('003', N'Mũi Né 4N3Đ', '0', N'Phan Thiết', N'Mũi Né là trung tâm du lịch của thành phố phan thiết, nổi tiếng với những đồi cát rộng mênh mang, bãi biển tuyệt đẹp và những hàng dừa cao vút bao quanh bao biển quanh năm tràn ngập ánh nắng.')," +
                "('004', N'Rừng Dừa 7 Mẫu', '0', N'Hội An', N'Du lịch Hội An chưa bao giờ hết hot với nhiều địa điểm lưu giữ lịch sử, không thể không kể đến Rừng dừa Bảy Mẫu, một nơi mà bạn chắc chắn sẽ thích thú khi được khám phá cảnh quan tuyệt đẹp và còn được chèo thuyền thúng để thử cái cảm giác lâng lâng khi lênh đênh trên sông nước nữa đấy.')";
            DatabaseHelper.executeQuery(query);


            query = "insert into THANHVIEN values ('00101', N'Lê Anh Hào')," +
                "('00102', N'Đào Văn Hiếu')," +
                "('00103', N'Nguyễn Minh Hiếu')," +
                "('00201', N'Lê Anh Hào')," +
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


            query = "insert into CHUYENDI_THANHVIEN values('001', '00101', '5000000')," +
                "('001', '00102', '1000000')," +
                "('001', '00103', '1000000')," +
                "('002', '00201', '10000000')," +
                "('002', '00202', '2000000')," +
                "('002', '00203', '2000000')," +
                "('002', '00204', '2000000')," +
                "('003', '00301', '5000000')," +
                "('003', '00302', '5000000')," +
                "('004', '00401', '4000000')," +
                "('004', '00402', '4000000')," +
                "('004', '00403', '2000000')," +
                "('004', '00404', '2000000')";
            DatabaseHelper.executeQuery(query);

            query = "insert into HINHANHCHUYENDI values	('001', '..\\Assets\\Images\\1.png')," +
                "('001', '..\\Assets\\Images\\2.png')," +
                "('001', '..\\Assets\\Images\\3.png')," +
                "('002', '..\\Assets\\Images\\4.jpg')," +
                "('002', '..\\Assets\\Images\\5.jpg')," +
                "('002', '..\\Assets\\Images\\6.jpg')," +
                "('003', '..\\Assets\\Images\\7.jpg')," +
                "('003', '..\\Assets\\Images\\8.jpg')," +
                "('003', '..\\Assets\\Images\\9.jpg')," +
                "('004', '..\\Assets\\Images\\10.jpg')," +
                "('004', '..\\Assets\\Images\\11.jpg')," +
                "('004', '..\\Assets\\Images\\12.jpg')";
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
                "('004', N'Rừng Dừa 7 Mẫu')";
            DatabaseHelper.executeQuery(query);
        }

        private void createDatabaseIfNotExist()
        {

            DatabaseHelper.Database = "master";
            String db = "QLChuyenDi";
            String query = "";
            String con = $"Server=localhost; Database= master; Trusted_Connection=True;";
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
                "primary key(STT))";
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

        private void LearnMoreButtonClick(int type)
        {
            MainScreen.Children.Clear();
            var tripDetailScreen = new TripDetailScreen(type);
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
