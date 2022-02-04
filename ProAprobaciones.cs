using Microsoft.EntityFrameworkCore;
using Modelo.Entidades;
using Modelo.Operaciones;
using ModeloDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class ProAprobaciones
    {
        private AcademiaDB db;

        public ProAprobaciones(AcademiaDB db)
        {
            this.db = db;
        }

        public bool Aprobo(Estudiante estudiante, Materia materia)
        {
            var aprobacion  = new bool();

            //Consultar materia
            var tmpMateria = db.materias
                .Include(mat => mat.Nombre)
                .Single(mat => mat.MateriaId == materia.MateriaId);

            //Consultar estudiante
            var tmpEstudiante = db.estudiantes
                .Include(est => est.Matriculas)
                .Single(est => est.EstudianteId == estudiante.EstudianteId);

            //Si no ha tomado esa materia, no constara como estudiante
            if (tmpEstudiante.Matriculas == null) return false;

            //Consultar las matriculas 
            var tmpMatricula = db.matriculas
                .Include(mtr => mtr.Estudiante)
                .Where(mtr => mtr.MatriculaId == tmpEstudiante.EstudianteId);

            //Si no consta como estudiante, retorna false
            if (tmpMatricula == null) return false;

            //
            foreach (var aprb in tmpMatricula)
            {
                var sublistaMatricula Aprobo(aprb.Estudiante, aprb.);
            }
            return false;
        }

    }
}
