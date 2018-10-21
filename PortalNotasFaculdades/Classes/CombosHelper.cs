using PortalNotasFaculdades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalNotas.Classes {    

    public class CombosHelper :IDisposable {        

        private static PortalContext db = new PortalContext();

        public static List<Cursos> GetCursos() {            

            var dep = db.Cursos.ToList();
            dep.Add(new Cursos {
                CursoId = 0,
                NomeCurso = "[Selecione um Curso]"
            });

            return dep = dep.OrderBy(d => d.NomeCurso).ToList();

        }

        public static List<DisciplinasCursos> GetDisciplinas() {

            var dep = db.DisciplinasCursos.ToList();
            dep.Add(new DisciplinasCursos {
                DisciplinaId = 0,
                NomeDisciplina = "[Selecione uma Disciplina]"
            });

            return dep = dep.OrderBy(d => d.NomeDisciplina).ToList();

        }

       /* public static List<DisciplinasCursos> GetDisciplinasNot() {

            var dep = db.DisciplinasCursos.ToList();
            dep.Add(new DisciplinasCursos {
                DisciplinaId = 99999,
                NomeDisciplina = "[Nenhuma]"
            });

            return dep = dep.OrderBy(d => d.NomeDisciplina).ToList();

        }*/

        public void Dispose() {
            db.Dispose();
        }
    }
}