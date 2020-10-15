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
    /// Implements the Length profile message.
    /// </summary>
    public class LengthMesg : Mesg
    {
        #region Fields
        #endregion

        /// <summary>
        /// Field Numbers for <see cref="LengthMesg"/>
        /// </summary>
        public sealed class FieldDefNum
        {
            public const byte MessageIndex = 254;
            public const byte Timestamp = 253;
            public const byte Event = 0;
            public const byte EventType = 1;
            public const byte StartTime = 2;
            public const byte TotalElapsedTime = 3;
            public const byte TotalTimerTime = 4;
            public const byte TotalStrokes = 5;
            public const byte AvgSpeed = 6;
            public const byte SwimStroke = 7;
            public const byte AvgSwimmingCadence = 9;
            public const byte EventGroup = 10;
            public const byte TotalCalories = 11;
            public const byte LengthType = 12;
            public const byte PlayerScore = 18;
            public const byte OpponentScore = 19;
            public const byte StrokeCount = 20;
            public const byte ZoneCount = 21;
            public const byte Invalid = Fit.FieldNumInvalid;
        }

        #region Constructors
        public LengthMesg() : base(Profile.GetMesg(MesgNum.Length))
        {
        }

        public LengthMesg(Mesg mesg) : base(mesg)
        {
        }
        #endregion // Constructors

        #region Methods
        ///<summary>
        /// Retrieves the MessageIndex field</summary>
        /// <returns>Returns nullable ushort representing the MessageIndex field</returns>
        public ushort? GetMessageIndex()
        {
            Object val = GetFieldValue(254, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt16(val));
            
        }

        /// <summary>
        /// Set MessageIndex field</summary>
        /// <param name="messageIndex_">Nullable field value to be set</param>
        public void SetMessageIndex(ushort? messageIndex_)
        {
            SetFieldValue(254, 0, messageIndex_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the Timestamp field</summary>
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
        /// Set Timestamp field</summary>
        /// <param name="timestamp_">Nullable field value to be set</param>
        public void SetTimestamp(DateTime timestamp_)
        {
            SetFieldValue(253, 0, timestamp_.GetTimeStamp(), Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the Event field</summary>
        /// <returns>Returns nullable Event enum representing the Event field</returns>
        public Event? GetEvent()
        {
            object obj = GetFieldValue(0, 0, Fit.SubfieldIndexMainField);
            Event? value = obj == null ? (Event?)null : (Event)obj;
            return value;
        }

        /// <summary>
        /// Set Event field</summary>
        /// <param name="event_">Nullable field value to be set</param>
        public void SetEvent(Event? event_)
        {
            SetFieldValue(0, 0, event_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the EventType field</summary>
        /// <returns>Returns nullable EventType enum representing the EventType field</returns>
        public EventType? GetEventType()
        {
            object obj = GetFieldValue(1, 0, Fit.SubfieldIndexMainField);
            EventType? value = obj == null ? (EventType?)null : (EventType)obj;
            return value;
        }

        /// <summary>
        /// Set EventType field</summary>
        /// <param name="eventType_">Nullable field value to be set</param>
        public void SetEventType(EventType? eventType_)
        {
            SetFieldValue(1, 0, eventType_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the StartTime field</summary>
        /// <returns>Returns DateTime representing the StartTime field</returns>
        public DateTime GetStartTime()
        {
            Object val = GetFieldValue(2, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return TimestampToDateTime(Convert.ToUInt32(val));
            
        }

        /// <summary>
        /// Set StartTime field</summary>
        /// <param name="startTime_">Nullable field value to be set</param>
        public void SetStartTime(DateTime startTime_)
        {
            SetFieldValue(2, 0, startTime_.GetTimeStamp(), Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the TotalElapsedTime field
        /// Units: s</summary>
        /// <returns>Returns nullable float representing the TotalElapsedTime field</returns>
        public float? GetTotalElapsedTime()
        {
            Object val = GetFieldValue(3, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToSingle(val));
            
        }

        /// <summary>
        /// Set TotalElapsedTime field
        /// Units: s</summary>
        /// <param name="totalElapsedTime_">Nullable field value to be set</param>
        public void SetTotalElapsedTime(float? totalElapsedTime_)
        {
            SetFieldValue(3, 0, totalElapsedTime_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the TotalTimerTime field
        /// Units: s</summary>
        /// <returns>Returns nullable float representing the TotalTimerTime field</returns>
        public float? GetTotalTimerTime()
        {
            Object val = GetFieldValue(4, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToSingle(val));
            
        }

        /// <summary>
        /// Set TotalTimerTime field
        /// Units: s</summary>
        /// <param name="totalTimerTime_">Nullable field value to be set</param>
        public void SetTotalTimerTime(float? totalTimerTime_)
        {
            SetFieldValue(4, 0, totalTimerTime_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the TotalStrokes field
        /// Units: strokes</summary>
        /// <returns>Returns nullable ushort representing the TotalStrokes field</returns>
        public ushort? GetTotalStrokes()
        {
            Object val = GetFieldValue(5, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt16(val));
            
        }

        /// <summary>
        /// Set TotalStrokes field
        /// Units: strokes</summary>
        /// <param name="totalStrokes_">Nullable field value to be set</param>
        public void SetTotalStrokes(ushort? totalStrokes_)
        {
            SetFieldValue(5, 0, totalStrokes_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the AvgSpeed field
        /// Units: m/s</summary>
        /// <returns>Returns nullable float representing the AvgSpeed field</returns>
        public float? GetAvgSpeed()
        {
            Object val = GetFieldValue(6, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToSingle(val));
            
        }

        /// <summary>
        /// Set AvgSpeed field
        /// Units: m/s</summary>
        /// <param name="avgSpeed_">Nullable field value to be set</param>
        public void SetAvgSpeed(float? avgSpeed_)
        {
            SetFieldValue(6, 0, avgSpeed_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the SwimStroke field
        /// Units: swim_stroke</summary>
        /// <returns>Returns nullable SwimStroke enum representing the SwimStroke field</returns>
        public SwimStroke? GetSwimStroke()
        {
            object obj = GetFieldValue(7, 0, Fit.SubfieldIndexMainField);
            SwimStroke? value = obj == null ? (SwimStroke?)null : (SwimStroke)obj;
            return value;
        }

        /// <summary>
        /// Set SwimStroke field
        /// Units: swim_stroke</summary>
        /// <param name="swimStroke_">Nullable field value to be set</param>
        public void SetSwimStroke(SwimStroke? swimStroke_)
        {
            SetFieldValue(7, 0, swimStroke_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the AvgSwimmingCadence field
        /// Units: strokes/min</summary>
        /// <returns>Returns nullable byte representing the AvgSwimmingCadence field</returns>
        public byte? GetAvgSwimmingCadence()
        {
            Object val = GetFieldValue(9, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToByte(val));
            
        }

        /// <summary>
        /// Set AvgSwimmingCadence field
        /// Units: strokes/min</summary>
        /// <param name="avgSwimmingCadence_">Nullable field value to be set</param>
        public void SetAvgSwimmingCadence(byte? avgSwimmingCadence_)
        {
            SetFieldValue(9, 0, avgSwimmingCadence_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the EventGroup field</summary>
        /// <returns>Returns nullable byte representing the EventGroup field</returns>
        public byte? GetEventGroup()
        {
            Object val = GetFieldValue(10, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToByte(val));
            
        }

        /// <summary>
        /// Set EventGroup field</summary>
        /// <param name="eventGroup_">Nullable field value to be set</param>
        public void SetEventGroup(byte? eventGroup_)
        {
            SetFieldValue(10, 0, eventGroup_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the TotalCalories field
        /// Units: kcal</summary>
        /// <returns>Returns nullable ushort representing the TotalCalories field</returns>
        public ushort? GetTotalCalories()
        {
            Object val = GetFieldValue(11, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt16(val));
            
        }

        /// <summary>
        /// Set TotalCalories field
        /// Units: kcal</summary>
        /// <param name="totalCalories_">Nullable field value to be set</param>
        public void SetTotalCalories(ushort? totalCalories_)
        {
            SetFieldValue(11, 0, totalCalories_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the LengthType field</summary>
        /// <returns>Returns nullable LengthType enum representing the LengthType field</returns>
        public LengthType? GetLengthType()
        {
            object obj = GetFieldValue(12, 0, Fit.SubfieldIndexMainField);
            LengthType? value = obj == null ? (LengthType?)null : (LengthType)obj;
            return value;
        }

        /// <summary>
        /// Set LengthType field</summary>
        /// <param name="lengthType_">Nullable field value to be set</param>
        public void SetLengthType(LengthType? lengthType_)
        {
            SetFieldValue(12, 0, lengthType_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the PlayerScore field</summary>
        /// <returns>Returns nullable ushort representing the PlayerScore field</returns>
        public ushort? GetPlayerScore()
        {
            Object val = GetFieldValue(18, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt16(val));
            
        }

        /// <summary>
        /// Set PlayerScore field</summary>
        /// <param name="playerScore_">Nullable field value to be set</param>
        public void SetPlayerScore(ushort? playerScore_)
        {
            SetFieldValue(18, 0, playerScore_, Fit.SubfieldIndexMainField);
        }
        
        ///<summary>
        /// Retrieves the OpponentScore field</summary>
        /// <returns>Returns nullable ushort representing the OpponentScore field</returns>
        public ushort? GetOpponentScore()
        {
            Object val = GetFieldValue(19, 0, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt16(val));
            
        }

        /// <summary>
        /// Set OpponentScore field</summary>
        /// <param name="opponentScore_">Nullable field value to be set</param>
        public void SetOpponentScore(ushort? opponentScore_)
        {
            SetFieldValue(19, 0, opponentScore_, Fit.SubfieldIndexMainField);
        }
        
        
        /// <summary>
        ///
        /// </summary>
        /// <returns>returns number of elements in field StrokeCount</returns>
        public int GetNumStrokeCount()
        {
            return GetNumFieldValues(20, Fit.SubfieldIndexMainField);
        }

        ///<summary>
        /// Retrieves the StrokeCount field
        /// Units: counts
        /// Comment: stroke_type enum used as the index</summary>
        /// <param name="index">0 based index of StrokeCount element to retrieve</param>
        /// <returns>Returns nullable ushort representing the StrokeCount field</returns>
        public ushort? GetStrokeCount(int index)
        {
            Object val = GetFieldValue(20, index, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt16(val));
            
        }

        /// <summary>
        /// Set StrokeCount field
        /// Units: counts
        /// Comment: stroke_type enum used as the index</summary>
        /// <param name="index">0 based index of stroke_count</param>
        /// <param name="strokeCount_">Nullable field value to be set</param>
        public void SetStrokeCount(int index, ushort? strokeCount_)
        {
            SetFieldValue(20, index, strokeCount_, Fit.SubfieldIndexMainField);
        }
        
        
        /// <summary>
        ///
        /// </summary>
        /// <returns>returns number of elements in field ZoneCount</returns>
        public int GetNumZoneCount()
        {
            return GetNumFieldValues(21, Fit.SubfieldIndexMainField);
        }

        ///<summary>
        /// Retrieves the ZoneCount field
        /// Units: counts
        /// Comment: zone number used as the index</summary>
        /// <param name="index">0 based index of ZoneCount element to retrieve</param>
        /// <returns>Returns nullable ushort representing the ZoneCount field</returns>
        public ushort? GetZoneCount(int index)
        {
            Object val = GetFieldValue(21, index, Fit.SubfieldIndexMainField);
            if(val == null)
            {
                return null;
            }

            return (Convert.ToUInt16(val));
            
        }

        /// <summary>
        /// Set ZoneCount field
        /// Units: counts
        /// Comment: zone number used as the index</summary>
        /// <param name="index">0 based index of zone_count</param>
        /// <param name="zoneCount_">Nullable field value to be set</param>
        public void SetZoneCount(int index, ushort? zoneCount_)
        {
            SetFieldValue(21, index, zoneCount_, Fit.SubfieldIndexMainField);
        }
        
        #endregion // Methods
    } // Class
} // namespace
