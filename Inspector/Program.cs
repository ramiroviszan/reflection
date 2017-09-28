using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inspector
{
    class Program
    {
        static void Main(string[] args)
        {
            Analize();
            DynamicObjects();
        }

        static void Analize()
        {
            // Cargamos el assembly de ejemplo en memoria
            Assembly miAssembly = Assembly.LoadFile(@"c:\InspectedAssembly.dll");
            // Podemos ver que Tipos hay dentro del assembly
            foreach (Type tipo in miAssembly.GetTypes())
            {
                Console.WriteLine(string.Format("Clase: {0}", tipo.Name));

                Console.WriteLine("Propiedades");
                foreach (PropertyInfo prop in tipo.GetProperties())
                {
                    Console.WriteLine(string.Format("\t{0} : {1}", prop.Name, prop.PropertyType.Name));
                }
                Console.WriteLine("Constructores");
                foreach (ConstructorInfo con in tipo.GetConstructors())
                {
                    Console.Write("\tConstructor: ");
                    foreach (ParameterInfo param in con.GetParameters())
                    {
                        Console.Write(string.Format("{0} : {1} ", param.Name, param.ParameterType.Name));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("Metodos");
                foreach (MethodInfo met in tipo.GetMethods())
                {
                    Console.Write(string.Format("\t{0} ", met.Name));
                    foreach (ParameterInfo param in met.GetParameters())
                    {
                        Console.Write(string.Format("{0} : {1} ", param.Name, param.ParameterType.Name));
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void DynamicObjects()
        {
            // Cargamos el assembly en memoria
            Assembly testAssembly = Assembly.LoadFile(@"c:\InspectedAssembly.dll");

            // Obtenemos el tipo que representa a Empleado por Hora (HourEmployee)
            Type employeeType = testAssembly.GetType("InspectedAssembly.HourEmployee");

            // Creamos una instancia de Empleado por hora
            object employeeInstance = Activator.CreateInstance(employeeType);

            // O también podemos crearlo pasandole parámetros
            employeeInstance = Activator.CreateInstance(employeeType, new object[] { "Juan", "1.232.232-3", 25.5, 10 });

            // Lo mostramos
            Console.WriteLine(employeeInstance.ToString());

            //Invocamos al método CalculateSalary
            MethodInfo met = employeeType.GetMethod("CalculateSalary");
            Console.WriteLine(string.Format("Sueldo: {0}", met.Invoke(employeeInstance, null)));

            //También podemos cambiar el valor de las horas trabajadas
            PropertyInfo prop = employeeType.GetProperty("HoursWorked");
            prop.SetValue(employeeInstance, 300, null);

            Console.ReadLine();

        }
    }
}
