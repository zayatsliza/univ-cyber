package piCalc;
import mpi.*;

import static jdk.nashorn.internal.objects.Global.println;

public class mpj3 {
    public static void main(String[] args) {
        int     NumIntervals    = 0;   // num intervals in the domain [0,1]
        double  IntervalWidth   = 0.0; // width of intervals
        double  IntervalLength  = 0.0; // length of intervals
        double  IntrvlMidPoint  = 0.0; // x mid point of interval
        int     Interval        = 0;   // loop counter
        int     done            = 0;   // flag
        double  MyPI            = 0.0; // storage for PI approximation results
        double  ReferencePI = 3.141592653589793238462643; // value for comparison
        double  PI;
        int MPI_MAX_PROCESSOR_NAME = 8;
        char  processor_name[] = new char[MPI_MAX_PROCESSOR_NAME ];
        char  all_proc_names[] = new char[MPI_MAX_PROCESSOR_NAME];
        int    numprocs;
        int    MyID;
        String namelen;
        int    proc = 0;
        MPI.Init(args);
        numprocs = MPI.COMM_WORLD.Size();
        MyID = MPI.COMM_WORLD.Rank();
        namelen = MPI.Get_processor_name();

        MPI.COMM_WORLD.Gather(processor_name,0,MPI_MAX_PROCESSOR_NAME,MPI.INT,all_proc_names,0,MPI_MAX_PROCESSOR_NAME ,MPI.INT,0);
        if (MyID == 0) {
            for (proc=0; proc < numprocs; ++proc)
                System.out.println("Process %d on %s\n" + proc + all_proc_names[proc]);
        }
        IntervalLength = 0.0;
        if (MyID == 0) {
            if (args.length > 1) {
                NumIntervals = atoi(args[1]);
            }else {
                NumIntervals = 100000;
            }     println("NumIntervals = %i\n", NumIntervals);   }

    }

    static int atoi(String str)
    {
        try {
            return Integer.parseInt(str);
        } catch(NumberFormatException ex) {
            return -1;
        }
    }
}
