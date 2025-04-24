class Program
{  
    public static void Main()
    {
        double a , b, c;
        double a1, a2;
        double p;

        List<double> values = new List<double>();

        //f(x) = ax² + bx + c 
        double f(double x)
        {
            return a * (x * x) + b * x + c;
        }

        string? restartInput;//t lub n
        string dash = "------------------------------------------------------------------------------------------------";

        Console.WriteLine(dash);
        Console.WriteLine("Program wylicza najwieksza i najmniejsza wartosc funkcji kwadratowej w przedziale domknietym.");

        do
        {
            Console.WriteLine(dash);
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
            }while(a1 > a2);

            p = -b / (2 * a);
            
            Console.WriteLine(dash);
            Console.WriteLine("p = {0} / (2 * {1}) = {2}",-b,a,p);

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

            Console.WriteLine(dash);
            Console.WriteLine("f(a1) = f({0}) = {1}", a1, values[0]);   
            Console.WriteLine("f(a2) = f({0}) = {1}", a2, values[1]);   

            if (values.Count == 3)
            {
                Console.WriteLine("f(p) = f({0}) = {1}", p, values[2]);
            }
            
            Console.WriteLine(dash);
            Console.WriteLine("Najmniejsza wartosc: " + values.Min());
            Console.WriteLine("Największa wartosc: " + values.Max());

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
        string aStr, bStr, cStr;

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