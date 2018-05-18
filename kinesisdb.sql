-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1:3306
-- Tiempo de generación: 18-05-2018 a las 05:08:28
-- Versión del servidor: 5.7.19
-- Versión de PHP: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `kinesisdb`
--

DELIMITER $$
--
-- Procedimientos
--
DROP PROCEDURE IF EXISTS `spAgregarPaciente`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spAgregarPaciente` (IN `pacedula` VARCHAR(100), IN `panombre` VARCHAR(100), IN `padireccion` VARCHAR(100), IN `patelefono` VARCHAR(100), IN `pafechana` VARCHAR(100), IN `paedad` VARCHAR(100), IN `paprofesion` VARCHAR(100), IN `paestadocivil` VARCHAR(100), IN `panumhijos` VARCHAR(100))  NO SQL
INSERT INTO PACIENTES VALUES(pacedula, panombre, padireccion, patelefono, pafechana, paedad, paprofesion, paestadocivil, panumhijos)$$

DROP PROCEDURE IF EXISTS `spConsultaHistoria`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spConsultaHistoria` (IN `ced` VARCHAR(100))  NO SQL
SELECT * FROM PACIENTES, HISTORIACLINICA WHERE PACIENTES.CEDULA = HISTORIACLINICA.CEDULAPAC AND PACIENTES.CEDULA = ced$$

DROP PROCEDURE IF EXISTS `spGuardarHistoriaCl`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `spGuardarHistoriaCl` (IN `pacedula` VARCHAR(100), IN `hfechare` VARCHAR(100), IN `hdescenfermedad` VARCHAR(100), IN `hotraenfermedad` VARCHAR(100), IN `hpeso` VARCHAR(100), IN `htalla` VARCHAR(100), IN `haltura` VARCHAR(100), IN `hmasa` VARCHAR(100), IN `hsilueta` VARCHAR(100), IN `hconstumbre` VARCHAR(100), IN `hmodovida` VARCHAR(100), IN `hfuma` VARCHAR(100), IN `halcohol` VARCHAR(100), IN `hsueño` VARCHAR(100), IN `hdeportes` VARCHAR(100))  NO SQL
INSERT INTO historiaclinica VALUES (null, hfechare, hdescenfermedad, hotraenfermedad, hpeso, htalla, haltura, hmasa, hsilueta, hconstumbre, hmodovida, hfuma, halcohol, hsueño, hdeportes, pacedula)$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `historiaclinica`
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
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `historiaclinica`
--

INSERT INTO `historiaclinica` (`IdHistorial`, `FechaRegistro`, `DescEnfermedad`, `OtraEnfermedad`, `Peso`, `Talla`, `Altura`, `MasaCorporal`, `Silueta`, `CostumbresAlimenticias`, `ModoVida`, `SiFuma`, `SiAlcohol`, `CalidadSueno`, `DeportesPracticados`, `CedulaPac`) VALUES
(1, '10/04/2018 7:23:51 p. m.', 'Digestivo', 'Ninguno', '80', '32', '2,9', '87', 'Pequeña', 'Todos lo malos por imaginarse', 'Activa', 'Ocasionalmente', 'No', 'Normal', 'Futbol, baile, ajedrez, etc. y mas y ams', '2343253'),
(2, '11/04/2018 1:07:19 p. m.', 'Circulacion', 'Migraña cronica', '32', '43', '2,1', '66', 'Grande', 'Solo frutas por las mañanas', 'Sedentaria', 'No', 'No', 'Mala', 'Carreras, Golf, Poker.', '123456'),
(3, '11/04/2018 1:13:47 p. m.', 'Circulacion', 'Pancreatitis', '12', '9', '2,1', '12', 'Grande', 'Todas las malas posibles ', 'Sedentaria', 'Ocasionalmente', 'Si', 'Mala', 'efsdvsdvsd', '09876'),
(4, '11/04/2018 1:16:21 p. m.', 'Circulacion', 'Pancreatitis', '12', '32', '2,1', '32', 'Mediana', 'sfsfdsf', 'Sedentaria', 'Si', 'Ocasionalmente', 'Normal', 'fe3fcsd', '2342342'),
(5, 'qqqq', 'qqq', 'qqq', 'qqq', 'qqq', 'qqq', 'qqq', 'qqq', 'qqq', 'qqq', 'qqq', 'qqq', 'qqq', 'qqq', '9999'),
(6, '2018-05-18 00:03:18.688971', 'Endocrino', 'Ninguno', '56', '34', '1,90', '32', 'Mediana', 'dwdwed', 'Sedentaria', 'Si', 'No', 'Mala', 'efsdvsdvsd', '4444');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pacientes`
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
-- Volcado de datos para la tabla `pacientes`
--

INSERT INTO `pacientes` (`Cedula`, `Nombres`, `Direccion`, `Telefono`, `FechaNacimiento`, `Edad`, `Profesion`, `EstadoCivil`, `NumeroHijos`) VALUES
('123456', 'Marclo Rodriguez', 'Campestre mz 3 lote 9 3 etapa', '334332535', '9/02/2014', '43', 'Estilista', 'Casada', '3'),
('2343253', 'Andre Paola Mendoza Rivera', 'Bocagrande mz 40 lote 20 etapa 1', '23243534', '4/01/1990', '43', 'Estudiantes', 'Soltera', '5'),
('09876', 'Maria Lola Rodriguez Miranda', 'Olaya Herrera mz 34 Lote 10 Etapa 1', '6678323', '10/10/1997', '34', 'Madre Soltera', 'Soltera', '24'),
('2342342', 'lola', 'fwef', '334332535', '4/01/1990', '345', 'Estudiantes', 'Soltera', '24'),
('9999', 'ccxxx', 'xxx', 'xxx', 'xxx', 'xxx', 'xxx', 'xxx', 'xxx'),
('4444', 'rafa tex', 'fwef', '23243534', '10/01/1990', '43', 'wfew', 'Casada', '3');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `userlogin`
--

DROP TABLE IF EXISTS `userlogin`;
CREATE TABLE IF NOT EXISTS `userlogin` (
  `Usuario` varchar(100) NOT NULL,
  `Contrasena` varchar(45) NOT NULL,
  PRIMARY KEY (`Usuario`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `userlogin`
--

INSERT INTO `userlogin` (`Usuario`, `Contrasena`) VALUES
('adri10', '12345'),
('fabian', 'soytupadre'),
('kevsan', '0000');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
