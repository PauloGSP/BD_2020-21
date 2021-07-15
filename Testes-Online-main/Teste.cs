using System;
using System.Collections.Generic;
using System.Text;

namespace TestesOnline
{
    class Teste
    {
        private DBAccess DBAccess = DBAccess.getInstance();

        private string testCode = null;
        private DateTime beginDate;
        private DateTime endDate ;
        private Nullable<DateTime> duration = null;
        private Nullable<DateTime> startDate = null;
        private int maxGrade;
        private int grade;


        public Teste(string testCode, DateTime dataInicio, DateTime dataFim, Nullable<DateTime> duration,int maxGrade, int grade)
        {
            this.testCode = testCode;
            this.endDate = dataFim;
            this.beginDate = dataInicio;
            this.duration = duration;
            this.maxGrade = maxGrade;
            this.grade = grade;
        }
        public string gettestCode()
        {
            return testCode;
        }
        public DateTime getdataFim()
        {
            return endDate;
        }
        public DateTime getdataInicio()
        {
            return beginDate;
        }
        public Nullable<DateTime> getduration()
        {
            return duration;
        }
        public int getmaxGrade()
        {
            return maxGrade;
        }
        public int getgrade()
        {
            return grade;
        }

        public TestData GetTestData()
        {
            TestData t = new TestData(testCode, beginDate, endDate, maxGrade);

            if (duration != null)
                t.addDuration(duration);

            DateTime now = DBAccess.getInstance().getDBDateTime();
            double msecondsFromBegin = now.Subtract(beginDate).TotalMilliseconds;
            double msecondsFromEnd = now.Subtract(endDate).TotalMilliseconds;
            double msecondsLeft = 1;
            
            if (startDate != null && duration != null)
                msecondsLeft = - now.Subtract(startDate.Value.AddMilliseconds(duration.Value.TimeOfDay.TotalMilliseconds)).TotalMilliseconds;

            if (msecondsFromBegin > 0 && msecondsFromEnd < 0 && msecondsLeft > 0)
            {
                if (startDate != null)
                    t.addBtnText("Continuar");
                else
                    t.addBtnText("Tentar");
            }
            else if (msecondsFromEnd >= 0)
                t.addGrade(grade);

            return t;
        }
    }
}

