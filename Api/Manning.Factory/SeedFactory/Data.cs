namespace Manning.Factory.SeedFactory;

public static class Data
{
    public readonly static Dictionary<string, string[]> ZoneStationsSeedData = new()
    {
        {
            "Manufacturing",
            new string[]
            {
                "Engine",
                "Transmission",
                "Brakes",
                "Fuel Pump",
                "Gearbox",
                "Exhaust"
            }
        },
        {
            "Fabrication",
            new string[]
            {
                "Chassis",
                "Interior",
                "Airbags",
                "Entertainment"
            }
        },
        {
            "Assembly",
            new string[]
            {
                "Quality Pass",
                "External",
                "Internal",
                "Paint & Trimming"
            }
        }
    };


    public readonly static (int ClockCardNumber, string OperatorName, bool IsAdministrator)[] OperatorSeedData = new (int ClockCardNumber, string OperatorName, bool IsAdministrator)[]
    {
        (123456, "Josh Morton", true),
        (333222, "Jade Woodward", true),
        (789123, "Emily Rodriguez", false),
        (456789, "Michael Jenkins", false),
        (987654, "Sophia Thompson", true),
        (654321, "Oliver Lee", false),
        (741852, "Ava Turner", true),
        (852963, "Liam Adams", false),
        (159357, "Emma Collins", true),
        (258369, "Noah Butler", false),
    };

    public readonly static (string fileName, int operatorID)[] AvatarSeedData = new (string fileName, int operatorID)[]
    {
      ("avatar-m-1.png", 1),
      ("avatar-f-1.png", 2),
      ("avatar-f-2.png", 3),
      ("avatar-m-2.png", 4),
      ("avatar-f-3.png", 5),
      ("avatar-m-3.png", 6),
      ("avatar-f-4.png", 7),
      ("avatar-m-4.png", 8),
      ("avatar-f-5.png", 9),
      ("avatar-m-5.png", 10),
    };

    public readonly static List<string> TrainingRequirementSeedData = new()
    {
        "Machine Safety Procedures",
        "Equipment Setup and Calibration",
        "Quality Inspection Techniques",
        "Assembly Line Efficiency",
        "Production Documentation and Reporting",
        "Lean Manufacturing Principles",
        "Material Handling and Storage",
        "Workplace Ergonomics",
        "Root Cause Analysis",
        "Statistical Process Control"
    };

    public readonly static string[] ShiftTypeSeedData = new string[]
    {
      "Day Shift",
      "Night Shift",
    };
}