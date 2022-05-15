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

            try
            {
                using (_context)
                {
                    DbCommand command;
                    DbDataReader dbReader;

                    command = _context.Database.GetDbConnection().CreateCommand();
                    command.CommandText = sql;
                    command.Parameters.Add(parameters[0]);

                    _context.Database.OpenConnection();

                    dbReader = command.ExecuteReader(CommandBehavior.CloseConnection);

                    while (dbReader.Read())
                    {
                        resultModel.AdInfo = new AdInfoSpModel()
                        {
                            Id = dbReader.GetString(0),
                            Title = dbReader.GetString(1),
                            Price = dbReader.GetDecimal(2),
                            PhoneNumber = dbReader.GetString(3),
                            Description = dbReader.GetString(4),
                            CreatedOn = dbReader.GetDateTime(5),
                            RegionName = dbReader.GetString(6),
                            Neiborhood = dbReader.GetString(7),
                            TownName = dbReader.GetString(8)
                        };

                    }

                    dbReader.NextResult();

                    while (dbReader.Read())
                    {
                        resultModel.Car = new CarSpModel()
                        {
                            Model = dbReader.GetString(0),
                            SeatsCount = dbReader.GetInt32(1),
                            Year = dbReader.GetInt32(2),
                            Color = dbReader.GetString(3),
                            GearType = dbReader.GetInt32(4),
                            Make = dbReader.GetString(5),
                            Mileage = dbReader.GetDecimal(6)
                        };
                    }

                    dbReader.NextResult();

                    while (dbReader.Read())
                    {
                        resultModel.Engine = new EngineSpModel()
                        {
                            CubicCapacity = dbReader.GetInt32(0),
                            EcoLevel = dbReader.GetInt32(1),
                            FuelConsuption = dbReader.GetDouble(2),
                            FuelType = dbReader.GetInt32(3),
                            HorsePower = dbReader.GetInt32(4),
                            NewtonMeter = dbReader.GetInt32(5)
                        };
                    }

                    dbReader.NextResult();

                    while (dbReader.Read())
                    {
                        resultModel.Images.Add(dbReader.GetString(0));
                    }

                    dbReader.Close();
                }

                return resultModel;
            }
            catch (Exception)
            {

            }
            return null;
        }
    }
}
