using System.Collections.Generic;
public class HeartRateZone
{
    public int HRStart {get;set;}
    public int HREnd {get;set;}
    public int TSSStart {get;set;}
    public int TSSEnd {get;set;}
    public HeartRateZone(int HRStart, int HREnd, int TSSStart, int TSSEnd)
    {
        this.HRStart = HRStart;
        this.HREnd = HREnd;
        this.TSSStart = TSSStart;
        this.TSSEnd = TSSEnd;
    }

    public bool Contains(int Number)
    {
        if (Number >= this.HRStart && Number <= this.HREnd)
        {
            return true;
        }
        return false;
    }
    

}