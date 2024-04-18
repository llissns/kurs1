# migrations example
```
-- создаем таблицу групп и вставляем значения групп
CREATE TABLE GroupList (
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(255) NOT null,
PRIMARY KEY (id)
);INSERT INTO GroupList (name)
VALUES ('1111');
INSERT INTO GroupList (name)
VALUES ('2222');
INSERT INTO GroupList (name)
VALUES ('3333');

-- создаем таблицу студентов и заполняем значениями
CREATE TABLE StudentList (
  id INT NOT NULL AUTO_INCREMENT,
  surname VARCHAR(255) NOT NULL,
  name VARCHAR(255) NOT NULL,
  patronymic VARCHAR(255) NOT NULL,
  group_id INT NOT NULL,
  phonenumber VARCHAR(255) NOT NULL,
  email VARCHAR(255) NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (group_id) REFERENCES GroupList(id)
  )ENGINE=INNODB;
  
 INSERT INTO StudentList (surname,name,patronymic,group_id,phonenumber,email)
 VALUES('name1','name1','patronimic1',1,'89853380000','aol@aol.com');
 INSERT INTO StudentList (surname,name,patronymic,group_id,phonenumber,email)
 VALUES('name2','name2','patronimic2',2,'89853380000','aol@aol.com');
 
-- создаем таблицу посещения и заполняем значениями
CREATE TABLE AttendanceReport (
  id INT NOT NULL AUTO_INCREMENT,
  student_id INT NOT NULL,
  group_id INT NOT NULL,
  abscense DATE NOT NULL,
  PRIMARY KEY (id),
  FOREIGN KEY (student_id) REFERENCES StudentList(id),
  FOREIGN KEY (group_id) REFERENCES GroupList(id)
  )ENGINE=INNODB;

INSERT INTO AttendanceReport(student_id, group_id,abscense)
VALUES(1,1,'2023-10-29');
INSERT INTO AttendanceReport(student_id, group_id,abscense)
VALUES(2,2,'2024-10-29');

-- выводим на экран
select * from AttendanceReport;
```
