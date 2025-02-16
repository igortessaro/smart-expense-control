INSERT INTO UserRoles (name, description) VALUES
('Master User', 'Full access to all features'),
('Standard User', 'Access to personal expense tracking and budget management'),
('Viewer', 'Read-only access to expenses and budgets');

INSERT INTO Users (username, email, password_hash, role_id) VALUES
('admin', 'admin@email.com', 'admin', 1),
('user', 'user@email.com', 'user', 2),
('viewer', 'viewer@email.com', 'viewer', 3);
