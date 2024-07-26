using System.Text;

namespace EmployesManageCommon
{
    public static class FileProvider
    {

        public static void Add(string path, string value)
        {
            var writer = new StreamWriter(path, true, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }

        //Перезапись данных
        public static void Set(string path, string value)
        {
            var writer = new StreamWriter(path, false, Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }

        //Получение данных

        public static string Get(string path)
        {
            StreamReader reader = new StreamReader(path);
            {
                string result = reader.ReadToEnd();
                reader.Close();
                return result;
            }
        }

        //Проверяем существует ли такой файл
        public static bool IsExists(string path)
        {
            return File.Exists(path);
        }
    }
}
