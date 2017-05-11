using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerate
{
    public class GenerateCode
    {
        public bool GenerateClassCode(List<DataTable> dts, string nameSpace, string folderPath)
        {
            GenerateDynamicClass gc = new GenerateDynamicClass();

            gc.GenerateAssembly(dts.ToArray(), string.Empty);

            Assembly ass = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "DynamicAssemblyForClass.dll");

            FileAttributes attr = File.GetAttributes(folderPath);
            File.SetAttributes(folderPath, attr & ~FileAttributes.ReadOnly);
     
            foreach(Type type in ass.GetTypes())
            {
                Console.SetOut(new StreamWriter(new FileStream(Path.Combine(folderPath, type.Name + ".cs"), FileMode.Create)));
                Console.WriteLine("namespace " + nameSpace);
                Console.WriteLine("{");
                
                Console.WriteLine("\tusing RMS.Utility;");
                Console.WriteLine("\t[DataTableName(\"" + type.Name.ToLower() +"\", ContainsIdentification = false)]");
                Console.WriteLine("\tpublic class "+ type.Name);
                Console.WriteLine("\t{");
                type.GetProperties().ToList().ForEach(p =>
                {
                    if(p.Name.ToLower().Equals("id"))
                    {
                        Console.WriteLine("\t\t[TableColumn(\"" + p.Name.ToLower() + "\",IsPrimaryKey=true,IsIdentification=false)]");
                        Console.WriteLine("\t\tpublic " + p.PropertyType + " " + p.Name + Environment.NewLine + "\t\t{" + Environment.NewLine + "\t\t\tget;" + Environment.NewLine + "\t\t\tset;" + Environment.NewLine + "\t\t}");
                    }
                    else
                    {
                        Console.WriteLine("\t\tpublic " + p.PropertyType + " " + p.Name + Environment.NewLine + "\t\t{" + Environment.NewLine + "\t\t\tget;" + Environment.NewLine + "\t\t\tset;" + Environment.NewLine + "\t\t}");
                    }
                });
                Console.WriteLine("\t}");
                Console.WriteLine("}");
                Console.Out.Flush();
            }

            Console.Out.Close();

            return true;
        }
    }
}
