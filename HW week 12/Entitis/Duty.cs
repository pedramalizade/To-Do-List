using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_week_12.Entitis
{
    public class Duty
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TimeToDone { get; set; }
        public int Order { get; set; }
        public State State { get; set; }
        public Duty(string title, DateTime timeToDone, int order, State state)
        {
            Title = title;
            TimeToDone = timeToDone;
            Order = order;
            State = state;
        }
    }

    public enum State
    {
        InPending = 1,
        Done,
        Cancelled
    }
}
