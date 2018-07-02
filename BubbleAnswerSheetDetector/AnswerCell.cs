using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleAnswerSheetDetector
{
    class AnswerCell
    {
        private Point[] contour;
        private int answerNum;
        private int answerType;
        private int marked;

        public Point[] Contour { get => contour; set => contour = value; }
        public int AnswerNum { get => answerNum; set => answerNum = value; }
        public int AnswerType { get => answerType; set => answerType = value; }
        public int Marked { get => marked; set => marked = value; }
    }
}
