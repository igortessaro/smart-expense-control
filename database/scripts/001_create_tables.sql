CREATE DATABASE IF NOT EXISTS `smart_expense_control`;
USE `smart_expense_control`;

-- user_roles Table
CREATE TABLE `user_roles` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for user_roles',
    `name` VARCHAR(255) NOT NULL COMMENT 'Role name (must be unique)',
    `description` TEXT COMMENT 'Description of the role',
    CONSTRAINT uq_user_roles_name UNIQUE (`name`)
);

-- users Table
CREATE TABLE `users` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for users',
    `username` VARCHAR(255) NOT NULL COMMENT 'Unique username',
    `email` VARCHAR(255) NOT NULL COMMENT 'Unique email address',
    `password_hash` VARCHAR(255) NOT NULL COMMENT 'Hashed password',
    `role_id` INT NOT NULL COMMENT 'Foreign key to user_roles',
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Creation timestamp',
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last update timestamp',
    CONSTRAINT uq_users_username UNIQUE (`username`),
    CONSTRAINT uq_users_email UNIQUE (`email`),
    INDEX idx_users_role_id (`role_id`),
    FOREIGN KEY (`role_id`) REFERENCES `user_roles`(`id`)
);

-- expense_groups Table
CREATE TABLE `expense_groups` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for expense_groups',
    `name` VARCHAR(255) NOT NULL COMMENT 'Group name (must be unique)',
    `description` VARCHAR(255) COMMENT 'Description of the group',
    `periodicity` ENUM('daily', 'weekly', 'bi-weekly', 'monthly', 'yearly', 'one-time') DEFAULT 'one-time' COMMENT 'How often expenses repeat',
    `created_by` INT NOT NULL COMMENT 'User who created the group',
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Creation timestamp',
    `updated_by` INT COMMENT 'User who last updated the group',
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last update timestamp',
    CONSTRAINT uq_expense_groups_name UNIQUE (`name`),
    INDEX idx_expense_groups_created_by (`created_by`),
    INDEX idx_expense_groups_updated_by (`updated_by`),
    FOREIGN KEY (`created_by`) REFERENCES `users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `users`(`id`)
);

-- expense_types Table
CREATE TABLE `expense_types` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for expense_types',
    `name` VARCHAR(255) NOT NULL COMMENT 'Type name (unique within group)',
    `limit` DECIMAL(18,2) COMMENT 'Monetary limit for this type',
    `expense_group_id` INT NOT NULL COMMENT 'Foreign key to expense_groups',
    CONSTRAINT uq_expense_types_group_name UNIQUE (`expense_group_id`, `name`),
    INDEX idx_expense_types_expense_group_id (`expense_group_id`),
    FOREIGN KEY (`expense_group_id`) REFERENCES `expense_groups`(`id`)
);

-- expense_periods Table
CREATE TABLE `expense_periods` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for expense_periods',
    `name` VARCHAR(255) NOT NULL COMMENT 'Period name (unique within group)',
    `status` ENUM('pending', 'open', 'closed', 'locked') DEFAULT 'pending' COMMENT 'Status of the period',
    `start_date` DATE NOT NULL COMMENT 'Start date of the period',
    `end_date` DATE COMMENT 'End date of the period',
    `expense_group_id` INT NOT NULL COMMENT 'Foreign key to expense_groups',
    CONSTRAINT uq_expense_periods_group_name UNIQUE (`expense_group_id`, `name`),
    INDEX idx_expense_periods_expense_group_id (`expense_group_id`),
    FOREIGN KEY (`expense_group_id`) REFERENCES `expense_groups`(`id`)
);

-- expenses Table
CREATE TABLE `expenses` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for expenses',
    `expense_period_id` INT NOT NULL COMMENT 'Foreign key to expense_periods',
    `name` VARCHAR(255) NOT NULL COMMENT 'Expense name or description',
    `amount` DECIMAL(18,2) COMMENT 'Expense amount',
    `payment_method` ENUM('pix', 'credit card', 'debit card', 'cash', 'bank transfer', 'boleto') DEFAULT NULL COMMENT 'Payment method used',
    `due_date` DATE COMMENT 'Due date for the expense',
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Creation timestamp',
    `created_by` INT NOT NULL COMMENT 'User who created the expense',
    `updated_by` INT COMMENT 'User who last updated the expense',
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last update timestamp',
    `paid_by` INT COMMENT 'User who paid the expense',
    `paid_at` TIMESTAMP COMMENT 'Timestamp when the expense was paid',
    `expense_type_id` INT COMMENT 'Foreign key to expense_types',
    INDEX idx_expenses_expense_period_id (`expense_period_id`),
    INDEX idx_expenses_created_by (`created_by`),
    INDEX idx_expenses_updated_by (`updated_by`),
    INDEX idx_expenses_paid_by (`paid_by`),
    INDEX idx_expenses_expense_type_id (`expense_type_id`),
    FOREIGN KEY (`created_by`) REFERENCES `users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `users`(`id`),
    FOREIGN KEY (`paid_by`) REFERENCES `users`(`id`),
    FOREIGN KEY (`expense_period_id`) REFERENCES `expense_periods`(`id`),
    FOREIGN KEY (`expense_type_id`) REFERENCES `expense_types`(`id`)
);

