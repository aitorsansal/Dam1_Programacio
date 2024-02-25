package aceptaElReto;

import java.util.Scanner;

public class MundoLimpio {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int loops = Integer.parseInt(sc.nextLine());
		String line, time;
		int timesCleaned;
		long timeInSeconds;
		for (int i = 0; i < loops; i++)
		{
			line = sc.nextLine();
			String[] sp = line.split(" ");
			timesCleaned = Integer.parseInt(sp[0]);
			String[] splitedTime = sp[1].split(":");
			timeInSeconds = Integer.parseInt(splitedTime[0]) * 3600 + 
					Integer.parseInt(splitedTime[1])*60 + 
					Integer.parseInt(splitedTime[2]);
			long timeClean = timesCleaned * timeInSeconds;
			System.out.println(TurnIntoFormat(timeClean));			
		}

	}
	
	static private String TurnIntoFormat(long totalSeconds)
	{
		int days, hours, minutes;
		hours = (int)Math.ceil(totalSeconds / 3600);
		days = (int)Math.ceil(hours / 24);
		hours %= 24;
		totalSeconds %= 3600;
		minutes = (int)Math.ceil(totalSeconds/60);
		totalSeconds %= 60;
		return days + " " + String.format("%02d",hours )+ ":" +  String.format("%02d",minutes) + ":" + String.format("%02d",totalSeconds);
	}

}
