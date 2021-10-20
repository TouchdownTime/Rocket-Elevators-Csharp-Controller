namespace Commercial_Controller
{
    //Button on a floor or basement to go back to lobby
    public class FloorRequestButton
    {
        int _ID;
        string _status;
        int _floor;
        string _direction;
        public FloorRequestButton(int _ID, string _status,int _floor, string _direction)
        {
            this._ID =_ID;
            this._status = _status;
            this._floor = _floor;
            this._direction = _direction;
        }
    }
}