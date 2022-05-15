using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MobileWorld.Infrastructure.Data.Common;
using MobileWorld.Infrastructure.Data.Models;
using MobileWorld.Infrastructure.Data.QueriesAndSPDtoModels;
using MobileWorld.Infrastructure.Data.Repositories.Contracts;
using System.Data;
using System.Data.Common;

namespace MobileWorld.Infrastructure.Data.Repositories
{
    public class AdRepository : Repository<Ad>, IAdRepository
    {
        private readonly ApplicationDbContext _context;
        public AdRepository(ApplicationDbContext context) :
            base(context)
        {
            _context = context;
        }

        public AdSpModel GetAdById(string sql, SqlParameter[] parameters)
        {
            AdSpModel resultModel = new();

            using (_context)
            {
                AdInfoSpModel adMidel = new();
                CarSpModel carModel = new CarSpModel();
                EngineSpModel engineModel = new EngineSpModel();
                List<string> images = new List<string>();

                //SqlCommand sqlCommand = new SqlCommand(sql);
                //sqlCommand.Parameters.Add(parameters[0]);


                DbCommand command;
                DbDataReader dbReader;

                command = _context.Database.GetDbConnection().CreateCommand();
                command.CommandText = sql;
                command.Parameters.Add(parameters[0]);

                _context.Database.OpenConnection();

                dbReader = command.ExecuteReader(CommandBehavior.CloseConnection);

                while (dbReader.Read())
                {
                    adMidel.Id = dbReader.GetString(0);
                    adMidel.Title = dbReader.GetString(1);
                    adMidel.Price = dbReader.GetDecimal(2);
                    adMidel.PhoneNumber = dbReader.GetString(3);
                    adMidel.Description = dbReader.GetString(4);
                    adMidel.CreatedOn = dbReader.GetDateTime(5);
                    adMidel.RegionName = dbReader.GetString(6);
                    adMidel.Neiborhood = dbReader.GetString(7);
                    adMidel.TownName = dbReader.GetString(8);
                }
                    resultModel.AdInfo = adMidel;

                dbReader.NextResult();

                while (dbReader.Read())
                {
                    carModel.Model=dbReader.GetString(0);
                    carModel.SeatsCount=dbReader.GetInt32(1);
                    carModel.Year = dbReader.GetInt32(2);
                    carModel.Color = dbReader.GetString(3);
                    carModel.GearType = dbReader.GetInt32(4);
                    carModel.Make = dbReader.GetString(5);
                    carModel.Mileage = dbReader.GetDecimal(6);
                }

                dbReader.NextResult();

                while (dbReader.Read())
                {
                    engineModel.CubicCapacity=dbReader.GetInt32(0);
                    engineModel.EcoLevel=dbReader.GetInt32(1);
                    engineModel.FuelConsuption=dbReader.GetDouble(2);
                    engineModel.FuelType=dbReader.GetInt32(3);
                    engineModel.HorsePower=dbReader.GetInt32(4);
                    engineModel.NewtonMeter=dbReader.GetInt32(5);
                }

                dbReader.NextResult();

                while (dbReader.Read())
                {
                    images.Add(dbReader.GetString(0));
                }

                dbReader.Close();
            }

            return resultModel;
        }
    }
}
