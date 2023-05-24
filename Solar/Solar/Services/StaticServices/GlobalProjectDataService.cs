namespace Solar.Services.StaticServices
{
    public static class GlobalProjectDataService
    {
        public static Project? ProjectDataNewProject { get; set; }
        public static Project? ProjectDataStepOne { get; set; }
        public static Project? ProjectDataStepTwo { get; set; }
        public static Project? ProjectDataStepThree { get; set; }
        public static Project? ProjectDataStepThreePointFive { get; set; }
        public static Project? ProjectDataStepFour { get; set; }



        public static Project Merge()
        {
            Project mergedProject = new Project();

            mergedProject.CaseName = ProjectDataNewProject.CaseName;
            mergedProject.Address = ProjectDataNewProject.Address;
            mergedProject.Zip = ProjectDataNewProject.Zip;
            mergedProject.StartDate = ProjectDataNewProject.StartDate;
            mergedProject.Followup = ProjectDataNewProject.Followup;
            mergedProject.Deadline = ProjectDataNewProject.Deadline;
            System.Diagnostics.Debug.WriteLine(ProjectDataStepOne.Assembly.RoofTypeId);
            int? rooofidtest = ProjectDataStepOne.Assembly.RoofTypeId;
            mergedProject.Assembly.RoofTypeId = rooofidtest;
            mergedProject.Assembly.RoofMaterialId = ProjectDataStepOne.Assembly.RoofMaterialId;
            mergedProject.Assembly.EastWestDirection = ProjectDataStepOne.Assembly.EastWestDirection;
            mergedProject.Assembly.Slope = ProjectDataStepOne.Assembly.Slope;
            mergedProject.Assembly.BuildingHeight = ProjectDataStepOne.Assembly.BuildingHeight;

            mergedProject.Battery.BatteryPrepare = ProjectDataStepTwo.Battery.BatteryPrepare;
            mergedProject.BatteryRequest.Capacity = ProjectDataStepTwo.BatteryRequest.Capacity;

            mergedProject.DimensioningId = ProjectDataStepThree.DimensioningId;
            mergedProject.DimensioningkWp.KiloWattPeak = ProjectDataStepThree.DimensioningkWp.KiloWattPeak;

            mergedProject.DimensioningConsumption.CategoryId = ProjectDataStepThreePointFive.DimensioningConsumption.CategoryId;
            mergedProject.DimensioningConsumption.CurrentConsumption = ProjectDataStepThreePointFive.DimensioningConsumption.CurrentConsumption;
            mergedProject.DimensioningConsumption.HeatPump = ProjectDataStepThreePointFive.DimensioningConsumption.HeatPump;
            mergedProject.DimensioningConsumption.HeatPumpIncluded = ProjectDataStepThreePointFive.DimensioningConsumption.HeatPumpIncluded;
            mergedProject.DimensioningConsumption.HouseSize = ProjectDataStepThreePointFive.DimensioningConsumption.HouseSize;
            mergedProject.DimensioningConsumption.EvKilometer = ProjectDataStepThreePointFive.DimensioningConsumption.EvKilometer;

            return mergedProject;

        }
        // Make new project object and merge from others 

    }
}
