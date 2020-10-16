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
                        PowerField = new Field("Power", RecordMesg.FieldDefNum.Power, 132, 1, 0, "watts", false, Profile.Type.DisplayPower);
                        PowerField.SetValue(TSSTool.AveragePower);
                        e.mesg.InsertField(0, PowerField);
                    }   
                }
            }
            TSSTool.Encoder.Write(e.mesg);
        }

        public static void MesgDefinitionEvent(object sender, MesgDefinitionEventArgs e) 
        {
            TSSTool.Encoder.Write(e.mesgDef);
        }

    }
}
