using System;
namespace Application
{
    public class StateMapping{
        
        private State prev;
        private State next;
        private State cur;
        private object p;
        private Intro1 intro1;
        private Intro2 intro2;
        private Intro3 intro3;

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
