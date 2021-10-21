using System.Threading;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        
    public string elevatorID = "1";
    public string status;
    public int amountOfFloors;
    public int currentFloor;

    public Elevator elevator;

    public string _direction;

        public Elevator(string _elevatorID, string status, int amountOfFloors,int currentFloor)
        {
            this.elevatorID=_elevatorID;
            this.status = status;
            this.amountOfFloors = amountOfFloors;
            this.currentFloor = currentFloor;
            this._direction = "Idle";

        }

        public void move()
        {

        }
        
    }
}