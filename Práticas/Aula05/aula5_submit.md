# BD: Guião 5


## ​Problema 5.1
 
### *a)*

```
π Pname, Fname, Minit, Lname, Ssn (σ (works_on.Essn=employee.Ssn) AND (works_on.Pno=project.Pnumber) (works_on ⨝ project ⨝ employee))
```


### *b)* 

```
π Fname, Minit, Lname (ρ manager (π Ssn (σ Fname='Carlos' ∧ Minit='D' ∧ Lname='Gomes' (employee))) ⨝ manager.Ssn=employee.Super_ssn employee)
```


### *c)* 

```
γ Pname; sum(Hours) -> Hours (project ⨝ Pnumber=Pno works_on)
```


### *d)* 

```
π Fname, Minit, Lname, Dno, Pname, Hours ((σ Pname='Aveiro Digital' (project) ⨝ σ Dno=3 (employee)) ⨝ Pnumber=Pno ∧ Ssn=Essn (σ Hours > 20 (works_on)))
```


### *e)* 

```
... Write here your answer ...
```


### *f)* 

```
... Write here your answer ...
```


### *g)* 

```
... Write here your answer ...
```


### *h)* 

```
... Write here your answer ...
```


### *i)* 

```
... Write here your answer ...
```


## ​Problema 5.2

### *a)*

```
... Write here your answer ...
```

### *b)* 

```
... Write here your answer ...
```


### *c)* 

```
... Write here your answer ...
```


### *d)* 

```
... Write here your answer ...
```


## ​Problema 5.3

### *a)*

```
... Write here your answer ...
```

### *b)* 

```
... Write here your answer ...
```


### *c)* 

```
... Write here your answer ...
```


### *d)* 

```
... Write here your answer ...
```

### *e)* 

```
... Write here your answer ...
```

### *f)* 

```
... Write here your answer ...
```
