namespace a

//[< WebSharper.JavaScript >]
module b =

    type Simple = {  before : bool }
    with
        static member New  = {           before = false }
        member this.Before = { this with before = true  }
    
    Simple.New
        .Before.Before.Before.Before.Before.Before
        .Before.Before.Before.Before.Before.Before  // < 10 seconds
        .Before.Before.Before.Before.Before.Before  //   10 seconds
        .Before.Before                              //   25 seconds
        .Before                                     //   44 seconds
        .Before                                     //   86 seconds
        .Before                                     //  164 seconds
        .Before                                     //  322 seconds
    |> printfn "%A"