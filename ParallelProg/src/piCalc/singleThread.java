package piCalc;

import java.util.Random;
import java.util.Scanner;

public class singleThread {

    // Print a very basic program description

    public static void main (String[] args)
    {
        Scanner reader = new Scanner(System.in);
        System.out.println("This program approximates PI using the Monte Carlo method.");
        System.out.println("It simulates throwing darts at a dartboard.");
        System.out.print("number of throws: 10.000.000");
        int numThrows = 10_000_000;

        double PI = computePI(numThrows);

        // Determine the difference from the PI constant defined in Math
        double Difference = PI - Math.PI;

        // Print out the total results of our trials
        System.out.println (" Number of throws = " + numThrows + ", Computed PI = " + PI + ", Difference = " + Difference );
    }



    // Determine if dart thrown is inside the dart board

    public static boolean isInside (double xPos, double yPos)
    {
        double distance = Math.sqrt((xPos * xPos) + (yPos * yPos));

        return (distance < 1.0);
    }



    // Calculates PI based on the number of throws versus misses
    public static double computePI (int numThrows)
    {
        Random randomGen = new Random (System.currentTimeMillis());
        int hits = 0;
        double PI = 0;

        for (int i = 1; i <= numThrows; i++)
        {
            // Create a random coordinate result to test
            double xPos = (randomGen.nextDouble()) * 2 - 1.0;
            double yPos = (randomGen.nextDouble()) * 2 - 1.0;

            // Was the coordinate hitting the dart board?
            if (isInside(xPos, yPos))
            {
                hits++;
            }
        }

        double dthrows = numThrows;

        // Use Monte Carlo method formula
        PI = (4.0 * (hits/dthrows));

        return PI;
    }

}
