Total comic books in all collections; total Marvel comics in all collections, Total Spiderman comics in all collections.

number of comics per user, avg number of comics, user with most, least, comics held by largest number of people. list on admin statistics page

SELECT * FROM users
SELECT * FROM issues
SELECT * FROM collections_issues
SELECT * FROM collections

--comics(issues) per user
SELECT u.username, c.user_id, COUNT(i.id) 'number of issues' from  issues i --issues per user