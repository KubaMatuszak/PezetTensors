using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZImageTests.Process.Parameters;

namespace ZImageTests.VM.Controls
{
    public static class ParamFactory
    {
        public static List<AParameter_VM> GetParamVMs(List<AGeneralParam> parameters)
        {
            List<AParameter_VM> aParameters = new List<AParameter_VM>();

            foreach(var par in parameters)
            {
                AParameter_VM resAGP_VM = null;
                if (par is DoubleParam)
                {
                    var dp = par as DoubleParam;
                    resAGP_VM = new ContParameter_VM(dp);

                }
                else if (par is IntParam)
                {
                    var ip = par as IntParam;
                    resAGP_VM = new ContParameter_VM(ip);
                }
                else { }

                if(resAGP_VM != null)
                    aParameters.Add(resAGP_VM);

            }


            return aParameters;
        }
    }
}
