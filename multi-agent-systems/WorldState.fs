﻿module WorldState

open Types
open Agent1

let currentWorld = {
    VotingType = Borda;
    Buildings = [];
    Policies = List.empty<Rule * bool>;
    System = List.empty<ImmutableRule>;
    CurrentTurn = 1;
    NumStag = 10;
    NumHare = 10;
    }

let energyProfile (agents : Agent1 list) =
    agents
    |> List.map (fun el -> el.ID * el.Energy)