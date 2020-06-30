using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace Management.Interest.Infrastructure.Data.Query.Tests
{
    public class SpecimenBase<T> where T : class
    {
        public static T Create(string path)
        {
            StringBuilder jsonBuilder = null;

            using (StreamReader reader = new StreamReader(path))
                jsonBuilder = new StringBuilder(reader.ReadToEnd());

            return JsonConvert.DeserializeObject<T>(jsonBuilder.ToString());
        }
    }
}
