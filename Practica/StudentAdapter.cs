using System;

namespace Practica
{

    // Practica 4 - Ejercicio 3 //

    public class StudentAdapter: Student
    {
        public Alumno estudiante;
        bool muyEstudioso=false;
        

        public StudentAdapter(Alumno alumno)
        {
            if (alumno.GetType().ToString() == "Practica.AlumnoMuyEstudioso")
            {
                muyEstudioso = true;
            }
            estudiante = alumno;
        }

        public string getName()
        {
            return estudiante.getNombre();
        }

        public int yourAnswerIs(int question)
        {
            if (muyEstudioso)
            {
                return ((AlumnoMuyEstudioso)estudiante).responderPregunta(question);
            }
            else
            {
                return estudiante.responderPregunta(question);
            }
            
        }
        public void setScore(int score)
        {
            estudiante.setCalificacion(score);
        }
        public string showResult()
        {

            // Practica 4 - Ejercicio 7 //
   

            DecoratorCalificacion decorador = new Decorator(estudiante);
            LegajoDecorator legDec = new LegajoDecorator(decorador, estudiante);
            LetrasDecorator letrDec = new LetrasDecorator(legDec, estudiante);
            NumeroDecorator numDec = new NumeroDecorator(letrDec, estudiante);
            PromocionDecorator promDec = new PromocionDecorator(numDec, estudiante);
            CuadroDecorator cuadroDec = new CuadroDecorator(promDec, estudiante);
            return (cuadroDec.mostrarCalificacion());
        }

        // Practica 4 - Ejercicio 5 //


        public int getCalification()
        {
            return estudiante.getCalificacion();
        }

        public bool equals(Student student)
        {
            return this.getCalification() == ((StudentAdapter)student).getCalification();
        }

        public bool lessThan(Student student)
        {
            return this.getCalification() < ((StudentAdapter)student).getCalification();
        }

        public bool greaterThan(Student student)
        {
            return this.getCalification() > ((StudentAdapter)student).getCalification();
        }

    }
    

}