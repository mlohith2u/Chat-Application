using Application.Dal.DataModel;
using Application.Helpers.BiometricsHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bal.Biometrics
{
    public static class BiometricsRepository
    {
        static ChatAppEntities db;
        static BiometricsRepository()
        {
            db = new ChatAppEntities();
        }

       
    }
}
