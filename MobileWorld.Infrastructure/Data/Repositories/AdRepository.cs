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
                AdInfoSpModel model = new();

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
                    model.Id = dbReader.GetString(0);
                    model.Title = dbReader.GetString(1);
                    model.Price = dbReader.GetDecimal(2);
                    model.PhoneNumber = dbReader.GetString(3);
                    model.Description = dbReader.GetString(4);
                    model.CreatedOn = dbReader.GetDateTime(5);
                    model.RegionName = dbReader.GetString(6);
                    model.Neiborhood = dbReader.GetString(7);
                    model.TownName = dbReader.GetString(8);
                }
                resultModel.AdInfo = model;

            }

            return resultModel;
        }
    }
}
