using System;
using System.Collections.Generic;
using System.Text;
using Galaxy.Core.Common;

namespace Galaxy.Core.Models
{
    public struct Position
    {
        public double x;
        public double y;
    }

    public abstract class Start
    {
        /// <summary>
        /// Representa la posición cartensiana  sobre el eje X
        /// </summary>
        protected double x { get; set; }
        /// <summary>
        /// Reporesenta la posición cartesiana sobre el eje Y
        /// </summary>
        protected double y { get; set; }

        /// <summary>
        /// Convierte una unidades en expresadas en grados a unidades expresadas en raidanes.
        /// </summary>
        /// <param name="degress">Unidades en grados a convertir.</param>
        /// <returns>Valor polar expresado en radianes.</returns>
        protected double DegreeToRadian(double degress)
        {
            return Math.PI * degress / Constants.RADIAN_UNIT;
        }

        /// <summary>
        /// Calcula la posición axial cartesiana en base al angulo de apertura y la distancia respecto del sol
        /// </summary>
        /// <param name="degress">Valor polar expresado en grados (anuglo tita)</param>
        /// <param name="distance">Distancia respecto del sol</param>
        /// <returns></returns>
        protected Position GetAxialPosition(double degress, int distance)
        {
            return new Position { x = Math.Cos(this.DegreeToRadian(degress)) * distance, y = Math.Sin(this.DegreeToRadian(degress)) * distance };
        }
    }
}
