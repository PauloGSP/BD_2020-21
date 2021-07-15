using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace TestesOnline
{
    class Pessoa
    {
        private int NumCC;
        private string Email;
        private Nullable<int> Telemovel;
        private DateTime DataNasc;
        private string Nome;
        private string Morada;

        private bool isAluno = false;
        private Nullable<DateTime> DataMatricula = null;

        private bool isProf = false;
        private string AreaCodigo = null;
        private string AreaDesignacao = null;

        private Pessoa (int NumCC, string Email, Nullable<int> Telemovel, DateTime DataNasc, string Nome, string Morada)
        {
            this.NumCC = NumCC;
            this.Email = Email;
            this.Telemovel = Telemovel;
            this.DataNasc = DataNasc;
            this.Nome = Nome;
            this.Morada = Morada;
        }

        public static Pessoa getInstance(int NumCC, SqlConnection conn)
        {
            conn.Open();
            SqlDataReader reader = new SqlCommand("SELECT * FROM projeto.PessoaInfo(" + NumCC + ")", conn).ExecuteReader();

            Pessoa pessoa = null;
            if (reader.Read())
            {
                string Email = reader["Email"].ToString();
                Nullable<int> Telemovel = null;
                if (reader["Telemovel"].ToString() != "")
                    Telemovel = int.Parse(reader["Telemovel"].ToString());
                DateTime DataNasc = Convert.ToDateTime(reader["DataNasc"].ToString());
                string Nome = reader["Nome"].ToString();
                string Morada = reader["Morada"].ToString();

                pessoa = new Pessoa(NumCC, Email, Telemovel, DataNasc, Nome, Morada);

                if (int.Parse(reader["isAluno"].ToString()) > 0)
                    pessoa.addAluno(reader.GetDateTime(8));

                if (int.Parse(reader["isProf"].ToString()) > 0)
                {
                    string code = null;
                    string desig = null;

                    if (reader["CodigoArea"] != null)
                        code = reader["CodigoArea"].ToString();

                    if (reader["DesignacaoArea"] != null)
                        desig = reader["DesignacaoArea"].ToString();

                    pessoa.addProf(code, desig);
                }
            }
            
            conn.Close();
            return pessoa;
        }

        public void addAluno(DateTime DataMatricula)
        {
            isAluno = true;
            this.DataMatricula = DataMatricula;
        }

        public void addProf(string areaCode, string areaText)
        {
            isProf = true;
            this.AreaCodigo = areaCode;
            this.AreaDesignacao = areaText;
        }

        public List<Grupo> getGrupos(SqlConnection conn)
        {

            conn.Open();

            SqlDataReader rd = new SqlCommand("SELECT * FROM projeto.ListagemGrupos(" + NumCC + ")", conn).ExecuteReader();
            List<Grupo> list = new List<Grupo>();
            while (rd.Read())
            {
                Nullable<int> NumCCProfessor = null;
                if (rd["NumCCProfessor"].ToString() != null)
                    NumCCProfessor = int.Parse(rd["NumCCProfessor"].ToString());

                list.Add(new Grupo(
                    rd["DesignacaoGrupo"].ToString(),
                    int.Parse(rd["Participantes"].ToString()),
                    int.Parse(rd["NumMax"].ToString()),
                    NumCCProfessor,
                    rd["Nome"].ToString() != null ? rd["Nome"].ToString() : null,
                    rd["Prof"].ToString() == "1"
                    ));
            }
            conn.Close();

            return list;
        }

        public List<Teste> getTestes(SqlConnection conn, string Designacao)
        {
            conn.Open();
            SqlDataReader r = new SqlCommand("select * from projeto.TestesInfo(" + NumCC + ", '" + Designacao + "')",conn).ExecuteReader();

            List<Teste> list = new List<Teste>();
            while (r.Read())
            {
                Nullable<DateTime> duration = null;
                if (r["Duracao"].ToString() != null)
                    duration = DateTime.Parse(r["Duracao"].ToString());
                list.Add(new Teste(
                        r["Codigo"].ToString(),
                        DateTime.Parse(r["DataInicio"].ToString()),
                        DateTime.Parse(r["DataFim"].ToString()),
                       
                        duration,
                        int.Parse(r["CotacaoMaxima"].ToString()),
                        int.Parse(r["Nota"].ToString())




                 )); 
            }
            conn.Close();

            return list;
        }

        public int getNumCC()
        {
            return NumCC;
        }

        public string getEmail()
        {
            return Email;
        }

        public Nullable<int> getTelemovel()
        {
            return Telemovel;
        }

        public DateTime getDataNasc()
        {
            return DataNasc;
        }

        public string getNome()
        {
            return Nome;
        }

        public string getMorada()
        {
            return Morada;
        }
        public bool getIsProf()
        {
            return isProf;
        }
        public string getAreaCodigo()
        {
            return AreaCodigo;
        }
        public string getAreaDesignacao()
        {
            return AreaDesignacao;
        }
        public bool getIsAluno()
        {
            return isAluno;
        }
        public DateTime getDataMatricula()
        {
            return DataMatricula.Value;
        }
    }
}
