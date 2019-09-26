-- phpMyAdmin SQL Dump
-- version 4.9.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 26-09-2019 a las 14:50:12
-- Versión del servidor: 10.4.6-MariaDB
-- Versión de PHP: 5.5.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `Ejercicio1_Accesodatos`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `APUESTA`
--

CREATE TABLE `APUESTA` (
  `ID_APUESTA` int(11) NOT NULL,
  `ID_MERCADO_FK` int(11) NOT NULL,
  `EMAIL_FK` varchar(25) NOT NULL,
  `TIPO APUESTA` int(11) NOT NULL,
  `CUOTA` double NOT NULL,
  `DINERO APOSTADO` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `CUENTA`
--

CREATE TABLE `CUENTA` (
  `ID_CUENTA` int(11) NOT NULL,
  `EMAIL_FKC` varchar(25) NOT NULL,
  `SALDO ACTUAL` double NOT NULL,
  `NOMBRE BANCO` varchar(25) NOT NULL,
  `NUMERO TARJETA` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `EVENTOS`
--

CREATE TABLE `EVENTOS` (
  `ID_EVENTO` int(11) NOT NULL,
  `LOCAL` varchar(25) NOT NULL,
  `VISITANTE` varchar(25) NOT NULL,
  `GOLES` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `MERCADO`
--

CREATE TABLE `MERCADO` (
  `ID_MERCADO` int(11) NOT NULL,
  `CUOTA OVER` double NOT NULL,
  `CUOTA UNDER` double NOT NULL,
  `DINERO APOSTADO OVER` double NOT NULL,
  `DINERO APOSTADO UNDER` double NOT NULL,
  `ID_EVENTO_FK` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `USUARIO`
--

CREATE TABLE `USUARIO` (
  `EMAIL` varchar(25) NOT NULL,
  `NOMBRE` varchar(15) NOT NULL,
  `APELLIDO` varchar(25) NOT NULL,
  `EDAD` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `APUESTA`
--
ALTER TABLE `APUESTA`
  ADD PRIMARY KEY (`ID_APUESTA`),
  ADD KEY `ID_MERCADO_FK` (`ID_MERCADO_FK`,`EMAIL_FK`),
  ADD KEY `EMAIL_FK` (`EMAIL_FK`);

--
-- Indices de la tabla `CUENTA`
--
ALTER TABLE `CUENTA`
  ADD PRIMARY KEY (`ID_CUENTA`),
  ADD KEY `EMAIL_FKC` (`EMAIL_FKC`);

--
-- Indices de la tabla `EVENTOS`
--
ALTER TABLE `EVENTOS`
  ADD PRIMARY KEY (`ID_EVENTO`);

--
-- Indices de la tabla `MERCADO`
--
ALTER TABLE `MERCADO`
  ADD PRIMARY KEY (`ID_MERCADO`),
  ADD KEY `ID_EVENTO_FK` (`ID_EVENTO_FK`);

--
-- Indices de la tabla `USUARIO`
--
ALTER TABLE `USUARIO`
  ADD PRIMARY KEY (`EMAIL`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `APUESTA`
--
ALTER TABLE `APUESTA`
  ADD CONSTRAINT `apuesta_ibfk_1` FOREIGN KEY (`EMAIL_FK`) REFERENCES `USUARIO` (`EMAIL`);

--
-- Filtros para la tabla `EVENTOS`
--
ALTER TABLE `EVENTOS`
  ADD CONSTRAINT `eventos_ibfk_1` FOREIGN KEY (`ID_EVENTO`) REFERENCES `MERCADO` (`ID_EVENTO_FK`);

--
-- Filtros para la tabla `MERCADO`
--
ALTER TABLE `MERCADO`
  ADD CONSTRAINT `mercado_ibfk_1` FOREIGN KEY (`ID_MERCADO`) REFERENCES `APUESTA` (`ID_MERCADO_FK`);

--
-- Filtros para la tabla `USUARIO`
--
ALTER TABLE `USUARIO`
  ADD CONSTRAINT `usuario_ibfk_1` FOREIGN KEY (`EMAIL`) REFERENCES `CUENTA` (`EMAIL_FKC`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
