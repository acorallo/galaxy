using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Common;
using Galaxy.Core.Contracts;

namespace Galaxy.Core.Models
{


    /// <summary>
    /// Especificacion de los tipos de clima.
    /// Draught: Todos lo planetas estan alineado entre si y con el sol (centro del sistema)
    /// Reains:  Los planeatas con estan alineados y forman un triangulo y el sol queda dentro de él.
    /// Normal: Este estado se agrego ya que le especificiacion del sistema no contemplaba el caso de que los planetas no estén alineados (formen un triangulo) pero el sol quede fuera.
    /// Best: la galaxy esperimenta condiciones optimas de presión y temperatura.
    /// </summary>
    public enum Wheather
    {
        Drought,
        Rains,
        Normal,
        Best
    }

    public class Galaxy
    {

        private IGeometric _geometric = null;

        private IGeometric Geometric
        {
            get
            {
                if (this._geometric == null)
                    this._geometric = GeometricFactory.GetGeometric(this.Planets);
                return _geometric;
            }
        }

        private List<Planet> _planets = new List<Planet>();

        public List<Planet> Planets { get => this._planets; }

        public Galaxy(IGalaxySetup galaxySetup)
        {
            this.SetupGalaxy(galaxySetup);
        }

        private void SetupGalaxy(IGalaxySetup galaxySetup)
        {
            this._planets = galaxySetup.getPlanets();
        }

        #region Public Methods

        /// <summary>
        /// Determina si todos los planetas del sistema están alineados con el sol (centro del sistema).
        /// Utiliza un calculo polar.
        /// </summary>
        /// <returns></returns>
        public bool AreAllPlanetsAlingToSun()
        {
            bool result = false;

            if (this.Planets.Count > 1)
            {
                var angule = this.Planets[0].AngularPosition % Constants.RADIAN_UNIT;
                result = this.Planets.TrueForAll(x=> (x.AngularPosition % Constants.RADIAN_UNIT) == angule);
                
            } else
                result = true;

            return result;
        }

        /// <summary>
        /// Establece la edad de toda la galaxia.
        /// </summary>
        /// <param name="age"></param>
        public void SetAge (int age)
        {
            foreach (var planet in this.Planets)
            {
                planet.SetAge(age);
            }
        }


        /// <summary>
        /// Agraga año a la longevidad de toda la galaxia.
        /// </summary>
        public void AddDay()
        {
            foreach(var planet in this. Planets)
            {
                planet.AddDay();
            }
        }

        /// <summary>
        /// Determina si todos los planetas estan alineados sin considerar al sol.
        /// Utiliza la similitud de la pendiente de todos los puntos carticianos. 
        /// </summary>
        /// <returns></returns>
        public bool AreAllPlantsAling()
        {
            bool result = true;

            if (this.Planets.Count > 2)
            {
                var p1 = this.Planets[0];
                var p2 = this.Planets[1];
                var refSlope = getGradientFromTwoPoints(p1.x, p2.x, p1.y, p2.y);
                int count = 1;
                bool flag = true;

                while (count<this.Planets.Count-1 && flag)
                {
                    var pn0 = this.Planets[count];
                    var pn1 = this.Planets[count+1];

                    flag = refSlope == getGradientFromTwoPoints(pn0.x, pn1.x, pn0.y, pn1.y);
                    count++;
                }

                result = flag;

            }

            return result;
        }

        /// <summary>
        /// Dermina el perimetro de la figura formada por los planetas del sistema.
        /// </summary>
        /// <returns></returns>
        public double GeometricPerimeter()
        {
            return this.Geometric.getPerimeter();
        }


        #endregion Public Methods

        /// <summary>
        /// Detemina si el centro esta dentro de la figura formada por los planetas.
        /// </summary>
        /// <returns></returns>
        public bool GeometricIncludeCenter()
        {
            return this.Geometric.IsCenterInside();
        }

        

        /// <summary>
        /// Determina el valor de la pendiente de la recta formada por dos puntos en el plano.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns>Pendiente de la recta</returns>
        private double getGradientFromTwoPoints(double x1, double x2, double y1, double y2)
        {
            // Exceptua el caso de la division por cero y devulve una pendiente infinita.
            if (x1 - x2 == 0)
                return double.MaxValue;

            return (y2 - y1) / (x2 - x1);
        }


        public SimulateInformation Simulate(int days)
        {
            SimulateInformation resultInformation = new SimulateInformation();

            Wheather lastwheather = this.GetWheather();
            
            int counter = 1;
            while (counter<=days)
            {
                resultInformation.CountPeriod(lastwheather);
                Wheather Currentwheather = this.GetWheather();
                while (counter <= days && lastwheather==this.GetWheather())
                {
                    this.AddDay();
                    counter++;
                }

                lastwheather = this.GetWheather();
            }
            
            return resultInformation;
        }

        /// <summary>
        /// Determina que tipo de clima tiene la galaxia.
        /// </summary>
        /// <returns></returns>
        private Wheather GetWheather()
        {
            Wheather result = Wheather.Normal;

            if (this.AreAllPlanetsAlingToSun())
            {
                result = Wheather.Drought;
            }
            else
            {
                if (this.AreAllPlantsAling())
                {
                    result = Wheather.Best;
                }
                else
                {
                    if (this.Geometric.IsCenterInside())
                    {
                        result = Wheather.Rains;
                    }
                }
                   
             }         

            return result;
        }
        
    }
}
