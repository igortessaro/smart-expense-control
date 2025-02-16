CREATE DATABASE IF NOT EXISTS smart_expense_control;
USE smart_expense_control;

CREATE TABLE UserRoles (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description TEXT
);

CREATE TABLE Users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    username VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    role_id INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (role_id) REFERENCES UserRoles(id)
);

CREATE TABLE ExpenseGroups (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    created_by INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_by INT,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (created_by) REFERENCES Users(id),
    FOREIGN KEY (updated_by) REFERENCES Users(id)
);

CREATE TABLE Expenses (
    id INT AUTO_INCREMENT PRIMARY KEY,
    expense_group_id INT NOT NULL,
    name VARCHAR(255) NOT NULL,
    tag VARCHAR(100) NOT NULL,
    -- user_id INT NOT NULL,
    -- category_id INT NOT NULL,
    amount DECIMAL(10, 2),
    payment_method VARCHAR(50) NOT NULL,
    period VARCHAR(6) NOT NULL,
    -- description TEXT,
    -- date DATE NOT NULL,
    created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    created_by INT NOT NULL,
    updated_by INT,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    payed_by INT,
    payed_at TIMESTAMP,
    -- FOREIGN KEY (user_id) REFERENCES Users(id),
    -- FOREIGN KEY (category_id) REFERENCES ExpenseCategories(id),
    FOREIGN KEY (created_by) REFERENCES Users(id),
    FOREIGN KEY (updated_by) REFERENCES Users(id),
    FOREIGN KEY (payed_by) REFERENCES Users(id),
    FOREIGN KEY (expense_group_id) REFERENCES ExpenseGroups(id)
);

CREATE TABLE ExpenseGroupsUsers (
    id INT AUTO_INCREMENT PRIMARY KEY,
    expense_group_id INT NOT NULL,
    user_id INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    created_by INT NOT NULL,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    updated_by INT,
    FOREIGN KEY (expense_group_id) REFERENCES ExpenseGroups(id),
    FOREIGN KEY (user_id) REFERENCES Users(id),
    FOREIGN KEY (created_by) REFERENCES Users(id),
    FOREIGN KEY (updated_by) REFERENCES Users(id)
);

CREATE TABLE Budgets (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT NOT NULL,
    expense_group_id INT NOT NULL,
    amount DECIMAL(10, 2) NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    created_by INT,
    updated_by INT,
    FOREIGN KEY (user_id) REFERENCES Users(id),
    -- FOREIGN KEY (category_id) REFERENCES ExpenseCategories(id),
    FOREIGN KEY (created_by) REFERENCES Users(id),
    FOREIGN KEY (updated_by) REFERENCES Users(id),
    FOREIGN KEY (expense_group_id) REFERENCES ExpenseGroups(id)
);

CREATE TABLE `Notifications` (
    `id` INT AUTO_INCREMENT PRIMARY KEY,
    `user_id` INT NOT NULL,
    `message` TEXT NOT NULL,
    `read` boolean default FALSE,
    `created_at` TIMESTAMP  NOT NULL DEFAULT CURRENT_TIMESTAMP,
    `updated_at` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    `created_by` INT,
    `updated_by` INT,
    FOREIGN KEY (`user_id`) REFERENCES Users(`id`),
    FOREIGN KEY (`created_by`) REFERENCES Users(`id`),
    FOREIGN KEY (`updated_by`) REFERENCES Users(`id`)
);
