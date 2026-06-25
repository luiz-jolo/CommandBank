using CommandBank.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandBank.StateMachine
{
    public class StateModel
    {
        public ScreenEnum CurrentScreen { get; set; }
        public bool IsRunning { get; set; }
    }
}
