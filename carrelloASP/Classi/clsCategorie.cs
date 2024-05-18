using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// using specifiche
using System.Data;
using adoNetWebSQlServer;

namespace carrelloASP.Classi
{
    public class clsCategorie
    {
        // proprietà
        private int pId;
        private string pNome;

        // costruttore
        public clsCategorie(int id, string nome)
        {
            pId = id;
            pNome = nome;
        }

        public clsCategorie(string nome)
        {
            pNome = nome;
        }

        public clsCategorie(int id)
        {
            pId = id;
        }

        public clsCategorie()
        {

        }

        // metodi per recuperare i valori delle proprietà e modificarli
        public int id
        {
            get { return pId; }
            set { pId = value; }
        }

        public string nome
        {
            get { return pNome; }
            set { pNome = value; }
        }

        // metodi collegati al database
        public List<clsCategorie> elenco()
        {
            List<clsCategorie> categorie = new List<clsCategorie>();
            adoNet db = new adoNet();
            DataTable dt = db.eseguiQuery("SELECT * FROM categorie WHERE validita = 1", CommandType.Text);

            foreach (DataRow riga in dt.Rows)
            {
                clsCategorie categoria = new clsCategorie(
                    Convert.ToInt32(riga["id"]),
                    riga["nome"].ToString()
                );
                categorie.Add(categoria);
            }

            return categorie;
        }

        public clsCategorie getCategoria(int id)
        {
            adoNet db = new adoNet();
            DataTable dt = db.eseguiQuery("SELECT * FROM categorie WHERE id = '" + id + "'", CommandType.Text);

            if (dt.Rows.Count != 1)
                return null;

            return new clsCategorie(
                id = Convert.ToInt32(dt.Rows[0]["id"]),
                nome = dt.Rows[0]["nome"].ToString()
            );
        }

        public bool inserisci()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("INSERT INTO categorie (nome) VALUES ('" + pNome + "')", CommandType.Text);

            return ris == 1;
        }

        public bool modifica()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("UPDATE categorie SET nome = '" + pNome + "' WHERE id = '" + pId + "'", CommandType.Text);

            return ris == 1;
        }

        public bool elimina()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("UPDATE categorie SET validita = 0 WHERE id = '" + pId + "'", CommandType.Text);

            return ris == 1;
        }
    }
}