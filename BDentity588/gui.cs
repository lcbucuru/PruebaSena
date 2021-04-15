using System;

namespace BDentity588
{

    class gui
    {
        public static void Marco(int Xmin, int Xmax, int Ymin, int Ymax)
        {
            for (int x = Xmin; x <= Xmax; x++)
            {
                Console.SetCursorPosition(x, Ymin); Console.Write("═");
                Console.SetCursorPosition(x, Ymax); Console.Write("═");
            }

            for (int y = Ymin; y <= Ymax; y++)
            {
                Console.SetCursorPosition(Xmin, y); Console.Write("║");
                Console.SetCursorPosition(Xmax, y); Console.Write("║");
            }

            Console.SetCursorPosition(Xmin, Ymin); Console.Write("╔");
            Console.SetCursorPosition(Xmax, Ymin); Console.Write("╗");
            Console.SetCursorPosition(Xmin, Ymax); Console.Write("╚");
            Console.SetCursorPosition(Xmax, Ymax); Console.Write("╝");

        }

        public static void Linea(int Xmin, int Xmax, int y)
        {
            for (int x = Xmin; x <= Xmax; x++)
            {
                Console.SetCursorPosition(x, y); Console.Write("-");

            }

        }

        public static void BorrarLinea(int Xmin, int y, int Xmax)
        {
            for (int x = Xmin; x <= Xmax; x++)
            {
                Console.SetCursorPosition(x, y); Console.Write(" ");

            }
        }
        public static void Borrarlogo()
        {
           BorrarLinea(10, 24,56);
           BorrarLinea(10, 25, 56);
           BorrarLinea(10, 26, 56);
           BorrarLinea(10, 27, 56);
           BorrarLinea(10, 28, 100);
        }



        public static void logo(int x, int y)
        {
            Console.SetCursorPosition(10,24);Console.WriteLine(@"  ___  ____   _  _    __ ");
            Console.SetCursorPosition(10,25);Console.WriteLine(@" / __)( ___) ( \( )  /__\");
            Console.SetCursorPosition(10,26);Console.WriteLine(@" \__ \ )__)   )  (  /(__)\ ");
            Console.SetCursorPosition(10,27);Console.WriteLine(@" (___/(____) (_)\_)(__)(__) ");
            Console.SetCursorPosition(10,28); Console.WriteLine(@"Centro de Mercados, Logista y Tecnologia de la Información");
        }
         
    }
}






