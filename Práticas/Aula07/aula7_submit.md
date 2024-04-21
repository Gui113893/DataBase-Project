# BD: Guião 7


## ​7.2 
 
### *a)*

```
Está na 1FN - nome_autor tem dependencias parciais
```

### *b)* 

```
1FN:
Livro (<u>Titulo_Livro</u>, <u>Nome_Autor</u>, Afiliacao_Autor, Tipo_Livro, Preco, NoPaginas, Editor, Endereco_Editor, Ano_Publicacao)


2FN:
Livro (<u>Titulo_Livro</u>, <u>Nome_Autor</u>, Tipo_Livro, Preco, NoPaginas, Editor, Endereco_Editor, Ano_Publicacao)
Autor (<u>Nome_Autor</u>, Afiliacao_Autor) 

3FN
Livro (<u>Titulo_Livro</u>, <u>Nome_Autor</u>, Tipo_Livro, NoPaginas, Editor, Ano_Publicacao)
Autor (<u>Nome_Autor</u>, Afiliacao_Autor)
Editor (<u>Editor</u>, Endereco_Editor)
Valor_Livro (<u>Tipo_Livro</u>, <u>NoPaginas</u>, Preco)
```




## ​7.3
 
### *a)*

```
Chave de R: {A,B}
```


### *b)* 

```
R1={<u>A</u>,<u>B</u>,C,G,H,I,J}
R2={<u>A</u>,D,E}
R3={<u>B</u>,F}
```


### *c)* 

```
R1={<u>A</u>,<u>B</u>,C}
R2={<u>A</u>,D,E}
R3={<u>B</u>,F}
R4={<u>F</u>,G,H}
R5={<u>D</u>,I,J}
```


## ​7.4
 
### *a)*

```
{A,B}
```


### *b)* 

```
R1 = {A,B,C,D,E} F = {{A,B}->{C,D,E}, {C}->{A}}
R2 = {D,E} F = {{D}->{E}}
```


### *c)* 

```
R1 = {B,C,D,E} F = {{B,C}->{D,E}}
R2 = {D,E} F = {{D}->{E}}
R3 = {C,A} F = {{C}->{A}}
```



## ​7.5
 
### *a)*

```
{A,B}
```

### *b)* 

```
R1 = {A,B,C,D,E} F = {{A,B}->{C,D,E}}
R2 = {A,C,D} F = {{A}->{C}, {C}->{D}}
```


### *c)* 

```
R1 = {A,B,C,D,E} F = {{A,B}->{C,D,E}}
R2 = {A,C} F = {{A}->{C}}
R3 = {C,D} F = {{C}->{D}}
```

### *d)* 

```
R1 = {A,B,C,D,E} F = {{A,B}->{C,D,E}}
R2 = {A,C} F = {{A}->{C}}
R3 = {C,D} F = {{C}->{D}}
```
