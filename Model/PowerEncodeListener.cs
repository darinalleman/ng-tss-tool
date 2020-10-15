using System;
using System.Collections.Generic;
using Dynastream.Fit;

namespace Models
{
    public class PowerEncodeListener
    {
        public static void MesgEvent(object sender, MesgEventArgs e)
        {
            if (e.mesg.Num == 20) 
            {
                Field HRField = e.mesg.GetField(RecordMesg.FieldDefNum.HeartRate);
                if (HRField != null) 
                {
                    Field PowerField = e.mesg.GetField(RecordMesg.FieldDefNum.Power);
                    if (PowerField == null)
                    {
                        PowerField = new Field(RecordMesg.FieldDefNum.Power, 2);
                        PowerField.SetValue(100);
                        e.mesg.InsertField(0, PowerField);
                    }   
                }
            }
        }
    }
}
