namespace Solar.Services.StaticServices
{
    public class GlobalProjectDataService
    {
        public static Project? ProjectDataNewProject { get; set; }
        public static Project? ProjectDataStepOne { get; set; }
        public static Project? ProjectDataStepTwo { get; set; }
        public static Project? ProjectDataStepThree { get; set; }
        public static Project? ProjectDataStepThreePointFive { get; set; }
        public static Project? ProjectDataStepFour { get; set; }



        public static Project Merge(List<Project> projects)
        {
            Project mergedProject = new Project();

            foreach (var project in projects)
            {
                mergedProject.CaseName = project.CaseName;
                mergedProject.Address = project.Address;
                mergedProject.Zip = project.Zip;
                mergedProject.StartDate = project.StartDate;
                mergedProject.Deadline = project.Deadline;
                mergedProject.Followup = project.Followup;
                mergedProject.Installer = project.Installer;
                mergedProject.Department = project.Department;
                mergedProject.Contact = project.Contact;
                mergedProject.PhoneNumber = project.PhoneNumber;
                mergedProject.Email = project.Email;
                mergedProject.Remarks = project.Remarks;
                mergedProject.Assembly.RoofTypeId = project.Assembly.RoofTypeId;
                mergedProject.Assembly.RoofMaterialId = project.Assembly.RoofMaterialId;
                mergedProject.Assembly.EastWestDirection = project.Assembly.EastWestDirection;
                mergedProject.Assembly.Slope = project.Assembly.Slope;
                mergedProject.Assembly.BuildingHeight = project.Assembly.BuildingHeight;
                mergedProject.Battery.BatteryPrepare = project.Battery.BatteryPrepare;
                mergedProject.BatteryRequest.Capacity = project.BatteryRequest.Capacity;
                mergedProject.DimensioningId = project.DimensioningId;
                mergedProject.DimensioningkWp.KiloWattPeak = project.DimensioningkWp.KiloWattPeak;
                mergedProject.DimensioningConsumption.CurrentConsumption = project.DimensioningConsumption.CurrentConsumption;
                mergedProject.DimensioningConsumption.HeatPump = project.DimensioningConsumption.HeatPump;
                mergedProject.DimensioningConsumption.HeatPumpIncluded = project.DimensioningConsumption.HeatPumpIncluded;
                mergedProject.DimensioningConsumption.HouseSize = project.DimensioningConsumption.HouseSize;
                mergedProject.DimensioningConsumption.EvKilometer = project.DimensioningConsumption.EvKilometer;
            }

            return mergedProject;

        }
        // Make new project object and merge from others 

    }
}
