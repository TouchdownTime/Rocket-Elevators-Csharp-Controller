using System.Threading;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        
        int elevatorID = 1;
        string status;
        int amountOfFloors;
        int currentFloor;

        public Elevator(string _elevatorID, string status, int amountOfFloors,int currentFloor)
        {
            this.elevatorID=_elevatorID;
            this.status = status;
            this.amountOfFloors = amountOfFloors;
            this.currentFloor = currentFloor;

        }
        public void move()
        {

        }
        
    }
}