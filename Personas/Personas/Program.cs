using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Personas
{
    class Program
    {
            static void Crear(List<Persona> persona)
            {
                Console.WriteLine("Ingrese un nombre: ");
                string name = Console.ReadLine();
                Console.WriteLine("Ingrese un apellido: ");
                string apellido = Console.ReadLine();
                Console.WriteLine("Ingrese la edad de la persona");
                int edad = Convert.ToInt32(Console.ReadLine());
                Persona character = new Persona(name, apellido, edad);
                persona.Add(character);
            }

            static void Mostrar(List<Persona> persona)
            {
                int i = 1;
                foreach (Persona data in persona)
                {
                    Console.WriteLine(i + ")  Nombre Completo: " + data.nombre + " " + data.apellido + " Edad: " + data.edad);
                    i++;
                }
            }

            static void Cargar(List<Persona> persona)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Personas.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                int linea = (int)formatter.Deserialize(stream);
                
                for(int i = 0; i < linea; i++)
                {
                    Persona data = (Persona)formatter.Deserialize(stream);
                    persona.Add(data);
                }
                
                stream.Close();
            }

            static void Guardar(List<Persona> persona)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Personas.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, persona.Count());
                foreach (Persona data in persona)
                {
                    formatter.Serialize(stream, data);
                }
                stream.Close();
            }

            static void Main(string[] args)
            {
                List<Persona> characters = new List<Persona>();

                int menu = 1;

                while (menu == 1)
                {
                    Console.WriteLine("Programa de personas");
                    Console.WriteLine("1) Crear persona");
                    Console.WriteLine("2) Mostrar personas");
                    Console.WriteLine("3) Almacenar persona");
                    Console.WriteLine("4) Cargar personas");
                    Console.WriteLine("5) Salir");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Crear(characters);
                            break;

                        case 2:
                            Mostrar(characters);
                            break;

                        case 3:
                            Guardar(characters);
                            break;

                        case 4:
                            Cargar(characters);
                            break;

                        case 5:
                            menu = 0;
                            break;
                    }

                }
            }
        }
    }
