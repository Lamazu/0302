using Procesos;
using System;
using System.Linq;

namespace Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grabar grabar = new Grabar();
            grabar.DatosIni();

            using(var db = AcademiaDBBuilder.Crear())
            {
                var tmpMateria = db.materias
                    .Single(materia => materia.Nombre == "E-Learning");
                var tmpEstudiante = db.estudiantes
                    .Single(estudiante => estudiante.Nombre == "Karla Sanchez");

                ProAprobaciones opAprobaciones = new ProAprobaciones(db);

                var bl = opAprobaciones.Aprobo(tmpEstudiante, tmpMateria);

                
                Console.WriteLine("En la materia:  "+ tmpMateria.Nombre + " el estudiante " + tmpEstudiante + "" +
                    " se encuntra: ");
                if (bl == false)
                {
                    Console.WriteLine("No aprobado");
                } 
                else
                {
                    Console.WriteLine("Aprobado");
                }              
            }
        }
    }
}
