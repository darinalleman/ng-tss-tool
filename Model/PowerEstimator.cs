using System.Collections.Generic;
using System;
using Models;
public static class PowerEstimator
{
    public static int CalculatePower(int FTP) 
    {
        TSSTool.AveragePower = (int)(Math.Sqrt(FTP*FTP*TSSTool.TSS*36/ElapsedTimeLogger.Instance.ElapsedTime));
        return TSSTool.AveragePower;
    }

}