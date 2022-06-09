using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EXAMENU6
{
    class Program
    {
        class Amazon
        {
            // campos de la clase
            public string NomProducto, Descripcion;
            public float Precio;
            public int CantidadStock;

            // constructor de la clase
            public Amazon(string NomProducto, string Descripcion, float Precio, int CantidadStock)
            {
                this.NomProducto = NomProducto;
                this.Descripcion = Descripcion;
                this.Precio = Precio;
                this.CantidadStock = CantidadStock;
            }
           

            // Desctructor de la clase 
            ~Amazon()
            {
                Console.WriteLine("Liberar memoria clase AMAZON");
            }

        }
        static void Main(string[] args)
        {
            // Declaración de variables auxiliares
             string NomProducto, Descripcion;
             float Precio;
             int CantidadStock, op;

            // Menú de opciones

            do
            {
                Console.Clear();
                Console.WriteLine("----AMAZON----");
                Console.WriteLine("\n---MENÚ---");
                Console.WriteLine("1. Registro de inventario.");
                Console.WriteLine("2. Lectura de inventario.");
                Console.WriteLine("3. Salida del Programa");
                Console.Write("\nElija una opcion: ");
                op = Int16.Parse(Console.ReadLine());
                Console.Clear();

                switch (op)
                {
                    case 1:
                        
                        try
                        {
                            StreamWriter sw = new StreamWriter("Productos.txt", true);

                            // captura de datos
                            Console.WriteLine("----INVENTARIO AMAZON----");
                            Console.WriteLine("Registro de productos\n");
                            Console.Write("Ingrese nombre del producto: ");
                            NomProducto = Console.ReadLine();
                            Console.Write("Ingrese descripción del producto: ");
                            Descripcion = Console.ReadLine();
                            Console.Write("Ingrese cantidad en stock: ");
                            CantidadStock = Int16.Parse(Console.ReadLine());
                            Console.Write("Ingrese Precio del producto ");
                            Precio = float.Parse(Console.ReadLine());

                            // Objeto de la clase
                            Amazon AM = new Amazon(NomProducto, Descripcion, Precio, CantidadStock);
                            Console.Clear();

                            // despliegue de datos
                            sw.WriteLine("\nNombre del producto: " + AM.NomProducto);
                            sw.WriteLine("Descripción: " + AM.Descripcion);
                            sw.WriteLine("Precio del producto: {0:C}", AM.Precio);
                            sw.WriteLine("Cantidad de stock: " + AM.CantidadStock);

                            sw.Close(); // cerrar el archivo

                            Console.WriteLine("\nEscribiendo en el archivo...");
                            Console.ReadLine();
                           
                        }

                        catch (IOException e)
                        {
                            Console.WriteLine("\nError :" + e.Message);
                            
                        }
                        break;

                    case 2:

                        try
                        {
                            // lectura del archivo
                            StreamReader sr = new StreamReader("Producto. txt");

                            string producto;

                            while ((producto = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(producto);
                            }


                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError :" + e.Message);
                           
                        }
                        break;

                    case 3:
                        Console.Write("\nPresione ENTER para salir del programa.");
                        Console.ReadKey();

                        break;

                    default:

                        Console.Write("\nEsa Opcion no EXISTE , presione ENTER para continuar...");
                        Console.ReadKey();

                        break;
                }
            } while (op != 3);

        }
    }
}
