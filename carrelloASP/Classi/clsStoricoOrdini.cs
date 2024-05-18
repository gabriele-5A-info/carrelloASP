using adoNetWebSQlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace carrelloASP.Classi
{
    public class clsStoricoOrdini
    {
        // proprietà
        private int pId;
        private int pQuantita;
        private int pProdotto_id;
        private int pUser_id;
        private DateTime pData;
        private bool pValidita;

        // costruttore
        public clsStoricoOrdini(int id, int quantita, int prodotto_id, int user_id, DateTime data, bool validita)
        {
            pId = id;
            pQuantita = quantita;
            pProdotto_id = prodotto_id;
            pUser_id = user_id;
            pData = data;
            pValidita = validita;
        }

        public clsStoricoOrdini(int user_id)
        {
            pUser_id = user_id;
        }

        public clsStoricoOrdini(int prodotto_id, int user_id)
        {
            pProdotto_id = prodotto_id;
            pUser_id = user_id;
        }

        // metodi per recuperare i valori delle proprietà e modificarli
        public int id
        {
            get { return pId; }
            set { pId = value; }
        }

        public int quantita
        {
            get { return pQuantita; }
            set { pQuantita = value; }
        }

        public int prodotto_id
        {
            get { return pProdotto_id; }
            set { pProdotto_id = value; }
        }

        public int user_id
        {
            get { return pUser_id; }
            set { pUser_id = value; }
        }

        public DateTime data
        {
            get { return pData; }
            set { pData = value; }
        }

        public bool validita
        {
            get { return pValidita; }
            set { pValidita = value; }
        }

        // metodi collegati al database
        public bool inserisci(List<clsCarrelli> carrello)
        {
            adoNet db = new adoNet();

            foreach (clsCarrelli c in carrello)
            {
                string sql = "INSERT INTO storico_ordini (quantita, prodotto_id, user_id, data) VALUES ('" + c.quantita + "', '" + c.prodotto_id + "', '" + c.user_id + "', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                int ris = db.eseguiNonQuery(sql, CommandType.Text);
                if(ris == 0)
                    return false;
            }

            return true;
        }

        public List<clsStoricoOrdini> getOrdini()
        {
            adoNet db = new adoNet();
            DataTable dt = db.eseguiQuery("SELECT * FROM storico_ordini WHERE user_id = " + pUser_id + "AND validita = 1 ORDER BY data DESC", CommandType.Text);

            List<clsStoricoOrdini> ordini = new List<clsStoricoOrdini>();

            foreach (DataRow riga in dt.Rows)
            {
                clsStoricoOrdini ordine = new clsStoricoOrdini(Convert.ToInt32(riga["id"]), Convert.ToInt32(riga["quantita"]), Convert.ToInt32(riga["prodotto_id"]), Convert.ToInt32(riga["user_id"]), Convert.ToDateTime(riga["data"]), Convert.ToBoolean(riga["validita"]));
                ordini.Add(ordine);
            }

            return ordini;
        }

        public bool elimina()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("UPDATE storico_ordini SET validita = 0 WHERE user_id = " + pUser_id, CommandType.Text);

            return ris == 1;
        }
    }
}