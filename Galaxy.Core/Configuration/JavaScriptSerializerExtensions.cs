using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace System.Web.Script.Serialization
{
    public static class JavaScriptSerializerExtensions
    {
        public static T DeserializeFrom<T>(this JavaScriptSerializer obj, string filepath)
        {
            using (var streamReader = new StreamReader(filepath))
            {
                var json = streamReader.ReadToEnd();
                return obj.Deserialize<T>(json);
            }
        }
    }
}
