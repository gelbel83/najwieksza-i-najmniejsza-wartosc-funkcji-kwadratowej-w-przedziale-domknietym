class Program
{  
    public static void Main()
    {
        double a , b, c;//współczynniki funkcji
        double a1, a2;//argumenty ciagu 
        double p;//argument wierzcholka

        List<double> values = new List<double>();//wartosci z ktorych program wybiera najmiejsza i najwieksza(f(a1) i f(a2) i ewentualnie q)

        //f(x) = ax² + bx + c 
        double f(double x)
        {
            return a * (x * x) + b * x + c;
        }

        string restartInput;//t lub n
        string dash = "------------------------------------------------------------------------------------------------";

        Console.WriteLine(dash);
        Console.WriteLine("Program wylicza najwieksza i najmniejsza wartosc funkcji kwadratowej w przedziale domknietym.");

        do
        {
            Console.WriteLine(dash);
            //TryParse - zwraca false jesli nie mozna przekonwertowac, a jesli sie da normalnie zapisuej wartosc
            do
            {
                Console.Write("Wprowadz a: ");
            } while(!double.TryParse(Console.ReadLine(), out a) || a == 0);

            do
            {
                Console.Write("Wprowadz b: ");
            } while(!double.TryParse(Console.ReadLine(), out b));

            do
            {
                Console.Write("Wprowadz c: ");
            } while(!double.TryParse(Console.ReadLine(), out c));

            //wypisac wzor funkcji kwadratowej
            Console.WriteLine(dash);
            PrintFunction(a,b,c);

            
            do
            {
                Console.WriteLine(dash);
                do
                {
                    Console.Write("Wprowadz poczatek przedzialu domknietego(a1): ");
                } while(!double.TryParse(Console.ReadLine(), out a1));

                do
                {
                    Console.Write("Wprowadz koniec przedzialu domknietego(a2): ");
                } while(!double.TryParse(Console.ReadLine(), out a2));

                if(a1 > a2)
                {
                    Console.WriteLine(dash);
                    Console.WriteLine("Koniec przedzialu nie moze byc wiekszy niz jego poczatek!");
                }
            }while(a1 > a2);//poczatek przedzialu musi byc zawsze mniejszy od konca

            //obliczyc p
            p = -b / (2 * a);
            
            Console.WriteLine(dash);
            //wypisac p
            Console.WriteLine("p = {0} / (2 * {1}) = {2}",-b,a,p);

            //dodać f(a1) i f(a2) ponieważ beda porównywanymi wartosciami w obu przypadkach
            values.Add(f(a1));
            values.Add(f(a2));

            //jesli p ∈ [a1,a2] -> dodać q = f(p)
            if (p >= a1 && p <= a2)
            {
                Console.WriteLine("p nalezy do [{0},{1}]",a1,a2);
                values.Add(f(p));         
            }
            else
            {
                Console.WriteLine("p nie nalezy do [{0},{1}]",a1,a2);
            }

            //wypisać wartosci
            Console.WriteLine(dash);
            //używam values[0] i values[1] zamiast kolejnego wywołania funkcji f() ponieważ już ją komputer wyliczyl i zapisał w liscie
            Console.WriteLine("f(a1) = f({0}) = {1}", a1, values[0]);   
            Console.WriteLine("f(a2) = f({0}) = {1}", a2, values[1]);   

            if (values.Count == 3)
            {
                Console.WriteLine("f(p) = f({0}) = {1}", p, values[2]);
            }
            
            //wypisac najmniejsza i najwieksza wartosc
            Console.WriteLine(dash);
            Console.WriteLine("Najmniejsza wartosc: " + values.Min());
            Console.WriteLine("Największa wartosc: " + values.Max());

            //zapytac uzytkownika czy chce jeszcze raz
            Console.WriteLine(dash);
            do
            {
                Console.Write("Czy chcesz wyliczyc wartosci jeszcze raz?(t/n): ");
                restartInput = Console.ReadLine();
            }while(restartInput != "t" && restartInput != "n");

            values.Clear();
        } while(restartInput == "t");
    }

    //Funkcja do wypisania wzoru funkcji kwadratowej aby użytkownik mógł sie upewnić że dobrze wpisał wartosci a, b i c
    static void PrintFunction(double a, double b, double c)
    {
        string aStr, bStr, cStr;//współczynniki funkcji jako ciągi znaków

        //-1x² -> -x² i 1x² -> x²
        if(a == -1)
        {
            aStr = "-x^2 ";
        }
        else if(a == 1)
        {
            aStr = "x^2 ";
        }
        else
        {
            aStr = a.ToString() + "x^2 ";
        }

        //np. '-5' -> '- 5x' albo '6' -> '+ 6x' albo 0 -> ''
        if(b < 0)
        {
            if(b == -1)
            {
                bStr = "- x ";
            }
            
            else
            {
                bStr = "- " + (-b).ToString() + "x ";
            }   
        }
        else if(b == 0)
        {
            bStr = "";
        }
        else if(b == 1)
        {
            bStr = "+ x ";
        }
        else
        {
            bStr = "+ " + b.ToString() + "x ";
        }

        //np. '-2' -> '- 2' albo '9' -> '+ 9' albo 0 -> ''
        if(c < 0)
        {
            cStr = "- " + (-c).ToString();
        }
        else if(c == 0)
        {
            cStr = "";
        }
        else
        {
            cStr = "+ " + c.ToString();
        }

        Console.WriteLine("f(x) = " + aStr + bStr + cStr);
    }
}