using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Column
    { 
    public List <int> elevatorsList;
    string _ID;
    string _status;
    int _amountOfBasements;
    int _amountOfElevators;
    public List <int> servedFloorsList;
    bool _isBasement;
    public List <CallButton> callButtonsList;
    int amountOfFloors;

    
        
        public Column(string _ID, string _status, int _amountOfBasements, int _amountOfElevators, List<int> _servedFloors, bool _isBasement)
        {
            this._ID = _ID;
            this._status =_status;
            this._amountOfBasements = _amountOfBasements;
            this.amountOfFloors = _amountOfBasements;
            this._amountOfElevators =_amountOfElevators;
            this._isBasement = _isBasement;
            this.servedFloorsList = _servedFloors;
            this.elevatorsList = new List <int> ();
            this.callButtonsList = new List <CallButton>();
            this.createElevators(amountOfFloors,_amountOfElevators);
        }

        public void createElevators(int amountOfFloors,int _amountOfElevators){
            int elevatorID = 1;
            for (int i =0;i <_amountOfElevators;i++ ){
                string elevatoriD = elevatorID.ToString();
                Elevator elevator = new Elevator (elevatoriD,"Idle",amountOfFloors,1);
                ++elevatorID;

            }
        }


        //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int userPosition, string direction)
        {
            
        }

    }
}