-- Categories
INSERT INTO [Categories] (CategoryName, CategoryImage, CategoryDescription, ParentCategoryId) VALUES ( 'Laptops', 'laptops.jpg', 'Latest laptops', NULL);
INSERT INTO [Categories] (CategoryName, CategoryImage, CategoryDescription, ParentCategoryId) VALUES ( 'Smartphones', 'smartphones.jpg', 'Smart devices', NULL);
INSERT INTO [Categories] (CategoryName, CategoryImage, CategoryDescription, ParentCategoryId) VALUES ( 'Cameras', 'cameras.jpg', 'DSLR and more', NULL);
INSERT INTO [Categories] (CategoryName, CategoryImage, CategoryDescription, ParentCategoryId) VALUES ( 'Accessories', 'accessories.jpg', 'Useful accessories', NULL);
INSERT INTO [Categories] (CategoryName, CategoryImage, CategoryDescription, ParentCategoryId) VALUES ( 'Gaming Laptops', 'gaming_laptops.jpg', 'High-performance gaming laptops', 1);
INSERT INTO [Categories] (CategoryName, CategoryImage, CategoryDescription, ParentCategoryId) VALUES ( 'Android Phones', 'android_phones.jpg', 'All Android smartphones', 2);

-- Brands
INSERT INTO [Brands] (Name) VALUES ( 'Dell');
INSERT INTO [Brands] (Name) VALUES ( 'Apple');
INSERT INTO [Brands] (Name) VALUES ( 'Samsung');
INSERT INTO [Brands] (Name) VALUES ( 'Sony');
INSERT INTO [Brands] (Name) VALUES ( 'Logitech');

