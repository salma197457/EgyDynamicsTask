CREATE DATABASE EgyDynamics;

CREATE TABLE الموظف (
    [كود الموظف] int PRIMARY KEY IDENTITY(1,1),
    [اسم الموظف] NVARCHAR(255)
);


CREATE TABLE العميل (
    [كود العميل] int PRIMARY KEY IDENTITY(1,1),
    [اسم العميل] NVARCHAR(255),
    [محل الاقامة] NVARCHAR(255),
    [توصيف] NVARCHAR(255),
    [الوظيفة] NVARCHAR(255),
    [ادخال بواسطة] int FOREIGN KEY REFERENCES الموظف([كود الموظف]),
    [تاريخ الادخال] Date,
    [اخر تعديل] int FOREIGN KEY REFERENCES الموظف([كود الموظف]),
    [اخر تعديل في] Date,
    [رجل المبيعات] NVARCHAR(255),
    [مصدر العميل] NVARCHAR(255),
    [تصنيف العميل] NVARCHAR(255)
);

ALTER TABLE العميل
ADD [موبايل] int

ALTER TABLE العميل
ADD [تليفون1] int

ALTER TABLE العميل
ADD [تليفون2] int

ALTER TABLE العميل
ADD [واتس] int

ALTER TABLE العميل
ADD [جنسية] NVARCHAR(50)

ALTER TABLE العميل
ADD [الايميل] NVARCHAR(50)

ALTER TABLE الموظف
ADD [اسم المستخدم] NVARCHAR(20)

ALTER TABLE الموظف
ADD [كلمة المرور] NVARCHAR(20)

CREATE TABLE [مكالمه العميل] (
    [كود مكالمة العميل] int PRIMARY KEY IDENTITY(1,1),
    [التوصيف] NVARCHAR(255),
    [مدة المكالمه] int,
    [التاريخ] Date,
    [المشروع] NVARCHAR(255),
    [الموظف] int FOREIGN KEY REFERENCES [الموظف]([كود الموظف]),
    [هل تمت] bit,
    [نوع المكالمه] NVARCHAR(255),
    [هل وارد] bit,
    [ادخال بواسطه] int FOREIGN KEY REFERENCES [الموظف]([كود الموظف]),
    [تاريخ الادخال] Date,
    [اخر تعديل في] Date,
    [اخر تعديل] int FOREIGN KEY REFERENCES [الموظف]([كود الموظف]),
    [كود العميل] int FOREIGN KEY REFERENCES [العميل]([كود العميل])
);


ALTER TABLE العميل
ALTER COLUMN [موبايل] NVARCHAR(20);

ALTER TABLE العميل
ALTER COLUMN [تليفون1] NVARCHAR(20);

ALTER TABLE العميل
ALTER COLUMN [تليفون2] NVARCHAR(20);

ALTER TABLE العميل
ALTER COLUMN [واتس] NVARCHAR(20);

INSERT INTO الموظف ([اسم الموظف], [اسم المستخدم], [كلمة المرور]) VALUES
('John Doe', 'jdoe', 'password123'),
('Jane Smith', 'jsmith', 'password456'),
('Alice Johnson', 'ajohnson', 'password789'),
('Bob Brown', 'bbrown', 'password012');

INSERT INTO العميل ([اسم العميل], [محل الاقامة], [توصيف], [الوظيفة], [ادخال بواسطة], [تاريخ الادخال], [اخر تعديل], [اخر تعديل في], [رجل المبيعات], [مصدر العميل], [تصنيف العميل], [موبايل], [تليفون1], [تليفون2], [واتس], [جنسية], [الايميل]) VALUES
('Michael Johnson', 'New York', 'VIP', 'CEO', 1, '2024-06-10', 1, '2024-06-10', 'Salesman A', 'Referral', 'A', '1234567890', '1234567891', '1234567892', '1234567893', 'American', 'michael@example.com'),
('Emily Williams', 'Los Angeles', 'Regular', 'Lawyer', 2, '2024-06-09', 2, '2024-06-09', 'Salesman B', 'Ad', 'B', '2345678901', '2345678902', '2345678903', '2345678904', 'American', 'emily@example.com'),
('Christopher Brown', 'Chicago', 'Regular', 'Architect', 3, '2024-06-08', 3, '2024-06-08', 'Salesman C', 'Online', 'A', '3456789012', '3456789013', '3456789014', '3456789015', 'American', 'christopher@example.com'),
('Sarah Jones', 'Houston', 'Regular', 'Engineer', 4, '2024-06-07', 4, '2024-06-07', 'Salesman D', 'Referral', 'C', '4567890123', '4567890124', '4567890125', '4567890126', 'American', 'sarah@example.com'),
('David Smith', 'Phoenix', 'New', 'Artist', 1, '2024-06-06', 1, '2024-06-06', 'Salesman E', 'Referral', 'B', '5678901234', '5678901235', '5678901236', '5678901237', 'American', 'david@example.com');

INSERT INTO [مكالمه العميل] VALUES
('Initial Inquiry', 10, '2024-06-11', 'Project X', 1, 1, 'Outbound', 0, 1, '2024-06-11', '2024-06-11', 2, 4),
('Follow-up Discussion', 20, '2024-06-10', 'Project Y', 2, 1, 'Outbound', 0, 2, '2024-06-10', '2024-06-10', 3, 3),
('Feedback Call', 15, '2024-06-09', 'Project Z', 3, 1, 'Inbound', 1, 3, '2024-06-09', '2024-06-09', 4, 5),
('Final Negotiation', 25, '2024-06-08', 'Project W', 4, 0, 'Outbound', 0, 4, '2024-06-08', '2024-06-08', 1, 6),
('Closure Discussion', 30, '2024-06-07', 'Project V', 1, 1, 'Outbound', 0, 1, '2024-06-07', '2024-06-07', 2, 7);
