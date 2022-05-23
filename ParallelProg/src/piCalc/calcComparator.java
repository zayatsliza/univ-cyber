package piCalc;

public class calcComparator {
    public static void main(String[] args) {

//        int n = 10_000_000;
        int n = 1_000_000_000;
        long start;
        long finish;
        long timeConsumedMillis;

        System.out.println("Starting single - thread java core Pi calculating");
        start = System.currentTimeMillis();
        System.out.println(singleThread.computePI(n));
        finish = System.currentTimeMillis();
        timeConsumedMillis = finish - start;
        System.out.println("finished, time consumed: " + timeConsumedMillis + " ms");


        System.out.println("Starting multi - thread java core Pi calculating");
        PiMonteCarlo PiVal = new PiMonteCarlo(10000000);
        start = System.currentTimeMillis();
        double value = PiVal.getPi();
        System.out.println(value);
        finish = System.currentTimeMillis();
        timeConsumedMillis = finish - start;
        System.out.println("finished, time consumed: " + timeConsumedMillis + " ms");


        System.out.println("Starting multithread MPI (mpj express) Pi calculating");
        start = System.currentTimeMillis();
//        System.out.println(mpjExpr.computePI(n));
        finish = System.currentTimeMillis();
        timeConsumedMillis = finish - start;
        System.out.println("finished, time consumed: " + timeConsumedMillis + " ms");


        System.out.println("Starting multithread openmp (omp4j) Pi calculating");
        start = System.currentTimeMillis();
//        System.out.println(omp4j.computePI(n));
        finish = System.currentTimeMillis();
        timeConsumedMillis = finish - start;
        System.out.println("finished, time consumed: " + timeConsumedMillis + " ms");


    }
}
