using System;
using System.Collections;
namespace Application
{
    public class StateInitializer
    {

        private static StateInitializer stateInitializer;
        private static Hashtable stateTable;

        private StateInitializer(){
            stateTable = new Hashtable();
        }

        public static StateInitializer Create(){
            if (stateInitializer == null)
                stateInitializer = new StateInitializer();

            return stateInitializer;
        }

        public static void PopulateStateGraph(){   
            
        }



    }

    class StateMap
    {

        private State prev;
        private State next;

        public State Prev{
            get { return prev; }
        }

        public State Next{
            get { return Next; }
        }

        public StateMap(State prev, State next){
            this.prev = prev;
            this.next = next;
        }


    }
}