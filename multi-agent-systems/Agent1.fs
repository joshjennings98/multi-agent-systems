﻿module multi_agent_systems.Agent1

type Activity =
    | NONE
    | HUNTING
    | BUILDING
    
type Agent = {
    Profile : string;
    ID : int;
    Selflessness : int; 
    BuildingAptitude : int;
    HuntingAptitude : int;
    Political : int;
    Mood : int;
    Energy : int;
    Activity : Activity;
    AccessToShelter : int;
    Opinions : int[]    // Perhaps change string to int and add an ID field
    }

// Initialise Agent
let initialiseAgent (profile : string) (id : int)  (selflessness : int)  (buildingAptitude : int)  (huntingAptitude : int) (political : int)
                     (mood : int) (energy : int) (activity : Activity) (accessToShelter : int) (opinions : int[])  : Agent =
    {
        Profile = profile;
        ID = id;
        Selflessness = selflessness;
        BuildingAptitude = buildingAptitude;
        HuntingAptitude = huntingAptitude;
        Political = political;
        Mood = mood;
        Energy = energy;
        Activity = activity;
        AccessToShelter = accessToShelter;
        Opinions = opinions;
    }