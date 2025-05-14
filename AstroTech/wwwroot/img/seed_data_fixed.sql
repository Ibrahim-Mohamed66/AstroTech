
-- Insert Categories
INSERT INTO Categories (CategoryName, CategoryImage, CategoryDescription, ParentCategoryId) VALUES
('Laptops', 'laptops.png', 'All laptop models and types', NULL),
('Smartphones', 'smartphones.png', 'Latest smartphones', NULL),
('Cameras', 'cameras.png', 'Professional cameras', NULL),
('Accessories', 'accessories.png', 'Tech accessories', NULL),
('Gaming', 'gaming.png', 'Gaming gear and consoles', NULL),
('Headphones', 'headphones.png', 'Wired and wireless headphones', 4);

-- Insert Brands
INSERT INTO Brands (BrandName) VALUES
('Apple'),
('Samsung'),
('Dell'),
('Canon'),
('Sony');

-- Insert Products
INSERT INTO Products
(ProductName, ProductDescription, BasePrice, SpecificationsRaw, SalePrice, IsOnSale, StockQuantity, CategoryId, BrandId, DiscountPrice, WarrantyPeriodMonths, Color)
VALUES
('MacBook Pro 16"', 'Powerful laptop from Apple', 2399.99, '{"CPU":"M2 Pro","RAM":"16GB","Storage":"512GB SSD"}', NULL, 0, 20, 1, 1, NULL, 24, 'Silver'),
('Galaxy S23', 'Flagship Samsung phone', 999.99, '{"Screen":"6.1 AMOLED","RAM":"8GB","Camera":"108MP"}', 899.99, 1, 30, 2, 2, 100.00, 12, 'Black'),
('Canon EOS R6', 'Mirrorless Camera for Professionals', 1999.00, '{"Sensor":"20MP","Video":"4K","Lens":"RF"}', NULL, 0, 10, 3, 4, NULL, 24, 'Black'),
('Sony WH-1000XM5', 'Noise cancelling headphones', 349.99, '{"Battery":"30h","NoiseCancel":"Yes"}', NULL, 0, 15, 6, 5, NULL, 12, 'Matte Black'),
('Dell XPS 13', 'Premium ultrabook', 1299.99, '{"CPU":"i7","RAM":"16GB","Storage":"512GB SSD"}', 1099.99, 1, 10, 1, 200.00, 24, 'White'),
('Logitech MX Master 3', 'Advanced wireless mouse', 99.99, '{"DPI":"4000","Battery":"70 days"}', NULL, 0, 50, 4, 3, NULL, 12, 'Graphite');