-- expense_groups_users Table
CREATE TABLE `expense_groups_users` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for expense_groups_users',
    `expense_group_id` INT NOT NULL COMMENT 'Foreign key to expense_groups',
    `user_id` INT NOT NULL COMMENT 'Foreign key to users',
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Creation timestamp',
    `created_by` INT NOT NULL COMMENT 'User who created the record',
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last update timestamp',
    `updated_by` INT COMMENT 'User who last updated the record',
    CONSTRAINT uq_expense_groups_users_group_user UNIQUE (`expense_group_id`, `user_id`),
    INDEX idx_expense_groups_users_expense_group_id (`expense_group_id`),
    INDEX idx_expense_groups_users_user_id (`user_id`),
    FOREIGN KEY (`expense_group_id`) REFERENCES `expense_groups`(`id`),
    FOREIGN KEY (`user_id`) REFERENCES `users`(`id`),
    FOREIGN KEY (`created_by`) REFERENCES `users`(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES `users`(`id`)
);

-- expense_apportionments Table
CREATE TABLE `expense_apportionments` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for expense_apportionments',
    `user_id` INT NOT NULL COMMENT 'Foreign key to users',
    `expense_group_id` INT NOT NULL COMMENT 'Foreign key to expense_groups',
    `percentage` DECIMAL(5,2) NOT NULL COMMENT 'Percentage of the expense group assigned to the user',
    CONSTRAINT uq_expense_apportionments_group_user UNIQUE (`expense_group_id`, `user_id`),
    INDEX idx_expense_apportionments_expense_group_id (`expense_group_id`),
    INDEX idx_expense_apportionments_user_id (`user_id`),
    FOREIGN KEY (`expense_group_id`) REFERENCES `expense_groups`(`id`),
    FOREIGN KEY (`user_id`) REFERENCES `users`(`id`)
);

-- expense_period_settlement Table
CREATE TABLE `expense_period_settlement` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for expense_period_settlement',
    `expense_period_id` INT NOT NULL COMMENT 'Foreign key to expense_periods',
    `total_amount` DECIMAL(18,2) NOT NULL COMMENT 'Total amount to be settled for the period',
    `status` ENUM('pending', 'processing', 'settled') DEFAULT 'pending' COMMENT 'Settlement status',
    INDEX idx_expense_period_settlement_expense_period_id (`expense_period_id`),
    FOREIGN KEY (`expense_period_id`) REFERENCES `expense_periods`(`id`)
);

-- expense_settlement Table
CREATE TABLE `expense_settlement` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for expense_settlement',
    `user_id` INT NOT NULL COMMENT 'Foreign key to users',
    `expense_period_settlement_id` INT NOT NULL COMMENT 'Foreign key to expense_period_settlement',
    `total_amount` DECIMAL(18,2) NOT NULL COMMENT 'Total amount for the user in this settlement',
    `payable` DECIMAL(18,2) NOT NULL COMMENT 'Amount the user needs to pay',
    `receivable` DECIMAL(18,2) NOT NULL COMMENT 'Amount the user will receive',
    `percentage` DECIMAL(5,2) NOT NULL COMMENT 'User share percentage in this settlement',
    `status` ENUM('pending', 'processing', 'settled') DEFAULT 'pending' COMMENT 'Settlement status',
    CONSTRAINT uq_expense_settlement_user_period UNIQUE (`expense_period_settlement_id`, `user_id`),
    INDEX idx_expense_settlement_expense_period_settlement_id (`expense_period_settlement_id`),
    INDEX idx_expense_settlement_user_id (`user_id`),
    FOREIGN KEY (`expense_period_settlement_id`) REFERENCES `expense_period_settlement`(`id`),
    FOREIGN KEY (`user_id`) REFERENCES `users`(`id`)
);

-- financial_transactions Table
CREATE TABLE `financial_transactions` (
    `id` INT AUTO_INCREMENT PRIMARY KEY COMMENT 'Primary key for financial_transactions',
    `user_id` INT NOT NULL COMMENT 'User who created the transaction',
    `counterparty_id` INT NOT NULL COMMENT 'Other party involved in the transaction',
    `amount` DECIMAL(18,2) NOT NULL COMMENT 'Transaction amount',
    `transaction_type` ENUM('income', 'expense') NOT NULL COMMENT 'Type of transaction',
    `created_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP COMMENT 'Creation timestamp',
    `status` ENUM('pending', 'completed', 'failed') DEFAULT 'pending' COMMENT 'Transaction status',
    `expense_settlement_id` INT NOT NULL COMMENT 'Foreign key to expense_settlement',
    CONSTRAINT uq_financial_transactions_settlement_user_counterparty UNIQUE (`expense_settlement_id`, `user_id`, `counterparty_id`),
    INDEX idx_financial_transactions_user_id (`user_id`),
    INDEX idx_financial_transactions_counterparty_id (`counterparty_id`),
    INDEX idx_financial_transactions_expense_settlement_id (`expense_settlement_id`),
    FOREIGN KEY (`user_id`) REFERENCES `users`(`id`),
    FOREIGN KEY (`counterparty_id`) REFERENCES `users`(`id`),
    FOREIGN KEY (`expense_settlement_id`) REFERENCES `expense_settlement`(`id`)
);
