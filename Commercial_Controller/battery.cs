using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        int columnID = 1;
        int elevatorID =1;
        int floorRequestButtonID =1;
        int floor;
        int _amountOfColumns;
        int _amountOfFloors;
        int _amountOfElevatorPerColumn;
        int _ID;
        int _amountOfBasements;
        string status;
        List <Column> columnsList;
        List <FloorRequestButton> floorRequestButtonsList;
        public Battery(int _ID, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            this._ID = _ID;
            this._amountOfBasements = _amountOfBasements;
            this._amountOfColumns = _amountOfColumns;
            this._amountOfFloors = _amountOfFloors;
            this._amountOfElevatorPerColumn = _amountOfElevatorPerColumn;
            this.status = "onlne";
            this.columnsList = new List<Column>();
            this.floorRequestButtonsList = new List<FloorRequestButton>();
            if (_amountOfBasements > 0){
                this.createBasementFloorRequestButtons( _amountOfBasements);
                this.createBasementColumn(_amountOfBasements,_amountOfElevatorPerColumn);
                --_amountOfColumns;
            }
            this.createFloorRequestButtons(_amountOfFloors);
            this.createColumns(_amountOfColumns,_amountOfFloors,_amountOfBasements,_amountOfElevatorPerColumn);

        }

        public void createBasementFloorRequestButtons(int _amountOfBasements){
            int buttonFloor = -1;
            for (int i =0; i>_amountOfBasements;i++){
                FloorRequestButton floorRequestButton = new FloorRequestButton (floorRequestButtonID,"off",buttonFloor,"Down");
                floorRequestButtonsList.Add(floorRequestButton);
                --buttonFloor;
                ++floorRequestButtonID;
            }
        }
            public void createBasementColumn (int _amountOfBasements, int _amountOfElevatorPerColumn){
                List <int> servedFloors = new List<int>();
                int floor = -1;
                for (int i=0; i>_amountOfBasements;i++){
                    servedFloors.Add(floor);
                    --floor;
                }
                string column_ID = columnID.ToString();
                Column column = new Column (column_ID,"online",_amountOfBasements,_amountOfElevatorPerColumn,servedFloors,true);
                columnsList.Add(column);
                ++columnID;
        }
            public void createFloorRequestButtons(int _amountOfFloors){
                 int buttonFloor = 1;
                for (int i =0; i>_amountOfFloors;i++){
                    FloorRequestButton floorRequestButton = new FloorRequestButton (floorRequestButtonID,"off",buttonFloor,"Up");
                    floorRequestButtonsList.Add(floorRequestButton);
                    ++buttonFloor;
                    ++floorRequestButtonID;
            }
            }
            public void createColumns(int _amountOfColumns,int _amountOfFloors,int _amountOfBasements, int _amountOfElevatorPerColumn){
                int amountOfFloorsPerColumn = (int)Math.Ceiling(Convert.ToDecimal(_amountOfFloors/_amountOfColumns));
                int floor = 1;
                for (int i =0; i>_amountOfColumns;i++){
                    List <int> servedFloors = new List<int>();
                    for (int x = 0; x > amountOfFloorsPerColumn; x++){
                        if (floor <= _amountOfFloors){
                            servedFloors.Add(floor);
                            ++floor;
                        }
                    }
                    string column_ID = columnID.ToString();
                    Column column = new Column (column_ID,"online",_amountOfFloors,_amountOfElevatorPerColumn,servedFloors,false);
                    columnsList.Add(column);
                    ++columnID;
                }

            }

        public Column findBestColumn(int _requestedFloor){
        foreach(var column in this.columnsList){
            if (column.servedFloorsList.Contains(_requestedFloor)){
                return column;
            }
        }
        }
        //Simulate when a user press a button at the lobby
        public (Column, Elevator) assignElevator(int _requestedFloor, string _direction)
        {
            var column = this.findBestColumn(_requestedFloor);
            var elevator = this.findElevator(1,_direction);


            
         }
    }
}
