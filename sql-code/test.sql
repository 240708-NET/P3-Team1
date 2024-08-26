USE ReevatureOnlineEniversity;


SELECT * FROM Courses;
SELECT * FROM Professors;
SELECT * FROM Sections;
SELECT * FROM SectionStudent;
SELECT * FROM Students;



SELECT DATA_TYPE 
FROM ReevatureOnlineEniversity.INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'Sections';