using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// using specifiche
using System.Data;
using adoNetWebSQlServer;

namespace carrelloASP.Classi
{
    public class clsProdotti
    {
        // proprietà
        private int pId;
        private string pNome;
        private string pDescrizione;
        private string pPrezzo;
        private int pQuantita;
        private string pImmagine;
        private int pCategoria_id;
        private int pFornitore_id;
        private bool pValidita;

        // costruttore
        public clsProdotti(int id, string nome, string descrizione, string prezzo, int quantita, string immagine, int categoria_id, int fornitore_id, bool validita)
        {
            pId = id;
            pNome = nome;
            pDescrizione = descrizione;
            pPrezzo = prezzo;
            pQuantita = quantita;
            pImmagine = immagine;
            pCategoria_id = categoria_id;
            pFornitore_id = fornitore_id;
            pValidita = validita;
        }

        public clsProdotti(string nome, string descrizione, string prezzo, int quantita, string immagine, int categoria_id, int fornitore_id, bool validita)
        {
            pNome = nome;
            pDescrizione = descrizione;
            pPrezzo = prezzo;
            pQuantita = quantita;
            pImmagine = immagine;
            pCategoria_id = categoria_id;
            pFornitore_id = fornitore_id;
            pValidita = validita;
        }

        public clsProdotti(string nome, string descrizione, string prezzo, int quantita, string immagine)
        {
            pNome = nome;
            pDescrizione = descrizione;
            pPrezzo = prezzo;
            pQuantita = quantita;
            pImmagine = immagine;
        }

        public clsProdotti(string nome)
        {
            pNome = nome;
        }

        public clsProdotti(int id)
        {
            pId = id;
        }

        public clsProdotti()
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

        public string descrizione
        {
            get { return pDescrizione; }
            set { pDescrizione = value; }
        }

        public string prezzo
        {
            get { return pPrezzo; }
            set { pPrezzo = value; }
        }

        public int quantita
        {
            get { return pQuantita; }
            set { pQuantita = value; }
        }

        public string immagine
        {
            get { return pImmagine; }
            set { pImmagine = value; }
        }

        public int categoria_id
        {
            get { return pCategoria_id; }
            set { pCategoria_id = value; }
        }

        public int fornitore_id
        {
            get { return pFornitore_id; }
            set { pFornitore_id = value; }
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

            int ris = db.eseguiNonQuery("INSERT INTO prodotti (nome, descrizione, prezzo, quantita, immagine, categoria_id, fornitore_id, validita) VALUES ('" + pNome + "', '" + pDescrizione + "', '" + pPrezzo + "', '" + pQuantita + "', '" + pImmagine + "', '" + pCategoria_id + "', '" + pFornitore_id + "', '" + pValidita + "')", CommandType.Text);

            return ris == 1;
        }

        public bool modifica()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("UPDATE prodotti SET nome = '" + pNome + "', descrizione = '" + pDescrizione + "', prezzo = '" + pPrezzo.Replace(".", ",") + "', quantita = '" + pQuantita + "', immagine = '" + pImmagine + "', categoria_id = '" + pCategoria_id + "', fornitore_id = '" + pFornitore_id + "', validita = '" + pValidita + "' WHERE id = '" + pId + "'", CommandType.Text);

            return ris == 1;
        }

        public bool elimina()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("UPDATE prodotti SET validita = 0 WHERE id = '" + pId + "'", CommandType.Text);

            return ris == 1;
        }

        public bool ripristina()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("UPDATE prodotti SET validita = 1 WHERE id = '" + pId + "'", CommandType.Text);

            return ris == 1;
        }

        public clsProdotti getProdotto()
        {
            adoNet db = new adoNet();

            DataTable dt = db.eseguiQuery("SELECT * FROM prodotti WHERE id = '" + pId + "'", CommandType.Text);

            if (dt.Rows.Count != 1)
                return null;

            return new clsProdotti(
                id = Convert.ToInt32(dt.Rows[0]["id"]),
                nome = dt.Rows[0]["nome"].ToString(),
                descrizione = dt.Rows[0]["descrizione"].ToString(),
                prezzo = dt.Rows[0]["prezzo"].ToString(),
                quantita = Convert.ToInt32(dt.Rows[0]["quantita"]),
                immagine = dt.Rows[0]["immagine"].ToString(),
                categoria_id = Convert.ToInt32(dt.Rows[0]["categoria_id"]),
                fornitore_id = Convert.ToInt32(dt.Rows[0]["fornitore_id"]),
                validita = Convert.ToBoolean(dt.Rows[0]["validita"].ToString())
            );
        }

        public clsProdotti getProdotto(int id)
        {
            adoNet db = new adoNet();

            DataTable dt = db.eseguiQuery("SELECT * FROM prodotti WHERE id = '" + id + "'", CommandType.Text);

            if (dt.Rows.Count != 1)
                return null;

            return new clsProdotti(
                id = Convert.ToInt32(dt.Rows[0]["id"]),
                nome = dt.Rows[0]["nome"].ToString(),
                descrizione = dt.Rows[0]["descrizione"].ToString(),
                prezzo = dt.Rows[0]["prezzo"].ToString(),
                quantita = Convert.ToInt32(dt.Rows[0]["quantita"]),
                immagine = dt.Rows[0]["immagine"].ToString(),
                categoria_id = Convert.ToInt32(dt.Rows[0]["categoria_id"]),
                fornitore_id = Convert.ToInt32(dt.Rows[0]["fornitore_id"]),
                validita = Convert.ToBoolean(dt.Rows[0]["validita"])
            );
        }

        public DataTable elenco(int fornitore_id, bool annullate)
        {
            adoNet db = new adoNet();

            if (annullate)
                return db.eseguiQuery("SELECT * FROM prodotti WHERE fornitore_id = '" + fornitore_id + "'", CommandType.Text);
            else
                return db.eseguiQuery("SELECT * FROM prodotti WHERE fornitore_id = '" + fornitore_id + "' AND validita = 1", CommandType.Text);
        }

        public DataTable elenco(bool annullate)
        {
            adoNet db = new adoNet();

            if(annullate)
                return db.eseguiQuery("SELECT * FROM prodotti", CommandType.Text);
            else
                return db.eseguiQuery("SELECT * FROM prodotti WHERE validita = 1", CommandType.Text);
        }

        public List<clsProdotti> elencoLista(bool annullate)
        {
            adoNet db = new adoNet();
            DataTable dt = new DataTable();

            dt = elenco(annullate);

            List<clsProdotti> lista = new List<clsProdotti>();

            foreach (DataRow riga in dt.Rows)
            {
                clsProdotti prodotto = new clsProdotti(
                    id = Convert.ToInt32(riga["id"]),
                    nome = riga["nome"].ToString(),
                    descrizione = riga["descrizione"].ToString(),
                    prezzo = riga["prezzo"].ToString(),
                    quantita = Convert.ToInt32(riga["quantita"]),
                    immagine = riga["immagine"].ToString(),
                    categoria_id = Convert.ToInt32(riga["categoria_id"]),
                    fornitore_id = Convert.ToInt32(riga["fornitore_id"]),
                    validita = Convert.ToBoolean(riga["validita"])
                );

                lista.Add(prodotto);
            }

            return lista;
        }
    }
}