Example:

C:\test>DataGenerator.exe 10 10 10

where:
argument 1 is the seconds between generations.
argument 2 is the number of vehicles in the fleet.
argument 3 is the number of spn informations to spawn per vehicle per generation

output files will appear in the same folder as the program.

output file format is : veh{UniqueVehicleId}_MonthDayYear_HourMinuteSecond.data
output file contents are:
eg: [10-07-2015_09:29:17,9,1021,55349][10-07-2015_09:29:17,9,1021,55349][10-07-2015_09:29:17,9,1021,55349]...
ie: [Date_Time,UniqueVehicleId,SpnNumber,SpnValue][Date_Time,UniqueVehicleId,SpnNumber,SpnValue]...

see example output file for details.