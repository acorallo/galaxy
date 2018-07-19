using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Common;
using Galaxy.Core.Contracts;
using GalaxyData = Galaxy.Data;

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

                var p1Clone = (Planet)this.Planets[0].Clone();
                var p2Clone = (Planet)this.Planets[1].Clone();
                p1Clone.AddDay();
                p2Clone.AddDay();

                var minGradient = getGradientFromTwoPoints(p1.x, p2.x, p1.y, p2.y);
                var maxGradient = getGradientFromTwoPoints(p1Clone.x, p2Clone.x, p1Clone.y, p2Clone.y);

                int count = 1;
                bool flag = true;

                while (count<this.Planets.Count-1 && flag)
                {
                    var pn0 = this.Planets[count];
                    var pn1 = this.Planets[count+1];

                    var currentGradient = getGradientFromTwoPoints(pn0.x, pn1.x, pn0.y, pn1.y);

                    flag = currentGradient >= minGradient && currentGradient <= maxGradient; 

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

        private void PersistDay(GalaxyData.GalaxyDal galaxyDal, int day)
        {
            var galaxyDataModel = new GalaxyData.Datamodels.GalaxyDataModel();
            galaxyDataModel.Day = day;
            galaxyDataModel.Weather = this.GetWheather().ToString();
            galaxyDataModel.Perimeter = this.GeometricPerimeter();
            galaxyDataModel.SunIn = this.Geometric.IsCenterInside();

            galaxyDal.PersistWeather(galaxyDataModel);
        }

        public SimulateInformation Simulate(int days)
        {
            var resultInformation = new SimulateInformation();
            var galaxyDal = new GalaxyData.GalaxyDal();

            try
            {

                galaxyDal.OpenConnection();
                galaxyDal.DeleteAllWeather();

                Wheather lastwheather = this.GetWheather();

                int counter = 1;
                while (counter <= days)
                {
                    resultInformation.CountPeriod(lastwheather);

                    while (counter <= days && lastwheather == this.GetWheather())
                    {
                        this.EvaluateGeometric(resultInformation, counter);
                        PersistDay(galaxyDal, counter);
                        this.AddDay();
                        counter++;
                    }

                    lastwheather = this.GetWheather();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                galaxyDal.ClosConnection();
            }
            

            return resultInformation;
        }

        public static bool RunNextDay(IGalaxySetup galaxySetup)
        {
            bool result = false;

            using (var galaxyDal = new GalaxyData.GalaxyDal())
            {

                try
                {
                    galaxyDal.OpenConnection();
                    int lastDay = galaxyDal.GetLastProcecedDay();
                    int nextDay = lastDay == GalaxyData.GalaxyDal.NULL_INT ? 0 : lastDay + 1;

                    var galaxy = new Galaxy(galaxySetup);
                    galaxy.SetAge(nextDay);
                    galaxy.PersistDay(galaxyDal, nextDay);

                    result = true;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    galaxyDal.ClosConnection();
                }
            }

            return result;
        }

        /// <summary>
        /// Determina que tipo de clima tiene actualmente la galaxia
        /// </summary>
        /// <returns></returns>
        public Wheather GetWheather()
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

        private void EvaluateGeometric(SimulateInformation simulateInformation, int currentDay)
        {
            if(this.GetWheather()==Wheather.Rains)
            {
                var currentPerimeter = this.GeometricPerimeter();
                if (currentPerimeter > simulateInformation.TrianglePerimeter)
                {
                    simulateInformation.TrianglePerimeter = currentPerimeter;
                    simulateInformation.MaxTrianglePerimeterDay = currentDay;
                }
            }

        }
        
    }
}
