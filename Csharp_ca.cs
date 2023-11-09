using MySql.Data.MySqlClient;
using WebApplication3.Models;
using MySql.Data;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;
namespace WebApplication3
{
    public class Csharp_ca
    {
        public string ConnectionString { get; set; }
        public Csharp_ca(String ConnectionStriong)//쿼리문자를 생성자로 넘겨 서버연결
        {
            ConnectionString = ConnectionStriong;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);//
        }
        public List<CultureAssets> GetCa()
        {
            List<CultureAssets> list = new List<CultureAssets>();
            string SQL = "select * from assets ";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CultureAssets()
                        {//C#에서는 독특하게 중괄호안데 데이터를 넣어서 초기화 해줄수있게 만들어줌 
                           
                            ca_type = reader["ca_type"].ToString(),
                            ca_name = reader["ca_name"].ToString(),
                            ca_addr = reader["ca_addr"].ToString(),
                            ca_period = reader["ca_period"].ToString(),
                            ca_date = Convert.ToDateTime(reader["ca_date"]),
                            ca_detail = reader["ca_detail"].ToString()
                        });

                    }
                }
                conn.Close();
            }
            return list;
        }
        public CultureAssets SelectCa(string ca_name)//Detail 
        {
            CultureAssets emp = new CultureAssets();
            String SQL = "select * from assets where ca_name= '" + ca_name + "'";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        emp.ca_type = reader["ca_type"].ToString();
                        emp.ca_name = reader["ca_name"].ToString();
                        emp.ca_addr = reader["ca_addr"].ToString();
                        emp.ca_period = reader["ca_period"].ToString();
                        emp.ca_date = Convert.ToDateTime(reader["ca_date"]);
                        emp.ca_detail = reader["ca_detail"].ToString();

                    }
                }
                conn.Close();
            }
            return emp;
        }
        public CultureAssets FindCa(string whatever)// 특정 문자 포함 검색 , 아직진행중 !!!!
        {
            CultureAssets emp = new CultureAssets();
            String SQL = "select * from assets where ca_name= '" + whatever + "'";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        emp.ca_type = reader["ca_type"].ToString();
                        emp.ca_name = reader["ca_name"].ToString();
                        emp.ca_addr = reader["ca_addr"].ToString();
                        emp.ca_period = reader["ca_period"].ToString();
                        emp.ca_date = Convert.ToDateTime(reader["ca_date"]);
                        emp.ca_detail = reader["ca_detail"].ToString();

                    }
                }
                conn.Close();
            }
            return emp;
        }
    }
    
}

