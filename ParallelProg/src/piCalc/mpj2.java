package piCalc;

import mpi .*;
 public class mpj2 {
     public static void main(String[] args) {
         int rank, size, i;
         double pi125dt = 3.141592653589793238462643; //табличное ПИ, для сравнения с результатом
         double h, sum, x;
         MPI.Init(args);
         size = MPI.COMM_WORLD.Size();
         rank = MPI.COMM_WORLD.Rank();
         int[] n = new int[1];
         double[] mypi = new double[1];
         double[] pi = new double[1];

         if (rank == 0) {
             n[0] = 100000000;
             System.out.println("Запуск вычисления на " + n[0] + " итерациях");
         }


         MPI.COMM_WORLD.Bcast(n, 0, 1, MPI.INT, 0);     // Рассылаем кол-во итераций всем потокам
         h = 1.0 / (double) n[0];
         sum = 0.0;
         for (i = rank + 1; i <= n[0]; i += size) {
             x = h * ((double) i - 0.5);
             sum += (4.0 / (1.0 + x * x));
         }
         mypi[0] = h * sum;
         MPI.COMM_WORLD.Reduce(mypi, 0, pi, 0, 1, MPI.DOUBLE, MPI.SUM, 0);
         if (rank == 0) {
             System.out.println("Табличное Пи " + pi[0]);
             System.out.println("Ошибка расчёта :" + (pi[0]/4 - pi125dt));
             System.out.println("Результат " + mypi[0]*4);
         }
         MPI.Finalize();
     }
}
