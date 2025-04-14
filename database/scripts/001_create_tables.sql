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
    `created_by` INT NOT NULL,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `updated_by` INT,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`)
);

-- Expenses Table
CREATE TABLE `Expenses` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `expense_group_id` INT NOT NULL,
    `name` VARCHAR(255) NOT NULL,
    `tag` VARCHAR(100) NOT NULL,
    `amount` DECIMAL(10, 2),
    `payment_method` VARCHAR(50) NOT NULL, -- ENUM('pix', 'credit card', 'debit card', 'cash', 'bank transfer', 'boleto')
    `period` VARCHAR(6) NOT NULL,
    `due_day` INT,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `created_by` INT NOT NULL,
    `updated_by` INT,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `payed_by` INT,
    `payed_at` TIMESTAMP,
    FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`payed_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`expense_group_id`) REFERENCES `ExpenseGroups`(`id`)
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

-- Budgets Table
CREATE TABLE `Budgets` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `user_id` INT NOT NULL,
    `expense_group_id` INT NOT NULL,
    `amount` DECIMAL(10, 2) NOT NULL,
    `start_date` DATE NOT NULL,
    `end_date` DATE NOT NULL,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `created_by` INT,
    `updated_by` INT,
    FOREIGN KEY (`user_id`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`expense_group_id`) REFERENCES `ExpenseGroups`(`id`)
);

-- Notifications Table
CREATE TABLE `Notifications` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `user_id` INT NOT NULL,
    `message` TEXT NOT NULL,
    `read` BOOLEAN DEFAULT FALSE,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `created_by` INT,
    `updated_by` INT,
    FOREIGN KEY (`user_id`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`)
);

-- Expense Installments Table
CREATE TABLE `ExpenseInstallments` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `amount` DECIMAL(10, 2) NOT NULL,
    `due_day` INT NOT NULL,
    `payment_method` VARCHAR(50) NOT NULL,
    `status` ENUM('pending', 'paid') DEFAULT 'pending',
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `created_by` INT NOT NULL,
    `updated_by` INT,
    FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`)
);
