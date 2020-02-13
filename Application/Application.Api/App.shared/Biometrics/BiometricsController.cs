using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Application.Dal;
using Application.Dal.DataModel;
using Application.Helpers.BiometricsHelpers;
using Application.Bal.Biometrics;

namespace Application.Api.App.shared.Biometrics
{
    public class BiometricsController : ApiController
    {
        public IHttpActionResult PostBiometricsAuthentication(BiometricDetails biometrics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            A_U_Biometrics eld = new A_U_Biometrics
            {
                ID = biometrics.ID,
                TemplateOne = biometrics.Templateone,
                TemplateTwo = biometrics.Templatetwo
            };

            BiometricsRepository.saveBiometrics(eld);
            return CreatedAtRoute("DefaultApi", new { id = biometrics.ID }, biometrics);
        }
    }
}
