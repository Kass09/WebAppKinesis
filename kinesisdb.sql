-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Apr 11, 2018 at 05:22 PM
-- Server version: 5.7.19
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kinesisdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `historiaclinica`
--

DROP TABLE IF EXISTS `historiaclinica`;
CREATE TABLE IF NOT EXISTS `historiaclinica` (
  `IdHistorial` int(11) NOT NULL AUTO_INCREMENT,
  `FechaRegistro` varchar(45) NOT NULL,
  `DescEnfermedad` varchar(45) NOT NULL,
  `OtraEnfermedad` varchar(45) DEFAULT NULL,
  `Peso` varchar(45) NOT NULL,
  `Talla` varchar(45) NOT NULL,
  `Altura` varchar(45) NOT NULL,
  `MasaCorporal` varchar(45) NOT NULL,
  `Silueta` varchar(45) NOT NULL,
  `CostumbresAlimenticias` varchar(45) NOT NULL,
  `ModoVida` varchar(45) NOT NULL,
  `SiFuma` varchar(45) NOT NULL,
  `SiAlcohol` varchar(45) NOT NULL,
  `CalidadSueno` varchar(45) NOT NULL,
  `DeportesPracticados` varchar(45) NOT NULL,
  `CedulaPac` varchar(45) NOT NULL,
  PRIMARY KEY (`IdHistorial`),
  KEY `CedulaPac` (`CedulaPac`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `historiaclinica`
--

INSERT INTO `historiaclinica` (`IdHistorial`, `FechaRegistro`, `DescEnfermedad`, `OtraEnfermedad`, `Peso`, `Talla`, `Altura`, `MasaCorporal`, `Silueta`, `CostumbresAlimenticias`, `ModoVida`, `SiFuma`, `SiAlcohol`, `CalidadSueno`, `DeportesPracticados`, `CedulaPac`) VALUES
(1, '10/04/2018 7:23:51 p. m.', 'Digestivo', 'Ninguno', '80', '32', '2,9', '87', 'Pequeña', 'Todos lo malos por imaginarse', 'Activa', 'Ocasionalmente', 'No', 'Normal', 'Futbol, baile, ajedrez, etc. y mas y ams', '2343253');

-- --------------------------------------------------------

--
-- Table structure for table `pacientes`
--

DROP TABLE IF EXISTS `pacientes`;
CREATE TABLE IF NOT EXISTS `pacientes` (
  `Cedula` varchar(100) NOT NULL,
  `Nombres` varchar(45) NOT NULL,
  `Direccion` varchar(45) NOT NULL,
  `Telefono` varchar(45) NOT NULL,
  `FechaNacimiento` varchar(45) NOT NULL,
  `Edad` varchar(45) NOT NULL,
  `Profesion` varchar(45) NOT NULL,
  `EstadoCivil` varchar(45) NOT NULL,
  `NumeroHijos` varchar(45) NOT NULL,
  PRIMARY KEY (`Cedula`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pacientes`
--

INSERT INTO `pacientes` (`Cedula`, `Nombres`, `Direccion`, `Telefono`, `FechaNacimiento`, `Edad`, `Profesion`, `EstadoCivil`, `NumeroHijos`) VALUES
('2343253', 'Andre Paola Mendoza Rivera', 'Bocagrande mz 40 lote 20 etapa 1', '23243534', '4/01/1990', '43', 'Estudiantes', 'Soltera', '5');

-- --------------------------------------------------------

--
-- Table structure for table `userlogin`
--

DROP TABLE IF EXISTS `userlogin`;
CREATE TABLE IF NOT EXISTS `userlogin` (
  `Usuario` varchar(100) NOT NULL,
  `Contrasena` varchar(45) NOT NULL,
  PRIMARY KEY (`Usuario`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `userlogin`
--

INSERT INTO `userlogin` (`Usuario`, `Contrasena`) VALUES
('adri10', '12345'),
('andres', 'soytupadre'),
('lola', '0000');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
