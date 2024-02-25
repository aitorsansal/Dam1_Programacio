package aceptaElReto;

import java.util.Scanner;

public class RadaresDeTramo {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		double distance, maxVelocity, timeToFinish;
		String line = sc.nextLine();
		String[] numbersSplited = line.split(" ");
		while(!line.contentEquals("0 0 0"))
		{
			distance = Long.parseLong(numbersSplited[0])/1000.00;
			maxVelocity = Long.parseLong(numbersSplited[1]);
			timeToFinish = Long.parseLong(numbersSplited[2])/3600.00;
			if(distance <= 0 || maxVelocity <= 0 || timeToFinish <= 0)
			{
				System.out.println("ERROR");
			}
			else
			{
				double averageVelocity = distance/timeToFinish;
				if(averageVelocity > (double)maxVelocity)
				{
					double plus20 = maxVelocity * 1.20;
					System.out.println(averageVelocity > plus20 ? "PUNTOS" : "MULTA");
				}
				else
					System.out.println("OK");
			}
			line = sc.nextLine();
			numbersSplited = line.split(" ");
		}
	}

}
