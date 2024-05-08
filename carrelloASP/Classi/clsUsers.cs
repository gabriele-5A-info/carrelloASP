using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// using specifiche
using System.Data;
using adoNetWebSQlServer;

namespace carrelloASP.Classi
{
    public class clsUsers
    {
        // proprietà
        private int pId;
        private string pUsername;
        private string pPassword;
        private string pEmail;
        private string pRole;

        // costruttore
        public clsUsers(int id, string username, string password, string email, string role)
        {
            pId = id;
            pUsername = username;
            pPassword = password;
            pEmail = email;
            pRole = role;
        }

        public clsUsers(int id, string username, string email, string role)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.role = role;
        }

        public clsUsers(string username, string password, string email, string role)
        {
            pUsername = username;
            pPassword = password;
            pEmail = email;
            pRole = role;
        }

        public clsUsers(string email, string password)
        {
            pEmail = email;
            pPassword = password;
        }

        public clsUsers()
        {

        }

        // metodi per recuperare i valori delle proprietà e modificarli
        public int id
        {
            get { return pId; }
            set { pId = value; }
        }

        public string username
        {
            get { return pUsername; }
            set { pUsername = value; }
        }

        public string password
        {
            get { return pPassword; }
            set { pPassword = value; }
        }

        public string email
        {
            get { return pEmail; }
            set { pEmail = value; }
        }

        public string role
        {
            get { return pRole; }
            set
            {
                if(value != "admin" && value != "user" && value != "fornitore")
                    throw new Exception("Ruolo non valido");
                pRole = value;
            }
        }

        // metodi collegati al database
        public bool inserisci()
        {
            adoNet db = new adoNet();

            int ris = db.eseguiNonQuery("INSERT INTO users (username, password, email, role) VALUES ('" + pUsername + "', '" + pPassword + "', '" + pEmail + "', '" + pRole + "')", CommandType.Text);

            return ris == 1;
        }

        public clsUsers getUser()
        {
            adoNet db = new adoNet();

            DataTable dt = db.eseguiQuery("SELECT * FROM users WHERE email = '" + pEmail + "' AND password = '" + pPassword + "' AND validita = 1", CommandType.Text);

            if (dt.Rows.Count != 1)
                return null;

            return new clsUsers(
                id = Convert.ToInt32(dt.Rows[0]["id"]),
                username = dt.Rows[0]["username"].ToString(),
                password = dt.Rows[0]["password"].ToString(),
                email = dt.Rows[0]["email"].ToString(),
                role = dt.Rows[0]["role"].ToString()
            );
        }

        public List<clsUsers> elencoFornitori()
        {
            adoNet db = new adoNet();

            DataTable dt = db.eseguiQuery("SELECT * FROM users WHERE role = 'fornitore' AND validita = 1", CommandType.Text);

            List<clsUsers> fornitori = new List<clsUsers>();

            foreach (DataRow riga in dt.Rows)
            {
                clsUsers fornitore = new clsUsers(
                    id = Convert.ToInt32(riga["id"]),
                    username = riga["username"].ToString(),
                    email = riga["email"].ToString(),
                    role = riga["role"].ToString()
                );

                fornitori.Add(fornitore);
            }

            return fornitori;
        }
    }
}