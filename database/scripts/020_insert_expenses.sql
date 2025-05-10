-- Insert sample data into ExpenseCategories
INSERT INTO `ExpenseCategories` (`name`, `description`) VALUES
('Food', 'Expenses related to food and dining'),
('Transport', 'Expenses related to transportation'),
('Health', 'Expenses related to health and medical needs'),
('Entertainment', 'Expenses related to leisure and entertainment'),
('Education', 'Expenses related to learning and education'),
('Utilities', 'Expenses related to household utilities'),
('Shopping', 'Expenses related to shopping'),
('Travel', 'Expenses related to travel and vacations'),
('Insurance', 'Expenses related to insurance premiums'),
('Other', 'Miscellaneous expenses');

-- Insert sample data into Periods
INSERT INTO `Periods` (`name`, `description`, `type`) VALUES
('Daily', 'Daily recurring period', 'daily'),
('Weekly', 'Weekly recurring period', 'weekly'),
('Bi-Weekly', 'Bi-weekly recurring period', 'bi-weekly'),
('Monthly', 'Monthly recurring period', 'monthly'),
('Yearly', 'Yearly recurring period', 'yearly'),
('One-Time', 'One-time period', 'one-time'),
('Quarterly', 'Quarterly recurring period', 'monthly'),
('Semi-Annual', 'Semi-annual recurring period', 'monthly'),
('Custom', 'Custom period', 'one-time'),
('Seasonal', 'Seasonal period', 'one-time');

-- Insert sample data into PaymentMethods
INSERT INTO `PaymentMethods` (`name`, `description`) VALUES
('Credit Card', 'Payment made using a credit card'),
('Debit Card', 'Payment made using a debit card'),
('Cash', 'Payment made using cash'),
('Bank Transfer', 'Payment made using a bank transfer'),
('Pix', 'Payment made using Pix'),
('Boleto', 'Payment made using a boleto'),
('PayPal', 'Payment made using PayPal'),
('Google Pay', 'Payment made using Google Pay'),
('Apple Pay', 'Payment made using Apple Pay'),
('Other', 'Other payment methods');

-- Insert sample data into ExpenseGroups
INSERT INTO `ExpenseGroups` (`name`, `description`, `created_by`, `created_at`, `updated_by`, `updated_at`) VALUES
('Family Expenses', 'Shared expenses for the family', 1, NOW(), 2, NOW()),
('Work Expenses', 'Expenses related to work', 2, NOW(), 3, NOW()),
('Vacation Expenses', 'Expenses for vacations', 3, NOW(), 4, NOW()),
('Health Expenses', 'Expenses related to health', 4, NOW(), 5, NOW()),
('Education Expenses', 'Expenses for education', 5, NOW(), 6, NOW()),
('Entertainment Expenses', 'Expenses for entertainment', 6, NOW(), 7, NOW()),
('Transport Expenses', 'Expenses for transport', 7, NOW(), 8, NOW()),
('Shopping Expenses', 'Expenses for shopping', 8, NOW(), 9, NOW()),
('Utilities Expenses', 'Expenses for utilities', 9, NOW(), 10, NOW()),
('Miscellaneous Expenses', 'Miscellaneous expenses', 10, NOW(), 1, NOW());

-- Insert sample data into PeriodExpenses
INSERT INTO `PeriodExpenses` (`period_id`, `expense_group_id`, `start_date`, `end_date`, `status`) VALUES
(4, 1, '2023-01-01', '2023-12-31', 'open'),
(4, 2, '2023-01-01', '2023-12-31', 'open'),
(4, 3, '2023-01-01', '2023-12-31', 'open'),
(4, 4, '2023-01-01', '2023-12-31', 'open'),
(4, 5, '2023-01-01', '2023-12-31', 'open'),
(4, 6, '2023-01-01', '2023-12-31', 'open'),
(4, 7, '2023-01-01', '2023-12-31', 'open'),
(4, 8, '2023-01-01', '2023-12-31', 'open'),
(4, 9, '2023-01-01', '2023-12-31', 'open'),
(4, 10, '2023-01-01', '2023-12-31', 'open');

-- Insert sample data into ExpenseGroupsUsers
INSERT INTO `ExpenseGroupsUsers` (`expense_group_id`, `user_id`, `created_at`, `created_by`, `updated_at`, `updated_by`) VALUES
(1, 1, NOW(), 1, NOW(), 1),
(1, 2, NOW(), 1, NOW(), 1),
(2, 3, NOW(), 2, NOW(), 2),
(2, 4, NOW(), 2, NOW(), 2),
(3, 5, NOW(), 3, NOW(), 3),
(3, 6, NOW(), 3, NOW(), 3),
(4, 7, NOW(), 4, NOW(), 4),
(4, 8, NOW(), 4, NOW(), 4),
(5, 9, NOW(), 5, NOW(), 5),
(5, 10, NOW(), 5, NOW(), 5);

-- Insert sample data into Expenses
INSERT INTO `Expenses` (`period_expenses_id`, `name`, `tag`, `amount`, `payment_method_id`, `period`, `due_day`, `created_by`, `expense_category_id`) VALUES
(1, 'Groceries', 'Food', 150.00, 1, '202304', 15, 1, 1),
(1, 'Bus Ticket', 'Transport', 50.00, 2, '202304', 10, 1, 2),
(1, 'Doctor Visit', 'Health', 200.00, 3, '202304', 20, 1, 3),
(1, 'Movie Night', 'Entertainment', 30.00, 4, '202304', 25, 1, 4),
(1, 'Online Course', 'Education', 100.00, 5, '202304', 5, 1, 5),
(1, 'Electricity Bill', 'Utilities', 120.00, 6, '202304', 18, 1, 6),
(1, 'Clothes Shopping', 'Shopping', 250.00, 7, '202304', 12, 1, 7),
(1, 'Flight Ticket', 'Travel', 500.00, 8, '202304', 22, 1, 8),
(1, 'Car Insurance', 'Insurance', 300.00, 9, '202304', 28, 1, 9),
(1, 'Miscellaneous', 'Other', 75.00, 10, '202304', 30, 1, 10);

-- Add 90 more records for Expenses
INSERT INTO `Expenses` (`period_expenses_id`, `name`, `tag`, `amount`, `payment_method_id`, `period`, `due_day`, `created_by`, `expense_category_id`)
SELECT
    FLOOR(RAND() * 10) + 1, -- Random period_expenses_id
    CONCAT('Expense ', FLOOR(RAND() * 1000)), -- Random name
    'Other', -- Tag
    ROUND(RAND() * 1000, 2), -- Random amount
    FLOOR(RAND() * 10) + 1, -- Random payment_method_id
    CONCAT('2023', LPAD(FLOOR(RAND() * 12) + 1, 2, '0')), -- Random period
    FLOOR(RAND() * 28) + 1, -- Random due_day
    FLOOR(RAND() * 10) + 1, -- Random created_by
    FLOOR(RAND() * 10) + 1 -- Random expense_category_id
FROM
    (SELECT 1 AS dummy UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9 UNION ALL SELECT 10) AS numbers;
