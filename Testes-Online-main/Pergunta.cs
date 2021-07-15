using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestesOnline
{
    class Pergunta
    {
        private int identificadorPergunta;
        private string enunciado;
        private List<string> imagens = new List<string>();
        private List<KeyValuePair<int, string>> opcoes = new List<KeyValuePair<int, string>>();
        private Type classTemplate;

        private Pergunta(int identificadorPergunta, string enunciado, Type classTemplate)
        {
            this.identificadorPergunta = identificadorPergunta;
            this.enunciado = enunciado;
            this.classTemplate = classTemplate;
        }

        public static Pergunta getInstance(string codigoTeste, int numCC, SqlConnection conn)
        {
            SqlDataReader proxPergunta = new SqlCommand("SELECT * FROM projeto.ProximaPergunta(" + numCC + ", '" + codigoTeste + "')", conn).ExecuteReader();

            if (proxPergunta.Read())
            {
                Pergunta p = new Pergunta(int.Parse(proxPergunta["IdentificadorPergunta"].ToString()), proxPergunta["Enunciado"].ToString(), typeof(Form).Assembly.GetType("System.Windows.Forms." + proxPergunta["TemplateOpt"].ToString()));
                proxPergunta.Close();

                p.loadImagens(conn);
                p.loadOpcoes(conn);
                return p;
            }

            return null;
        }

        private void loadOpcoes(SqlConnection conn)
        {
            SqlDataReader opcoes = new SqlCommand("SELECT * FROM projeto.OpcoesDesordenadas(" + identificadorPergunta + ")", conn).ExecuteReader();

            while (opcoes.Read())
                this.opcoes.Add(new KeyValuePair<int, string>(int.Parse(opcoes["Identificador"].ToString()), opcoes["Texto"].ToString()));

            opcoes.Close();
        }

        private void loadImagens(SqlConnection conn)
        {
            SqlDataReader imagens = new SqlCommand("SELECT Link FROM projeto.Imagens WHERE IdentificadorPergunta = " + identificadorPergunta, conn).ExecuteReader();

            while (imagens.Read())
                this.imagens.Add(imagens["Link"].ToString());

            imagens.Close();
        }

        public int getIdentificadorPergunta()
        {
            return identificadorPergunta;
        }

        public string getEnunciado()
        {
            return enunciado;
        }

        public string[] getImagens()
        {
            return imagens.ToArray();
        }

        public KeyValuePair<int, string>[] getOpcoes()
        {
            return opcoes.ToArray();
        }

        public Type getInputType()
        {
            return classTemplate;
        }

    }
}
