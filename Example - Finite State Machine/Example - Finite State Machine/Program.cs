using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___Finite_State_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            FiniteStateMachine fsm = new FiniteStateMachine();
            //Console.WriteLine(fsm.currState);
            fsm.ProcessEvent(FiniteStateMachine.Events.PlugIn);
            //Console.WriteLine(fsm.currState);
            fsm.ProcessEvent(FiniteStateMachine.Events.PlugIn);
            //Console.WriteLine(fsm.currState);
            fsm.ProcessEvent(FiniteStateMachine.Events.TurnOn);
            //Console.WriteLine(fsm.currState);
            fsm.ProcessEvent(FiniteStateMachine.Events.TurnOff);
            //Console.WriteLine(fsm.currState);
            fsm.ProcessEvent(FiniteStateMachine.Events.TurnOn);
            //Console.WriteLine(fsm.currState);
            fsm.ProcessEvent(FiniteStateMachine.Events.Unplug);
            //Console.WriteLine(fsm.currState);
            // Wait for key press to continue
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        // TELEVISION - FSM(Finite State Machine)
        class FiniteStateMachine
        {
            // STATES
            public enum States { Off, Standby, On };
            public States currState { get; set; }

            // INPUTS
            public enum Events { PlugIn, TurnOn, TurnOff, Unplug };

            // delegate(Action) - Encapsulates a method that has no parameters and returns no value.
            // This is creating a 2D array of Action objects(fsm) which can hold references to multiple functions/methods.
            private Action[,] fsm;

            public FiniteStateMachine()
            {
                // Upon instantiation of this FiniteStateMachine class the Action 2D array (fsm) gets populated 
                // with all of the transitions(methods) for each input X for each state.
                this.fsm = new Action[3, 4] { 
                //PlugIn,       TurnOn,                 TurnOff,            Unplug
                {this.PowerOn,  null,                   null,               null},              //off
                {null,          this.StandbyWhileOff,    null,               this.PowerOff},     //standby
                {null,          null,                   this.StandbyWhileOn, this.PowerOff} };   //on
            }

            // TRANSITIONS (State Changes)
            private void PowerOn() { this.currState = States.Standby; }
            private void PowerOff() { this.currState = States.Off; }
            private void StandbyWhileOn() { this.currState = States.Standby; }
            private void StandbyWhileOff() { this.currState = States.On; }

            // Process INPUT on Finite State Machine(fsm)
            // This method uses the passed INPUT and the current STATE to locate and call 
            // the proper TRANSITION which may be null(do nothing/STATE remains the same)
            // or change the current STATE of the fsm
            public void ProcessEvent(Events theEvent)
            {
                if (this.fsm[(int)this.currState, (int)theEvent] != null)
                {
                    this.fsm[(int)this.currState, (int)theEvent].Invoke();
                    Console.WriteLine(theEvent + " made the TV change to " + currState);
                }
                else
                {
                    Console.WriteLine(theEvent + " did nothing!  TV is still " + currState);
                }
            }
        }

    }
}
