//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Escuela
{
    using System;
    using System.Collections.Generic;
    
    public partial class Calificaciones
    {
        public int ID_Calificacion { get; set; }
        public Nullable<int> Alumno_ID { get; set; }
        public Nullable<int> Materia_ID { get; set; }
        public Nullable<decimal> Calificacion { get; set; }
        public Nullable<int> Semestre { get; set; }
        public Nullable<int> Parcial { get; set; }
    
        public virtual Alumnos Alumnos { get; set; }
        public virtual Materias Materias { get; set; }
    }
}
