-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 07-02-2019 a las 18:13:53
-- Versión del servidor: 10.1.37-MariaDB
-- Versión de PHP: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `acum_totales`
--
CREATE DATABASE IF NOT EXISTS `acum_totales` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `acum_totales`;
--
-- Base de datos: `qu1r30n`
--
CREATE DATABASE IF NOT EXISTS `qu1r30n` DEFAULT CHARACTER SET utf8 COLLATE utf8_spanish_ci;
USE `qu1r30n`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sistema`
--

CREATE TABLE `sistema` (
  `id` int(11) NOT NULL,
  `NOM_TABLA_USU` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `NOM_TAB_PAT` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `ID_PATRO` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `1_LINEA` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `2_LINEA` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `3_LINEA` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `NIVEL` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `DINERO` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `SE_PAGARA` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `PUNTOS` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `ID_NIVEL_HORISONTAL` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `NOMBRE` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `APELLIDO_P` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `APELLIDO_M` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `DIRECCION` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `CIUDAD` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `ESTADO` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `COLONIA` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `PAIS` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `TELEFONO` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `FECHA_DE_NACIMIENTO` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `NUMERO_CUENTA` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `NOMBRE_DE_BANCO` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `GERARQUIA` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `SAP` varchar(100) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `sistema`
--

INSERT INTO `sistema` (`id`, `NOM_TABLA_USU`, `NOM_TAB_PAT`, `ID_PATRO`, `1_LINEA`, `2_LINEA`, `3_LINEA`, `NIVEL`, `DINERO`, `SE_PAGARA`, `PUNTOS`, `ID_NIVEL_HORISONTAL`, `NOMBRE`, `APELLIDO_P`, `APELLIDO_M`, `DIRECCION`, `CIUDAD`, `ESTADO`, `COLONIA`, `PAIS`, `TELEFONO`, `FECHA_DE_NACIMIENTO`, `NUMERO_CUENTA`, `NOMBRE_DE_BANCO`, `GERARQUIA`, `SAP`) VALUES
(1, 'sistma', 'sistema', '1', '1', '1', '1', '1', '1', '0', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', '9/08/1989', '1', '1', '1', '1'),
(2, 'sistema', 'sistema', '1', '1', '1', '1', '2', '2', '0', '0', '1', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2', '2'),
(3, 'sistema', 'sistema', '2', '2', '1', '1', '3', '3', '0', '0', '1', '3', '3', '3', '3', '3', '3', '3', '3', '3', '3', '3', '3', '2', '3'),
(4, 'sistema', 'sistema', '3', '3', '2', '1', '4', '4', '0', '0', '1', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '4', '3', '4'),
(5, 'sistema', 'sistema', '4', '4', '3', '2', '5', '5', '0', '0', '1', '5', '5', '5', '5', '5', '5', '5', '5', '5', '5', '5', '55', '4', '5');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `total_hor`
--

CREATE TABLE `total_hor` (
  `id` int(11) NOT NULL,
  `NIVEL_reg` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `ID_TOTAL_HORISONTAL` varchar(100) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `total_hor`
--

INSERT INTO `total_hor` (`id`, `NIVEL_reg`, `ID_TOTAL_HORISONTAL`) VALUES
(1, '1', '1'),
(2, '2', '1'),
(3, '3', '1'),
(4, '4', '1'),
(5, '5', '1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `total_niv_us`
--

CREATE TABLE `total_niv_us` (
  `id` int(11) NOT NULL,
  `ID_TOTAL_VERTICAL` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `TOTAL_NIVEL_VERTICAL` varchar(100) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `total_niv_us`
--

INSERT INTO `total_niv_us` (`id`, `ID_TOTAL_VERTICAL`, `TOTAL_NIVEL_VERTICAL`) VALUES
(1, '5', '5');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `sistema`
--
ALTER TABLE `sistema`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `total_hor`
--
ALTER TABLE `total_hor`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `total_niv_us`
--
ALTER TABLE `total_niv_us`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `sistema`
--
ALTER TABLE `sistema`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `total_hor`
--
ALTER TABLE `total_hor`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `total_niv_us`
--
ALTER TABLE `total_niv_us`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Base de datos: `tien`
--
CREATE DATABASE IF NOT EXISTS `tien` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `tien`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `acum_tot`
--

CREATE TABLE `acum_tot` (
  `id` int(11) NOT NULL,
  `servicio` varchar(255) NOT NULL,
  `dinero` double(100,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `acum_tot`
--

INSERT INTO `acum_tot` (`id`, `servicio`, `dinero`) VALUES
(1, 'dinero', 0.00),
(2, 'qu1r30n', 0.00);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `conciliacion_2019`
--

CREATE TABLE `conciliacion_2019` (
  `id` int(10) NOT NULL,
  `mes` int(2) DEFAULT NULL,
  `dia` int(2) DEFAULT NULL,
  `venta` double(255,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `conciliacion_2019`
--

INSERT INTO `conciliacion_2019` (`id`, `mes`, `dia`, `venta`) VALUES
(1, 1, 27, 46.00);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inventario`
--

CREATE TABLE `inventario` (
  `ID` int(10) NOT NULL,
  `CODIGO` int(10) NOT NULL,
  `PRODUCTO` varchar(90) NOT NULL,
  `COSTO_VENTA` double(100,2) NOT NULL,
  `CANTIDAD` int(10) NOT NULL,
  `UBICACION` varchar(90) NOT NULL,
  `CADUCIDAD` varchar(15) NOT NULL,
  `COSTO_COMPRA` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `inventario`
--

INSERT INTO `inventario` (`ID`, `CODIGO`, `PRODUCTO`, `COSTO_VENTA`, `CANTIDAD`, `UBICACION`, `CADUCIDAD`, `COSTO_COMPRA`) VALUES
(1, 1, 'producto qu1r30n', 23.00, 10, '1', '9/08/2019', 10);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `acum_tot`
--
ALTER TABLE `acum_tot`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `conciliacion_2019`
--
ALTER TABLE `conciliacion_2019`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `inventario`
--
ALTER TABLE `inventario`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `acum_tot`
--
ALTER TABLE `acum_tot`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `conciliacion_2019`
--
ALTER TABLE `conciliacion_2019`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `inventario`
--
ALTER TABLE `inventario`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
