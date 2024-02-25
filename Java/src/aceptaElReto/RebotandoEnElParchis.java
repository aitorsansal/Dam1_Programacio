package aceptaElReto;

import java.util.Scanner;

public class RebotandoEnElParchis {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String linia = sc.nextLine();
		String[] sp = linia.split(" ");
		int casillas, posicion, tirada;
		while(!linia.contentEquals("0 0 0"))
		{
			casillas = Integer.parseInt(sp[0]);
			posicion = Integer.parseInt(sp[1]);
			tirada = Integer.parseInt(sp[2]);
			int afterMove = posicion + tirada;
			if(afterMove > casillas) 
			{
				int toRemove = afterMove-casillas;
				afterMove = casillas-toRemove;
			}
			System.out.println(afterMove);
			linia = sc.nextLine();
			sp = linia.split(" ");
		}
	}

}
