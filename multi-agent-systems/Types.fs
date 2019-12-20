﻿module Types

type Activity =
    | NONE
    | HUNTING
    | BUILDING

type Fauna =
    | Rabbos
    | Staggi

type VotingSystem =
    | InstantRunoff
    | Approval
    | Borda
    | Plurality

type FoodRule =
    | Communism // Equal Split
    | Socialism // Weakest get more
    | Meritocracy // Biggest contributors get more
    | Oligarchy // Strongest get more

type ShelterRule =
    | Random
    | Socialism // Weakest get more
    | Meritocracy // Biggest contributors get more
    | Oligarchy // Strongest get more

type WorkAllocation =
    | Everyone
    | Strongest
    | ByChoice

type Punishment =
    | NoFoodAndShelter
    | Exile
    | Increment
    | Decrement

type Rule =
    | Shelter of ShelterRule
    | Food of FoodRule
    | Voting of VotingSystem
    | Work of WorkAllocation
    | Sanction of Punishment

type Agent = {
    ID : int;
    Susceptibility : float;
    Idealism : float;
    Egotism : float;
    
    Reward : float;
    Friends : Agent list;
    Enemies : Agent list;
    Infamy : float;
    Energy : float;
    TodaysActivity : Activity * float;
    AccessToShelter : float option;
    BuildingAptitude : float;
    HuntingAptitude : float;
    }

type Reward = float
type SocialGood = float

type RuleSet = (Rule * Reward * SocialGood) list


type WorldState = {
    Buildings : float list;
    CurrentChair : Agent option;
    TimeToNewChair : int;
    CurrentShelterRule : ShelterRule;
    CurrentVotingRule : VotingSystem;
    CurrentFoodRule : FoodRule;
    CurrentWorkRule : WorkAllocation;
    CurrentMaxPunishment : Punishment;
    CurrentSanctionStepSize : float;
    CurrentDay : int;
    NumHare : int;
    NumStag : int;
    //RuleSet : RuleSet;
    }

type Shelter = {
    Quality : float
}

type Proposal = Rule * Agent list


