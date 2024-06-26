USE [master]
GO

/****** Object:  Database [BankDB]    Script Date: 07.05.2024 22:27:32 ******/
CREATE DATABASE [BankDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BankDB', FILENAME = N'E:\SQL\MSSQL16.MSSQLSERVER\MSSQL\DATA\BankDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BankDB_log', FILENAME = N'E:\SQL\MSSQL16.MSSQLSERVER\MSSQL\DATA\BankDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BankDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BankDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BankDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BankDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BankDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BankDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [BankDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BankDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BankDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BankDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BankDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BankDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BankDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BankDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BankDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BankDB] SET  ENABLE_BROKER 
GO

ALTER DATABASE [BankDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BankDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BankDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BankDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BankDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BankDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BankDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BankDB] SET RECOVERY FULL 
GO

ALTER DATABASE [BankDB] SET  MULTI_USER 
GO

ALTER DATABASE [BankDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BankDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BankDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BankDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BankDB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BankDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [BankDB] SET QUERY_STORE = ON
GO

ALTER DATABASE [BankDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [BankDB] SET  READ_WRITE 
GO

