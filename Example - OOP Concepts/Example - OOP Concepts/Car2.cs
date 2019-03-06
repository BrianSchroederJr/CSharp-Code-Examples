using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example___OOP_Concepts
{
    class Car2
    {
        // Events in the Car class
        // This delegate works in conjunction with the Car's events.
        //public delegate void CarEngineHandler(string msg);
        //public delegate void CarEngineHandler(object sender, CarEventArgs e);   //Handling Events the Microsoft recommended way (pass sender and custom EventArgs)
        
        // This car can send these events.
        // With events you don't have to define custom registration functions or declare delegate member variables.
        //public event CarEngineHandler Exploded;
        //public event CarEngineHandler AboutToBlow;
        //FURTHER SIMPLIFYING THE EVENT PROCESS BY USING A Generic EventHandler<T> Delegate
        public event EventHandler<CarEventArgs> Exploded;
        public event EventHandler<CarEventArgs> AboutToBlow;



        // Internal state data.
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        // Is the car alive or dead?
        private bool carIsDead;
        // Class constructors.
        public Car2() { MaxSpeed = 100; }
        public Car2(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }


        public void Accelerate(int delta)
        {
            // If this car is "dead," send dead message.
            if (carIsDead)
            {
                //if (listOfHandlers != null)
                    //listOfHandlers("Sorry, this car is dead...");
                if (Exploded != null)
                {
                    //Exploded("Sorry, this car is dead 2...");
                    Exploded(this, new CarEventArgs("Sorry, this car is dead 2..."));
                }
            }
            else
            {
                CurrentSpeed += delta;
                // Is this car "almost dead"?
                //if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
                if (10 == (MaxSpeed - CurrentSpeed) && AboutToBlow != null)
                {
                    //listOfHandlers("Careful buddy! Gonna blow!");
                    //AboutToBlow("Careful buddy! Gonna blow!2");
                    AboutToBlow(this, new CarEventArgs("Careful buddy! Gonna blow!2"));
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }


        internal void FixCar()
        {
            carIsDead = false;
            CurrentSpeed = 0;
        }
    }
}
