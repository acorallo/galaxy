using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Galaxy.Data
{
    public class GalaxyDal : DataAccess
    {

        public const int NULL_INT = Int32.MinValue;

        public const string DAY_COLUMN = "day";
        public const string WEATHER_COLUMN = "weather";
        public const string PERIMETER_COLUMN = "perimeter";
        public const string SUNIN_COLUMN = "sunin";
        public const string ID_COLUMN = "id";
        public const string LAST_DAY_COLUMN = "lastDay";

        public const string INSERT_GALAXY_SLQ = "INSERT INTO Weather(day, weather, perimeter, sunin) VALUES(@day,@weather, @perimeter, @sunin)";
        public const string LAST_DAY_SQL = "select lastDay = max(day) from weather";
        public const string GET_WEATHER_SQL = "select Id, Day, weather, perimeter, sunin from weather where (day = @day or @day is null)";
        public const string DELETE_ALL_WEATHER = "delete from weather";

        public bool PersistWeather(Datamodels.GalaxyDataModel galaxy)
        {
            bool result = false;
            try
            {
                IDbCommand command = this.getCommand();
                command.CommandText = INSERT_GALAXY_SLQ;
                command.CommandType = CommandType.Text;

                command.Parameters.Add(new SqlParameter() { ParameterName = DAY_COLUMN, DbType = DbType.Int32, Value = galaxy.Day});
                command.Parameters.Add(new SqlParameter() { ParameterName = WEATHER_COLUMN, DbType = DbType.String, Value = galaxy.Weather });
                command.Parameters.Add(new SqlParameter() { ParameterName = PERIMETER_COLUMN, DbType = DbType.Int32, Value = galaxy.Perimeter });
                command.Parameters.Add(new SqlParameter() { ParameterName = SUNIN_COLUMN, DbType = DbType.Int32, Value = galaxy.SunIn ? 1 : 0 });

                command.ExecuteNonQuery();
                result = true;

            }
            catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Datamodels.GalaxyDataModel getModelByDay(int day)
        {
            Datamodels.GalaxyDataModel resultModel = null;

            try
            {

                IDbCommand command = this.getCommand();
                command.CommandText = INSERT_GALAXY_SLQ;
                command.CommandType = CommandType.Text;

                command.Parameters.Add(new SqlParameter() { ParameterName = DAY_COLUMN, DbType = DbType.Int32, Value = day });

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        resultModel = new Datamodels.GalaxyDataModel();
                        resultModel.Id = Int32.Parse(dataReader[ID_COLUMN].ToString());
                        resultModel.Day = Int32.Parse(dataReader[DAY_COLUMN].ToString());
                        resultModel.Weather = dataReader[WEATHER_COLUMN].ToString();
                        resultModel.Perimeter = Double.Parse(dataReader[PERIMETER_COLUMN].ToString());
                        resultModel.SunIn = dataReader[SUNIN_COLUMN].ToString() == "1";
                    }
                    dataReader.Close();
                }
                
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return resultModel;
        }

        public int GetLastProcecedDay()
        {
            int result = NULL_INT;

            try
            {
                IDbCommand command = this.getCommand();
                command.CommandText = LAST_DAY_SQL;
                command.CommandType = CommandType.Text;

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        result = dataReader[LAST_DAY_COLUMN].ToString() != string.Empty ? Int32.Parse(dataReader[LAST_DAY_COLUMN].ToString()) : NULL_INT;
                    }
                    dataReader.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool DeleteAllWeather()
        {
            bool result = false;

            try
            {
                IDbCommand command = this.getCommand();
                command.CommandText = DELETE_ALL_WEATHER;
                command.CommandType = CommandType.Text;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

    }
}