-- Products

    INSERT INTO Products (
        Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
        SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
        WarrantyPeriodMonths, Color
    ) VALUES ( 'Switchable analyzing time-frame', 'Study data measure seek.
World along president deal perhaps account lead. If hit why party situation view.', 1393.28, '{"Processor": "get", "RAM": "16 GB", "Storage": "1024 GB", "Screen": "13 inch"}',
        1311.21, NULL,
        43, 1, 4, 2,
        NULL, NULL
    );

    INSERT INTO Products (
        Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
        SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
        WarrantyPeriodMonths, Color
    ) VALUES ( 'Front-line tertiary project', 'Share ability language president.
Their good space community hotel. Be leave them contain.', 1472.35, '{"Processor": "wait", "RAM": "8 GB", "Storage": "256 GB", "Screen": "14 inch"}',
        1445.4299999999998, NULL,
        94, 1, 1, 4,
        12, 'Black'
    );

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Decentralized bandwidth-monitored alliance', 'Energy quality picture international several very. New community same forget senior each maybe letter. And choice wait number attention director.', 393.84, '{"Processor": "price", "RAM": "16 GB", "Storage": "512 GB", "Screen": "17 inch"}',
    NULL, 370.02,
    38, 0, 3, 2,
    NULL, NULL
);

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Upgradable radical middleware', 'Bring authority rock service any drive cold. Police serious cup word magazine above rather. Consider various pull nor trade candidate myself share.', 1035.31, '{"Processor": "team", "RAM": "32 GB", "Storage": "128 GB", "Screen": "17 inch"}',
    966.28, 1008.9399999999999,
    52, 1, 4, 1,
    12, NULL
);

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Advanced intermediate productivity', 'Student side fact church world later put. By ten body room. Very already this risk. Administration his wear prepare establish.', 1174.29, '{"Processor": "scientist", "RAM": "32 GB", "Storage": "512 GB", "Screen": "13 inch"}',
    1097.6, NULL,
    52, 1, 4, 3,
    24, 'Blue'
);

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Front-line scalable matrix', 'Walk citizen stock son. Little positive themselves marriage. Seek behavior teach floor pattern use wish.', 1938.4, '{"Processor": "camera", "RAM": "16 GB", "Storage": "512 GB", "Screen": "14 inch"}',
    1865.67, NULL,
    83, 1, 6, 1,
    36, 'Gray'
);

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Ergonomic uniform alliance', 'Sell agency relate husband read. Scene music form wonder question.', 1734.8, '{"Processor": "identify", "RAM": "16 GB", "Storage": "1024 GB", "Screen": "17 inch"}',
    NULL, 1691.49,
    100, 0, 1, 4,
    NULL, NULL
);

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Exclusive high-level methodology', 'House and light sea share. Discuss pressure agreement nature skin detail.', 685.89, '{"Processor": "nation", "RAM": "16 GB", "Storage": "512 GB", "Screen": "14 inch"}',
    660.65, NULL,
    89, 1, 3, 4,
    24, 'Blue'
);

    INSERT INTO Products (
        Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
        SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
        WarrantyPeriodMonths, Color
    ) VALUES ( 'Customizable web-enabled firmware', 'Fear level little I improve article only.
Ever sing drug yet first sea oil. Student bag agent.', 1147.69, '{"Processor": "church", "RAM": "4 GB", "Storage": "256 GB", "Screen": "14 inch"}',
        NULL, NULL,
        54, 0, 5, 5,
        12, 'White'
    );

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Expanded static concept', 'Interest us process picture. Case wrong modern try then war.', 1837.72, '{"Processor": "onto", "RAM": "4 GB", "Storage": "256 GB", "Screen": "17 inch"}',
    1796.1200000000001, NULL,
    92, 1, 5, 4,
    12, 'White'
);

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Synergistic 24hour orchestration', 'Good top black site entire sort machine. After lawyer other turn staff I. Firm family democratic appear fear movie true guess.', 1614.56, '{"Processor": "commercial", "RAM": "8 GB", "Storage": "512 GB", "Screen": "13 inch"}',
    NULL, NULL,
    38, 0, 5, 4,
    12, 'White'
);

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Right-sized homogeneous Graphical User Interface', 'Around process voice example social well this. Lose pull majority hit to.', 1486.09, '{"Processor": "society", "RAM": "32 GB", "Storage": "1024 GB", "Screen": "15 inch"}',
    1414.0, NULL,
    94, 1, 2, 1,
    36, 'Black'
);

    INSERT INTO Products (
        Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
        SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
        WarrantyPeriodMonths, Color
    ) VALUES ( 'Vision-oriented composite alliance', 'She nothing oil charge cover. Cover involve game catch.
Who long control senior. Foreign detail too different successful dark American network.', 768.49, '{"Processor": "effort", "RAM": "8 GB", "Storage": "256 GB", "Screen": "15 inch"}',
        NULL, NULL,
        26, 0, 1, 5,
        NULL, 'Gray'
    );

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Down-sized dedicated standardization', 'Hundred dark law economy article. Difficult type bring provide meet.', 1700.7, '{"Processor": "national", "RAM": "16 GB", "Storage": "512 GB", "Screen": "17 inch"}',
    NULL, NULL,
    34, 0, 1, 5,
    NULL, 'Black'
);

    INSERT INTO Products (
        Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
        SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
        WarrantyPeriodMonths, Color
    ) VALUES ( 'Future-proofed regional hub', 'Work gun not rest somebody. Collection bit mother ask job.
Trade somebody five plant. Rather customer rise teach break interest.', 940.05, '{"Processor": "century", "RAM": "32 GB", "Storage": "256 GB", "Screen": "13 inch"}',
        NULL, NULL,
        87, 0, 6, 2,
        24, 'Gray'
    );

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Synchronized system-worthy array', 'Watch keep no city approach speech likely appear. Picture fear charge sea soon reach home bar.', 1272.57, '{"Processor": "future", "RAM": "16 GB", "Storage": "1024 GB", "Screen": "14 inch"}',
    1215.22, NULL,
    14, 1, 5, 4,
    12, 'Blue'
);

    INSERT INTO Products (
        Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
        SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
        WarrantyPeriodMonths, Color
    ) VALUES ( 'Up-sized multi-tasking help-desk', 'Item woman wait. Be pick teach respond throughout pay.
Many discover fight natural Mr. Nation want entire since raise.', 189.56, '{"Processor": "manage", "RAM": "16 GB", "Storage": "1024 GB", "Screen": "15 inch"}',
        116.55, NULL,
        68, 1, 1, 1,
        24, 'Blue'
    );

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Intuitive clear-thinking approach', 'Term likely this suddenly artist late. Ask when likely people consumer. Structure college do provide leader way.', 819.2, '{"Processor": "for", "RAM": "32 GB", "Storage": "1024 GB", "Screen": "17 inch"}',
    NULL, NULL,
    75, 0, 2, 1,
    36, 'Gray'
);

INSERT INTO Products (
    Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
    SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
    WarrantyPeriodMonths, Color
) VALUES ( 'Switchable national Graphic Interface', 'Age leave special similar month see prepare. Crime trial that tonight machine cut hope amount. Maybe reason letter.', 1348.66, '{"Processor": "impact", "RAM": "16 GB", "Storage": "512 GB", "Screen": "15 inch"}',
    NULL, 1303.78,
    77, 0, 5, 3,
    36, 'Gray'
);

    INSERT INTO Products (
        Id, ProductName, ProductDescription, BasePrice, SpecificationsRaw, 
        SalePrice, DiscountPrice, StockQuantity, IsOnSale, CategoryId, BrandId, 
        WarrantyPeriodMonths, Color
    ) VALUES ( 'Enterprise-wide systemic approach', 'Yourself woman large test seem. Game crime act tell better help. Letter each raise research scene bar.
Message fall you purpose do similar read.', 305.62, '{"Processor": "deal", "RAM": "32 GB", "Storage": "256 GB", "Screen": "15 inch"}',
        270.07, 289.45,
        100, 1, 1, 4,
        24, 'Black'
    );