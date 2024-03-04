using Microsoft.VisualBasic;
using System;
using System.Linq.Expressions;

namespace Fraction
{
    class Program
    {
        static void Main(string[] args)
        {


            int encerts = 0;
            Fraction fPerDefecte;
            Fraction f1;
            Fraction f2;

            #region constructors
            //CONSTRUCTOR SENSE PARÀMETRES**************************************************************************************************
            try
            {
                fPerDefecte = new Fraction();
                if (fPerDefecte.Numerator != 0 || fPerDefecte.Denominator != 1 || fPerDefecte.Sign != '-') throw new Exception("CONSTRUCTOR PER DEFECTE ERRONI");
                Console.WriteLine("CONSTRUCTOR SENSE PARÀMETRES OK!");
                encerts++;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //CONSTRUCTOR AMB PARÀMETRES****************************************************************************************************
            try
            {
                f1 = new Fraction(1, 2, '-');
                if (f1.Numerator != 1 || f1.Denominator != 2 || f1.Sign != '-') throw new Exception("CONSTRUCTOR AMB 3 PARÀMETRES ERRONI");
                encerts++;
                Console.WriteLine("CONSTRUCTOR AMB 3 PARÀMETRES OK!");
                //DENOMINADOR 0
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {
                f1 = new Fraction(1, 0, '-');
                Console.WriteLine("ERROR EN CONSTRUCTOR AMB 3 PARÀMETRES. NO ES POT CONSTRUIR FRACCIÓ AMB DENOMINADOR = 0 ");
                encerts--;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //SIGNE NI + NI -
            try
            {
                f1 = new Fraction(1, 1, '?');
                Console.WriteLine("ERROR EN CONSTRUCTOR AMB 3 PARÀMETRES. NO ES POT CONSTRUIR FRACCIÓ AMB SIGNE DIFERENT DE '+' o '-' ");
                encerts--;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //NUMERADOR NEGATIU
            try
            {
                f1 = new Fraction(-1, 1, '+');
                Console.WriteLine("ERROR EN CONSTRUCTOR AMB 3 PARÀMETRES. NO ES POT CONSTRUIR FRACCIÓ AMB NUMERADOR NEGATIU ");
                encerts--;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //DENOMINADOR NEGATIU
            try
            {
                f1 = new Fraction(1, -1, '+');
                Console.WriteLine("ERROR EN CONSTRUCTOR AMB 3 PARÀMETRES. NO ES POT CONSTRUIR FRACCIÓ AMB DENOMINADOR NEGATIU ");
                encerts--;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }




            //CONSTRUCTOR COPIA****************************************************************************************************
            try
            {
                f1 = new Fraction(5, 7, '+');
                f2 = new Fraction(f1);
                f1.Numerator = 1;
                f1.Denominator = 2;
                f1.Sign = '-';
                if (f2.Numerator != 5 || f2.Denominator != 7 || f2.Sign != '+') throw new Exception("ERROR EN CONSTRUCTOR CÒPIA");
                encerts++;
                Console.WriteLine("CONSTRUCTOR CÒPIA OK!");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            #endregion

            #region propietats

            //PROPIETAT Numerator****************************************************************************************************
            f1 = new Fraction(5, 2, '+');
            try
            {
                f1.Numerator = 1;
                if (f1.Numerator != 1) throw new Exception("ERROR EN LA PROPIETAT Numerator");
                encerts++;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //NUMERADOR NEGATIU
            try
            {
                f1.Numerator = -1;
                Console.WriteLine("ERROR EN LA PROPIETAT Numerator: NO ES POT ASSIGNAR UN NUMERADOR NEGATIU");
                encerts--;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //PROPIETAT Denominator****************************************************************************************************
            try
            {
                f1.Denominator = 19;
                if (f1.Denominator != 19) throw new Exception("ERROR EN LA PROPIETAT Denominator");
                encerts++;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //DENOMINADOR NEGATIU
            try
            {
                f1.Denominator = -1;
                Console.WriteLine("ERROR EN LA PROPIETAT Denominator: NO ES POT ASSIGNAR UN DENOMINADOR NEGATIU");
                encerts--;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //DENOMINADOR 0
            try
            {
                f1.Denominator = 0;
                Console.WriteLine("ERROR EN LA PROPIETAT Denominator: NO ES POT ASSIGNAR UN DENOMINADOR =0");
                encerts--;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            //PROPIETAT Sign****************************************************************************************************
            try
            {
                f1.Sign = '-';
                encerts++;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            try
            {
                f1.Sign = '*';
                Console.WriteLine("ERROR EN LA PROPIETAT Sign: NO ES POT ASSIGNAR UN SIGNE DIFERENT DE '+' o '-'");
                encerts--;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            //PROPIETAT RealValue****************************************************************************************************
            try
            {
                f1 = new Fraction(1, 2, '+');
                if (f1.RealValue != 0.5) throw new Exception("Real Value Erroni");
                f1.Sign = '-';
                if (f1.RealValue != -0.5) throw new Exception("Real Value Erroni");
                Console.WriteLine("PROPIETAT RealValue OK!");
                encerts++;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            #endregion

            #region metodes d'instancia

            f1 = new Fraction(72, 48, '+');
            // MÈTODE Simplify ******************************************************
            try
            {
                f1.Simplify();
                if (f1.Numerator != 3 && f1.Denominator != 2) throw new Exception("ERROR MÈTODE Simplify");
                Console.WriteLine("SIMPLIFIACIÓ DE FRACCIONS OK!");
                encerts++;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            // MÈTODE Add **************************************************************
            f1 = new Fraction(7, 2, '+');
            f2 = new Fraction(6, 4, '+');
            f1.Add(f2);
            try
            {
                if (f1.Numerator != 5 || f1.Denominator != 1 || f1.Sign != '+' || f2.Numerator != 6 || f2.Denominator != 4 || f2.Sign != '+')
                    throw new Exception("ERROR EN LA SUMA AMB DOS SUMANDS POSITIUS");
                Console.WriteLine("SUMA FRACCIONS AMB DOS SUMANDS POSITIUS OK!");
                encerts++;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message + "\n"); }
            f1 = new Fraction(7, 2, '-');
            f2 = new Fraction(6, 4, '-');
            f1.Add(f2);
            try
            {
                if (f1.Numerator != 5 || f1.Denominator != 1 || f1.Sign != '-' || f2.Numerator != 6 || f2.Denominator != 4 || f2.Sign != '-')
                    throw new Exception("ERROR EN LA SUMA AMB DOS SUMANDS NEGATIUS");
                Console.WriteLine("SUMA FRACCIONS AMB DOS SUMANDS NEGATIUS OK!");
                encerts++;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message + "\n"); }
            f1 = new Fraction(7, 2, '+');
            f2 = new Fraction(6, 4, '-');
            f1.Add(f2);
            try
            {
                if (f1.Numerator != 2 || f1.Denominator != 1 || f1.Sign != '+' || f2.Numerator != 6 || f2.Denominator != 4 || f2.Sign != '-')
                    throw new Exception("ERROR EN LA SUMA  7/2 - 6/4");
                Console.WriteLine("SUMA FRACCIONS 7/2 - 6/4   OK!");
                encerts++;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message + "\n"); }
            f1 = new Fraction(6, 4, '+');
            f2 = new Fraction(7, 2, '-');
            f1.Add(f2);
            try
            {
                if (f1.Numerator != 2 || f1.Denominator != 1 || f1.Sign != '-' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '-')
                    throw new Exception("ERROR EN LA SUMA 6/4 - 7/2");
                Console.WriteLine("SUMA FRACCIONS 6/4 - 7/2   OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }

            // MÈTODE Multiply **************************************************************
            f1 = new Fraction(6, 4, '+');
            f2 = new Fraction(7, 2, '+');
            f1.Multiply(f2);
            try
            {
                if (f1.Numerator != 21 || f1.Denominator != 4 || f1.Sign != '+' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '+')
                    throw new Exception("ERROR EN EL PRODUCTE  + * +");
                Console.WriteLine("PRODUCTE  + * + OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            f1 = new Fraction(6, 4, '-');
            f2 = new Fraction(7, 2, '-');
            f1.Multiply(f2);
            try
            {
                if (f1.Numerator != 21 || f1.Denominator != 4 || f1.Sign != '+' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '-')
                    throw new Exception("ERROR EN EL PRODUCTE  - * -");
                Console.WriteLine("PRODUCTE  - * - OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            f1 = new Fraction(6, 4, '-');
            f2 = new Fraction(7, 2, '+');
            f1.Multiply(f2);
            try
            {
                if (f1.Numerator != 21 || f1.Denominator != 4 || f1.Sign != '-' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '+')
                    throw new Exception("ERROR EN EL PRODUCTE  - * -");
                Console.WriteLine("PRODUCTE  - * + OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            //// MÈTODE Divide **************************************************************

            f1 = new Fraction(6, 4, '+');
            f2 = new Fraction(7, 2, '+');
            f1.Divide(f2);
            try
            {
                if (f1.Numerator != 3 || f1.Denominator != 7 || f1.Sign != '+' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '+')
                    throw new Exception("ERROR EN LA DIVISIÓ + /+");
                Console.WriteLine("DIVISIO  + / + OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            f1 = new Fraction(6, 4, '-');
            f2 = new Fraction(7, 2, '-');
            f1.Divide(f2);
            try
            {
                if (f1.Numerator != 3 || f1.Denominator != 7 || f1.Sign != '+' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '-')
                    throw new Exception("ERROR EN LA DIVISIÓ - /-");
                Console.WriteLine("DIVISIO  - / - OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            f1 = new Fraction(6, 4, '+');
            f2 = new Fraction(7, 2, '-');
            f1.Divide(f2);
            try
            {
                if (f1.Numerator != 3|| f1.Denominator != 7 || f1.Sign != '-' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '-')
                    throw new Exception("ERROR EN LA DIVISIÓ + /-");
                Console.WriteLine("DIVISIO  + / - OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            #endregion

            #region metodes static

            // MÈTODE Equivalents ******************************************************
            f1 = new Fraction(234, 146, '+');
            
            f2 = new Fraction(936, 584, '+');
            if (Fraction.Equivalents(f1,f2) && f1.Numerator==234 && f1.Denominator==146 && f1.Sign=='+' && f2.Numerator == 936 && f2.Denominator == 584 && f2.Sign == '+')
            {
                encerts++;
                Console.WriteLine("FRACCIONS EQUIVALENTS OK");
            }
            f1 = new Fraction(234, 146, '+');
            f2 = new Fraction(936, 584, '-');
            if (!Fraction.Equivalents(f1, f2) && f1.Numerator == 234 && f1.Denominator == 146 && f1.Sign == '+' && f2.Numerator == 936 && f2.Denominator == 584 && f2.Sign == '-')
            {
                encerts++;
                Console.WriteLine("FRACCIONS EQUIVALENTS OK");
            }
            // MÈTODE Add Static******************************************************
            f1 = new Fraction(7, 2, '+');
            f2 = new Fraction(6, 4, '+');
            Fraction f3=Fraction.Add(f1,f2);
            try
            {
                if (f3.Numerator != 5 || f3.Denominator != 1 || f3.Sign != '+' || f2.Numerator != 6 || f2.Denominator != 4 || f2.Sign != '+' || f1.Numerator != 7 || f1.Denominator != 2 || f2.Sign != '+')
                    throw new Exception("ERROR EN LA SUMA ESTATICA AMB DOS SUMANDS POSITIUS");
                Console.WriteLine("SUMA FRACCIONS ESTATICA AMB DOS SUMANDS POSITIUS OK!");
                encerts++;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message + "\n"); }
            f1 = new Fraction(7, 2, '-');
            f2 = new Fraction(6, 4, '-');

            f3 =Fraction.Add(f1,f2);
            try
            {
                if (f3.Numerator != 5 || f3.Denominator != 1 || f3.Sign != '-' || f2.Numerator != 6 || f2.Denominator != 4 || f2.Sign != '-' || f1.Numerator != 7 || f1.Denominator != 2 || f2.Sign != '-')
                    throw new Exception("ERROR EN LA SUMA ESTATICA AMB DOS SUMANDS NEGATIUS");
                Console.WriteLine("SUMA FRACCIONS ESTATICA AMB DOS SUMANDS NEGATIUS OK!");
                encerts++;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message + "\n"); }
            f1 = new Fraction(7, 2, '+');
            f2 = new Fraction(6, 4, '-');
            f3 = Fraction.Add(f1, f2);
            try
            {
                if (f3.Numerator != 2 || f3.Denominator != 1 || f3.Sign != '+' || f2.Numerator != 6 || f2.Denominator != 4 || f2.Sign != '-' || f1.Numerator != 7 || f1.Denominator != 2 || f1.Sign != '+')
                    throw new Exception("ERROR EN LA SUMA ESTATICA  7/2 - 6/4");
                Console.WriteLine("SUMA FRACCION ESTATICA   7/2 - 6/4   OK!");
                encerts++;
            }

            catch (Exception ex) { Console.WriteLine(ex.Message + "\n"); }
            f1 = new Fraction(6, 4, '+');
            f2 = new Fraction(7, 2, '-');
            f3 = Fraction.Add(f1, f2);
            try
            {
                if (f3.Numerator != 2 || f3.Denominator != 1 || f3.Sign != '-' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '-' || f1.Numerator != 6 || f1.Denominator != 4 || f1.Sign != '+')
                    throw new Exception("ERROR EN LA SUMA ESTATICA 6/4 - 7/2");
                Console.WriteLine("SUMA FRACCIONS ESTATICA 6/4 - 7/2   OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            // MÈTODE Multiply STATIC **************************************************************
            f1 = new Fraction(6, 4, '+');
            f2 = new Fraction(7, 2, '+');
            f3 = Fraction.Multiply(f1, f2);
            try
            {
                if (f3.Numerator != 21 || f3.Denominator != 4 || f3.Sign != '+' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '+' || f1.Numerator != 6 || f1.Denominator != 4 || f1.Sign != '+')
                    throw new Exception("ERROR EN EL PRODUCTE STATIC  + * +");
                Console.WriteLine("PRODUCTE STATIC  + * + OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            f1 = new Fraction(6, 4, '-');
            f2 = new Fraction(7, 2, '-');
            f3 = Fraction.Multiply(f1, f2);
            try
            {
                if (f3.Numerator != 21 || f3.Denominator != 4 || f3.Sign != '+' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '-' || f1.Numerator != 6 || f1.Denominator != 4 || f1.Sign != '-')
                    throw new Exception("ERROR EN EL PRODUCTE STATIC - * -");
                Console.WriteLine("PRODUCTE  STATIC - * - OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            f1 = new Fraction(6, 4, '-');
            f2 = new Fraction(7, 2, '+');
            f3 = Fraction.Multiply(f1, f2);
            try
            {
                if (f3.Numerator != 21 || f3.Denominator != 4 || f3.Sign != '-' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '+' || f1.Numerator != 6 || f1.Denominator != 4 || f1.Sign != '-')
                    throw new Exception("ERROR EN EL PRODUCTE  STATIC - * +");
                Console.WriteLine("PRODUCTE STATIC  - * + OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }

            // MÈTODE Divide STATIC **************************************************************
            f1 = new Fraction(6, 4, '+');
            f2 = new Fraction(7, 2, '+');
            f3 = Fraction.Divide(f1, f2);
            try
            {
                if (f3.Numerator != 3 || f3.Denominator != 7 || f3.Sign != '+' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '+' || f1.Numerator != 6 || f1.Denominator != 4 || f1.Sign != '+')
                    throw new Exception("ERROR EN LA DIVISIÓ STATICA + /+");
                Console.WriteLine("DIVISIO  STATICA + / + OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            f1 = new Fraction(6, 4, '-');
            f2 = new Fraction(7, 2, '-');
            f3 = Fraction.Divide(f1, f2);
            try
            {
                if (f3.Numerator != 3 || f3.Denominator != 7 || f3.Sign != '+' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '-' || f1.Numerator != 6 || f1.Denominator != 4 || f1.Sign != '-')
                    throw new Exception("ERROR EN LA DIVISIÓ STATICA - /-");
                Console.WriteLine("DIVISIO STATICA  - / - OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            f1 = new Fraction(6, 4, '+');
            f2 = new Fraction(7, 2, '-');
            f3 = Fraction.Divide(f1, f2);
            try
            {
                if (f3.Numerator != 3 || f3.Denominator != 7 || f3.Sign != '-' || f2.Numerator != 7 || f2.Denominator != 2 || f2.Sign != '-' || f1.Numerator != 6 || f1.Denominator != 4 || f1.Sign != '+')
                    throw new Exception("ERROR EN LA DIVISIÓ STATICA + /-");
                Console.WriteLine("DIVISIO STATICA  + / - OK!");
                encerts++;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            #endregion
            #region operadors explicits i implicits
            // Conversio implicita de int a Fraction
            Fraction f = -7;
            try { 
            if (f.Numerator != 7 || f.Denominator != 1 || f.Sign != '-') throw new Exception("ERROR EN CONVERSIO IMPLICITA Fraction <- int");
                f = 7;
                if (f.Numerator != 7 || f.Denominator != 1 || f.Sign != '+') throw new Exception("ERROR EN CONVERSIO IMPLICITA Fraction <- int");
                Console.WriteLine("CONVERSIO IMPLICITA Fraction < -int OK!");
                encerts++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            f = new Fraction(21,5,'-');
            double fReal = (double)f;
            try
            {
                if (fReal!=-4.2) throw new Exception("ERROR EN CONVERSIO EXPLICITA double <- Fraction");
               
                Console.WriteLine("CONVERSIO EXPLICITA double < -Fraction OK!");
                encerts++;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n");

            }
            #endregion

            #region override
            int encertsToString = 0;
            Fraction fPrimera = new Fraction(1, 1, '+');
            Fraction fSegona = new Fraction(1, 1, '-');
            Fraction fTercera = new Fraction(0, 5, '-');
            Fraction fQuarta = new Fraction(0, 5, '+');
            Fraction fCinquena = new Fraction(24, 2, '+');
            Fraction fSisena = new Fraction(12, 7, '+');
            if (fPrimera.ToString() == "1") encertsToString++;
            if (fSegona.ToString() == "(-1)") encertsToString++;
            if (fTercera.ToString() == "0") encertsToString++;
            if (fQuarta.ToString() == "0") encertsToString++;
            if (fCinquena.ToString() == "12") encertsToString++;
            if (fSisena.ToString() == "12/7") encertsToString++;
            encerts=encerts+encertsToString/2;
            #endregion



            Console.WriteLine($"ENCERTS={encerts}");
            }
        }
    }

