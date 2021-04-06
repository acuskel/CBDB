USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE collections (
	id int IDENTITY (1,1) NOT NULL,
	collection_name varchar(50) NOT NULL,
	user_id int NOT NULL
)

CREATE TABLE issues (
	id int IDENTITY NOT NULL,
	issue_title varchar(150),
	series_title varchar (150),
	release_date date,
	ISBN int,
	UPC int,
	summary varchar(max),
	cover_link varchar(100),
	publisher varchar(50)
	)

CREATE TABLE collections_issues (
	collection_id int NOT NULL,
	issue_id int NOT NULL
	)

--populate default data
-- user/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
--admin/password
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

--populate collections data
INSERT INTO collections (collection_name, user_id) VALUES ('Batman', 1);
INSERT INTO collections (collection_name, user_id) VALUES ('Spiderman', 1);
INSERT INTO collections (collection_name, user_id) VALUES ('Tick', 1);
INSERT INTO collections (collection_name, user_id) VALUES ('Marvel', 2);
INSERT INTO collections (collection_name, user_id) VALUES ('DC', 2);
INSERT INTO collections (collection_name, user_id) VALUES ('Image', 2);

--populate issues data
INSERT INTO issues (issue_title, series_title) VALUES ('Far From Home', 'Spiderman');
INSERT INTO issues (issue_title, series_title) VALUES ('Court of Owls', 'Batman');
INSERT INTO issues (issue_title, series_title) VALUES ('Whisperer Wars', 'The Walking Dead');
INSERT INTO issues (issue_title, series_title) VALUES ('Crawling', 'The Tick');

-- populate join table
INSERT INTO collections_issues (collection_id, issue_id) VALUES (1,2);INSERT INTO collections_issues (collection_id, issue_id) VALUES (1,3);INSERT INTO collections_issues (collection_id, issue_id) VALUES (2,4);INSERT INTO collections_issues (collection_id, issue_id) VALUES (3,1);


GO