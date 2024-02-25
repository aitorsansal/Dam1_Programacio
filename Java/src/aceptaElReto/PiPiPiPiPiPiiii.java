package aceptaElReto;

import java.util.Scanner;

public class PiPiPiPiPiPiiii {

	public static final int TIME_FOR_DAY = 6*24;
	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String line = sc.nextLine();
		String[] splitted = line.split(" ");
		while(!line.contentEquals("0 0"))
		{
			int quantity = Integer.parseInt(splitted[1]);
			int days = Integer.parseInt(splitted[0]);
			long sec = TIME_FOR_DAY * quantity * days;
			System.out.println(TurnIntoFormat(sec));
			line = sc.nextLine();
			splitted = line.split(" ");
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
		return days + ":" + String.format("%02d",hours) + ":" +  String.format("%02d",minutes) + ":" + String.format("%02d",totalSeconds);
	}

}
