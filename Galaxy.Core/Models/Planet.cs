using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Common;
using Galaxy.Core.Exceptions;

namespace Galaxy.Core.Models
{
    public class Planet : Star
    {
        
        #region Properties
        
        /// <summary>
        /// Distancia al sol en Km.
        /// </summary>
        public int SunDistance { get; }

        /// <summary>
        /// Determina si el astro se mueve en sentido horario o no.
        /// </summary>
        public bool ClockWise { get; }

        private int _angularPosition;

        /// <summary>
        /// Reporesenta la posicion angular del astro.
        /// </summary>
        public int AngularPosition {
            get
            {
                return _angularPosition;
            }
        }

        private int _age;

        /// <summary>
        /// Representa la edad del planeta en día
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
        }

        private int AngularStep { get; set; }

        #endregion Properties
        
        #region Constructors

        public Planet(string name, int angularPosition, int angularStep, int sunDistance, bool clockwise) : base (name)
        {
            var myPostion = this.GetAxialPosition(angularPosition, sunDistance);
            this.Name = name;
            this.x = myPostion.x;
            this.y = myPostion.y;
            this.SunDistance = sunDistance;
            this.ClockWise = clockwise;
            this._angularPosition = angularPosition;
            this._age = 0;
            this.AngularStep = angularStep;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Traduce la edad en dias del planeta a posición angular.
        /// Utiliza congruencia modular para hacer la conversion.
        /// </summary>
        /// <param name="age">reporesenta </param>
        /// <returns></returns>
        protected int GetAngualerPositionFromAge(int age) 
        {
            this.ValidateAge(age);

            var absolutePostion = (this.AngularStep * age) % Constants.RADIAN;
            return this.ClockWise ? Constants.RADIAN - absolutePostion : absolutePostion;
        }

        /// <summary>
        /// Establece la edad del planeta y ajusta la posición acorde.
        /// </summary>
        /// <param name="age"></param>
        public void SetAge(int age)
        {
            this.ValidateAge(age);

            this._angularPosition = this.GetAngualerPositionFromAge(age);
            var myPosition = this.GetAxialPosition(this._angularPosition, this.SunDistance);
            this.x = myPosition.x;
            this.y = myPosition.y;
            this._age = age;
        }

        /// <summary>
        /// Agrega un año a la longevidad del planeta.
        /// Set todo los valores acordes a si edad.
        /// </summary>
        /// <returns></returns>
        public int AddDay()
        {
            this._age++;
            this.SetAge(_age);

            return _age;

        }

        #endregion Methods

        #region Validations

        /// <summary>
        /// Verifica que el valor de age sea positivo. 
        /// Caso contrario genera una excepción ad hoc.
        /// </summary>
        /// <param name="age"></param>
        private void ValidateAge(int age)
        {
            if (age < 0)
                throw new AgeException();
        }

        #endregion Validations
    }
}
