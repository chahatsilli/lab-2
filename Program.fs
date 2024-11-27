open System

// Define the Coach record
type Coach = {
    Name: string
    FormerPlayer: bool
}

// Define the Stats record
type Stats = {
    Wins: int
    Losses: int
}

// Define the Team record
type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

// Example usage
let coach = { Name = "John Doe"; FormerPlayer = true }
let stats = { Wins = 20; Losses = 10 }
let team = { Name = "Tigers"; Coach = coach; Stats = stats }

// Print the team details
printfn "Team: %s" team.Name
printfn "Coach: %s (Former Player: %b)" team.Coach.Name team.Coach.FormerPlayer
printfn "Stats: %d Wins, %d Losses" team.Stats.Wins team.Stats.Losses


// Create sample data for coaches
let coach1 = { Name = "John Smith"; FormerPlayer = true }
let coach2 = { Name = "Mary Johnson"; FormerPlayer = false }
let coach3 = { Name = "James Brown"; FormerPlayer = true }
let coach4 = { Name = "Patricia Garcia"; FormerPlayer = false }
let coach5 = { Name = "Robert Martinez"; FormerPlayer = true }

// Create sample data for stats
let stats1 = { Wins = 2305; Losses = 1562 }
let stats2 = { Wins = 3643; Losses = 2405 }
let stats3 = { Wins = 3550; Losses = 2453}
let stats4 = { Wins = 2429; Losses = 2096}
let stats5 = { Wins = 1532; Losses = 1000}

// Create teams using the coaches and stats
let team1 = { Name = "Eagles"; Coach = coach1; Stats = stats1 }
let team2 = { Name = "Sharks"; Coach = coach2; Stats = stats2 }
let team3 = { Name = "Panthers"; Coach = coach3; Stats = stats3 }
let team4 = { Name = "Wolves"; Coach = coach4; Stats = stats4 }
let team5 = { Name = "Falcons"; Coach = coach5; Stats = stats5 }

// Add the teams to a list
let teams = [team1; team2; team3; team4; team5]

// Print team details
teams |> List.iter (fun team ->
    printfn "Team: %s" team.Name
    printfn "  Coach: %s (Former Player: %b)" team.Coach.Name team.Coach.FormerPlayer
    printfn "  Stats: %d Wins, %d Losses" team.Stats.Wins team.Stats.Losses
)

// Filter successful teams
let successfulTeams = 
    teams |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

// Print successful team details
printfn "Successful Teams:"
successfulTeams |> List.iter (fun team ->
    printfn "Team: %s" team.Name
    printfn "  Coach: %s (Former Player: %b)" team.Coach.Name team.Coach.FormerPlayer
    printfn "  Stats: %d Wins, %d Losses" team.Stats.Wins team.Stats.Losses
)


// Calculate success percentage for each team using map
let teamsWithSuccessPercentage = 
    teams 
    |> List.map (fun team -> 
        let wins = float team.Stats.Wins
        let losses = float team.Stats.Losses
        let successPercentage = (wins / (wins + losses)) * 100.0
        team, successPercentage
    )

// Print team names and their success percentages
teamsWithSuccessPercentage |> List.iter (fun (team, successPercentage) ->
    printfn "Team: %s" team.Name
    printfn "  Success Percentage: %.2f%%" successPercentage
)

// Define the Cuisine discriminated union
type Cuisine =
    | Korean
    | Turkish

// Define the MovieType discriminated union
type MovieType =
    | Regular
    | IMAX
    | DBOX
    | RegularWithSnacks
    | IMAXWithSnacks
    | DBOXWithSnacks

// Define the Activity discriminated union
type Activity =
    | BoardGame
    | Chill
    | Movie of MovieType
    | Restaurant of Cuisine
    | LongDrive of int * float  // (kilometres, fuel charge per kilometre)

// Function to calculate the budget based on the activity
let calculateBudget activity =
    match activity with
    | BoardGame -> 0.0  // Playing a board game costs 0 CAD
    | Chill -> 0.0      // Chilling out costs 0 CAD
    | Movie movieType -> 
        match movieType with
        | Regular -> 12.0
        | IMAX -> 17.0
        | DBOX -> 20.0
        | RegularWithSnacks -> 12.0 + 5.0
        | IMAXWithSnacks -> 17.0 + 5.0
        | DBOXWithSnacks -> 20.0 + 5.0
    | Restaurant cuisine -> 
        match cuisine with
        | Korean -> 70.0  // Korean costs $70 CAD per couple
        | Turkish -> 65.0 // Turkish costs $65 CAD per couple
    | LongDrive (kilometres, fuelCostPerKm) -> 
        float kilometres * fuelCostPerKm // Calculate the cost of the long drive

// Example activities and budget calculation
let activities = [
    BoardGame
    Chill
    Movie Regular
    Movie IMAXWithSnacks
    Restaurant Korean
    Restaurant Turkish
    LongDrive (150, 1.2)  // 150 km with fuel cost 1.2 CAD per km
]

// Calculate and print the budget for each activity
activities
|> List.iter (fun activity ->
    let cost = calculateBudget activity
    printfn "Activity: %A, Cost: %.2f CAD" activity cost
)
