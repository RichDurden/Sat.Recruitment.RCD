using System.IO;

namespace Sat.Recruitment.DataAccess
{
    public static class StreamFileHelper
    {
        internal static StreamReader GetStrimReaderFromFile(string path)
        {
            //var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }

        internal static StreamWriter GetStrimWriterFromFile(string path)
        {

            FileStream fileStream = new FileStream(path, FileMode.Append);

            StreamWriter reader = new StreamWriter(fileStream);
            return reader;

        }
    }
}
