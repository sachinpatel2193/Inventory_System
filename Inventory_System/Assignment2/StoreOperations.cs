using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment2
{
    class StoreOperations
    {
        /// <summary>
        /// This class will do store operations. For Example, save load, quit, listitems.
        /// </summary>
        public Items[] Item;
        public int count, counter = 0;
        static DirectoryInfo CDI;
        static string path;
         

        public void Help()          //When user press ? or help
        {
            string fnameI = "inventory.txt";
            string fnameM = "management.txt";
            StreamReader srI = new StreamReader(fnameI);
            StreamReader srM = new StreamReader(fnameM);
            int countI = Convert.ToInt32(srI.ReadLine());
            

            Console.WriteLine("Inventory commands:");
            Console.WriteLine("{0, -6} {1,-12} {2,-12} {3,-50}",
                "Cmd", "Command", "Params", "Description");
            for (int i=0;i<countI;i++)
            {
                string line = srI.ReadLine();       //Reads data from inventory.txt
                string[] invent = line.Split(',');
                string cmd = invent[0];
                string command = invent[1];
                string Params= invent[2];
                string Descript = invent[3];
                
                Console.WriteLine("{0, -6} {1,-12} {2,-12} {3,-40}",
                    cmd, command, Params, Descript);
            }
            int countM = Convert.ToInt32(srM.ReadLine());
            Console.WriteLine("Management commands:");
            Console.WriteLine("{0, -6} {1,-12} {2,-12} {3,-50}", 
                "Cmd", "Command", "Params", "Description");
            for (int i = 0; i < countM; i++)
            {
                string line = srM.ReadLine();       //Reads data from management.txt
                string[] manage = line.Split(',');
                string cmd = manage[0];
                string command= manage[1];
                string Params = manage[2];
                string Descript = manage[3];

                Console.WriteLine("{0, -6} {1,-12} {2,-12} {3,-40}",
                    cmd, command, Params, Descript);
            }
        }
        public void listfiles()
        {
            CDI = new DirectoryInfo(".");
            // getting the files in the directory, their names and size
            FileInfo[] fileList = CDI.GetFiles();
            Console.WriteLine("Files in Directory {0}", CDI.FullName);
            for (int i = 0; i < fileList.Length; i++)
            {
                FileInfo file = fileList[i];
                Console.WriteLine("{0}", file.Name);
            }
            Console.WriteLine("Directories in Directory{0}", CDI.FullName);
            DirectoryInfo[] dirList = CDI.GetDirectories();
            for (int i = 0; i < dirList.Length; ++i)
            {
                DirectoryInfo dic = dirList[i];
                Console.WriteLine("{0}", dic.Name);
            }
        }
        public void loaddb(string fname)
        {
            counter++;
            StreamReader sr = new StreamReader(fname);
            count = Convert.ToInt32(sr.ReadLine());     //reading the number of lines in db4.txt file.
            int i = 0;
            Item = new Items[count];           //create array of Items which are in the db 4.txt
            for (i = 0; i < count; i++)
            {
                string line = sr.ReadLine();
                string[] data = line.Split(',');
                string Name = data[0];
                int Code = Convert.ToInt32(data[1]);
                int Rate = Convert.ToInt32(data[2]);
                int Stock = Convert.ToInt32(data[3]);
                int Lead = Convert.ToInt32(data[4]);
                Item[i] = new Items(Name, Code, Rate, Stock, Lead);
            }
            sr.Close();

            string[] file = fname.Split('.');
            Console.WriteLine("Loading file {0}",file[0]);
            Console.WriteLine("{0} records loaded",count);
        }
        public void savedb(string fname)
        {
            using (StreamWriter sw = new StreamWriter(fname))
            {
            for (int i = 0; i < this.count; i++)
            {                                              //writes the data into the text file
                sw.Write(this.Item[i].Name);
                sw.Write(",{0}",this.Item[i].Code);
                sw.Write(",{0}", this.Item[i].Rate);
                sw.Write(",{0}", this.Item[i].Stock);
                sw.WriteLine(",{0}", this.Item[i].Lead);       
            }
            Console.WriteLine("Saving File {0}",fname);
            Console.WriteLine("{0} records saved", this.count);
            }
        }
        public void quit()
        {
            Console.WriteLine("Thank you for using IMS -"+
                " Inventory Management System.");
        }
        public void listitems()
        { 
            if(counter!=0)
            {
                for (int i = 0; i < this.count; i++)
                {                                              //writes the data into the text file
                    Items it = new Items(this.Item[i].Name,this.Item[i].Code,
                        this.Item[i].Rate,this.Item[i].Stock,this.Item[i].Lead);
                    it.PrintHeader();
                    break;
                }
                for (int i = 0; i < this.count; i++)
                {                                              //writes the data into the text file
                    Items it = new Items(this.Item[i].Name, this.Item[i].Code,
                        this.Item[i].Rate, this.Item[i].Stock, this.Item[i].Lead);
                    it.PrintRow();
                }
            }
            else
            {
                Console.WriteLine("Database not loaded. Please use ldb first.");
            }
        }
        public void inc(int code, int qty)
        {
            bool notFound = true;
            for (int i = 0; i < this.count; i++)
            {
                if (code == this.Item[i].Code)
                {
                    Console.WriteLine("Updating inventory");
                    Console.WriteLine("{0}-{1}", this.Item[i].Code, this.Item[i].Name);
                    this.Item[i].Stock = this.Item[i].Stock + qty;
                    Console.WriteLine("Stock:{0}", this.Item[i].Stock);
                    Console.WriteLine("Consumption-rate:{0}", this.Item[i].Rate);
                    Console.WriteLine("Lead-time:{0}", this.Item[i].Lead);
                    notFound = false;
                    break;
                }
            }
             if(notFound)
                {
                    Console.WriteLine("Code {0} is not found.", code);
                }   
        }
        public void dec(int code,int qty)
        {
            bool notFound = true;
            for(int i=0;i<this.count;i++)
            {
                
                if (code == this.Item[i].Code)
                {
                    Console.WriteLine("Updating inventory");
                    Console.WriteLine("{0}-{1}", this.Item[i].Code, this.Item[i].Name);
                    if (qty > this.Item[i].Stock)
                    {
                        this.Item[i].Stock = 0;
                    }
                    else
                    {
                        this.Item[i].Stock = this.Item[i].Stock - qty;
                    }
                    Console.WriteLine("Stock:{0}", this.Item[i].Stock);
                    Console.WriteLine("Consumption-rate:{0}", this.Item[i].Rate);
                    Console.WriteLine("Lead-time:{0}", this.Item[i].Lead);
                    notFound = false;
                    break;
                }
            }
            if(notFound)
            {
                Console.WriteLine("Code {0} is not found.", code);
            }
        }
        public void low()
        {
            bool found = false ;
            for (int i = 0; i < this.count; i++)
            {
                if (this.Item[i].Rate * this.Item[i].Lead > this.Item[i].Stock)
                found = true;
            }
            if (found == true)
            {
                Item[0].PrintHeader();
                for(int i=0;i<this.count;i++)
                {
                    if (this.Item[i].Rate * this.Item[i].Lead > this.Item[i].Stock)
                    {
                        this.Item[i].PrintRow();
                    }
                }
            }
            else
            {
                Console.WriteLine("No item is low in stock");
            }
        }
        public void prek(int k)
        {
            int preQuantity =0;
            for(int i=0;i<this.count;i++)
            {
                this.Item[i].PrintHeaderUnit();
                break;
            }
            for(int i=0;i<this.count;i++)
            {
                if (this.Item[i].Lead < k)
                {
                    preQuantity = (this.Item[i].Rate * k) - this.Item[i].Stock;
                    if (preQuantity > 0)
                    {
                        Console.WriteLine("{0,-20}{1,6}{2,6}{3,7}{4,6}{5,6}", 
                            this.Item[i].Name,this.Item[i].Code,this.Item[i].Rate,
                            this.Item[i].Stock,this.Item[i].Lead,preQuantity);
                    }
                }
                else
                {
                    preQuantity=(this.Item[i].Rate*this.Item[i].Lead)-this.Item[i].Stock;
                    if (preQuantity > 0)
                    {
                        Console.WriteLine("{0,-20}{1,6}{2,6}{3,7}{4,6}{5,6}",
                            this.Item[i].Name, this.Item[i].Code, this.Item[i].Rate,
                              this.Item[i].Stock, this.Item[i].Lead, preQuantity);
                    }
                }
            }
        }

    }
}
