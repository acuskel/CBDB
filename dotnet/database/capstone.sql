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
	user_role varchar(50) NOT NULL,
	is_premium bit NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE collections (
	id int IDENTITY (1,1) NOT NULL,
	collection_name varchar(50) NOT NULL,
	user_id int NOT NULL,
	is_public bit,
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
INSERT INTO users (username, password_hash, salt, user_role, is_premium) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 0);
--admin/password
INSERT INTO users (username, password_hash, salt, user_role, is_premium) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 1);

--populate collections data
INSERT INTO collections (collection_name, user_id, is_public) VALUES ('Batman', 1, 0);
INSERT INTO collections (collection_name, user_id, is_public) VALUES ('Spiderman', 1, 1);
INSERT INTO collections (collection_name, user_id, is_public) VALUES ('Tick', 1, 1);
INSERT INTO collections (collection_name, user_id, is_public) VALUES ('Marvel', 2, 0);
INSERT INTO collections (collection_name, user_id, is_public) VALUES ('DC', 2, 1);
INSERT INTO collections (collection_name, user_id, is_public) VALUES ('Image', 2, 0);

--populate issues data
INSERT INTO issues (issue_title, series_title, release_date, ISBN, UPC, summary, cover_link, publisher) VALUES ('Far From Home', 'Spiderman', '2010-01-01', 456789, 727272,'ppppp', 'mmfmf', 'Marvel');
INSERT INTO issues (issue_title, series_title, release_date, ISBN, UPC, summary, cover_link, publisher) VALUES ('Court of Owls', 'Batman', '2010-01-01', 456789, 727272, 'summ', 'mmfmf', 'DC');
INSERT INTO issues (issue_title, series_title, release_date, ISBN, UPC, summary, cover_link, publisher) VALUES ('Whisperer Wars', 'The Walking Dead', '2010-01-01', 456789, 727272, 'summ', 'mmfmf', 'Other');
INSERT INTO issues (issue_title, series_title, release_date, ISBN, UPC, summary, cover_link, publisher) VALUES ('Crawling', 'The Tick', '2010-01-01', 456789, 727272,'summ','mmfmf', 'Marvel');


-- populate join table
INSERT INTO collections_issues (collection_id, issue_id) VALUES (1,2);
INSERT INTO collections_issues (collection_id, issue_id) VALUES (1,3);
INSERT INTO collections_issues (collection_id, issue_id) VALUES (2,4);
INSERT INTO collections_issues (collection_id, issue_id) VALUES (3,1);


GO