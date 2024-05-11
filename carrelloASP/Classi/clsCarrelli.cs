using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// using specifiche
using System.Data;
using adoNetWebSQlServer;

namespace carrelloASP.Classi
{
    public class clsCarrelli
    {
        // proprietà
        private int pId;
        private int pQuantita;
        private int pProdotto_id;
        private int pUser_id;
        private bool pValidita;

        // costruttore
        public clsCarrelli(int id, int quantita, int prodotto_id, int user_id, bool validita)
        {
            pId = id;
            pQuantita = quantita;
            pProdotto_id = prodotto_id;
            pUser_id = user_id;
            pValidita = validita;
        }

        public clsCarrelli(int user_id)
        {
            pUser_id = user_id;
        }

        public clsCarrelli(int prodotto_id, int user_id)
        {
            pProdotto_id = prodotto_id;
            pUser_id = user_id;
        }

        public clsCarrelli(int prodotto_id, int user_id, int quantita)
        {
            pProdotto_id = prodotto_id;
            pUser_id = user_id;
            pQuantita = quantita;
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

        public bool validita
        {
            get { return pValidita; }
            set { pValidita = value; }
        }

        // metodi collegati al database
        public bool inserisci()
        {
            adoNet db = new adoNet();
            
            int ris = db.eseguiNonQuery("INSERT INTO carrelli (quantita, prodotto_id, user_id, validita) VALUES (" + pQuantita + ", " + pProdotto_id + ", " + pUser_id + ", 1)", CommandType.Text);

            return ris == 1;
        }

        public bool aggiorna()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("UPDATE carrelli SET quantita = " + pQuantita + " WHERE prodotto_id = " + pProdotto_id + " AND user_id = " + pUser_id, CommandType.Text);

            return ris == 1;
        }

        public bool elimina()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("UPDATE carrelli SET validita = 0 WHERE prodotto_id = " + pProdotto_id + " AND user_id = " + pUser_id, CommandType.Text);

            return ris == 1;
        }

        public bool acquista()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("DELETE FROM carrelli WHERE user_id = " + pUser_id, CommandType.Text);

            return ris == 1;
        }

        public List<clsCarrelli> elenco()
        {
            List<clsCarrelli> carrelli = new List<clsCarrelli>();
            adoNet db = new adoNet();
            DataTable dt = db.eseguiQuery("SELECT * FROM carrelli WHERE user_id = " + pUser_id + " AND validita = 1", CommandType.Text);

            foreach (DataRow riga in dt.Rows)
            {
                clsCarrelli carrello = new clsCarrelli(
                    Convert.ToInt32(riga["id"]),
                    Convert.ToInt32(riga["quantita"]),
                    Convert.ToInt32(riga["prodotto_id"]),
                    Convert.ToInt32(riga["user_id"]),
                    Convert.ToBoolean(riga["validita"])
                );
                carrelli.Add(carrello);
            }

            return carrelli;
        }
    }
}