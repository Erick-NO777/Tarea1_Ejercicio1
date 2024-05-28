using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tarea1_Ejercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string usuario;
            Console.WriteLine("CALCULADORA DE AUMENTOS SALARIALES");
            Console.WriteLine();

            Console.Write("Digite su nombre: ");
            usuario = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine($"Bienvenido/a {usuario}");
            Thread.Sleep(1000);
            Console.WriteLine();

            bool continuar = true;

            while (continuar)
            {
                // Variables de empleado
                string cedula, nombre;
                string puesto;
                int tipoEmpleado;
                decimal cantidadHoras, precioHora, salarioOrdinario, aumento, salarioBruto, deduccionCCSS, salarioNeto;

                // Valor 0 a las variables de las estadisticas
                int cantidadOperarios = 0, cantidadTecnicos = 0, cantidadProfesionales = 0;
                decimal salarioNetoOperarios = 0, salarioNetoTecnicos = 0, salarioNetoProfesionales = 0;

                // Número de empleados
                int numEmpleados;
                Console.Write("Cuantos empleados desea procesar?: ");
                numEmpleados = int.Parse(Console.ReadLine()); // Convierte la entrada en entero luego de que el usuario de enter
                Console.WriteLine();

                for (int i = 0; i < numEmpleados; i++) // Bucle for para procesar cada empleado
                {
                    // Datos del empleado
                    Console.Write("Digite la cedula del empleado: ");
                    cedula = Console.ReadLine();

                    Console.Write("Digite el nombre del empleado: ");
                    nombre = Console.ReadLine();

                    // Valida el tipo de empleado
                    Console.Write("Digite que tipo de empleado es: (1 = Operario, 2 = Tecnico, 3 = Profesional): ");
                    tipoEmpleado = int.Parse(Console.ReadLine());
                    while (tipoEmpleado < 1 || tipoEmpleado > 3) // Muestra error en caso de que el numero no este entre el rango 1-3
                    {
                        Console.WriteLine();
                        Console.Write("Lo sentimos, ese tipo de empleado no esta registrado. Intente de nuevo. (1 = Operario, 2 = Tecnico, 3 = Profesional): ");
                        tipoEmpleado = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                    }

                    // Cantidad de horas laboradas
                    Console.Write("Ingrese la cantidad de horas laboradas: ");
                    cantidadHoras = decimal.Parse(Console.ReadLine());

                    // Precio por hora
                    Console.Write("Ingrese el precio por hora: ");
                    precioHora = decimal.Parse(Console.ReadLine());

                    // Salario ordinario
                    salarioOrdinario = cantidadHoras * precioHora;

                    // Aumento según el tipo de empleado y nombre del puesto
                    if (tipoEmpleado == 1)
                    {
                        aumento = salarioOrdinario * 0.15m;
                        puesto = "Operario";
                    }
                    else if (tipoEmpleado == 2)
                    {
                        aumento = salarioOrdinario * 0.10m;
                        puesto = "Tecnico";
                    }
                    else
                    {
                        aumento = salarioOrdinario * 0.05m;
                        puesto = "Profesional";
                    }

                    // Salario bruto, deducciones, salario neto
                    salarioBruto = salarioOrdinario + aumento;
                    deduccionCCSS = salarioBruto * 0.0917m;
                    salarioNeto = salarioBruto - deduccionCCSS;

                    // Mostrar los resultados del cálculo
                    Console.WriteLine();
                    Console.WriteLine("RESULTADOS DEL CALCULO SALARIAL");
                    Thread.Sleep(1000); // Espera un segundo para continuar
                    Console.WriteLine();
                    Console.WriteLine($"Cedula: {cedula}");
                    Console.WriteLine($"Nombre Empleado: {nombre}");
                    Console.WriteLine($"Tipo Empleado: {puesto}");
                    Console.WriteLine($"Salario por Hora: {precioHora:F2}");
                    Console.WriteLine($"Cantidad de Horas: {cantidadHoras:F2}");
                    Console.WriteLine($"Salario Ordinario: {salarioOrdinario:F2}");
                    Console.WriteLine($"Aumento: {aumento:F2}");
                    Console.WriteLine($"Salario Bruto: {salarioBruto:F2}");
                    Console.WriteLine($"Deducción CCSS: {deduccionCCSS:F2}");
                    Console.WriteLine($"Salario Neto: {salarioNeto:F2}");
                    Console.WriteLine();

                    // Actualiza las estadísticas según el tipo de empleado
                    if (tipoEmpleado == 1)
                    {
                        cantidadOperarios++;
                        salarioNetoOperarios += salarioNeto;
                    }
                    else if (tipoEmpleado == 2)
                    {
                        cantidadTecnicos++;
                        salarioNetoTecnicos += salarioNeto;
                    }
                    else if (tipoEmpleado == 3)
                    {
                        cantidadProfesionales++;
                        salarioNetoProfesionales += salarioNeto;
                    }
                }

                // Mostrar estadísticas finales
                Thread.Sleep(1000);
                Console.WriteLine("ESTADISTICAS FINALES");
                Thread.Sleep(1000);
                Console.WriteLine();
                Console.WriteLine($"Cantidad de Empleados Tipo Operarios: {cantidadOperarios}");
                Console.WriteLine($"Acumulado Salario Neto para Operarios: {salarioNetoOperarios:F2}");
                Console.WriteLine($"Promedio Salario Neto para Operarios: {(cantidadOperarios > 0 ? (salarioNetoOperarios / cantidadOperarios).ToString("F2") : "N/A")}");
                Console.WriteLine($"Cantidad de Empleados Tipo Tecnicos: {cantidadTecnicos:F2}");
                Console.WriteLine($"Acumulado Salario Neto para Tecnicos: {salarioNetoTecnicos:F2}");
                Console.WriteLine($"Promedio Salario Neto para Tecnicos: {(cantidadTecnicos > 0 ? (salarioNetoTecnicos / cantidadTecnicos).ToString("F2") : "N/A")}");
                Console.WriteLine($"Cantidad de Empleados Tipo Profesionales: {cantidadProfesionales}");
                Console.WriteLine($"Acumulado Salario Neto para Profesionales: {salarioNetoProfesionales:F2}");
                Console.WriteLine($"Promedio Salario Neto para Profesionales: { (cantidadProfesionales > 0 ? (salarioNetoProfesionales / cantidadProfesionales).ToString("F2") : "N/A")}");
                Thread.Sleep(2000);

                // Preguntar si desea continuar
                Console.WriteLine();
                Console.Write("¿Desea continuar? (S/N): ");
                char respuesta = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                continuar = respuesta == 'S';

                if (continuar)
                {
                    Console.WriteLine("Reiniciando el programa...");
                    Thread.Sleep(2500); // Esperar 2.5 segundo antes de continuar
                    Console.Clear(); // Limpiar la consola para empezar de nuevo
                }

                Console.WriteLine();
            }

        }
    }
}