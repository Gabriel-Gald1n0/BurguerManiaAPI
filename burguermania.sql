-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3307
-- Tempo de geração: 04/12/2024 às 06:29
-- Versão do servidor: 10.4.28-MariaDB
-- Versão do PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `burguermania`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `categories`
--

CREATE TABLE `categories` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` text DEFAULT NULL,
  `PathImage` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `categories`
--

INSERT INTO `categories` (`Id`, `Name`, `Description`, `PathImage`) VALUES
(1, 'X-Vegan', 'Pão, hambúrguer, alface, tomate, queijo e maionese.', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png'),
(2, 'X-Fitness', 'Pão, hambúrguer, alface, tomate, pepino e maionese.', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png'),
(3, 'X-Infarto', 'Pão, hambúrguer, bacon, frango, presunto, queijo e calabresa.', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png'),
(4, 'X-Calabresa', 'Pão, hambúrguer, alface, tomate, presunto, queijo e calabresa.', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png'),
(5, 'X-Tudo', 'Pão, hambúrguer, alface, tomate, presunto, queijo, calabresa, bacon, frango enpanado.', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png');

-- --------------------------------------------------------

--
-- Estrutura para tabela `orders`
--

CREATE TABLE `orders` (
  `Id` int(11) NOT NULL,
  `StatusId` int(11) NOT NULL,
  `Value` decimal(18,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `orders`
--

INSERT INTO `orders` (`Id`, `StatusId`, `Value`) VALUES
(1, 1, 9.99);

-- --------------------------------------------------------

--
-- Estrutura para tabela `ordersproducts`
--

CREATE TABLE `ordersproducts` (
  `Id` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `OrderId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `ordersproducts`
--

