using System;
using System.Collections.Generic;
using Dynastream.Fit;
using System.IO;

namespace Models
{
    public class TSSTool
    {
        private static TSSTool Instance = null;
        public static int AveragePower { get; set;}
        public static double TSS { get; set;}
        public static Dynastream.Fit.Encode Encoder = new Encode(ProtocolVersion.V20);

        public static TSSTool GetInstance()
        {
            if (Instance == null)
            {
                return new TSSTool();
            }
            else {
                return Instance;
            }
        }

        public Boolean DecodeFile(FileStream fitSource)
        {
            Decode decoder = new Decode();
            MesgBroadcaster Broadcaster = new MesgBroadcaster();

            decoder.MesgEvent += Broadcaster.OnMesg;
            decoder.MesgDefinitionEvent += Broadcaster.OnMesgDefinition;

            //add HrMesg listener HeartRateMesgListener
            Broadcaster.RecordMesgEvent += HeartRateMesgListener.MesgEvent;
            Broadcaster.SessionMesgEvent += ElapsedTimeMesgListener.MesgEvent;
            //Broadcaster.RecordMesgEvent += PowerEncodeListener.MesgEvent;

            Boolean status = decoder.IsFIT(fitSource);
            status &= decoder.CheckIntegrity(fitSource);

            Boolean DecodeResult;
            if (status)
            {
                HeartRateLogger.Instance.Reset();
                DecodeResult = decoder.Read(fitSource);
            }
            else{
                try
                    {
                        Console.WriteLine("Integrity Check Failed {0}", fitSource.Name);
                        if (decoder.InvalidDataSize)
                        {
                            Console.WriteLine("Invalid Size Detected, Attempting to decode...");
                            DecodeResult = decoder.Read(fitSource);
                        }
                        else
                        {
                            Console.WriteLine("Attempting to decode by skipping the header...");
                            DecodeResult = decoder.Read(fitSource, DecodeMode.InvalidHeader);
                        }
                    }
                    catch (FitException ex)
                    {
                        Console.WriteLine("DecodeDemo caught FitException: " + ex.Message);
                        DecodeResult = false;
                    }
            }
            fitSource.Dispose();
            return DecodeResult;
        }

        public Boolean EncodeFile(FileStream fitSource, FileStream fitDest) 
        {
            Encoder.Open(fitDest);
            Decode decoder = new Decode();
            MesgBroadcaster Broadcaster = new MesgBroadcaster();
            decoder.MesgEvent += Broadcaster.OnMesg;
            decoder.MesgDefinitionEvent += Broadcaster.OnMesgDefinition;
            Broadcaster.MesgEvent += PowerEncodeListener.MesgEvent;
            Broadcaster.MesgDefinitionEvent += PowerEncodeListener.MesgDefinitionEvent;
            Boolean DecodeResult;
            DecodeResult = decoder.Read(fitSource);
            Encoder.Close();
            fitSource.Close();
            fitDest.Close();
            return DecodeResult;
        }

    }
}
