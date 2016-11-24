using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //required

namespace NetTWO_RandomFile
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream f = new FileStream(@"C:\Users\ryang\Desktop\.random.dat", 
                FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader r = new BinaryReader(f);
            BinaryWriter w = new BinaryWriter(f);

            string record, name;
            int id;
            double amount;
            long key; //when reading and writing the byte address you must use a 'long' for the byte address
            id = 1;
            name = "bob";
            amount = 100.00;

            //write a record
            record = string.Format("{0,2}{1,-18}{2,10:f2}", id, name, amount);
            //above{0,2} means column one (zero based) is 2 digits...-18 is left adjust...f2 is two decimal points
            key = f.Length;     //required to move to next record
            f.SetLength(key);   //required to move to next record
            f.Position = key;   //required to move to next record
            w.Write(record);

            //write another record
            id = 2;
            name = "mary";
            amount = 200.00;
            record = string.Format("{0,2}{1,-18}{2,10:f2}", id, name, amount);
            //above{0,2} means column one (zero based) is 2 digits...-18 is left adjust...f2 is two decimal points
            key = f.Length;     //required to move to next record
            f.SetLength(key);   //required to move to next record
            f.Position = key;
            w.Write(record);

            //write another record
            id = 3;
            name = "ed";
            amount = 300.00;
            record = string.Format("{0,2}{1,-18}{2,10:f2}", id, name, amount);
            //above{0,2} means column one (zero based) is 2 digits...-18 is left adjust...f2 is two decimal points
            key = f.Length;     //required to move to next record
            f.SetLength(key);   //required to move to next record
            f.Position = key;   //required to move to next record
            w.Write(record);

            //Now Read Back the file...
            //read a record
            int record_number;
            record_number = 2;
            key = (record_number - 1) * (record.Length + 1);
            f.Position = key;
            record = r.ReadString();
            id = Convert.ToInt32(record.Substring(0, 2));
            name = record.Substring(2, 18);
            amount = Convert.ToDouble(record.Substring(20, 10));
            Console.WriteLine(id + " " + name + " " + amount);
            //to change record #2 you must do the Position command again
            //before you do a write
            name = "marilyn";
            f.Position = key;
            record = string.Format("{0,2}{1,-18}{2,10:f2}", id, name, amount);
            w.Write(record);

            r.Close();
            w.Close();
            f.Close();

            Console.ReadLine();
        }
    }
}
