-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 16, 2020 at 05:21 PM
-- Server version: 10.4.13-MariaDB
-- PHP Version: 7.2.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `users_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `ID` int(11) NOT NULL,
  `Nume` varchar(40) NOT NULL,
  `Prenume` varchar(40) NOT NULL,
  `TipBursa` varchar(40) NOT NULL,
  `Liceu` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `Nume`, `Prenume`, `TipBursa`, `Liceu`) VALUES
(1, 'Bugeac', 'Claudiu', 'Merit', 'Liceul Economic \"Virgil Madgearu\" Galati'),
(2, 'Nisip', 'Ionut', 'Performanta', 'Liceul Emil Racovita'),
(3, 'Caramel', 'Viorel', 'Performanta', 'Liceul Sfanta Maria'),
(4, 'Cireasa', 'Marcel', 'Merit', 'Colegiul Vasile Alecsandri'),
(5, 'Sorinel', 'Florin', 'Performanta', 'Liceul de muzică'),
(6, 'Cioara', 'Mirel', 'Merit', 'Liceul Traian Vuia'),
(7, 'Sterp', 'Culita', 'Merit', 'Liceul de muzică'),
(8, 'Sterp', 'Iancu', 'Merit', 'Liceul de sport'),
(9, 'Nisip', 'Ionel', 'Merit', 'Liceul de arte'),
(10, 'Caterinca', 'Dani', 'Sociala', 'Liceul Traian Vuia'),
(11, 'Ginel', 'Cici', 'Merit', 'Liceul maritim'),
(12, 'Burlacu', 'Ion', 'Sociala', 'Liceul Sfanta Maria'),
(13, 'Nicolas', 'Valeriu', 'Merit', 'Liceul Economic'),
(14, 'Budinca', 'Robert', 'Sociala', 'Liceul de sport'),
(15, 'Cocu', 'Florin', 'Sociala', 'Liceul Sfanta Maria'),
(16, 'Codreanu', 'Gina', 'Sociala', 'Liceul Sfanta Maria'),
(17, 'Costeaasa', 'Virgilasasa', 'Performanta', 'Colegiul Vasile Alecsandri'),
(18, 'Iacob', 'Mihai', 'Merit', 'Colegiul Vasile Alecsandri'),
(19, 'Chiper', 'Andrei', 'Performanta', 'Liceul maritim'),
(20, 'Lozoveanu', 'Marcela', 'Performanta', 'Liceul Emil Racovita');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
