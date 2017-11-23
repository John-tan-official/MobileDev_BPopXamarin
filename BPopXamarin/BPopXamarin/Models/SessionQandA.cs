using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPopXamarin.Models
{
    class SessionQandA
    {
        static public int numberOfQuestions { get; set; }
        static public List<QandA> QandAs { get; set; }
        static public string Question { get; set; }
        static public string ChoiceA { get; set; }
        static public string ChoiceB { get; set; }
        static public string ChoiceC { get; set; }
        static public string ChoiceD { get; set; }
        static public string Answer { get; set; }
    }
}
