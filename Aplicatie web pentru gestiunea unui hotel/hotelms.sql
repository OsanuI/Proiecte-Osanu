-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gazdă: 127.0.0.1
-- Timp de generare: iul. 13, 2022 la 12:16 PM
-- Versiune server: 10.4.22-MariaDB
-- Versiune PHP: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Bază de date: `hotelms`
--

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `booking`
--

CREATE TABLE `booking` (
  `booking_id` int(10) NOT NULL,
  `customer_id` int(10) NOT NULL,
  `room_id` int(10) NOT NULL,
  `booking_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `check_in` varchar(100) DEFAULT NULL,
  `check_out` varchar(100) NOT NULL,
  `total_price` int(10) NOT NULL,
  `remaining_price` int(10) NOT NULL,
  `payment_status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `booking`
--

INSERT INTO `booking` (`booking_id`, `customer_id`, `room_id`, `booking_date`, `check_in`, `check_out`, `total_price`, `remaining_price`, `payment_status`) VALUES
(90, 91, 94, '2022-06-06 12:57:16', '05-07-2022', '07-07-2022', 600, 0, 1),
(91, 92, 95, '2022-06-05 13:01:59', '06-06-2022', '07-06-2022', 300, 0, 1),
(92, 93, 96, '2022-05-10 13:11:29', '11-05-2022', '13-05-2022', 600, 600, 0),
(93, 94, 91, '2022-06-14 14:29:09', '15-06-2022', '17-06-2022', 500, 0, 1),
(94, 95, 95, '2022-07-06 07:13:29', '06-07-2022', '08-07-2022', 600, 300, 0);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `complaint`
--

CREATE TABLE `complaint` (
  `id` int(11) NOT NULL,
  `complainant_name` varchar(100) NOT NULL,
  `complaint_type` varchar(100) NOT NULL,
  `complaint` varchar(200) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `resolve_status` tinyint(1) NOT NULL,
  `resolve_date` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `budget` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `complaint`
--

INSERT INTO `complaint` (`id`, `complainant_name`, `complaint_type`, `complaint`, `created_at`, `resolve_status`, `resolve_date`, `budget`) VALUES
(16, 'Bulgaru Florin', 'Defec?iune fereastr?', 'Nu se mai închide fereastra din camera S-E1.', '2022-07-06 06:56:45', 1, '2022-07-06 06:58:23', 100);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `customer`
--

CREATE TABLE `customer` (
  `customer_id` int(10) NOT NULL,
  `customer_name` varchar(100) NOT NULL,
  `contact_no` varchar(20) NOT NULL,
  `email` varchar(100) NOT NULL,
  `id_card_type_id` int(10) NOT NULL,
  `id_card_no` varchar(20) NOT NULL,
  `address` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `customer`
--

INSERT INTO `customer` (`customer_id`, `customer_name`, `contact_no`, `email`, `id_card_type_id`, `id_card_no`, `address`) VALUES
(91, 'Litvinenco Costel', '0743334445', 'lc@yahoo.com', 1, '1921104170053', 'Galati'),
(92, 'Dublea Adrian', '0748883339', 'da@yahoo.com', 1, '1950301141051', 'Brasov'),
(93, 'Iliescu Stefan', '0748889991', 'si@yahoo.com', 1, '1980202172052', 'Galati'),
(94, 'Mitrofan Claudiu', '0748883339', 'yo@yahoo.com', 1, '1991204473052', 'Galati'),
(95, 'Bujor M?d?lin', '0788833398', 'yo@yahoo.com', 1, '1971204670552', 'Galati');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `emp_history`
--

CREATE TABLE `emp_history` (
  `id` int(11) NOT NULL,
  `emp_id` int(11) NOT NULL,
  `shift_id` int(11) NOT NULL,
  `from_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `to_date` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `emp_history`
--

INSERT INTO `emp_history` (`id`, `emp_id`, `shift_id`, `from_date`, `to_date`, `created_at`) VALUES
(68, 33, 1, '2022-07-05 15:39:10', NULL, '2022-07-05 15:39:10'),
(69, 34, 4, '2022-07-05 15:56:40', '2022-07-05 15:01:47', '2022-07-05 15:56:40'),
(70, 34, 3, '2022-07-05 16:01:47', '2022-07-06 05:29:58', '2022-07-05 16:01:47'),
(71, 32, 2, '2022-07-05 16:13:23', NULL, '2022-07-05 16:13:23'),
(72, 34, 4, '2022-07-06 06:29:58', '2022-07-11 10:03:16', '2022-07-06 06:29:58'),
(73, 34, 3, '2022-07-11 11:03:16', '2022-07-12 09:42:06', '2022-07-11 11:03:16'),
(74, 35, 1, '2022-07-11 11:21:07', NULL, '2022-07-11 11:21:07'),
(77, 34, 4, '2022-07-12 10:42:06', NULL, '2022-07-12 10:42:06');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `id_card_type`
--

CREATE TABLE `id_card_type` (
  `id_card_type_id` int(10) NOT NULL,
  `id_card_type` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `id_card_type`
--

INSERT INTO `id_card_type` (`id_card_type_id`, `id_card_type`) VALUES
(1, 'Carte de identitate'),
(2, 'Pasaport'),
(3, 'Permis de conducere');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `review`
--

CREATE TABLE `review` (
  `review_id` int(11) NOT NULL,
  `user_name` varchar(200) NOT NULL,
  `user_rating` int(1) NOT NULL,
  `user_review` text NOT NULL,
  `datetime` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `review`
--

INSERT INTO `review` (`review_id`, `user_name`, `user_rating`, `user_review`, `datetime`) VALUES
(11, 'Mihai', 3, 'Am avut probleme cu personalul, dar in rest totul ok!', 1655283658),
(12, 'Dan', 5, 'Foarte frumos', 1655283972),
(13, 'Iulia', 5, 'M-am simtit extraordinar!', 1655284058),
(14, 'Andrei', 5, 'Foarte frumos', 1655305448),
(15, 'Ionut', 5, 'Totul a fost perfect!', 1657022104),
(16, 'Gabi', 4, 'Un hotel foarte frumos.', 1657538326),
(17, 'Ioan', 5, 'M-am simtit foarte bine.', 1657622019);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `room`
--

CREATE TABLE `room` (
  `room_id` int(10) NOT NULL,
  `room_type_id` int(10) NOT NULL,
  `room_no` varchar(10) NOT NULL,
  `status` tinyint(1) DEFAULT NULL,
  `check_in_status` tinyint(1) NOT NULL,
  `check_out_status` tinyint(1) NOT NULL,
  `deleteStatus` tinyint(1) DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `room`
--

INSERT INTO `room` (`room_id`, `room_type_id`, `room_no`, `status`, `check_in_status`, `check_out_status`, `deleteStatus`) VALUES
(88, 1, 'S-E1', NULL, 0, 0, 0),
(89, 1, 'S-E2', NULL, 0, 0, 0),
(90, 1, 'S-E3', NULL, 0, 0, 0),
(91, 2, 'D-E1', NULL, 0, 0, 0),
(92, 2, 'D-E2', 1, 0, 0, 0),
(93, 2, 'D-E3', NULL, 0, 0, 0),
(94, 3, 'DT-E1', NULL, 0, 1, 0),
(95, 3, 'DT-E2', 1, 1, 1, 0),
(96, 3, 'DT-E3', 1, 0, 0, 0),
(97, 4, 'M-E1', NULL, 0, 0, 0),
(98, 4, 'M-E2', NULL, 0, 0, 0),
(99, 4, 'M-E3', NULL, 0, 0, 0),
(100, 5, 'T-E1', NULL, 0, 0, 0),
(101, 5, 'T-E2', NULL, 0, 0, 0),
(102, 5, 'T-E3', NULL, 0, 0, 0),
(103, 6, 'Q-E1', NULL, 0, 0, 0),
(104, 6, 'Q-E2', NULL, 0, 0, 0),
(105, 6, 'Q-E3', NULL, 0, 0, 0),
(106, 2, 'D-E4', NULL, 0, 0, 0);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `room_type`
--

CREATE TABLE `room_type` (
  `room_type_id` int(10) NOT NULL,
  `room_type` varchar(100) NOT NULL,
  `price` int(10) NOT NULL,
  `max_person` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `room_type`
--

INSERT INTO `room_type` (`room_type_id`, `room_type`, `price`, `max_person`) VALUES
(1, 'Single', 150, 1),
(2, 'Dubla', 250, 2),
(3, 'Dubla twin', 300, 2),
(4, 'Matrimoniala', 500, 2),
(5, 'Tripla', 700, 3),
(6, 'Quad', 1000, 4);

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `shift`
--

CREATE TABLE `shift` (
  `shift_id` int(10) NOT NULL,
  `shift` varchar(100) NOT NULL,
  `shift_timing` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `shift`
--

INSERT INTO `shift` (`shift_id`, `shift`, `shift_timing`) VALUES
(1, 'Dimineata', '5:00 AM - 10:00 AM'),
(2, 'Zi', '10:00 AM - 4:00 PM'),
(3, 'Seara', '4:00 PM - 10:00 PM'),
(4, 'Noapte', '10:00 PM - 5:00 AM');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `staff`
--

CREATE TABLE `staff` (
  `emp_id` int(11) NOT NULL,
  `emp_name` varchar(100) NOT NULL,
  `staff_type_id` int(11) NOT NULL,
  `shift_id` int(11) NOT NULL,
  `id_card_type` int(11) NOT NULL,
  `id_card_no` varchar(20) NOT NULL,
  `address` varchar(100) NOT NULL,
  `contact_no` varchar(10) NOT NULL,
  `salary` bigint(20) NOT NULL,
  `joining_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `staff`
--

INSERT INTO `staff` (`emp_id`, `emp_name`, `staff_type_id`, `shift_id`, `id_card_type`, `id_card_no`, `address`, `contact_no`, `salary`, `joining_date`, `updated_at`) VALUES
(32, 'Mitrofan Adrian', 4, 2, 1, '1234567891023', 'Brasov', '0748341970', 5000, '2022-06-29 12:33:12', '2022-07-05 16:13:23'),
(33, 'Cuibaru Mihai', 4, 1, 1, '1981204272052', 'Brasov', '0748399444', 3000, '2022-07-05 15:39:10', '2022-07-05 15:39:10'),
(34, 'Sofitei Darius', 7, 4, 1, '1950604130353', 'Brasov', '0728241972', 3000, '2022-07-05 15:56:40', '2022-07-12 10:42:06'),
(35, 'Coman Oana', 1, 1, 1, '2981004132251', 'Brasov', '0748343332', 2000, '2022-07-11 11:21:07', '2022-07-11 11:21:07');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `staff_type`
--

CREATE TABLE `staff_type` (
  `staff_type_id` int(10) NOT NULL,
  `staff_type` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `staff_type`
--

INSERT INTO `staff_type` (`staff_type_id`, `staff_type`) VALUES
(1, 'Administrator'),
(2, 'Administrator de menaj'),
(3, 'Receptioner'),
(4, 'Bucatar'),
(5, 'Ospatar'),
(6, 'Insotitor camera'),
(7, 'Paznic'),
(8, 'Inginer de intretinere hoteliera'),
(9, 'Director de vanzari');

-- --------------------------------------------------------

--
-- Structură tabel pentru tabel `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `username` varchar(15) NOT NULL,
  `email` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `role` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Eliminarea datelor din tabel `user`
--

INSERT INTO `user` (`id`, `name`, `username`, `email`, `password`, `created_at`, `role`) VALUES
(8, 'Osanu', 'Ionut', 'yo@yahoo.com', '123456', '2022-05-12 09:55:56', 'administrator'),
(9, 'Paun', 'Dan', 'dan@yahoo.com', '123456', '2022-05-12 10:04:02', 'receptioner'),
(10, 'Radu', 'Alexandru', 'alex@yahoo.com', '123456', '2022-05-12 10:25:32', 'client'),
(17, 'Mitrofan', 'Adi', 'ma@yahoo.com', '123456', '2022-06-29 13:00:42', 'client');

--
-- Indexuri pentru tabele eliminate
--

--
-- Indexuri pentru tabele `booking`
--
ALTER TABLE `booking`
  ADD PRIMARY KEY (`booking_id`),
  ADD KEY `customer_id` (`customer_id`),
  ADD KEY `room_id` (`room_id`);

--
-- Indexuri pentru tabele `complaint`
--
ALTER TABLE `complaint`
  ADD PRIMARY KEY (`id`);

--
-- Indexuri pentru tabele `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`customer_id`),
  ADD KEY `customer_id_type` (`id_card_type_id`);

--
-- Indexuri pentru tabele `emp_history`
--
ALTER TABLE `emp_history`
  ADD PRIMARY KEY (`id`),
  ADD KEY `emp_id` (`emp_id`),
  ADD KEY `shift_id` (`shift_id`);

--
-- Indexuri pentru tabele `id_card_type`
--
ALTER TABLE `id_card_type`
  ADD PRIMARY KEY (`id_card_type_id`);

--
-- Indexuri pentru tabele `review`
--
ALTER TABLE `review`
  ADD PRIMARY KEY (`review_id`);

--
-- Indexuri pentru tabele `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`room_id`),
  ADD KEY `room_type_id` (`room_type_id`);

--
-- Indexuri pentru tabele `room_type`
--
ALTER TABLE `room_type`
  ADD PRIMARY KEY (`room_type_id`);

--
-- Indexuri pentru tabele `shift`
--
ALTER TABLE `shift`
  ADD PRIMARY KEY (`shift_id`);

--
-- Indexuri pentru tabele `staff`
--
ALTER TABLE `staff`
  ADD PRIMARY KEY (`emp_id`),
  ADD KEY `id_card_type` (`id_card_type`),
  ADD KEY `shift_id` (`shift_id`),
  ADD KEY `staff_type_id` (`staff_type_id`);

--
-- Indexuri pentru tabele `staff_type`
--
ALTER TABLE `staff_type`
  ADD PRIMARY KEY (`staff_type_id`);

--
-- Indexuri pentru tabele `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT pentru tabele eliminate
--

--
-- AUTO_INCREMENT pentru tabele `booking`
--
ALTER TABLE `booking`
  MODIFY `booking_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=97;

--
-- AUTO_INCREMENT pentru tabele `complaint`
--
ALTER TABLE `complaint`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT pentru tabele `customer`
--
ALTER TABLE `customer`
  MODIFY `customer_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=98;

--
-- AUTO_INCREMENT pentru tabele `emp_history`
--
ALTER TABLE `emp_history`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=78;

--
-- AUTO_INCREMENT pentru tabele `id_card_type`
--
ALTER TABLE `id_card_type`
  MODIFY `id_card_type_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pentru tabele `review`
--
ALTER TABLE `review`
  MODIFY `review_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT pentru tabele `room`
--
ALTER TABLE `room`
  MODIFY `room_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=107;

--
-- AUTO_INCREMENT pentru tabele `room_type`
--
ALTER TABLE `room_type`
  MODIFY `room_type_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT pentru tabele `shift`
--
ALTER TABLE `shift`
  MODIFY `shift_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT pentru tabele `staff`
--
ALTER TABLE `staff`
  MODIFY `emp_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- AUTO_INCREMENT pentru tabele `staff_type`
--
ALTER TABLE `staff_type`
  MODIFY `staff_type_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT pentru tabele `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Constrângeri pentru tabele eliminate
--

--
-- Constrângeri pentru tabele `booking`
--
ALTER TABLE `booking`
  ADD CONSTRAINT `booking_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customer` (`customer_id`),
  ADD CONSTRAINT `booking_ibfk_2` FOREIGN KEY (`room_id`) REFERENCES `room` (`room_id`);

--
-- Constrângeri pentru tabele `customer`
--
ALTER TABLE `customer`
  ADD CONSTRAINT `customer_ibfk_1` FOREIGN KEY (`id_card_type_id`) REFERENCES `id_card_type` (`id_card_type_id`);

--
-- Constrângeri pentru tabele `emp_history`
--
ALTER TABLE `emp_history`
  ADD CONSTRAINT `emp_history_ibfk_2` FOREIGN KEY (`shift_id`) REFERENCES `shift` (`shift_id`);

--
-- Constrângeri pentru tabele `room`
--
ALTER TABLE `room`
  ADD CONSTRAINT `room_ibfk_1` FOREIGN KEY (`room_type_id`) REFERENCES `room_type` (`room_type_id`);

--
-- Constrângeri pentru tabele `staff`
--
ALTER TABLE `staff`
  ADD CONSTRAINT `staff_ibfk_1` FOREIGN KEY (`id_card_type`) REFERENCES `id_card_type` (`id_card_type_id`),
  ADD CONSTRAINT `staff_ibfk_2` FOREIGN KEY (`shift_id`) REFERENCES `shift` (`shift_id`),
  ADD CONSTRAINT `staff_ibfk_3` FOREIGN KEY (`staff_type_id`) REFERENCES `staff_type` (`staff_type_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
