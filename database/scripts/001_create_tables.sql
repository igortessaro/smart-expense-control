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

-- Category of Expenses Table
-- Home/Transport/Food/Health/Entertainment/Education/Other
CREATE TABLE `ExpenseCategories` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(255) NOT NULL,
    `description` TEXT
);

-- Periods Table
CREATE TABLE `Periods` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(255) NOT NULL,
    `description` TEXT,
    `type` ENUM('daily', 'weekly', 'bi-weekly', 'monthly', 'yearly', 'one-time') NOT NULL
);

-- Period of expenses Table
CREATE TABLE `PeriodExpenses`(
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `period_id` INT NOT NULL,
    `expense_group_id` INT NOT NULL,
    `start_date` DATE NOT NULL,
    `end_date` DATE NOT NULL,
    `status` ENUM('pending', 'open', 'locked') DEFAULT 'pending',
    FOREIGN KEY (`period_id`) REFERENCES `Periods`(`id`),
    FOREIGN KEY (`expense_group_id`) REFERENCES `ExpenseGroups`(`id`)
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

-- Payment Methods Table
-- 'pix', 'credit card', 'debit card', 'cash', 'bank transfer', 'boleto'
CREATE TABLE `PaymentMethods` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `name` VARCHAR(255) NOT NULL,
    `description` TEXT
);

-- Expenses Table
CREATE TABLE `Expenses` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `period_expenses_id` INT NOT NULL,
    `name` VARCHAR(255) NOT NULL,
    `tag` VARCHAR(100) NOT NULL,
    `amount` DECIMAL(10, 2),
    `payment_method_id` INT NULL,
    `due_day` INT,
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    `created_by` INT NOT NULL,
    `updated_by` INT,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `paid_by` INT,
    `paid_at` TIMESTAMP,
    `expense_category_id` INT,
    FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`paid_by`) REFERENCES `Users`(`id`),
    FOREIGN KEY (`period_expenses_id`) REFERENCES `PeriodExpenses`(`id`),
    FOREIGN KEY (`payment_method_id`) REFERENCES `PaymentMethods`(`id`),
    FOREIGN KEY (`expense_category_id`) REFERENCES `ExpenseCategories`(`id`)
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

-- -- Budgets Table
-- CREATE TABLE `Budgets` (
--     `id` INT AUTO_INCREMENT PRIMARY KEY,
--     `user_id` INT NOT NULL,
--     `expense_group_id` INT NOT NULL,
--     `amount` DECIMAL(10, 2) NOT NULL,
--     `start_date` DATE NOT NULL,
--     `end_date` DATE NOT NULL,
--     `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
--     `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--     `created_by` INT,
--     `updated_by` INT,
--     FOREIGN KEY (`user_id`) REFERENCES `Users`(`id`),
--     FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
--     FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`),
--     FOREIGN KEY (`expense_group_id`) REFERENCES `ExpenseGroups`(`id`)
-- );

-- -- Notifications Table
-- CREATE TABLE `Notifications` (
--     `id` INT AUTO_INCREMENT PRIMARY KEY,
--     `user_id` INT NOT NULL,
--     `message` TEXT NOT NULL,
--     `read` BOOLEAN DEFAULT FALSE,
--     `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
--     `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--     `created_by` INT,
--     `updated_by` INT,
--     FOREIGN KEY (`user_id`) REFERENCES `Users`(`id`),
--     FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
--     FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`)
-- );

-- -- Expense Installments Table
-- CREATE TABLE `ExpenseInstallments` (
--     `id` INT AUTO_INCREMENT PRIMARY KEY,
--     `amount` DECIMAL(10, 2) NOT NULL,
--     `due_day` INT NOT NULL,
--     `payment_method` VARCHAR(50) NOT NULL,
--     `status` ENUM('pending', 'paid') DEFAULT 'pending',
--     `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
--     `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
--     `created_by` INT NOT NULL,
--     `updated_by` INT,
--     FOREIGN KEY (`created_by`) REFERENCES `Users`(`id`),
--     FOREIGN KEY (`updated_by`) REFERENCES `Users`(`id`)
-- );
