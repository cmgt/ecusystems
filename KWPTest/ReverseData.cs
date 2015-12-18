using System;
using Helper;

namespace KWPTest
{
    class ReverseData
    {
        public readonly static ReverseData instance = new ReverseData();

        public bool Enabled;
        public string RequestHeader;
        public string AnswerHeader;
        public string AnswerData;

        public byte[] Answer;

        public void Prepare()
        {
            Answer = DataHelper.StrToByteArray(AnswerHeader + AnswerData + "00");
            DataHelper.CalcCRC(Answer);
        }
    }
}
