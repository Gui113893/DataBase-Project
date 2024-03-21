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
(π Fname, Minit, Lname (employee)) - ((π Fname, Minit, Lname ((employee) ⨝ Ssn = Essn (works_on))))
```


### *f)* 

```
γ Dname; avg(Salary) -> F_AvgSalary (σ Sex = 'F' ((employee) ⨝ Dno = Dnumber (department)))
```


### *g)* 

```
(employee) ⨝ (σ N_dependents > 2 (γ Fname, Minit, Lname; count(Dependent_name) -> N_dependents ((dependent) ⨝ Essn = Ssn (employee))))
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
fornecedor-(π nif,nome,fax,endereco,condpag,tipo (fornecedor ⨝ nif=fornecedor encomenda))
```

### *b)* 

```
γ nome, codigo; avg(item.unidades) -> media (item ⨝ codProd=codigo produto)
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
π nome (paciente ▷ prescricao)
```

### *b)* 

```
γ especialidade; count(numPresc) -> countPresc (medico ⨝ prescricao)
```


### *c)* 

```
γ nome; count(numPresc) -> countPresc (farmacia ⨝ prescricao)
```


### *d)* 

```
(σ numRegFarm=906 (farmaco)) - (π farmaco.numRegFarm, nome, formula ((σ numRegFarm=906 (farmaco)) ⨝ nome=nomeFarmaco ∧ farmaco.numRegFarm=presc_farmaco.numRegFarm presc_farmaco))
```

### *e)* 

```
γ farmacia.nome, farmaceutica.nome; count(nomeFarmaco) -> countFarmaco (((farmacia ⨝ nome=farmacia prescricao) ⨝ presc_farmaco) ⨝ numRegFarm=numReg farmaceutica)
```

### *f)* 

```
π nome, numUtente (σ max≠min (γ nome, numUtente; max(numMedico) -> max, min(numMedico) -> min (paciente ⨝ prescricao)))
```
