using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISS_Client
{
    class DBConnector
    {

        private static DBConnector instance;
        private MySqlConnection SpamCon { get; set; }
        private MySqlConnection EnronCon { get; set; }

        private DBConnector()
        {
            //enron
            //con = new MySqlConnection("Server=localhost;Database=enron;Uid=root;Pwd=1234");
            //scam
            SpamCon = new MySqlConnection("Server=localhost;Database=scam;Uid=root;Pwd=1234");
            EnronCon = new MySqlConnection("Server=localhost;Database=enron;Uid=root;Pwd=1234");
            try
            {
                EnronCon.Open();
                Console.WriteLine("Great Success");
                EnronCon.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static DBConnector Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBConnector();
                }
                return instance;
            }
        }

        public static DBConnector getInstance()
        {
            if (instance == null)
            {
                instance = new DBConnector();
            }
            else
            {
                return instance;
            }
            return instance;
        }


        public List<string> TrainSpam()
        {
            List<string> results = new List<string>();

            //urgent command
            //MySqlCommand comand = new MySqlCommand("Select body from message where subject like '%urgent%' limit 0,100",con);

            //work
            MySqlCommand comand = new MySqlCommand("Select Column2 from book1 limit 1000", SpamCon);

           
            SpamCon.Open();
            using(MySqlDataReader reader = comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var result = reader["Column2"];
                    results.Add(result.ToString());
                }
                

            }
            SpamCon.Close();
            //results.ForEach(i => Console.WriteLine("{0}\t", i));
            return results;
        }
        public List<string> TrainWork()
        {
            List<string> results = new List<string>();

            //urgent command
            MySqlCommand comand = new MySqlCommand("Select body from message where subject NOT like '%urgent%' OR '%important%' limit 1000", EnronCon);
            EnronCon.Open();
            using (MySqlDataReader reader = comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var result = reader["body"];
                    results.Add(result.ToString());
                }


            }
            EnronCon.Close();
            //results.ForEach(i => Console.WriteLine("{0}\t", i));
            return results;
        }
        public List<string> TrainUrgent()
        {
            List<string> results = new List<string>();

            MySqlCommand comand = new MySqlCommand("Select body from message where subject like '%urgent%' OR '%important%' limit 1000", EnronCon);


            EnronCon.Open();
            using (MySqlDataReader reader = comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var result = reader["body"];
                    results.Add(result.ToString());
                }


            }
            EnronCon.Close();
            //results.ForEach(i => Console.WriteLine("{0}\t", i));
            return results;
        }
        public List<string> TrainMeeting()
        {
            List<string> results = new List<string>();

            MySqlCommand comand = new MySqlCommand("Select body from message where subject like '%meeting%' limit 1000", EnronCon);


            EnronCon.Open();
            using (MySqlDataReader reader = comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var result = reader["body"];
                    results.Add(result.ToString());
                }


            }
            EnronCon.Close();
            //results.ForEach(i => Console.WriteLine("{0}\t", i));
            return results;
        }

        public List<string> TrainContract()
        {
            List<string> results = new List<string>();

            MySqlCommand comand = new MySqlCommand("Select body from message where subject like '%contract%' limit 1000", EnronCon);


            EnronCon.Open();
            using (MySqlDataReader reader = comand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var result = reader["body"];
                    results.Add(result.ToString());
                }


            }
            EnronCon.Close();
            //results.ForEach(i => Console.WriteLine("{0}\t", i));
            return results;
        }



    }
}
