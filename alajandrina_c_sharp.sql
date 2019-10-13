-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 10-12-2016 a las 11:27:02
-- Versión del servidor: 10.1.16-MariaDB
-- Versión de PHP: 7.0.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `alajandrina_c_sharp`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `alumno`
--

CREATE TABLE `alumno` (
  `idAlumno` int(22) NOT NULL,
  `nombreAlumno` varchar(250) COLLATE utf8_spanish2_ci NOT NULL,
  `apellidoAlumno` varchar(250) COLLATE utf8_spanish2_ci NOT NULL,
  `nCarnet` int(11) NOT NULL,
  `idCarrera` int(22) NOT NULL,
  `genero` varchar(1) COLLATE utf8_spanish2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `alumno`
--

INSERT INTO `alumno` (`idAlumno`, `nombreAlumno`, `apellidoAlumno`, `nCarnet`, `idCarrera`, `genero`) VALUES
(3, 'Eduardo Jose', 'Vasquez Flores', 20161026, 1, 'M'),
(4, 'Roger Alejandro', 'Canales Gallo', 1234582, 3, 'M'),
(5, 'Mirna Mercedes', 'Herrador Lazo', 20161407, 4, 'F'),
(6, 'Yeny Lisseth', 'Ayala Alfaro', 20164785, 4, 'F');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `autor`
--

CREATE TABLE `autor` (
  `idAutor` int(22) NOT NULL,
  `nombreAutor` varchar(250) COLLATE utf8_spanish2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `autor`
--

INSERT INTO `autor` (`idAutor`, `nombreAutor`) VALUES
(1, 'noooo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `carrera`
--

CREATE TABLE `carrera` (
  `idCarrera` int(22) NOT NULL,
  `nombreCarrera` varchar(250) COLLATE utf8_spanish2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `carrera`
--

INSERT INTO `carrera` (`idCarrera`, `nombreCarrera`) VALUES
(1, 'Ingenieria En Sistemas Informaticos'),
(2, 'Licenciatura en Ciencias Juridicas'),
(3, 'Ingenieria Industrial'),
(4, 'Arquitectura'),
(5, 'Ingenieria Civil'),
(6, 'Doctorado en Medicina'),
(7, 'Licenciatura en Contaduria Publica'),
(8, 'Licenciatura en Psicologia'),
(9, 'Licenciatura en Laboratorio Clinico');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categoria`
--

CREATE TABLE `categoria` (
  `idCategoria` int(22) NOT NULL,
  `nombreCategoria` varchar(150) COLLATE utf8_spanish2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `categoria`
--

INSERT INTO `categoria` (`idCategoria`, `nombreCategoria`) VALUES
(2, 'Informatica');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `editorial`
--

CREATE TABLE `editorial` (
  `idEditorial` int(22) NOT NULL,
  `nombreEditorial` varchar(200) COLLATE utf8_spanish2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `editorial`
--

INSERT INTO `editorial` (`idEditorial`, `nombreEditorial`) VALUES
(1, 'ANAYA'),
(2, 'El Manguito Feliz'),
(14, 'Los Pericos'),
(17, 'desde'),
(18, 'frgt'),
(19, 'de'),
(21, 'deew');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `libro`
--

CREATE TABLE `libro` (
  `idLibro` int(22) NOT NULL,
  `nombreLibro` varchar(250) COLLATE utf8_spanish2_ci NOT NULL,
  `idEditorial` int(22) NOT NULL,
  `anio` int(4) NOT NULL,
  `idCategoria` int(22) NOT NULL,
  `descripcion` text COLLATE utf8_spanish2_ci NOT NULL,
  `idAutor` int(22) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `libro`
--

INSERT INTO `libro` (`idLibro`, `nombreLibro`, `idEditorial`, `anio`, `idCategoria`, `descripcion`, `idAutor`) VALUES
(1, 'Aprende a programar', 1, 1245, 2, 'Este libro es para aprender a programamar', 1),
(2, 'Java', 1, 2014, 2, 'sadasd', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mora`
--

CREATE TABLE `mora` (
  `idMora` int(255) NOT NULL,
  `idPrestamoLibro` int(255) NOT NULL,
  `cantidadMora` double(10,2) NOT NULL,
  `moraCancelada` varchar(2) NOT NULL,
  `fechaPagoMora` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `mora`
--

INSERT INTO `mora` (`idMora`, `idPrestamoLibro`, `cantidadMora`, `moraCancelada`, `fechaPagoMora`) VALUES
(1, 2, 0.00, 'No', '0000-00-00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `nivel_user`
--

CREATE TABLE `nivel_user` (
  `idNuvelUser` int(1) NOT NULL,
  `nivel` varchar(50) COLLATE utf8_spanish2_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `nivel_user`
--

INSERT INTO `nivel_user` (`idNuvelUser`, `nivel`) VALUES
(1, 'admin'),
(2, 'user');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `prestamo_libro`
--

CREATE TABLE `prestamo_libro` (
  `idPrestamoLibro` int(22) NOT NULL,
  `idAlumno` int(22) NOT NULL,
  `idLibro` int(22) NOT NULL,
  `fechaPrestamo` date NOT NULL,
  `fechaEntrega` date NOT NULL,
  `prestamoSolvente` varchar(200) COLLATE utf8_spanish2_ci NOT NULL,
  `fechaLimite` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `prestamo_libro`
--

INSERT INTO `prestamo_libro` (`idPrestamoLibro`, `idAlumno`, `idLibro`, `fechaPrestamo`, `fechaEntrega`, `prestamoSolvente`, `fechaLimite`) VALUES
(1, 3, 2, '2016-11-06', '2016-12-06', 'Solvente', '2016-12-07'),
(2, 5, 1, '2016-12-06', '2016-12-10', 'Solvente', '2016-12-07');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `idUsuario` int(22) NOT NULL,
  `nombreUsuario` varchar(250) COLLATE utf8_spanish2_ci NOT NULL,
  `apellidoUsiario` varchar(250) COLLATE utf8_spanish2_ci NOT NULL,
  `pw` varchar(250) COLLATE utf8_spanish2_ci NOT NULL,
  `codCarnetUser` varchar(10) COLLATE utf8_spanish2_ci NOT NULL,
  `idNivelUser` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish2_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`idUsuario`, `nombreUsuario`, `apellidoUsiario`, `pw`, `codCarnetUser`, `idNivelUser`) VALUES
(1, 'mirna', 'herrador', 'mercedes', 'u20161407', 2),
(2, 'mir', 'her', 'mercedes', '15y54541y', 2),
(3, 'htg', 'tghg', 'tg', 'yth', 1),
(4, 'htg', 'tghg', 'tg', 'yth', 1),
(5, '', '', 'mercedes', 'mercedes', 2),
(6, 'mercedes', 'mercedes', '$2y$10$ldce0pMJ1G5qFrtt/Uxrs.9QuZL/xlfpaNj2H.RlvkjFCFgQErUPW', 'mercedes', 1),
(7, 'herrador', 'herrador', '$2y$10$DiYrQjrx.HFl2Zuh.PTEjeE.jWszuBDiTNKEN.uYHekusBMjQuz6.', 'herrador', 2);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `alumno`
--
ALTER TABLE `alumno`
  ADD PRIMARY KEY (`idAlumno`),
  ADD KEY `idCarrera` (`idCarrera`);

--
-- Indices de la tabla `autor`
--
ALTER TABLE `autor`
  ADD PRIMARY KEY (`idAutor`);

--
-- Indices de la tabla `carrera`
--
ALTER TABLE `carrera`
  ADD PRIMARY KEY (`idCarrera`);

--
-- Indices de la tabla `categoria`
--
ALTER TABLE `categoria`
  ADD PRIMARY KEY (`idCategoria`);

--
-- Indices de la tabla `editorial`
--
ALTER TABLE `editorial`
  ADD PRIMARY KEY (`idEditorial`);

--
-- Indices de la tabla `libro`
--
ALTER TABLE `libro`
  ADD PRIMARY KEY (`idLibro`),
  ADD KEY `libro-idEditorial` (`idEditorial`),
  ADD KEY `libro-idCategoria` (`idCategoria`),
  ADD KEY `indice_idAutor-libro` (`idAutor`);

--
-- Indices de la tabla `mora`
--
ALTER TABLE `mora`
  ADD PRIMARY KEY (`idMora`),
  ADD KEY `idPrestamoLibro` (`idPrestamoLibro`);

--
-- Indices de la tabla `nivel_user`
--
ALTER TABLE `nivel_user`
  ADD PRIMARY KEY (`idNuvelUser`);

--
-- Indices de la tabla `prestamo_libro`
--
ALTER TABLE `prestamo_libro`
  ADD PRIMARY KEY (`idPrestamoLibro`),
  ADD KEY `prestamoLibro_idAlumno` (`idAlumno`),
  ADD KEY `prestamoLibro_idLibro` (`idLibro`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`idUsuario`),
  ADD KEY `usuarios_idNivelUser` (`idNivelUser`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `alumno`
--
ALTER TABLE `alumno`
  MODIFY `idAlumno` int(22) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT de la tabla `autor`
--
ALTER TABLE `autor`
  MODIFY `idAutor` int(22) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `carrera`
--
ALTER TABLE `carrera`
  MODIFY `idCarrera` int(22) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT de la tabla `categoria`
--
ALTER TABLE `categoria`
  MODIFY `idCategoria` int(22) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `editorial`
--
ALTER TABLE `editorial`
  MODIFY `idEditorial` int(22) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
--
-- AUTO_INCREMENT de la tabla `libro`
--
ALTER TABLE `libro`
  MODIFY `idLibro` int(22) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `mora`
--
ALTER TABLE `mora`
  MODIFY `idMora` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT de la tabla `nivel_user`
--
ALTER TABLE `nivel_user`
  MODIFY `idNuvelUser` int(1) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `prestamo_libro`
--
ALTER TABLE `prestamo_libro`
  MODIFY `idPrestamoLibro` int(22) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `idUsuario` int(22) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `alumno`
--
ALTER TABLE `alumno`
  ADD CONSTRAINT `alumno_ibfk_1` FOREIGN KEY (`idCarrera`) REFERENCES `carrera` (`idCarrera`);

--
-- Filtros para la tabla `libro`
--
ALTER TABLE `libro`
  ADD CONSTRAINT `libro_ibfk_1` FOREIGN KEY (`idEditorial`) REFERENCES `editorial` (`idEditorial`),
  ADD CONSTRAINT `libro_ibfk_2` FOREIGN KEY (`idCategoria`) REFERENCES `categoria` (`idCategoria`),
  ADD CONSTRAINT `libro_ibfk_3` FOREIGN KEY (`idAutor`) REFERENCES `autor` (`idAutor`);

--
-- Filtros para la tabla `mora`
--
ALTER TABLE `mora`
  ADD CONSTRAINT `mora_ibfk_1` FOREIGN KEY (`idPrestamoLibro`) REFERENCES `prestamo_libro` (`idPrestamoLibro`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `prestamo_libro`
--
ALTER TABLE `prestamo_libro`
  ADD CONSTRAINT `prestamo_libro_ibfk_1` FOREIGN KEY (`idAlumno`) REFERENCES `alumno` (`idAlumno`),
  ADD CONSTRAINT `prestamo_libro_ibfk_2` FOREIGN KEY (`idLibro`) REFERENCES `libro` (`idLibro`);

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`idNivelUser`) REFERENCES `nivel_user` (`idNuvelUser`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
