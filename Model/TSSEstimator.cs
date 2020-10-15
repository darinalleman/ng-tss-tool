using System.Collections.Generic;
using System;
using Models;

public static class TSSEstimator
{
    public static double FromHeartRate(IList<int> Zones, IList<int> HeartRates)
    {
        IList<HeartRateZone> HeartRateZones = BuildZones(Zones);
        double totalTSS = 0;
        foreach(int HeartRate in HeartRates)
        {
            totalTSS += CalculateTSS(HeartRate, HeartRateZones);
        }
        if (totalTSS > 0) 
        {
            var finalTSS = totalTSS/3600;
            TSSTool.TSS = finalTSS;
    		return finalTSS;
        }
        else 
            return 0;
    }
    /**
    http://home.trainingpeaks.com/blog/article/estimating-training-stress-score-tss
     */
    private static IList<HeartRateZone> BuildZones(IList<int> Zones)
    {
        IList<HeartRateZone> HeartRateZones = new List<HeartRateZone>();
        HeartRateZone Zone1 = new HeartRateZone(0, Zones[0] - 40, 0, 20);
        HeartRateZones.Add(Zone1);
        HeartRateZone Zone2 = new HeartRateZone(Zone1.HREnd+1, Zones[0] - 10, 20, 30);
        HeartRateZones.Add(Zone2);
        HeartRateZone Zone3 = new HeartRateZone(Zone2.HREnd+1, Zones[0], 30, 40);
        HeartRateZones.Add(Zone3);
        HeartRateZone Zone4 = new HeartRateZone(Zone3.HREnd+1, Zones[1] - ((Zones[1] - Zones[0]) / 2), 40, 50);
        HeartRateZones.Add(Zone4);
        HeartRateZone Zone5 = new HeartRateZone(Zone4.HREnd+1, Zones[1], 50, 60);
        HeartRateZones.Add(Zone5);
        HeartRateZone Zone6 = new HeartRateZone(Zone5.HREnd+1, Zones[2], 60, 70);
        HeartRateZones.Add(Zone6);
        HeartRateZone Zone7 = new HeartRateZone(Zone6.HREnd+1, Zones[3], 70, 80);
        HeartRateZones.Add(Zone7);
        HeartRateZone Zone8 = new HeartRateZone(Zone7.HREnd+1, Zones[3] + (Zones[4] - Zones[3]) / 3, 80, 100);
        HeartRateZones.Add(Zone8);
        HeartRateZone Zone9 = new HeartRateZone(Zone8.HREnd+1,  Zones[3] + 2 * (Zones[4] - Zones[3]) / 3, 100, 120);
        HeartRateZones.Add(Zone9);
        HeartRateZone Zone10 = new HeartRateZone(Zone9.HREnd+1,  Zones[4], 120, 140);
        HeartRateZones.Add(Zone10);
        return HeartRateZones;
    }

    private static double CalculateTSS(int HeartRate, IList<HeartRateZone> HeartRateZones)
    {
        double tss = 0;
        for (int i = 0; i < HeartRateZones.Count; i++)
        {
            if (HeartRateZones[i].Contains(HeartRate))
            {
                HeartRateZone HRZ = HeartRateZones[i];
                tss = HRZ.TSSStart + (HeartRate - HRZ.HRStart)*((HRZ.TSSEnd - HRZ.TSSStart)/(HRZ.HREnd - HRZ.HRStart));
            }
        }
        return tss;
    }

}