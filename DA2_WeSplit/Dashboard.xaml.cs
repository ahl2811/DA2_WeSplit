﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
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
            TripScreen allTripScreen = new TripScreen();
            MainScreen.Children.Add(allTripScreen);
            allTripScreen.LearnMoreHandler += LearnMoreButtonClick;
            allTripScreen.AddNewTripHandler += AddNewTripClick;

            createDatabaseIfNotExist();
        }

        private void createDatabaseIfNotExist()
        {

            DatabaseHelper.Database = "master";
            String db = "QLChuyenDi";
            String query = "";

            String con = $"Server=localhost; Database= master; Trusted_Connection=True;";
            bool isCreated = isDatabaseExists(con, db);

            if (!isCreated)
            {
                query = "create database QLChuyenDi";
                DatabaseHelper.executeQuery(query);

                DatabaseHelper.Database = db;

                query = "use QLChuyenDi";
                DatabaseHelper.executeQuery(query);

                createDefaultTable();
                addForeignKey();
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
                                "TRANGTHAI char(7)," +
                                "DIADIEM nvarchar(50)," +
                                "MOTA text," +
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
                "HINHANH varchar(50)," +
                "primary key(MACHUYENDI, HINHANH))";
            DatabaseHelper.executeQuery(query);

            query = "create table CACMOCLOTRINH(" +
                "MACHUYENDI varchar(6)," +
                "MOCLOTRINH nvarchar(50)," +
                "primary key(MACHUYENDI, MOCLOTRINH))";
            DatabaseHelper.executeQuery(query);

            query = "create table MUCCHI(" +
                "STT int," +
                "MACHUYENDI varchar(6)," +
                "NDCHI text," +
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

        public static bool isDatabaseExists(string connectionString, string databaseName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection))
                {
                    connection.Open();
                    return (command.ExecuteScalar() != DBNull.Value);
                }
            }
        }

        private void AddNewTripClick()
        {
            var newTrip = new NewTripScreen();
            MainScreen.Children.Clear();
            MainScreen.Children.Add(newTrip);
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
     
            MainScreen.Children.Clear();
            TripScreen allTripScreen = new TripScreen();
            MainScreen.Children.Add(allTripScreen);
            allTripScreen.LearnMoreHandler += LearnMoreButtonClick;
            allTripScreen.AddNewTripHandler += AddNewTripClick;
        }

        private void LearnMoreButtonClick()
        {
            MainScreen.Children.Clear();
            MainScreen.Children.Add(new TripDetailScreen());
        }

        private void CurrentTripButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen.Children.Clear();
            TripScreen currentTripScreen = new TripScreen();
            MainScreen.Children.Add(currentTripScreen);
            currentTripScreen.LearnMoreHandler += LearnMoreButtonClick;
            currentTripScreen.AddNewTripHandler += AddNewTripClick;
        }

        private void PassedTripButton_Click(object sender, RoutedEventArgs e)
        {
            MainScreen.Children.Clear();
            TripScreen passedTripScreen = new TripScreen();
            MainScreen.Children.Add(passedTripScreen);
            passedTripScreen.LearnMoreHandler += LearnMoreButtonClick;
            passedTripScreen.AddNewTripHandler += AddNewTripClick;
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
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
