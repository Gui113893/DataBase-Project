# BD: Guião 3


## ​Problema 3.1
 
### *a)*

```
VEICULO(matricula, marca, ano)
TIPO_VEICULO(designacao, arcondicionado, codigo)
LIGEIRO(codigo, numlugares, portas, combustivel)
PESADO(codigo, peso, passageiros)    
SIMILARIDADE(cod_veiculo1, cod_veiculo2)
```


### *b)* 

```
Chaves Candidatas:
    VEICULO: {matricula}
    TIPO_VEICULO: {codigo}
    LIGEIRO: {codigo}
    PESADO: {codigo}
    SIMILARIDADE: {cod_veiculo1, cod_veiculo2}

Chaves Primárias:
    VEICULO: {matricula}
    TIPO_VEICULO: {codigo}
    LIGEIRO: {codigo}
    PESADO: {codigo}
    SIMILARIDADE: {cod_veiculo1, cod_veiculo2}

Chaves Estrangeiras:
    LIGEIRO: {codigo}
    PESADO: {codigo}
    SIMILARIDADE: {cod_veiculo1, cod_veiculo2}
```


### *c)* 

![ex_3_1c!](ex_3_1c.jpg "AnImage")


## ​Problema 3.2

### *a)*

```
... Write here your answer ...
```


### *b)* 

```
... Write here your answer ...
```


### *c)* 

![ex_3_2c!](ex_3_2c.jpg "AnImage")


## ​Problema 3.3


### *a)* 2.1

![ex_3_3_a!](ex_3_3a.jpg "AnImage")

### *b)* 2.2

![ex_3_3_b!](ex_3_3b.jpg "AnImage")

### *c)* 2.3

![ex_3_3_c!](ex_3_3c.jpg "AnImage")

### *d)* 2.4

![ex_3_3_d!](ex_3_3d.jpg "AnImage")