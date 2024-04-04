# BD: Guião 6

## Problema 6.1

### *a)* Todos os tuplos da tabela autores (authors);

```
SELECT * FROM authors;
```

### *b)* O primeiro nome, o último nome e o telefone dos autores;

```
SELECT au_fname, au_lname, phone FROM authors;
```

### *c)* Consulta definida em b) mas ordenada pelo primeiro nome (ascendente) e depois o último nome (ascendente); 

```
SELECT au_fname, au_lname, phone FROM authors
ORDER BY au_fname, au_lname;
```

### *d)* Consulta definida em c) mas renomeando os atributos para (first_name, last_name, telephone); 

```
SELECT au_fname AS first_name, au_lname AS last_name, phone AS telephone FROM authors
ORDER BY first_name, last_name;
```

### *e)* Consulta definida em d) mas só os autores da Califórnia (CA) cujo último nome é diferente de ‘Ringer’; 

```
SELECT au_fname AS first_name, au_lname AS last_name, phone AS telephone FROM authors
WHERE state = 'CA' AND au_lname <> 'Ringer'
ORDER BY first_name, last_name;
```

### *f)* Todas as editoras (publishers) que tenham ‘Bo’ em qualquer parte do nome; 

```
SELECT * FROM publishers
WHERE pub_name LIKE '%Bo%';
```

### *g)* Nome das editoras que têm pelo menos uma publicação do tipo ‘Business’; 

```
SELECT pub_name FROM publishers, titles
WHERE publishers.pub_id=titles.pub_id AND type='Business'
GROUP BY pub_name
```

### *h)* Número total de vendas de cada editora; 

```
SELECT pub_name, SUM(ytd_sales) AS total_sales FROM publishers, titles
WHERE publishers.pub_id=titles.pub_id
GROUP BY pub_name;
```

### *i)* Número total de vendas de cada editora agrupado por título; 

```
SELECT pub_name, title, ytd_sales AS total_sales FROM publishers, titles
WHERE publishers.pub_id=titles.pub_id AND ytd_sales IS NOT NULL
ORDER BY pub_name;
```

### *j)* Nome dos títulos vendidos pela loja ‘Bookbeat’; 

```
SELECT title FROM titles, sales, stores
WHERE titles.title_id=sales.title_id AND sales.stor_id=stores.stor_id AND stor_name='Bookbeat';
```

### *k)* Nome de autores que tenham publicações de tipos diferentes; 

```
SELECT au_fname, au_lname FROM authors, titleauthor, titles
WHERE authors.au_id=titleauthor.au_id AND titleauthor.title_id=titles.title_id
GROUP BY au_fname, au_lname
HAVING COUNT(type) > 1;
```

### *l)* Para os títulos, obter o preço médio e o número total de vendas agrupado por tipo (type) e editora (pub_id);

```
SELECT type, pub_id, AVG(price) as avg_price, SUM(ytd_sales) AS total_sales FROM titles
WHERE price IS NOT NULL
GROUP BY type, pub_id;
```

### *m)* Obter o(s) tipo(s) de título(s) para o(s) qual(is) o máximo de dinheiro “à cabeça” (advance) é uma vez e meia superior à média do grupo (tipo);

```
SELECT type FROM titles
WHERE price IS NOT NULL
GROUP BY type
HAVING MAX(price) > 1.5*AVG(price);
```

### *n)* Obter, para cada título, nome dos autores e valor arrecadado por estes com a sua venda;

```
SELECT title, au_fname, au_lname, price*ytd_sales*royalty/100*royaltyper/100 AS revenue FROM titles, titleauthor, authors
WHERE titles.title_id=titleauthor.title_id AND titleauthor.au_id=authors.au_id AND price IS NOT NULL
ORDER BY title;
```

### *o)* Obter uma lista que incluía o número de vendas de um título (ytd_sales), o seu nome, a faturação total, o valor da faturação relativa aos autores e o valor da faturação relativa à editora;

```
SELECT title, ytd_sales, price*ytd_sales AS total_revenue, price*ytd_sales*royalty/100 AS author_revenue, price*ytd_sales*(100-royalty)/100 AS pub_revenue FROM titles
WHERE price IS NOT NULL
ORDER BY title
```

### *p)* Obter uma lista que incluía o número de vendas de um título (ytd_sales), o seu nome, o nome de cada autor, o valor da faturação de cada autor e o valor da faturação relativa à editora;

```
SELECT title, au_fname+' '+au_lname AS author, ytd_sales, price*ytd_sales AS total_revenue, price*ytd_sales*royalty/100*royaltyper/100 AS author_revenue, price*ytd_sales*(100-royalty)/100 AS pub_revenue FROM titles, titleauthor, authors
WHERE titles.title_id=titleauthor.title_id AND titleauthor.au_id=authors.au_id AND price IS NOT NULL
ORDER BY title
```

### *q)* Lista de lojas que venderam pelo menos um exemplar de todos os livros;

```
SELECT stor_name, COUNT(title_id) AS cnt FROM stores, sales
WHERE stores.stor_id=sales.stor_id
GROUP BY stor_name
HAVING COUNT(title_id)=(SELECT COUNT(title_id) FROM titles);
```

