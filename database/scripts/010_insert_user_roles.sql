-- Insert sample data into UserRoles
INSERT INTO `user_roles` (`name`, `description`) VALUES
('Master User', 'Full access to all features'),
('Standard User', 'Access to personal expense tracking and budget management'),
('Viewer', 'Read-only access to expenses and budgets'),
('Admin', 'Administrative privileges'),
('Guest', 'Limited access for trial users'),
('Manager', 'Manage team expenses'),
('Accountant', 'Access to financial reports'),
('Auditor', 'Audit access to all data'),
('Developer', 'Access for development purposes'),
('Tester', 'Access for testing purposes');

-- Insert sample data into Users
INSERT INTO `users` (`username`, `email`, `password_hash`, `role_id`, `created_at`, `updated_at`) VALUES
('admin', 'admin@email.com', 'hashed_password_1', 1, NOW(), NOW()),
('user1', 'user1@email.com', 'hashed_password_2', 2, NOW(), NOW()),
('user2', 'user2@email.com', 'hashed_password_3', 2, NOW(), NOW()),
('viewer1', 'viewer1@email.com', 'hashed_password_4', 3, NOW(), NOW()),
('manager1', 'manager1@email.com', 'hashed_password_5', 6, NOW(), NOW()),
('accountant1', 'accountant1@email.com', 'hashed_password_6', 7, NOW(), NOW()),
('auditor1', 'auditor1@email.com', 'hashed_password_7', 8, NOW(), NOW()),
('developer1', 'developer1@email.com', 'hashed_password_8', 9, NOW(), NOW()),
('tester1', 'tester1@email.com', 'hashed_password_9', 10, NOW(), NOW()),
('guest1', 'guest1@email.com', 'hashed_password_10', 5, NOW(), NOW());
