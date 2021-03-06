namespace Year2020

module Day09 =
    open Utilities

    let numbers = getMany 2020 9 int64
    let preambleSize = 25

    let findInvalid size numbers =
        let n = Array.last numbers
        let lookup = Array.take size numbers |> Set.ofArray
        match Set.exists (fun x -> Set.contains (n - x) lookup) lookup with
        | true -> None
        | _ -> Some n
    
    let rec findRange invalidNumber = function
        | [] -> None
        | range -> 
            if List.sum range = invalidNumber 
            then Some (List.min range + List.max range)
            else findRange invalidNumber (List.tail range)

    let part1() = 
        numbers 
        |> Seq.windowed (preambleSize + 1) 
        |> Seq.pick (findInvalid preambleSize)

    let part2() =
        let invalidNumber = part1()
        numbers 
        |> Seq.windowed (Seq.length numbers / 4)
        |> Seq.pick (List.ofArray >> findRange invalidNumber)         

    let solve () = printDay 2020 9 part1 part2
