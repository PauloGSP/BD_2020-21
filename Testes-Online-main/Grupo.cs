using System;
using System.Collections.Generic;
using System.Text;

namespace TestesOnline
{
    class Grupo
    {
        private string DesignacaoGrupo;
        private int Participants;
        private int NumMax;
        private Nullable<int> NumCCProfessor;
        private string Nome;
        private bool Prof;

        public Grupo(string DesignacaoGrupo, int Participants, int NumMax, Nullable<int> NumCCProfessor, string Nome, bool Prof)
        {
            this.DesignacaoGrupo = DesignacaoGrupo;
            this.Participants = Participants;
            this.NumMax = NumMax;
            this.NumCCProfessor = NumCCProfessor;
            this.Nome = Nome;
            this.Prof = Prof;
        }

        public string getDesignacaoGrupo()
        {
            return DesignacaoGrupo;
        }

        public int getParticipants()
        {
            return Participants;
        }

        public int getNumMax()
        {
            return NumMax;
        }

        public Nullable<int> getNumCCProfessor()
        {
            return NumCCProfessor;
        }

        public string getNome()
        {
            return Nome;
        }

        public Boolean getProf()
        {
            return Prof;
        }

        public GroupData getGroupData()
        {
            GroupData g = new GroupData(DesignacaoGrupo, Participants, NumMax);
            if (NumCCProfessor != null && !Prof)
                g.addProf(NumCCProfessor.Value, Nome);
            else if (Prof)
                g.addProf("You");

            return g;
        }
    }
}
