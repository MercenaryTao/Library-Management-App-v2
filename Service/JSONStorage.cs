using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;
using Library_Management_App_v2.Model;
using System.Windows.Forms;

namespace Library_Management_App_v2.Controller
{
    internal class JSONStorage
    {
        public static BindingList<Model.Book> books = new BindingList<Book>();
      
        public static void SaveData<T>(BindingList<T> data, string filePath)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                System.IO.File.WriteAllText(filePath, jsonData);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while saving data to the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public  BindingList<Model.Book> loadData (string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                new BindingList<Model.Book>();
            }
            string jsonData = System.IO.File.ReadAllText(filePath);
       
          return books =  JsonConvert.DeserializeObject<BindingList<Model.Book>>(jsonData);
          

        }
     
   
    }
}
