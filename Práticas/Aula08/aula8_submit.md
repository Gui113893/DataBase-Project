# BD: Guião 8


## ​8.1. Complete a seguinte tabela.
Complete the following table.

| #    | Query                                                                                                      | Rows  | Cost  | Pag. Reads | Time (ms) | Index used | Index Op.            | Discussion |
| :--- | :--------------------------------------------------------------------------------------------------------- | :---- | :---- | :--------- | :-------- | :--------- | :------------------- | :--------- |
| 1    | SELECT * from Production.WorkOrder                                                                         | 72591 | 0.474 | 552        | 322       | WorkOrderID          | Clustered Index Scan |            |
| 2    | SELECT * from Production.WorkOrder where WorkOrderID=1234                                                  | 1     | 0.003 | 216        | 24        | WorkOrderID          | Clustered Index Seek |            |
| 3.1  | SELECT * FROM Production.WorkOrder WHERE WorkOrderID between 10000 and 10010                               | 11    | 0.003 | 216        | 37        | WorkOrderID          | Clustered Index Seek |            |
| 3.2  | SELECT * FROM Production.WorkOrder WHERE WorkOrderID between 1 and 72591                                   | 72591 | 0.474 | 744        | 338       | WorkOrderID          | Clustered Index Seek |            |
| 4    | SELECT * FROM Production.WorkOrder WHERE StartDate = '2012-05-14'                                          | 72591 | 0.474 | 618       | 198        | WorkOrderID          | Clustered Index Scan |            |
| 5    | SELECT * FROM Production.WorkOrder WHERE ProductID = 757                                                   | 72591 | 0.474 | 748        | 60        | ProductID            | Clustered Index Scan |            |
| 6.1  | SELECT WorkOrderID, StartDate FROM Production.WorkOrder WHERE ProductID = 757                              |   9   | 0.003 |   44       |  46       |  ProductID Covered (StartDate)  | Index Seek Non Clustered|  |
| 6.2  | SELECT WorkOrderID, StartDate FROM Production.WorkOrder WHERE ProductID = 945                              |  72591|  0.474| 554        |  72       |  ProductID Covered (StartDate)  |Clustered Index Scan| |
| 6.3  | SELECT WorkOrderID FROM Production.WorkOrder WHERE ProductID = 945 AND StartDate = '2011-12-04'            |  72591|  0.474| 556        |  21       |  ProductID Covered (StartDate)  |Clustered Index Scan| |
| 7    | SELECT WorkOrderID, StartDate FROM Production.WorkOrder WHERE ProductID = 945 AND StartDate = '2011-12-04' |  72591| 0.474 | 556        |  29       |  ProductID and StartDate        |Clustered Index Scan|  |
| 8    | SELECT WorkOrderID, StartDate FROM Production.WorkOrder WHERE ProductID = 945 AND StartDate = '2011-12-04' |  72591| 0.474 | 812        |  32       |  Composite (ProductID, StartDate)|Clustered Index Scan| |

## ​8.2.

### a)

```
CREATE TABLE mytemp (
    rid BIGINT PRIMARY KEY CLUSTERED,
    at1 INT NULL,
    at2 INT NULL,
    at3 INT NULL,
    lixo VARCHAR(100) NULL
);
```

### b)

```
Tempo de introdução: 42 segundos
Codigo para a percentagem:
SELECT * from  sys.dm_db_index_physical_stats(db_id(), object_id('mytemp'), NULL, NULL, 'DETAILED');
Percentagem de fragmentação: 99.10%
Percentagem de uso da página: 68.70%
```

### c)

```
ALTER TABLE mytemp ADD CONSTRAINT mPK
    PRIMARY KEY CLUSTERED (rid)
    WITH (fillfactor=90, pad_Index=ON);

fillfacotr=65 - 39.0s
fillfactor=80 - 39.1s
fillfactor=90 - 39.5s
```

### d)

```
CREATE TABLE mytemp (
    rid BIGINT IDENTITY(1,1) PRIMARY KEY,
    at1 INT NULL,
    at2 INT NULL,
    at3 INT NULL,
    lixo VARCHAR(100) NULL
);
SET IDENTITY_INSERT mytemp ON;

time: 44.8s
```

### e)

```
CREATE INDEX idx_at1 ON mytemp(at1);
CREATE INDEX idx_at2 ON mytemp(at2);
CREATE INDEX idx_at3 ON mytemp(at3);
CREATE INDEX idx_lixo ON mytemp(lixo);

Com indexes: 49.0s
Sem indexes : 42.5s
```

## ​8.3.

```
 1. (O index é criado automaticamente por ser primary key)
 2. CREATE INDEX IxEmployeeName ON Employee(Fname, Lname);
 3. CREATE INDEX IxEmployeeWorksDept ON Employee(Dno);
 4. CREATE INDEX IxEmployeeWorksOn ON Works_On(Essn, Pno);
 5. (O index é criado automaticamente por ser primary key)
 6. CREATE INDEX IxProjectDept ON Project(Dnum);
```
