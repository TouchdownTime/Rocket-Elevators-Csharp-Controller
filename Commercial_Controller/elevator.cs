using System.Threading;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        
    public string ID = "1";
    public string status;
    public int amountOfFloors;
    public int currentFloor;

    public Elevator elevator;

    public string direction;
   public  List<int> floorRequestsList;
   public List <int> completedRequestsList;
   public Door door;

    public int screenDisplay;

        public Elevator(string _ID, string status, int amountOfFloors,int currentFloor)
        {
            this.ID=_ID;
            this.status = status;
            this.amountOfFloors = amountOfFloors;
            this.currentFloor = currentFloor;
            this.direction = "Idle";
            this.floorRequestsList = new List <int>();
            this.screenDisplay = 0;
            Door door = new Door (1,"Closed");

        }

        public void move()
        {
            while (floorRequestsList.Count != 0 ){
                int destination = floorRequestsList[0];
                this.status = "moving";
                if ( this.currentFloor < destination){
                    this.direction = "Up";
                    this.sortFloorList();
                    while (this.currentFloor < destination){
                        ++this.currentFloor;
                        this.screenDisplay = this.currentFloor;
                    }
                }else if (this.currentFloor > destination){
                    this.direction = "Down";
                    this.sortFloorList();
                    while (this.currentFloor > destination){
                        --this.currentFloor;
                        this.screenDisplay = this.currentFloor;
                    }
                }
                this.status = "Stopped";
                this.operateDoors();
                completedRequestsList.Add(destination);
                floorRequestsList.RemoveAt(0);
            }
            this.status ="Idle";
        }

        public void sortFloorList (){
            if (this.direction == "Up"){
                this.floorRequestsList.Sort();
            }else {
                this.floorRequestsList.Sort();
                this.floorRequestsList.Reverse();
            }
        }

        public void operateDoors(){
           this.door.status = "Opened";
            // wait 5 seconds
            this.door.status = "Closed";

        }
        public void addNewRequest(int _requestFloor){

            if (!floorRequestsList.Contains(_requestFloor)){
                floorRequestsList.Add(_requestFloor);
            }
            if (this.currentFloor < _requestFloor){
                this.direction = "Up";
            }
            if (this.currentFloor > _requestFloor){
                this.direction = "Down";
            }
        }
        
    }
}