using CourseProject2022FallBL.Models;
using CourseProject2022FallBL.Services;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject2022FallxUnitTest.DataServiceTests
{
    public class DatabaseFixtureUser : IDisposable
    {
        public string InitialCatalog { get; set; } = "UserTest";

        internal static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = "DESKTOP-9922B5A",
            InitialCatalog = "master",
            IntegratedSecurity = true,
            Encrypt = false,
        };

        public DatabaseFixtureUser()
        {
            using SqlConnection connection = new(builder.ConnectionString);
            var sql = $"use master;\r\n" +
                $"if exists(select * from sys.databases " +
                $"where name='{InitialCatalog}')\r\n" +
                $"drop database {InitialCatalog}\r\n\r\n" +
                $"create database {InitialCatalog}";
            using SqlCommand command = new(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            sql = $"use {InitialCatalog}\r\n" +
                $"create table Currency\r\n(\r\n\t" +
                $"ID int not null identity primary key,\r\n\t" +
                $"[Name] varchar(3) not null,\r\n\t" +
                $"Ratio real not null,\r\n);\r\n\r\n" +
                $"create table[Target]\r\n(\r\n\t" +
                $"ID int not null identity primary key,\r\n\t" +
                $"[Name] varchar(50) not null,\r\n);\r\n\r\n" +
                $"create table[User]\r\n(\r\n\t" +
                $"ID int not null identity primary key,\r\n\t" +
                $"[Name] varchar(100) not null,\r\n);\r\n\r\n" +
                $"create table Operation\r\n(\r\n\t" +
                $"ID int not null identity primary key,\r\n\t" +
                $"Value real not null,\r\n\t" +
                $"CurrencyID int not null,\r\n\t" +
                $"foreign key(CurrencyID) references Currency(ID),\r\n\t" +
                $"TargetID int not null,\r\n\t" +
                $"foreign key(TargetID) references[Target](ID),\r\n\t" +
                $"UserID int not null,\r\n\t" +
                $"foreign key(UserID) references[User](ID),\r\n\t" +
                $"Comment varchar(300) null,\r\n);\r\n\r\n" +
                $"create table Income\r\n(\r\n\t" +
                $"ID int not null identity primary key,\r\n\t" +
                $"OperationID int not null,\r\n\t" +
                $"foreign key(OperationID) references Operation(ID),\r\n);\r\n\r\n" +
                $"create table Expense\r\n(\r\n\t" +
                $"ID int not null identity primary key,\r\n\t" +
                $"OperationID int not null,\r\n\t" +
                $"foreign key(OperationID) references Operation(ID),\r\n); ";
            using SqlCommand command1 = new(sql, connection);
            connection.Open();
            command1.ExecuteNonQuery();
            connection.Close();
        }

        //#region Target
        //public bool AddTarget(Target target) => 
        //    DataService.AddTarget(target, InitialCatalog);

        //public Target GetTarget(int id) => 
        //    DataService.GetTarget(id, InitialCatalog);

        //public List<Target> GetTargets() => 
        //    DataService.GetTargets(InitialCatalog);

        //public int GetTargetID(Target target) => 
        //    DataService.GetTargetID(target, InitialCatalog);

        //public bool UpdateTarget(Target target) => 
        //    DataService.UpdateTarget(target, InitialCatalog);

        //public bool RemoveTarget(Target target) => 
        //    DataService.RemoveTarget(target, InitialCatalog);

        //public bool RemoveAllDataInTargetTable() =>
        //    DataService.RemoveAllDataInTargetTable(InitialCatalog);

        //public bool AddTargets(List<Target> targets) => 
        //    DataService.AddTargets(targets, InitialCatalog);

        //public bool UpsertTarget(Target target) => 
        //    DataService.UpsertTarget(target, InitialCatalog);
        //#endregion


        public void Dispose()
        {
            builder.InitialCatalog = "master";
            using SqlConnection connection = new(builder.ConnectionString);
            var sql = $"use master\r\nalter database {InitialCatalog} set single_user with rollback immediate\r\n\r\n drop database {InitialCatalog}";
            using SqlCommand command = new(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
