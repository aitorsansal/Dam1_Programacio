using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equips;
namespace DAO_Pattern
{
    public class IDAOTeamMySqlImpl : IDAO <Team>

    {
        MySqlConnection cN;
        public IDAOTeamMySqlImpl()
        {
            string strCn = $"datasource=127.0.0.1;port=3306;username=root;password=12345;database=equips;";
            cN = new MySqlConnection(strCn);
            cN.Open();
        }
        public bool Delete(string  id)
        {
            if (!GetAll().Contains(new Team(id)))
                return false;
            var sSql = "DELETE FROM EQUIPS WHERE ABREVIACIO = @ABV";
            MySqlCommand cmd = new MySqlCommand(sSql, cN);

            cmd.Parameters.AddWithValue("@ABV", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            return true;
        }

        public int Count()
        {
            var sSql = "SELECT COUNT(*) FROM EQUIPS";
            MySqlCommand cmd = new(sSql, cN);
            return Convert.ToInt32(cmd.ExecuteScalar().ToString());
        }

        public double Promig()
        {
            var sSql = "SELECT AVG(PRESSUPOST) FROM EQUIPS";
            MySqlCommand cmd = new(sSql, cN);
            return Convert.ToDouble(cmd.ExecuteScalar().ToString());
        }

        public HashSet<Team> GetAll()
        {

            var sSql = "SELECT * FROM EQUIPS";
            MySqlCommand cmd = new(sSql, cN);
            cmd.Prepare();
            MySqlDataReader cursor = cmd.ExecuteReader();
            HashSet<Team> hs = new();
            while (cursor.Read())
            {
                hs.Add(new Team(cursor.GetString("ABREVIACIO"), 
                    cursor.GetString("NOM"), 
                    cursor.GetInt32("PRESSUPOST"),
                    cursor.GetString("LOGOLINK")));
            }
            cursor.Close();
            return hs;

        }


        public Team GetValue(string abv)
        {
            Team equip=null;
            var sSql = "SELECT * FROM EQUIPS WHERE ABREVIACIO = @ABV";
            MySqlCommand cmd = new MySqlCommand(sSql, cN);

            cmd.Parameters.AddWithValue("@ABV", abv);
            
            cmd.Prepare();

            MySqlDataReader cursor = cmd.ExecuteReader() ;
            if (cursor.Read())
            {
                equip = new(cursor.GetString("ABREVIACIO"), 
                    cursor.GetString("NOM"), 
                    cursor.GetInt32("PRESSUPOST"), 
                    cursor.GetString("LOGOLINK"));
            }
            cursor.Close();
            
            return equip;
        }

        public void Save(Team value)
        {
            if (!GetAll().Contains(value))
            {
                var sSql = "INSERT INTO EQUIPS VALUES(@ABV,@NAME,@PRES,@LOGO)";
                MySqlCommand cmd = new MySqlCommand(sSql, cN);

                cmd.Parameters.AddWithValue("@ABV", value.Avb);
                cmd.Parameters.AddWithValue("@NAME", value.Name);
                cmd.Parameters.AddWithValue("@PRES", value.Budget);
                cmd.Parameters.AddWithValue("@LOGO", value.LogoLink);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        
        public void Update(string abreviacio, Team updatedTeam)
        {
            if (GetValue(abreviacio) is not null)
            {
                var sSql = "UPDATE EQUIPS SET NOM = @NOM, PRESSUPOST = @PRES, LOGOLINK = @LOGO WHERE ABREVIACIO = @ABV ";
                MySqlCommand cmd = new MySqlCommand(sSql, cN);

                cmd.Parameters.AddWithValue("@ABV", updatedTeam.Avb);
                cmd.Parameters.AddWithValue("@NAME", updatedTeam.Name);
                cmd.Parameters.AddWithValue("@PRES", updatedTeam.Budget);
                cmd.Parameters.AddWithValue("@LOGO", updatedTeam.LogoLink);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
