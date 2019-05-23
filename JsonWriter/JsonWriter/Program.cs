using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class data
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public bool GetCredential1 { get; set; }

    public bool GetCredential2 { get; set; }

    public bool GetCredential3 { get; set; }
}
namespace JsonWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "C:/Users/Ryan's Computer/source/repos/JsonExample.json";
            List<data> _data = new List<data>();
            _data.Add(new data()
            {
                UserName = "randor12",
                Password = "password",
                GetCredential1 = true,
                GetCredential2 = true,
                GetCredential3 = true
            });
            _data.Add(new data()
            {
                UserName = "name2",
                Password = "password2",
                GetCredential1 = false,
                GetCredential2 = true,
                GetCredential3 = false
            });
            
            string json = JsonConvert.SerializeObject(_data, Formatting.Indented);

            int count = 1;

            string conversion = json;

            while (json.Contains("{"))
            {
                int index = json.IndexOf("{");
                if (index != 0)
                {
                    conversion = "{" + json.Substring(1, index - 1) + "\"" + count.ToString() + "\": " 
                        + json.Substring(index, json.Length - index - 1) + "}";
                    json = json.Substring(0, index) + "\"" + count.ToString() + "\" : *" + json.Substring(index + 1);

                    for (int i = 0; i < conversion.Length; i++)
                    {
                        if (conversion[i].Equals("*"))
                        {
                            conversion = conversion.Substring(0, i) + "{" + conversion.Substring(i + 1);
                        }
                    }

                }
                count++;
            }

            System.IO.File.WriteAllText(file, conversion);
        }
    }
}
