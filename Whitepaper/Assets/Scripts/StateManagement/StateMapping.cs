using System;
namespace Application
{
    public class StateMapping{
        
        private State prev;
        private State next;
        private State cur;

        public StateMapping(State prev, State cur, State next){
            this.prev = prev;
            this.next = next;
            this.cur = cur;
        }

        public State Prev{
            get { return prev; }
        }

        public State Next{
            get { return next; }
        }

        public State Cur{
            get { return cur; }
        }

    }
}
