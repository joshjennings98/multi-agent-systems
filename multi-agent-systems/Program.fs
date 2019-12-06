﻿// Learn more about F# at http://fsharp.org

open System
open Agent
open Agent1
open Types
open Voting
open Activities
open Hunt
open Build
open Config
open WorldState

[<EntryPoint>]
let main argv =

    // Agent parsing

    try
        printfn "%A" (Parsing.parse argv) |> Parsing.printAgent |> ignore
    with e ->
        printfn "%s" e.Message


    // Start of game loop
    let mutable new_agents = Parsing.Agents
    let mutable oldAgents = agents
        

    
    let rec loop (currentWorld : WorldState) : WorldState =
        if float(currentWorld.CurrentTurn) >= maxSimulationTurn then currentWorld
        else
            new_agents <- 
                new_agents 
                |> List.map (fun el -> el) // PlaceHolder for Duma
                |> List.map (fun el -> 
                                {el with Activity = match rand.Next(1, 3) with
                                                    | 1 -> NONE
                                                    | 2 -> HUNTING
                                                    | 3 -> BUILDING}) // Placeholder for work allocation

            let hunt = hunt // PlaceHolder

            // To ensure consistency of agent definition, use oldAgents first
            let currentWorld = newWorldShelters currentWorld oldAgents
            


            new_agents <- 
                new_agents
                |> List.map (fun el -> {el with AccessToShelter = 0}) // PlaceHolder for sanctioning
                |> List.map (fun el -> {el with Energy = el.Energy + rand.Next(10)}) // PlaceHolder for food distribution
            
            oldAgents <- 
                oldAgents
                |> assignShelters currentWorld
                |> List.map (fun el -> newAgentEnergy el) // Energy Resolution


            let currentWorld = 
                {currentWorld with CurrentTurn = currentWorld.CurrentTurn + 1; NumHare = regenRate 0.1 currentWorld.NumHare maxNumHare; NumStag = regenRate 0.1 currentWorld.NumStag maxNumStag}  // Regeneration

            loop currentWorld

    
    let finalWorld = loop currentWorld;

    printfn "Final world status: %A" finalWorld;
    
    0

//    // Testing shit    
//    let whatToDo (agents : Agent list) =
//        agents
//        |> List.map (fun el ->
//            "\n" + el.Name +
//            " will do " + (el.TodaysActivity |> fst |> string) +
//            " and expend " + (el.TodaysActivity |> snd |> string) + " energy."
//        )
//
//    let allAgents =
//        agents 
//        |> jobAllocation
//
//
//    let builders =
//        allAgents
//        |> List.filter (fun el -> fst el.TodaysActivity = Building)
//
//
//    let hunters =
//        allAgents
//        |> List.filter (fun el -> fst el.TodaysActivity = Hunting)
//    
//    printfn "%A" agents
//    printfn "%A" (whatToDo allAgents)
//
//    printfn "borda winner %A" (voteOnWhatToHunt Borda hunters)
//    printfn "plurality winner %A" (voteOnWhatToHunt Plurality hunters)
//    printfn "approval winner %A" (voteOnWhatToHunt Approval hunters)
//    printfn "instant runnoff winner %A" (voteOnWhatToHunt InstantRunoff hunters)
//
//    let hunting = voteOnWhatToHunt Borda hunters
//
//    let test = 
//        hunters
//        |> hunt hunting huntingTime
//
//
//    printfn "Leftovers: %A" test
//
//    0 // return an integer exit code
//