﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DahlDesign.Plugin
{
    /// <summary>
    /// Settings class, make sure it can be correctly serialized using JSON.net
    /// </summary>
    public class DataPluginSettings : INotifyPropertyChanged
    {
        public int ReactionTime { get; set; } = 300;
        public bool DDUEnabled { get; set; } = false;
        public int DDUstartLED { get; set; } = 1;
        public bool SW1Enabled { get; set; } = false;
        public int SW1startLED { get; set; } = 30;

        public bool DashLEDEnabled { get; set; } = false;
        public bool LapInfoScreen { get; set; } = true;
        public bool ShiftWarning { get; set; } = false;
        public bool WheelSlipLEDs { get; set; } = false;

        public int SmallFuelIncrement { get; set; } = 2; //In Liters
        public int LargeFuelIncrement { get; set; } = 10; //In Liters

        public double FuelCalculationMargin { get; set; } = 0; //In liters

        public double FuelCommandMargin { get; set; } = 0.5; //In liters

        public bool CoupleInCarToPit { get; set; } = true; //Only allow pit commands when the in-car rotary is on Pit Mode.

        public bool ShiftTimingAssist { get; set; } = false;

        public string AheadPlayerText { get; set; } = "Blue flag";

        public string BehindPlayerText { get; set; } = "Sorry!";

        public string DDC { get; set; } = "Arduino_Leonardo";
        
        public bool DDCEnabled { get; set; } = false;
        
        public bool DDCclutchEnabled { get; set; } = false;

        public bool DDSEnabled { get; set; } = false;

        public double fuelPerLapTarget { get; set; } = 2.50;

        public double fuelOffsetIncrement { get; set; } = 0.01;

        public bool SupercarSwapPosition { get; set; } = false;

        public bool SupercarARBDirection { get; set; } = false;

        public bool CorrectByPitstop { get; set; } = false;

        public bool ShowMapEnabled { get; set; } = false;
        public bool ShowBrakeThrottleGaugesEnabled { get; set; } = false;
        public string DashType { get; set; } = "Automatic Selection";
        public string LeftScreen { get; set; } = "Time Attack";
        public string RightScreen { get; set; } = "Practice";

        #region Property supporting UI refresh from code
        /*
        private string _FilePath;
        public string FilePath
        {
            get => _FilePath;
            set => SetField(ref _FilePath, value);
        }
        */
        #endregion

        #region Utilities methods to refresh the UI see https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.7.2

        protected void OnPropertyChanged(string propertyName)
          => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


    }


}