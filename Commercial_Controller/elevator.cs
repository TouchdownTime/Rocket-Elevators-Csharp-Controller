using System;
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
            this.direction = "idle";
            this.floorRequestsList = new List <int>();
            this.screenDisplay = 0;
            Door door = new Door (1,"Closed");
            this.door = door;
            this.completedRequestsList = new List<int>();

        }

        public void move()
        {
            while (floorRequestsList.Count != 0 ){
                int userPosition = floorRequestsList[0];
                this.status = "moving";
                if ( this.currentFloor < userPosition){
                    this.direction = "up";
                    this.sortFloorList();
                    while (this.currentFloor < userPosition){
                        ++this.currentFloor;
                        this.screenDisplay = this.currentFloor;
                    }
                }else if (this.currentFloor > userPosition){
                    this.direction = "down";
                    this.sortFloorList();
                    while (this.currentFloor > userPosition){
                        --this.currentFloor;
                        this.screenDisplay = this.currentFloor;
                    }
                }
                this.status = "stopped";
                this.operateDoors();
                this.completedRequestsList.Add(floorRequestsList[0]);
                this.floorRequestsList.RemoveAt(0);
            }
            this.status ="idle";
        }

        public void sortFloorList (){
            if (this.direction == "up"){
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
        public void addNewRequest(int userPosition){

            if (!floorRequestsList.Contains(userPosition)){
                floorRequestsList.Add(userPosition);
            }
            if (this.currentFloor < userPosition){
                this.direction = "up";
            }
            if (this.currentFloor > userPosition){
                this.direction = "down";
            }
        }
        
    }
}