using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TestesOnline
{
    class DBAccess
    {
        private static DBAccess instance = null;
        private SqlConnection conn;

        private Pessoa pessoa = null;

        private DBAccess() {
            conn = new SqlConnection("Data Source=tcp:mednat.ieeta.pt\\SQLSERVER,8101;User ID=p6g2;Password=TriplePen21;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
        }

        public DateTime getDBDateTime()
        {
            DateTime dt;
            conn.Open();

            dt = (DateTime)new SqlCommand("SELECT GETDATE()", conn).ExecuteScalar();

            conn.Close();
            return dt;
        }

        public bool login(int numCC)
        {
            pessoa = Pessoa.getInstance(numCC, conn);
            return pessoa != null;
        }

        public Pessoa getPessoa()
        {
            return pessoa;
        }

        public List<Grupo> getGrupos()
        {
            return pessoa.getGrupos(conn);
        }

        public List<Teste> getTestes(string DesignacaoGrupo)
        {
            return pessoa.getTestes(conn, DesignacaoGrupo);
        }

        public List<ComboBoxItem> getAreas()
        {
            List<ComboBoxItem> comboBoxItems = new List<ComboBoxItem>();
            conn.Open();
            SqlDataReader areas = new SqlCommand("select * from projeto.Areas", conn).ExecuteReader();

            while (areas.Read())
                comboBoxItems.Add(new ComboBoxItem(areas["Designacao"].ToString(), areas["Codigo"].ToString()));

            conn.Close();

            return comboBoxItems;
        }

        public Pergunta getProximaPergunta(string codigoTeste)
        {
            conn.Open();
            Pergunta p = Pergunta.getInstance(codigoTeste, getPessoa().getNumCC(), conn);
            conn.Close();

            return p;
        }
        public bool createGrp(string desi, int nmax, int ncc)
        {
            conn.Open();
            desi = "'" + desi + "'";

            try
            {
                new SqlCommand("INSERT INTO projeto.GrupoAluno VALUES ("+ desi +","+ nmax + ","+ ncc+ ");", conn).ExecuteNonQuery();
                new Grupo(desi, 0, nmax, ncc, pessoa.getNome(), true);
                
                conn.Close();
                return true;
            }
            catch (SqlException)
            {
                conn.Close();
                return false;
            }
        }
        public DataTable showParticipants(string desi)
        {
            conn.Open();
            desi = "'" + desi + "'";
            try
            {
                //"SELECT * FROM projeto.ListagemAlunos(" + desi + ");"

                SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.ListagemAlunos(" + desi + ");", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                conn.Close();
                return table;
            }
            catch (SqlException)
            {
                conn.Close();
                return null;
            }
        }


        public DataTable showPauta(string desi)
        {
            conn.Open();
            desi = "'" + desi + "'";

            try
            {
                //"SELECT * FROM projeto.ListagemAlunos(" + desi + ");"

                SqlCommand cmd = new SqlCommand("SELECT * FROM projeto.PautaTeste(" + desi + ");", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                conn.Close();
                return table;
            }
            catch (SqlException)
            {
                conn.Close();
                return null;
            }
        }
       
        public bool AddParticipant(int ncc, string desi)
        {
            conn.Open();
            desi = "'" + desi + "'";
            try
            {
                new SqlCommand("INSERT INTO projeto.AlunoGrupo VALUES (" + ncc + "," + desi + ");", conn).ExecuteNonQuery();
                conn.Close();
                return true;

            }
            catch (SqlException)
            {
                conn.Close();
                return false;

            }
        }
        public bool responderPergunta(string codigoTeste, int identificadorPergunta, Nullable<int> identificadorOpcao)
        {
            conn.Open();
            try
            {
                new SqlCommand("EXEC projeto.createResposta @NumCC = " + pessoa.getNumCC() + ", @CodigoTeste = '" + codigoTeste + "', @IdentificadorPergunta = " + identificadorPergunta + ", @IdentificadorOpcao = " + (identificadorOpcao == null ? "NULL" : identificadorOpcao.Value.ToString()) + ";", conn).ExecuteNonQuery();
            }
            catch (SqlException)
            {
                conn.Close();
                return false;
            }

            conn.Close();
            return true;
        }

        public SqlDataAdapter getPerguntas()
        {
            SqlDataAdapter data;

            conn.Open();

            data = new SqlDataAdapter(new SqlCommand("SELECT * FROM projeto.ProfPerguntas(" + pessoa.getNumCC() + ")", conn));

            conn.Close();

            return data;
        }

        public SqlDataAdapter getPerguntaImagens(int perguntaId)
        {
            SqlDataAdapter data;

            conn.Open();
            data = new SqlDataAdapter(new SqlCommand("SELECT * FROM projeto.PerguntaImagens(" + perguntaId + ")", conn));
            conn.Close();

            return data;
        }

        public SqlDataAdapter getPerguntaOpcoes(int perguntaId)
        {
            SqlDataAdapter data;

            conn.Open();
            data = new SqlDataAdapter(new SqlCommand("SELECT * FROM projeto.PerguntaOpcoes(" + perguntaId + ")", conn));
            conn.Close();

            return data;
        }
        public bool sign(int ncc, string email, int telemovel, DateTime NascDate, string nome, string morada, Nullable<DateTime> datematricula, string codigoarea)
        {
            conn.Open();
            string date2 = "NULL";
            string code = "NULL";
            string date1 = NascDate.ToString("yyyy-MM-dd");

            if (datematricula != null)
                date2 = "'" + ((DateTime)datematricula).ToString("yyyy-MM-dd") + "'";

            if (codigoarea != null)
                code = "'" + codigoarea + "'";

            new SqlCommand("EXEC projeto.createPessoa @NumCC = " + ncc + ", @email ='" + email + "' , @Telemovel =" + telemovel + " , @DataNasc ='" + date1 + "', @Nome = '" + nome + "' , @Morada = '" + morada + "', @DataMatricula = " + date2 + ", @CodigoArea = " + code + ";", conn).ExecuteNonQuery();
            conn.Close();
            return true;
        }

        public string[] getTiposPergunta() {
            List<string> tipos = new List<string>();

            conn.Open();
            SqlDataReader r = new SqlCommand("SELECT Codigo FROM projeto.TipoPergunta", conn).ExecuteReader();
            while (r.Read())
                tipos.Add(r["Codigo"].ToString());
            conn.Close();

            return tipos.ToArray();
        }

        public void createPergunta(string Enunciado, string TipoPergunta)
        {
            conn.Open();
            new SqlCommand("EXEC projeto.CriarPergunta @Enunciado = '" + Enunciado + "', @CodigoTipoPergunta = '" + TipoPergunta + "', @NumCCProfessor = " + pessoa.getNumCC(), conn).ExecuteNonQuery();
            conn.Close();
        }

        public void createPerguntaImagem(int IDPergunta, string Descricao, string Link)
        {
            conn.Open();
            new SqlCommand("EXEC projeto.CriarPerguntaImagem @IdentificadorPergunta = '" + IDPergunta + "', @Descricao = '" + Descricao + "', @Link = '" + Link + "', @NumCCProfessor = " + pessoa.getNumCC(), conn).ExecuteNonQuery();
            conn.Close();
        }

        public void createPerguntaOpcao(int IDPergunta, string Texto, int Cotacao)
        {
            conn.Open();
            new SqlCommand("EXEC projeto.CriarPerguntaOpcao @IdentificadorPergunta = '" + IDPergunta + "', @Texto = '" + Texto + "', @Cotacao = " + Cotacao + ", @NumCCProfessor = " + pessoa.getNumCC(), conn).ExecuteNonQuery();
            conn.Close();
        }

        public void atualizarPergunta(int IDPergunta, string Enunciado, string TipoPergunta)
        {
            conn.Open();
            new SqlCommand("EXEC projeto.AtualizarPergunta @IdentificadorPergunta = " + IDPergunta + ", @NumCCProfessor = " + pessoa.getNumCC() + ", @Enunciado = '" + Enunciado + "', @CodigoTipoPergunta = '" + TipoPergunta + "'", conn).ExecuteNonQuery();
            conn.Close();
        }

        public void atualizarPerguntaImagem(int IDPergunta, int IDImagem, string Descricao, string Link)
        {
            conn.Open();
            new SqlCommand("EXEC projeto.AtualizarPerguntaImagem @IdentificadorPergunta = " + IDPergunta + ", @NumCCProfessor = " + pessoa.getNumCC() + ", @IdentificadorImagem = " + IDImagem + ", @Descricao = '" + Descricao + "', @Link = '" + Link + "'", conn).ExecuteNonQuery();
            conn.Close();
        }

        public void atualizarPerguntaOpcao(int IDPergunta, int IDOpcao, string Texto, int Cotacao)
        {
            conn.Open();
            new SqlCommand("EXEC projeto.AtualizarPerguntaOpcao @IdentificadorPergunta = " + IDPergunta + ", @NumCCProfessor = " + pessoa.getNumCC() + ", @IdentificadorOpcao = " + IDOpcao + ", @Texto = '" + Texto + "', @Cotacao = " + Cotacao, conn).ExecuteNonQuery();
            conn.Close();
        }

        public void toggleVisibilidadeTeste(string CodigoTeste)
        {
            conn.Open();
            new SqlCommand("EXEC projeto.ToggleTesteVisibilidade @CodigoTeste = '" + CodigoTeste + "', @NumCCProfessor = " + pessoa.getNumCC(), conn).ExecuteNonQuery();
            conn.Close();
        }

        public void criarTeste(string DesignacaoGrupo, string Codigo, int CotMax, DateTime dtInicio, DateTime dtFim, DateTime tDuracao, bool Visivel, DataTable perguntas)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("projeto.CriarTeste", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 15;
            cmd.CommandText = "projeto.CriarTeste";

            cmd.Parameters.AddWithValue("@NumCCProfessor", pessoa.getNumCC());
            cmd.Parameters.AddWithValue("@DesignacaoGrupo", DesignacaoGrupo);
            cmd.Parameters.AddWithValue("@Codigo", Codigo);
            cmd.Parameters.AddWithValue("@CotacaoMax", CotMax);
            cmd.Parameters.AddWithValue("@DataInicio", dtInicio);
            cmd.Parameters.AddWithValue("@DataFim", dtFim);
            cmd.Parameters.AddWithValue("@Duracao", tDuracao.TimeOfDay);
            cmd.Parameters.AddWithValue("@Visivel", Visivel ? 1 : 0);
            cmd.Parameters.AddWithValue("@Perguntas", perguntas);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static DBAccess getInstance () {
            if (instance == null)
                instance = new DBAccess();
            return instance;
        }
    }
}
