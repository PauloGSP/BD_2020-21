use pubs

--a

SELECT * FROM authors

--b

SELECT au_fname, au_lname, phone FROM authors

--c
SELECT au_fname, au_lname, phone FROM authors ORDER BY au_fname ASC, au_lname ASC

--d

SELECT au_fname AS first_name, au_lname AS last_name, phone AS telephone FROM authors ORDER BY au_fname ASC, au_lname ASC

--e

SELECT au_fname AS first_name, au_lname AS last_name, phone AS telephone FROM authors WHERE state='CA' and au_lname!='Ringer' ORDER BY au_fname ASC, au_lname ASC 

--f

SELECT * FROM publishers WHERE pub_name LIKE '%Bo%'

--g

SELECT DISTINCT pub_id FROM titles WHERE type='business'

--h

SELECT pub_name, SUM(ytd_sales) FROM publishers AS pub JOIN titles AS tit ON pub.pub_id = tit.pub_id GROUP BY pub_name

--i

SELECT pub_name, title, SUM(qty) FROM publishers AS pub JOIN titles AS tit ON pub.pub_id = tit.pub_id JOIN sales ON tit.title_id = sales.title_id GROUP BY pub_name, title ORDER BY pub_name ASC

--j

SELECT title FROM titles INNER JOIN publishers ON titles.pub_id = publishers.pub_id WHERE publishers.pub_name = 'Bookbeat'

--k

SELECT au_fname + ' ' + au_lname as au_name FROM authors WHERE au_id IN (SELECT au_id FROM titleauthor JOIN titles ON titleauthor.title_id=titles.title_id  GROUP BY au_id HAVING COUNT(titles.type)>1 )

--l

SELECT type, pub_id, AVG(price) AS avg_price, SUM(ytd_sales) AS total_sales FROM titles GROUP BY type, pub_id

--m

SELECT type FROM titles  GROUP BY type HAVING MAX(advance)>1.5*AVG(advance)

--n

SELECT title, au_fname + ' ' + au_lname as au_name, price * royalty * royaltyper * ytd_sales / 100 / 100 AS profit FROM titleauthor JOIN titles ON titles.title_id = titleauthor.title_id JOIN authors ON authors.au_id = titleauthor.au_id

--o 

SELECT title, ytd_sales,price*ytd_sales AS facturacao, price*ytd_sales*royalty/100 AS auths_revenue,price*ytd_sales-price*ytd_sales*royalty/100 AS publisher_revenue FROM titles WHERE ytd_sales is not NULL ORDER BY title

--p

SELECT title, ytd_sales, au_fname + ' ' + au_lname as author, price * royalty * royaltyper * ytd_sales / 100 / 100 AS auth_revenue, price * (100 - royalty) * ytd_sales / 100 AS publisher_revenue FROM titleauthor JOIN titles ON titles.title_id = titleauthor.title_id JOIN authors ON authors.au_id = titleauthor.au_id ORDER BY title

--q

SELECT stor_name, count(title) AS numTitles FROM ((stores JOIN sales ON stores.stor_id=sales.stor_id) JOIN titles ON sales.title_id=titles.title_id) GROUP BY stor_name HAVING count(title)=(SELECT count(title_id) FROM titles);

--r

SELECT stor_name FROM stores WHERE stor_id IN (SELECT stor_id FROM sales GROUP BY stor_id HAVING SUM(qty) > (SELECT AVG(total_sales) AS sales_avg FROM (SELECT stor_id, SUM(qty) as total_sales FROM sales GROUP BY stor_id) AS sales_data))

--s 

SELECT title FROM titles WHERE title_id NOT IN (SELECT title_id FROM sales WHERE sales.stor_id=8042)

--t

SELECT pub_name, stor_name FROM publishers JOIN stores ON stor_id NOT IN (SELECT stor_id FROM sales INNER JOIN titles ON sales.title_id = titles.title_id WHERE pub_id = 1389) ORDER BY pub_name 
