using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServerModManager.Util
{
    class ClassCopy
    {
        //This code from https://stackoverflow.com/questions/1031023/copy-a-class-c-sharp
        public static T DeepCopy<T>(T other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
