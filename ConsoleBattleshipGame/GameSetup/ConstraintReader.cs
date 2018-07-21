using System;
using System.IO;
using System.Text;

namespace ConsoleBattlefield.GameSetup
{
    public class ConstraintReader : IConstraintReader
    {
        public string ReadConstraintsFromJSON(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
            {
                throw new ArgumentNullException(nameof(filepath));
            }

            var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