### *r)* Lista de lojas que venderam mais livros do que a média de todas as lojas;

```
SELECT stor_name, SUM(qty) AS num_sales FROM stores, sales
WHERE stores.stor_id=sales.stor_id
GROUP BY stor_name
HAVING SUM(qty)>(SELECT AVG(n_sales) FROM (SELECT SUM(qty) AS n_sales FROM sales GROUP BY stor_id) AS q);
```

### *s)* Nome dos títulos que nunca foram vendidos na loja “Bookbeat”;

```
SELECT title FROM titles
WHERE title NOT IN (SELECT title FROM titles, sales, stores WHERE titles.title_id=sales.title_id AND sales.stor_id=stores.stor_id AND stor_name='Bookbeat')
```

### *t)* Para cada editora, a lista de todas as lojas que nunca venderam títulos dessa editora; 

```
SELECT pub_name, stor_name FROM publishers, stores
EXCEPT
SELECT pub_name, stor_name FROM publishers, titles, sales, stores
WHERE publishers.pub_id=titles.pub_id AND titles.title_id=sales.title_id AND sales.stor_id=stores.stor_id
```

## Problema 6.2

### ​5.1

#### a) SQL DDL Script
 
[a) SQL DDL File](ex_6_2_1_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex_6_2_1_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
SELECT DISTINCT project.Pname, employee.Fname, employee.Minit, employee.Lname, employee.Ssn
FROM works_on
JOIN project ON works_on.Pno = project.Pnumber
JOIN employee ON works_on.Essn = employee.Ssn;
```

##### *b)* 

```
SELECT DISTINCT employee.Fname, employee.Minit, employee.Lname
FROM (SELECT employee.Ssn AS manager_Ssn
      FROM employee
      WHERE employee.Fname = 'Carlos' AND employee.Minit = 'D' AND employee.Lname = 'Gomes') AS manager
JOIN employee ON manager.manager_Ssn = employee.Super_ssn;
```

##### *c)* 

```
SELECT DISTINCT project.Pname, SUM(works_on.Hours) AS Hours
FROM project
JOIN works_on ON project.Pnumber = works_on.Pno
GROUP BY project.Pname;
```

##### *d)* 

```
SELECT DISTINCT employee.Fname, employee.Minit, employee.Lname, employee.Dno, project.Pname, works_on.Hours
FROM project
JOIN employee ON project.Dnum = employee.Dno
JOIN works_on ON project.Pnumber = works_on.Pno AND employee.Ssn = works_on.Essn
WHERE project.Pname = 'Aveiro Digital' AND works_on.Hours > 20 AND employee.Dno = 3;
```

##### *e)* 

```
SELECT DISTINCT employee.Fname, employee.Minit, employee.Lname
FROM employee

EXCEPT

SELECT DISTINCT employee.Fname, employee.Minit, employee.Lname
FROM employee
JOIN works_on ON employee.Ssn = works_on.Essn
```

##### *f)*        

```
SELECT DISTINCT department.Dname, AVG(employee.Salary) AS F_AvgSalary
FROM employee
JOIN department ON employee.Dno = department.Dnumber
WHERE employee.Sex = 'F'
GROUP BY department.Dname
```

##### *g)* 

```
SELECT employee.*
FROM employee
JOIN (
    SELECT employee.Ssn, employee.Fname, employee.Minit, employee.Lname
    FROM employee
    JOIN (
        SELECT Essn, COUNT(Dependent_name) AS N_dependents
        FROM dependent
        GROUP BY Essn
        HAVING N_dependents > 2
    ) AS emp_dependents ON employee.Ssn = emp_dependents.Essn
) AS filtered_employees ON employee.Ssn = filtered_employees.Ssn
```

##### *h)* 

```
SELECT employee.*
FROM employee
JOIN (
    SELECT Ssn
    FROM (
        SELECT employee.Ssn
        FROM employee
        JOIN department ON employee.Ssn = department.Mgr_ssn
			
        EXCEPT
			
        SELECT employee.Ssn
        FROM employee
        JOIN dependent ON employee.Ssn = dependent.Essn
    ) AS targets
) AS filtered_employees ON employee.Ssn = filtered_employees.Ssn
```

##### *i)* 

```
... Write here your answer ...
```

### 5.2

#### a) SQL DDL Script
 
[a) SQL DDL File](ex_6_2_2_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex_6_2_2_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
... Write here your answer ...
```

##### *b)* 

```
... Write here your answer ...
```


##### *c)* 

```
... Write here your answer ...
```


##### *d)* 

```
... Write here your answer ...
```

### 5.3

#### a) SQL DDL Script
 
[a) SQL DDL File](ex_6_2_3_ddl.sql "SQLFileQuestion")

#### b) Data Insertion Script

[b) SQL Data Insertion File](ex_6_2_3_data.sql "SQLFileQuestion")

#### c) Queries

##### *a)*

```
... Write here your answer ...
```

##### *b)* 

```
... Write here your answer ...
```


##### *c)* 

```
... Write here your answer ...
```


##### *d)* 

```
... Write here your answer ...
```

##### *e)* 

```
... Write here your answer ...
```

##### *f)* 

```
... Write here your answer ...
```
