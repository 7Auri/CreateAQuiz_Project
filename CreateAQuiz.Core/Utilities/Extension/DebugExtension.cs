using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAQuiz.Core.Utilities.Extension
{
    public static class DebugExtension
    {
        public static string ToJson(this object anObject, bool isWriteConsole = true)
        {
            string json = JsonConvert.SerializeObject(anObject, Formatting.Indented, new JsonSerializerSettings()
            {

                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            });
            if (isWriteConsole)
            {
                Console.WriteLine(json);

            }
            return json;

        }
    }
}
