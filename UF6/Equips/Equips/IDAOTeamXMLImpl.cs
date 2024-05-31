using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;

namespace DAO_Pattern
{
    public class IDAOTeamXMLImpl : IDAO<Team>
    {
        string xmlFile = "EQUIPS.XML";
        public bool Delete(string id)
        {
            XDocument docEquips = XDocument.Load(xmlFile);
            XElement e = docEquips.XPathSelectElement($"/EQUIPS/EQUIP[ABREVIACIO='{id}']");
            if (e is null) return false;
            e.Remove();
            docEquips.Save(xmlFile);
            return true;

        }

        public int Count()
        {
            XDocument docEquips = XDocument.Load(xmlFile);
            return Convert.ToInt32(docEquips.XPathEvaluate("count(/EQUIPS/EQUIP)").ToString());
        }

        public double Promig()
        {
            XDocument docEquips = XDocument.Load(xmlFile);
            return docEquips.XPathSelectElements("/EQUIPS/EQUIP").
                Select(e => double.Parse(e.Element("PRESSUPOST").Value)).
                ToList().Average();
        }

        public HashSet<Team> GetAll()
        {
            XDocument docEquips = XDocument.Load(xmlFile);
            var all = docEquips.XPathSelectElements($"/EQUIPS/EQUIP");
            HashSet<Team> allTeams = new();
            foreach (var e in all)
            {
                allTeams.Add(new Team(e.Element("ABREVIACIO").Value, e.Element("NOM").Value, Convert.ToInt32(e.Element("PRESSUPOST").Value), e.Element("LOGO").Value));
            }

            return allTeams;
        }

        public Team GetValue(string abv)
        {
            Team eq = null;
            XDocument docEquips = XDocument.Load(xmlFile);

            XElement e = docEquips.XPathSelectElement($"/EQUIPS/EQUIP[ABREVIACIO='{abv}']");
           
            if (e!=null) 
                eq = new Team(e.Element("ABREVIACIO").Value, e.Element("NOM").Value, Convert.ToInt32(e.Element("PRESSUPOST").Value), e.Element("LOGO").Value);
            return eq;
        }

        public void Save(Team value)
        {
            var allTeams = GetAll();
            if (!allTeams.Contains(value))
            {
                XDocument doc = XDocument.Load(xmlFile);
                XElement root = new XElement("EQUIP");
                root.Add(new XElement("ABREVIACIO", value.Avb));
                root.Add(new XElement("NOM", value.Name));
                root.Add(new XElement("PRESSUPOST", value.Budget));
                root.Add(new XElement("LOGO", value.LogoLink));
                doc.Element("EQUIPS").Add(root);
                doc.Save(xmlFile);
            }
        }

        public void Update(string abreviacio, Team updatedTeam)
        {
            var doc = XDocument.Load(xmlFile);
            var team = doc.XPathSelectElement($"/EQUIPS/EQUIP[ABREVIACIO='{abreviacio}']");
            team.SetElementValue("NAME", updatedTeam.Name);
            team.SetElementValue("PRESSUPOST", updatedTeam.Budget);
            team.SetElementValue("LOGO", updatedTeam.LogoLink);
            doc.Save(xmlFile);
        }
    }
}
