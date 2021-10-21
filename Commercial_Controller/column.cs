using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Column
    { 
    public List <Elevator> elevatorsList;
   public  string ID;
    public string _status;
    public int _amountOfBasements;
    public int _amountOfElevatorsPerColumn;
    public List <int> servedFloorsList;
    public bool _isBasement;
    public List <CallButton> callButtonsList;
    public int amountOfFloors;
    public int callButtonID = 1;

    
        
        public Column(string ID, int _amountOfBasements,int _amountOfFloors, int _amountOfElevatorsPerColumn, List<int> _servedFloors, bool _isBasement)
        {
            this.ID = ID;
            this._status ="Idle";
            this._amountOfBasements = _amountOfBasements;
            this.amountOfFloors = _amountOfFloors;
            this._amountOfElevatorsPerColumn =_amountOfElevatorsPerColumn;
            this._isBasement = _isBasement;
            this.servedFloorsList = _servedFloors;
            this.elevatorsList = new List <Elevator> ();
            this.callButtonsList = new List <CallButton>();
            this.createElevators(amountOfFloors,_amountOfElevatorsPerColumn);
            this.createCallButtons(amountOfFloors,_isBasement);
        }
        //createCallButtons seems to work ok , however I am unsure if it should be creating 60 or 66 ( 1st scenario)
        public void createCallButtons(int _amountOfFloors, bool _isBasement){
            if (_isBasement){
                int buttonFloor = -1;
                for (int i = 0; i <_amountOfFloors;i++){
                    CallButton callbutton = new CallButton (callButtonID,"off","up",buttonFloor);
                    this.callButtonsList.Add(callbutton);
                    --buttonFloor;
                    ++ callButtonID;
                }
            }else {
                int buttonFloor = 1;
                                      
                for (int i =0; i<_amountOfFloors;i++){
                    CallButton callButton = new CallButton (callButtonID,"off","Down",buttonFloor);
                    this.callButtonsList.Add(callButton);
                    ++buttonFloor;
                    ++callButtonID;
                }
            }         
        }
            // createElevsators puts 5 objects into elevatorsList ( scenario1) This will create the elevators needed for each column 
        public void createElevators(int amountOfFloors,int _amountOfElevatorsPerColumn){
            int elevatorID = 1;
            for (int i =0;i < _amountOfElevatorsPerColumn;i++ ){
                string elevatoriD = elevatorID.ToString();
                Elevator elevator = new Elevator (elevatoriD,"Idle",amountOfFloors,1);
                elevatorsList.Add(elevator);
                ++elevatorID;
            }             
        }
      //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int _requestedFloor, string direction){
            var elevator = this.findElevator(_requestedFloor,direction);
            Console.WriteLine(elevator.direction);
            elevator.addNewRequest(_requestedFloor);
            elevator.move();
            elevator.addNewRequest(1);
            elevator.move();
            return (elevator);

        }
        public Elevator findElevator(int _requestedFloor, string direction){
            Elevator bestElevator = null;
            int bestScore = 6;
            int referenceGap = 1000000;
            Tuple <Elevator,int,int> bestElevatorInformations;
            if (_requestedFloor == 1){
                foreach(  Elevator elevator in this.elevatorsList){
                    if ((elevator.currentFloor == 1) && (elevator.status == "stopped")) {
                         bestElevatorInformations = this.checkIfElevatorIsBetter(1,elevator,bestScore,referenceGap,bestElevator,_requestedFloor); 
                    } else if ((elevator.currentFloor == 1) && (elevator.status == "Idle")){
                         bestElevatorInformations = this.checkIfElevatorIsBetter(2,elevator,bestScore,referenceGap,bestElevator,_requestedFloor); 
                    }else if ((1 > elevator.currentFloor) && (elevator.direction == "Up")){
                         bestElevatorInformations = this.checkIfElevatorIsBetter(3,elevator,bestScore,referenceGap,bestElevator,_requestedFloor); 
                    }else if ((1 < elevator.currentFloor) && (elevator.direction == "Down")){
                         bestElevatorInformations = this.checkIfElevatorIsBetter(3,elevator,bestScore,referenceGap,bestElevator,_requestedFloor); 
                    }else if (elevator.status == "Idle"){
                         bestElevatorInformations = this.checkIfElevatorIsBetter(4,elevator,bestScore,referenceGap,bestElevator,_requestedFloor); 
                    }else {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(5,elevator,bestScore,referenceGap,bestElevator,_requestedFloor);
                    }
                      bestElevator = bestElevatorInformations.Item1;
                      referenceGap = bestElevatorInformations.Item2;
                      bestScore = bestElevatorInformations.Item3;
                }
                
            }else 
                {
                     foreach(  Elevator elevator in elevatorsList){
                        if ((elevator.currentFloor == 1) && (elevator.status == "stopped")&& (elevator.direction == direction)) {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(1,elevator,bestScore,referenceGap,bestElevator,_requestedFloor); 
                     }else if ((_requestedFloor > elevator.currentFloor ) && (elevator.direction == "Up")&& (direction == "Up")) {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(2,elevator,bestScore,referenceGap,bestElevator,_requestedFloor);                
                    }else if ((_requestedFloor < elevator.currentFloor ) && (elevator.direction == "Up")&& (direction == "Up")) {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(2,elevator,bestScore,referenceGap,bestElevator,_requestedFloor);
                    }else if ((_requestedFloor < elevator.currentFloor ) && (elevator.direction == "Down")&& (direction == "Down")) {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(2,elevator,bestScore,referenceGap,bestElevator,_requestedFloor);
                    }else if (elevator.status == "Idle") {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(4,elevator,bestScore,referenceGap,bestElevator,_requestedFloor);
                    }else{
                        bestElevatorInformations = checkIfElevatorIsBetter(5,elevator,bestScore,referenceGap,bestElevator,_requestedFloor);
                    }
                    bestElevator = bestElevatorInformations.Item1;
                    referenceGap = bestElevatorInformations.Item2;
                    bestScore = bestElevatorInformations.Item3;
                    }

                    }
                        return bestElevator;
                    }
            public Tuple <Elevator,int,int> checkIfElevatorIsBetter(
                   int scoreToCheck, Elevator newElevator,int bestScore, int referenceGap, Elevator bestElevator, int _requestedFloor)
                {    if (scoreToCheck < bestScore){
                    bestScore = scoreToCheck;
                    bestElevator = newElevator;
                    referenceGap = Math.Abs(newElevator.currentFloor - _requestedFloor);
                } else {
                    if (bestScore == scoreToCheck){
                        int gap = Math.Abs(newElevator.currentFloor - _requestedFloor);
                          if (referenceGap > gap){
                              bestElevator=newElevator;
                              referenceGap = gap;
                            }
                    }
                }
                        var bestElevatorInformations = Tuple.Create(bestElevator,referenceGap,bestScore);
                        return bestElevatorInformations;

                    }


}}