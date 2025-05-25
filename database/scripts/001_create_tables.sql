CREATE DATABASE IF NOT EXISTS `smart_expense_control`;
USE `smart_expense_control`;

-- User Roles Table
CREATE TABLE `UserRoles` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(255) NOT NULL,
    `description` TEXT
);

-- Users Table
CREATE TABLE `Users` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `username` VARCHAR(255) NOT NULL,
    `email` VARCHAR(255) NOT NULL,
    `password_hash` VARCHAR(255) NOT NULL,
    `role_id` INT NOT NULL,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (`role_id`) REFERENCES `UserRoles`(`id`)
);

-- Expense Groups Table
CREATE TABLE `ExpenseGroups` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(255) NOT NULL,
    `description` VARCHAR(255),
    `periodicity` ENUM('daily', 'weekly', 'bi-weekly', 'monthly', 'yearly', 'one-time') DEFAULT 'one-time',
    `created_by` INT NOT NULL,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `updated_by` INT,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`)
);

CREATE TABLE `ExpenseTypes` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(255) NOT NULL,
    `description` TEXT,
    `expense_group_id` INT NOT NULL,
    FOREIGN KEY (`expense_group_id`) REFERENCES `ExpenseGroups`(`id`)
);

-- Periods Table
CREATE TABLE `ExpensePeriods` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(255) NOT NULL,
    `status` ENUM('pending', 'open', 'closed', 'locked') DEFAULT 'pending',
    `start_date` DATE NOT NULL,
    `end_date` DATE,
    `expense_group_id` INT NOT NULL,
    FOREIGN KEY (`expense_group_id`) REFERENCES `ExpenseGroups`(`id`)
);

-- Expenses Table
CREATE TABLE `Expenses` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `expense_period_id` INT NOT NULL,
    `name` VARCHAR(255) NOT NULL,
    `amount` DECIMAL(18,2),
    `payment_method` ENUM('pix', 'credit card', 'debit card', 'cash', 'bank transfer', 'boleto') DEFAULT NULL,
    `due_date` DATE,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `created_by` INT NOT NULL,
    `updated_by` INT,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `paid_by` INT,
    `paid_at` TIMESTAMP,
    `expense_type_id` INT,
    FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`paid_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`expense_period_id`) REFERENCES `ExpensePeriods`(`id`),
    FOREIGN KEY (`expense_type_id`) REFERENCES `ExpenseTypes`(`id`)
);

-- Expense Groups Users Table
CREATE TABLE `ExpenseGroupsUsers` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `expense_group_id` INT NOT NULL,
    `user_id` INT NOT NULL,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `created_by` INT NOT NULL,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `updated_by` INT,
    FOREIGN KEY (`expense_group_id`) REFERENCES `ExpenseGroups`(`id`),
    FOREIGN KEY (`user_id`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`)
);

CREATE TABLE `ExpensesApportionment` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `user_id` INT NOT NULL,
    `expense_group_id` INT NOT NULL,
    `percentage` DECIMAL(5,2) NOT NULL,
    FOREIGN KEY (`expense_group_id`) REFERENCES `ExpenseGroups`(`id`),
    FOREIGN KEY (`user_id`) REFERENCES `Users`(`id`)
);

CREATE TABLE `ExpensePeriodSettlement` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `expense_period_id` INT NOT NULL,
    `total_amount` DECIMAL(18,2) NOT NULL,
    `status` ENUM('pending', 'processing', 'settled') DEFAULT 'pending',
    FOREIGN KEY (`expense_period_id`) REFERENCES `ExpensePeriods`(`id`)
);

CREATE TABLE `ExpenseSettlement` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `user_id` INT NOT NULL,
    `expense_period_settlement_id` INT NOT NULL,
    `total_amount` DECIMAL(18,2) NOT NULL,
    `payable` DECIMAL(18,2) NOT NULL,
    `receivable` DECIMAL(18,2) NOT NULL,
    `percentage` DECIMAL(5,2) NOT NULL,
    `status` ENUM('pending', 'processing', 'settled') DEFAULT 'pending',
    FOREIGN KEY (`expense_period_settlement_id`) REFERENCES `ExpensePeriodSettlement`(`id`),
    FOREIGN KEY (`user_id`) REFERENCES `Users`(`id`)
);

CREATE TABLE `FinancialTransactions` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `user_id` INT NOT NULL,
    `counterparty_id` INT NOT NULL,
    `amount` DECIMAL(18,2) NOT NULL,
    `transaction_type` ENUM('income', 'expense') NOT NULL,
    `description` TEXT,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `status` ENUM('pending', 'completed', 'failed') DEFAULT 'pending',
    `expense_settlement_id` INT NOT NULL,
    FOREIGN KEY (`user_id`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`counterparty_id`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`expense_settlement_id`) REFERENCES `ExpenseSettlement`(`id`)
);
