# parallelProg

Заяць Єлизавета, ТК-32

Обчислення числа Pi з застовуванням технологій MPI(mpj express) і openmp(omp4j)

У всіх варіантах використовується метод Монте-Карло, тому результат обчислень може відрізнятись.

Щоб запустити **весь** проект - необхідно використовувати OS Linux, мати встановлені пакети sbt, scala, omp4j, mpj, mpjexpress, java-sdk8(headless) або jre-8.

# Звіт

При запуску на 10 мильйонах "кидків" багатопоточні реалізації не встигають показати приросту ефективності, 

Далі спостережується очікувана перемога багатопоточних рішень

(Всі заміри проводились на 8-ми ядерному процесорі Intel Core i7 8550U)

| drows | java single | java multi | mpjExpr | omp4j |
| --- | --- | --- | --- | --- |
| 10kk | 400ms | 5000ms | 500ms  | 150ms |
| 100кк | 4300ms | 8500ms | 1000ms | 2500ms |
| 1kkk | 42500ms | 11200ms | 6600ms | 7200ms
 

# src.piCalc.calcComparator

Замір часу виконання всіх 4 вариантів обчислень

# src.piCalc.singleThread 

Обчислення з використанням одного потоку, java-core

# src.piCalc.multiThread 

Обчислення з використанням багатопоточності, java-core

# src.piCalc.mpjExpr

Обчислення з використанням технології MPI, mpj express

# src.piCalc.omp4j

Обчислення з використанням технології openmp, omp4j
