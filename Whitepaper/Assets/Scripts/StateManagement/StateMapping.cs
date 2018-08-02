using System;
namespace Application
{
    public class StateMapping{
        
        private string prev;
        private string next;
        private string cur;

        public StateMapping(string prev, string cur, string next){
            this.prev = prev;
            this.next = next;
            this.cur = cur;
        }

        public string Prev{
            get { return prev; }
        }

        public string Next{
            get { return next; }
        }

        public string Cur{
            get { return cur; }
        }

    }
}
