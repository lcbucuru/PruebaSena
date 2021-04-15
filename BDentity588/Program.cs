using BDentity588.Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BDentity588
{
    class Program

    {
        static Validaciones verificar = new Validaciones();
        static List<Estudiantes> ListaEstudiantes = new List<Estudiantes>();
        static void Main(string[] args)
        {


            int Menu = 0;
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            do
            {
                Console.Clear();
                
                Console.SetCursorPosition(50, 16); Console.Write("BIENVENIDOS");
                gui.Marco(1, 115, 1, 6);
                gui.Marco(1, 115, 7, 30);
                Console.SetCursorPosition(6, 2); Console.Write("APP ESTUDIANTE");
                Console.SetCursorPosition(6, 4); Console.Write("1.Crear ");
                Console.SetCursorPosition(20, 4); Console.Write("2.Listar ");
                Console.SetCursorPosition(38, 4); Console.Write("3.Buscar ");
                Console.SetCursorPosition(54, 4); Console.Write("4.Editar ");
                Console.SetCursorPosition(70, 4); Console.Write("5.Eliminar ");
                Console.SetCursorPosition(88, 4); Console.Write("0.Salir ");
                Console.SetCursorPosition(88, 2); Console.Write("Escoga opción:");

                Menu = int.Parse(Console.ReadLine());

                switch (Menu)
                {
                    case 1:
                        CrearRegistro();
                        break;
                    case 2:
                        ListaRegistros();
                        break;
                    case 3:
                        BuscarRegistro();
                        break;
                    case 4:
                        EditarRegistro();
                        break;
                    case 5:
                        EliminarRegistro();
                        break;
                    case 0:
                        Console.SetCursorPosition(38,18); Console.Write("Gracias por utilizar nuestra plataforma ");
                        break;
                    default:
                        Console.WriteLine("Opción no valida");
                        break;
                        
                }
                Console.WriteLine();
                Console.SetCursorPosition(20,22);Console.Write("Presione cualquier tecla para continuar ... ");
                gui.Borrarlogo();
                gui.BorrarLinea(40, 16, 70);
                Console.ReadKey();
                
            } while (Menu > 0);


        }

        static void CrearRegistro()
        {
            gui.Borrarlogo();
            double no1, no2, no3;
            string nom, cor;
            int cod;
            string codTxt, no1Txt, no2Txt, no3Txt;
            bool EntradaValidaNombre = false;
            bool EntradaValidaCodigo = false;
            bool EntradaValidaCorreo = false;
            bool EntradaValidaNot1 = false;
            bool EntradaValidaNot2 = false;
            bool EntradaValidaNot3 = false;


            gui.BorrarLinea(20, 16, 22);
            
            do
            {

                Console.SetCursorPosition(30, 9); Console.Write("Digite Codigo Estudiante : ");
                codTxt = Console.ReadLine();
                if (!verificar.Vacio(codTxt))
                    if (verificar.TipoNumero(codTxt))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (!sabersiexiste(Int32.Parse(codTxt)))
            {
                do
                {

                    Console.SetCursorPosition(30, 10); Console.Write("Digite Nombre Estudiante:");
                    nom = Console.ReadLine();
                    if (!verificar.Vacio(nom))
                        if (verificar.TipoTexto(nom))
                            EntradaValidaNombre = true;
                } while (!EntradaValidaNombre);
                do
                {

                    Console.SetCursorPosition(30, 11); Console.Write("Digite Correo Estudiante: ");
                    cor = Console.ReadLine();
                    if (!verificar.Vacio(cor))
                        if (verificar.TipoCorreo(cor))
                            EntradaValidaCorreo = true;
                } while (!EntradaValidaCorreo);

                do
                {

                    Console.SetCursorPosition(30, 12); Console.Write("Digite Nota 1: ");
                    Console.SetCursorPosition(55, 12); no1Txt = Console.ReadLine();
                    if (!verificar.Vacio(no1Txt))
                        if (verificar.TipoNumero(no1Txt))
                            EntradaValidaNot1 = true;
                } while (!EntradaValidaNot1);

                do
                {

                    Console.SetCursorPosition(30, 13); Console.Write("Digite Nota 2: ");
                    Console.SetCursorPosition(55, 13); no2Txt = Console.ReadLine();
                    if (!verificar.Vacio(no2Txt))
                        if (verificar.TipoNumero(no2Txt))
                            EntradaValidaNot2 = true;
                } while (!EntradaValidaNot2);

                do
                {

                    Console.SetCursorPosition(30, 14); Console.Write("Digite Nota 3: ");
                    Console.SetCursorPosition(55, 14); no3Txt = Console.ReadLine();
                    if (!verificar.Vacio(no3Txt))
                        if (verificar.TipoNumero(no3Txt))
                            EntradaValidaNot3 = true;
                } while (!EntradaValidaNot3);

                var db = new tallersena588Context();
                Estudiantes estudiante = new Estudiantes
                {
                    Codigo = Convert.ToUInt32(codTxt),
                    Nombre = nom,
                    Correo = cor,
                    Nota1 = double.Parse(no1Txt),
                    Nota2 = double.Parse(no2Txt),
                    Nota3 = double.Parse(no3Txt)
                };
                db.Estudiantes.Add(estudiante);
                db.SaveChanges();
                Console.SetCursorPosition(40, 23); Console.Write("Registro agregado correctamente");
            }
            else
            {
                Console.SetCursorPosition(40, 23); Console.Write("El registro ya existe");
            }
        }
        static void ListaRegistros()
        {
            gui.Borrarlogo();
            // Consulta a una tabla de Mysql con entityFramework 
            Console.SetCursorPosition(9, 12); var db = new tallersena588Context();
            var estudiantes = db.Estudiantes.ToList();
            int Acendente = 13;
            string Estado;

            Console.SetCursorPosition(40, 9); Console.Write("Lista Estudiantes");
            Console.SetCursorPosition(3, 11); Console.Write("{0,5}{1,13}{2,21}{3,16}{4,10}{5,10}{6,14}{7,13}", "Codigo", "Nombre", "Correo", "Nota1", "Nota2", "Nota3", "Notafinal", "Estado");

            foreach (var myEstudiante in estudiantes)

            {

                double Not1, Not2, Not3, Notafinal;
                Not1 = Convert.ToDouble(myEstudiante.Nota1);
                Not2 = Convert.ToDouble(myEstudiante.Nota2);
                Not3 = Convert.ToDouble(myEstudiante.Nota3);
                Notafinal = (Not1 + Not2 + Not3) / 3;

                if (Notafinal >= 3.5)

                {
                    Estado = "Aprobado";
                }
                else
                {
                    Estado = "Reprobado";
                }

                Console.SetCursorPosition(2, Acendente); Console.Write($"{myEstudiante.Codigo,5}{myEstudiante.Nombre,15}{myEstudiante.Correo,26}{myEstudiante.Nota1,9}{myEstudiante.Nota2,10}{myEstudiante.Nota3,10}{Notafinal,12:.##}{Estado,18}");
                Acendente = Acendente + 1;
            }

        }

        static void BuscarRegistro()
        {
            gui.Borrarlogo();
            uint cod;
            string codTxt;
            bool EntradaValidaCodigo = false;
            gui.BorrarLinea(40, 16, 56);

            var db = new tallersena588Context();

            do
            {

                Console.SetCursorPosition(30, 9); Console.Write("Digite Codigo a Buscar: ");
                Console.SetCursorPosition(55, 9); codTxt = Console.ReadLine();
                if (!verificar.Vacio(codTxt))
                    if (verificar.TipoNumero(codTxt))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);


            if (sabersiexiste(Int32.Parse(codTxt)))
            {

                var myEstudiante = db.Estudiantes.FirstOrDefault(e => e.Codigo == Int32.Parse(codTxt)); // sirve para convertir stirign en entero
                Console.WriteLine($"{myEstudiante.Codigo}\t{myEstudiante.Nombre}\t{myEstudiante.Correo}\t{myEstudiante.Nota1}\t{myEstudiante.Nota2}\t{myEstudiante.Nota3}");
            }
            else
            {
                Console.SetCursorPosition(40, 23); Console.Write("No existe registro");
            }
        }
        // validación Saber si existe 

        public static bool sabersiexiste(int codigo)
        {
            bool traer = false;
            var db = new tallersena588Context();
            var lista = db.Estudiantes.ToList();

            foreach (var myEstudiante in lista)
            {
                if (codigo == myEstudiante.Codigo)
                {
                    traer = true;
                }

            }

            return traer;
        }

        static void EditarRegistro()
        {
            double no1, no2, no3;
            string nom, cor;
            uint cod;
            string codTxt, no1Txt, no2Txt, no3Txt;
            bool EntradaValidaNombre = false;
            bool EntradaValidaCodigo = false;
            bool EntradaValidaCorreo = false;
            bool EntradaValidaNot1 = false;
            bool EntradaValidaNot2 = false;
            bool EntradaValidaNot3 = false;
            gui.BorrarLinea(40, 16, 56);
            gui.BorrarLinea(40, 22, 56);
            gui.Borrarlogo();
            Console.SetCursorPosition(30, 10); Console.Write("Digite codigo a editar:");
            //codTxt = uint.Parse(Console.ReadLine());
            codTxt = Console.ReadLine();
            var db = new tallersena588Context();
            //var existe = db.Estudiantes.Find(cod);

            if (sabersiexiste(Int32.Parse(codTxt)))
            {

                do
                {

                    Console.SetCursorPosition(30, 11); Console.Write("Digite Nombre Estudiante: ");
                    nom = Console.ReadLine();
                    if (!verificar.Vacio(nom))
                    {

                        if (verificar.TipoTexto(nom))
                        {
                            EntradaValidaNombre = true;
                        }

                    }
                    else
                    {
                        EntradaValidaNombre = true;
                    }
                } while (!EntradaValidaNombre);

                do
                {

                    Console.SetCursorPosition(30, 12); Console.Write("Digite Correo Estudiante: ");
                    cor = Console.ReadLine();
                    if (!verificar.Vacio(cor))
                    {

                        if (verificar.TipoCorreo(cor))
                        {
                            EntradaValidaCorreo = true;
                        }
                    }
                    else
                    {
                        EntradaValidaCorreo = true;
                    }
                } while (!EntradaValidaCorreo);

                do
                {

                    Console.SetCursorPosition(30, 13); Console.Write("Digite Nota 1           : ");
                    no1Txt = Console.ReadLine();
                    if (!verificar.Vacio(no1Txt))
                    {


                        if (verificar.TipoNumero(no1Txt))
                        {
                            EntradaValidaNot1 = true;
                        }
                    }
                    else
                    {
                        EntradaValidaNot1 = true;
                    }
                } while (!EntradaValidaNot1);

                do
                {

                    Console.SetCursorPosition(30, 14); Console.Write("Digite Nota 2           : ");
                    no2Txt = Console.ReadLine();
                    if (!verificar.Vacio(no2Txt))
                    {

                        if (verificar.TipoNumero(no2Txt))
                        {
                            EntradaValidaNot2 = true;
                        }
                    }
                    else
                    {
                        EntradaValidaNot2 = true;
                    }
                } while (!EntradaValidaNot2);

                do
                {

                    Console.SetCursorPosition(30, 15); Console.Write("Digite Nota 3           : ");
                    no3Txt = Console.ReadLine();

                    if (!verificar.Vacio(no3Txt))
                    {


                        if (verificar.TipoNumero(no3Txt))
                        {
                            EntradaValidaNot3 = true;
                        }
                    }
                    else
                    {
                        EntradaValidaNot3 = true;
                    }

                } while (!EntradaValidaNot3);

                var myEstudiante = db.Estudiantes.FirstOrDefault(e => e.Codigo == Int32.Parse(codTxt));

                if (!String.Equals("", nom))
                {
                    myEstudiante.Nombre = nom;
                }
                if (!String.Equals("", cor))
                {
                    myEstudiante.Correo = cor;
                }
                if (!String.Equals("", no1Txt))
                {
                    myEstudiante.Nota1 = double.Parse(no1Txt);
                }
                if (!String.Equals("", no2Txt))
                {
                    myEstudiante.Nota2 = double.Parse(no2Txt);
                }
                if (!String.Equals("", no3Txt))
                {
                    myEstudiante.Nota3 = double.Parse(no3Txt);
                }
                db.Estudiantes.Update(myEstudiante);
                db.SaveChanges();
            }
            else
            {
                Console.SetCursorPosition(40, 23); Console.Write("El codigo No existe ");
            }

        }

        static void EliminarRegistro()
        {

            uint cod;
            string codTxt;
            bool EntradaValidaCodigo = false;
            gui.Borrarlogo();

            var db = new tallersena588Context();

            do
            {

                Console.SetCursorPosition(10, 11); Console.Write("Digite el codigo a eliminar: ");
                codTxt = Console.ReadLine();
                if (!verificar.Vacio(codTxt))
                    if (verificar.TipoNumero(codTxt))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (sabersiexiste(Int32.Parse(codTxt)))
            {
                var myEstudiante = db.Estudiantes.FirstOrDefault(e => e.Codigo == Int32.Parse(codTxt));

                string confirmar;
                Console.SetCursorPosition(10, 12); Console.Write($"Realmente desea eliminar los datos de {myEstudiante.Nombre}: S/N");
                confirmar = Console.ReadLine();
                if (confirmar == "S")
                {
                    db.Estudiantes.Remove(myEstudiante);
                    db.SaveChanges();
                    Console.WriteLine("El registro fue eliminado correctamente");

                }
                else
                {
                    Console.WriteLine("El estudiante No fue eliminado: ");
                }

            }
            else
            {
                Console.WriteLine("No existe registro");
            }


        }
    }

}