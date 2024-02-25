package aceptaElReto;

import java.util.Scanner;

public class Tarta_Sacher {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int loops = Integer.parseInt(sc.nextLine());
		double height, width, necessary;
		String line;
		for	(int i = 0; i < loops; i++)
		{
			line = sc.nextLine();
			String[] splitted = line.split(" ");
			width = Double.parseDouble(splitted[0]);
			height = Double.parseDouble(splitted[1]);
			necessary = Double.parseDouble(splitted[2]);
			double totalInChocolate = width * height;
			double numberOfChocolates = Math.ceil(necessary / totalInChocolate);
			System.out.println((int)numberOfChocolates);
		}

	}

}
