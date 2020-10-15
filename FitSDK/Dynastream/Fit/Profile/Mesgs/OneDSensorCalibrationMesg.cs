#region Copyright
////////////////////////////////////////////////////////////////////////////////
// The following FIT Protocol software provided may be used with FIT protocol
// devices only and remains the copyrighted property of Garmin Canada Inc.
// The software is being provided on an "as-is" basis and as an accommodation,
// and therefore all warranties, representations, or guarantees of any kind
// (whether express, implied or statutory) including, without limitation,
// warranties of merchantability, non-infringement, or fitness for a particular
// purpose, are specifically disclaimed.
//
// Copyright 2020 Garmin Canada Inc.
////////////////////////////////////////////////////////////////////////////////
// ****WARNING****  This file is auto-generated!  Do NOT edit this file.
// Profile Version = 21.38Release
// Tag = production/akw/21.38.00-0-g0d69e49
////////////////////////////////////////////////////////////////////////////////

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Linq;

namespace Dynastream.Fit
{
    /// <summary>
    /// Implements the OneDSensorCalibration profile message.
    /// </summary>
    public class OneDSensorCalibrationMesg : Mesg
    {
        #region Fields
        static class CalibrationFactorSubfield
        {
            public static ushort BaroCalFactor = 0;
            public static ushort Subfields = 1;
            public static ushort Active = Fit.SubfieldIndexActiveSubfield;
            public static ushort MainField = Fit.SubfieldIndexMainField;
        }
        #endregion

        /// <summary>
        /// Field Numbers for <see cref="OneDSensorCalibrationMesg"/>
        /// </summary>
        public sealed class FieldDefNum
        {
            public const byte Timestamp = 253;
            public const byte SensorType = 0;
            public const byte CalibrationFactor = 1;
            public const byte CalibrationDivisor = 2;
            public const byte LevelShift = 3;
            public const byte OffsetCal = 4;
            public const byte Invalid = Fit.FieldNumInvalid;
        }

        #region Constructors
        public OneDSensorCalibrationMesg() : base(Profile.GetMesg(MesgNum.OneDSensorCalibration))
        {
        }

        public OneDSensorCalibrationMesg(Mesg mesg) : base(mesg)
        {
        }
        #endregion // Constructors

        #region Methods
        ///<summary>
        /// Retrieves the Timestamp field
        /// Units: s
        /// Comment: Whole second part of the timestamp</summary>
        /// <returns>Returns DateTime representing the Timestamp field</returns>
        public DateTime GetTimestamp()
        {
            Object val = GetFieldValue(253, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return TimestampToDateTime(Convert.ToUInt32(val));
            
        }

        /// <summary>
        /// Set Timestamp field
        /// Units: s
        /// Comment: Whole second part of the timestamp</summary>
        /// <param name="timestamp_">Nullable field value to be set</param>
        public void SetTimestamp(DateTime timestamp_)
        {
            SetFieldValue(253, 0, timestamp_.GetTimeStamp(), Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the SensorType field
        /// Comment: Indicates which sensor the calibration is for</summary>
        /// <returns>Returns nullable SensorType enum representing the SensorType field</returns>
        public SensorType? GetSensorType()
        {
            object obj = GetFieldValue(0, 0, Fit.SubfieldIndexMainField);
            SensorType? value = obj == null ? (SensorType?)null : (SensorType)obj;
            return value;
        }

        /// <summary>
        /// Set SensorType field
        /// Comment: Indicates which sensor the calibration is for</summary>
        /// <param name="sensorType_">Nullable field value to be set</param>
        public void SetSensorType(SensorType? sensorType_)
        {
            SetFieldValue(0, 0, sensorType_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the CalibrationFactor field
        /// Comment: Calibration factor used to convert from raw ADC value to degrees, g,  etc.</summary>
        /// <returns>Returns nullable uint representing the CalibrationFactor field</returns>
        public uint? GetCalibrationFactor()
        {
            Object val = GetFieldValue(1, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt32(val));
            
        }

        /// <summary>
        /// Set CalibrationFactor field
        /// Comment: Calibration factor used to convert from raw ADC value to degrees, g,  etc.</summary>
        /// <param name="calibrationFactor_">Nullable field value to be set</param>
        public void SetCalibrationFactor(uint? calibrationFactor_)
        {
            SetFieldValue(1, 0, calibrationFactor_, Fit.SubfieldIndexMainField);
        }
        

        /// <summary>
        /// Retrieves the BaroCalFactor subfield
        /// Units: Pa
        /// Comment: Barometer calibration factor</summary>
        /// <returns>Nullable uint representing the BaroCalFactor subfield</returns>
        public uint? GetBaroCalFactor()
        {
            Object val = GetFieldValue(1, 0, CalibrationFactorSubfield.BaroCalFactor);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt32(val));
            
        }

        /// <summary>
        ///
        /// Set BaroCalFactor subfield
        /// Units: Pa
        /// Comment: Barometer calibration factor</summary>
        /// <param name="baroCalFactor">Subfield value to be set</param>
        public void SetBaroCalFactor(uint? baroCalFactor)
        {
            SetFieldValue(1, 0, baroCalFactor, CalibrationFactorSubfield.BaroCalFactor);
        }
        ///<summary>
        /// Retrieves the CalibrationDivisor field
        /// Units: counts
        /// Comment: Calibration factor divisor</summary>
        /// <returns>Returns nullable uint representing the CalibrationDivisor field</returns>
        public uint? GetCalibrationDivisor()
        {
            Object val = GetFieldValue(2, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt32(val));
            
        }

        /// <summary>
        /// Set CalibrationDivisor field
        /// Units: counts
        /// Comment: Calibration factor divisor</summary>
        /// <param name="calibrationDivisor_">Nullable field value to be set</param>
        public void SetCalibrationDivisor(uint? calibrationDivisor_)
        {
            SetFieldValue(2, 0, calibrationDivisor_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the LevelShift field
        /// Comment: Level shift value used to shift the ADC value back into range</summary>
        /// <returns>Returns nullable uint representing the LevelShift field</returns>
        public uint? GetLevelShift()
        {
            Object val = GetFieldValue(3, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt32(val));
            
        }

        /// <summary>
        /// Set LevelShift field
        /// Comment: Level shift value used to shift the ADC value back into range</summary>
        /// <param name="levelShift_">Nullable field value to be set</param>
        public void SetLevelShift(uint? levelShift_)
        {
            SetFieldValue(3, 0, levelShift_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the OffsetCal field
        /// Comment: Internal Calibration factor</summary>
        /// <returns>Returns nullable int representing the OffsetCal field</returns>
        public int? GetOffsetCal()
        {
            Object val = GetFieldValue(4, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToInt32(val));
            
        }

        /// <summary>
        /// Set OffsetCal field
        /// Comment: Internal Calibration factor</summary>
        /// <param name="offsetCal_">Nullable field value to be set</param>
        public void SetOffsetCal(int? offsetCal_)
        {
            SetFieldValue(4, 0, offsetCal_, Fit.SubfieldIndexMainField);
        }
        
        #endregion // Methods
    } // Class
} // namespace