INSERT INTO `ordersproducts` (`Id`, `ProductId`, `OrderId`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `products`
--

CREATE TABLE `products` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `PathImage` longtext DEFAULT NULL,
  `Price` decimal(18,2) NOT NULL,
  `Description` longtext DEFAULT NULL,
  `FullDescription` longtext DEFAULT NULL,
  `CategoryId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `products`
--

INSERT INTO `products` (`Id`, `Name`, `PathImage`, `Price`, `Description`, `FullDescription`, `CategoryId`) VALUES
(1, 'X-Alface-Premium', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 99.99, 'Pão, hambúrguer, alface, tomate, queijo e maionese.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 1),
(3, 'X-Tomate', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 35.50, 'Pão, hambúrguer, bacon, queijo e molho especial.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 1),
(4, 'X-Frutas', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 25.50, 'Pão, hambúrguer e frutas cítricas.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 1),
(5, 'X-Salada', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 25.50, 'Pão, hambúrguer e salada.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 1),
(6, 'X-Salada Monstra', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 45.50, 'Pão, hambúrguer e todos os tipos de salada da casa.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 1),
(7, 'X-FitZinho', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 45.50, 'Pão, hambúrguer e todos os tipos de salada da casa.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 2),
(8, 'X-corridinha', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 35.50, 'Pão, hambúrguer e todos os tipos de salada da casa.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 2),
(9, 'X-delicinha', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 55.50, 'Pão, frango, alface, tomate, queijo e maionese.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 2),
(10, 'X-topZeira', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 65.50, 'Pão, hambúrguer, calabresa, queijo e molho barbecue.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 2),
(11, 'X-top Monster', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 65.50, 'Pão, hambúrguer, bacon, ovo, queijo e molho especial.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 2),
(12, 'X-Ignorancia', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 65.50, 'Pão, hambúrguer, bacon, ovo, queijo e molho especial.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 3),
(13, 'X-Diabetes', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 65.50, 'Pão, hambúrguer, bacon, ovo, queijo e molho especial.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 3),
(14, 'X-Obesidade', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 65.50, 'Pão, hambúrguer, bacon, ovo, queijo e molho especial.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 3),
(15, 'X-MONSTRAO', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 105.50, 'Pão, hambúrguer, calabresa, queijo e molho barbecue.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 3),
(16, 'Calma Calabreso', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 105.50, 'Pão, hambúrguer, calabresa, queijo e molho barbecue.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 4),
(17, 'X-Picanha', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 185.50, 'Pão, hambúrguer, calabresa, queijo e molho barbecue.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 4),
(18, 'Pura Delicia', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 85.50, 'Pão, hambúrguer, calabresa, queijo e molho barbecue.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 4),
(19, 'x-top da casa', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 185.50, 'Pão, hambúrguer, calabresa, queijo e molho barbecue.', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de maça, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 4),
(20, 'XXX-TUDO', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 250.50, 'Contem TODOS os ingredientes da casa!', 'Um hambúrguer suculento feito com todos os ingredientes necessarios para sua felicidade', 5),
(21, 'X-Nada', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 10.50, 'Contem Pão, Hamburger e queijo', 'Um hambúrguer feito pra quem é universitário e está sem dinheiro', 5),
(22, 'X-Escolha', 'https://github.com/Gabriel-Gald1n0/BurguerManiaAPI/raw/main/Img/hamburguer.png', 120.50, 'Contem Pão, Hamburger e mais ingredientes de sua escolha', 'Um hambúrguer vegano suculento feito com uma base de grão-de-bico e quinoa, temperado com especiarias defumadas, cebola caramelizada e alho, garantindo uma textura rica e saborosa. Servido em um pão macio, ele vem acompanhado de fatias frescas de tomate, alface crocante, picles, abacate cremoso e uma generosa camada de maionese de ervas vegana. Finalizado com molho barbecue agridoce e uma pitada de pimenta-do-reino moída na hora, proporcionando uma combinação deliciosa de sabores e texturas em cada mordida.', 5);

-- --------------------------------------------------------

--
-- Estrutura para tabela `status`
--

CREATE TABLE `status` (
  `Id` int(11) NOT NULL,
  `Name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `status`
--

INSERT INTO `status` (`Id`, `Name`) VALUES
(1, 'EmAndamento'),
(2, 'Concluido'),
(3, 'Cancelado');

-- --------------------------------------------------------

--
-- Estrutura para tabela `users`
--

CREATE TABLE `users` (
  `Id` int(11) NOT NULL,
  `Name` varchar(100) DEFAULT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `users`
--

INSERT INTO `users` (`Id`, `Name`, `Email`, `Password`) VALUES
(1, 'Galds', 'user@example.com', 'galds12');

-- --------------------------------------------------------

--
-- Estrutura para tabela `usersorders`
--

CREATE TABLE `usersorders` (
  `Id` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `OrderId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `usersorders`
--

INSERT INTO `usersorders` (`Id`, `UserId`, `OrderId`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20241203201409_InicialMigrate', '8.0.10'),
('20241203233652_SecondMigrate', '8.0.10'),
('20241203235029_removeDescription', '8.0.10'),
('20241203235625_setPrice', '8.0.10'),
('20241204041728_configProduct', '8.0.10');

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Orders_StatusId` (`StatusId`);

--
-- Índices de tabela `ordersproducts`
--
ALTER TABLE `ordersproducts`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_OrdersProducts_OrderId` (`OrderId`),
  ADD KEY `IX_OrdersProducts_ProductId` (`ProductId`);

--
-- Índices de tabela `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `IX_Products_NameUnique` (`Name`),
  ADD KEY `IX_Products_CategoryId` (`CategoryId`);

--
-- Índices de tabela `status`
--
ALTER TABLE `status`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- Índices de tabela `usersorders`
--
ALTER TABLE `usersorders`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_UsersOrders_OrderId` (`OrderId`),
  ADD KEY `IX_UsersOrders_UserId` (`UserId`);

--
-- Índices de tabela `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `categories`
--
ALTER TABLE `categories`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `orders`
--
ALTER TABLE `orders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `ordersproducts`
--
ALTER TABLE `ordersproducts`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `products`
--
ALTER TABLE `products`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT de tabela `status`
--
ALTER TABLE `status`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `users`
--
ALTER TABLE `users`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `usersorders`
--
ALTER TABLE `usersorders`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `orders`
--
ALTER TABLE `orders`
  ADD CONSTRAINT `FK_Orders_Status_StatusId` FOREIGN KEY (`StatusId`) REFERENCES `status` (`Id`);

--
-- Restrições para tabelas `ordersproducts`
--
ALTER TABLE `ordersproducts`
  ADD CONSTRAINT `FK_OrdersProducts_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_OrdersProducts_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`);

--
-- Restrições para tabelas `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `FK_Products_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`);

--
-- Restrições para tabelas `usersorders`
--
ALTER TABLE `usersorders`
  ADD CONSTRAINT `FK_UsersOrders_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_UsersOrders_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
