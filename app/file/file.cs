using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.file
{
    public class file
    {
        public static List<string> readFile(string filename)
        {
            const Int32 BufferSize = 128;
            List<string> content = new List<string>(); 
            using (var fileStream = File.OpenRead(filename))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    content.Add(line); 
                }
            }
            return content; 
        }
    }
}
