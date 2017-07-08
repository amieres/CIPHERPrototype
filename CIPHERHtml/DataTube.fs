namespace CIPHERPrototype

open WebSharper

[<JavaScript>]
module DataTube =

//    type Datum<'KD, 'KL when 'KD : comparison and 'KL : comparison> = {
//        mutable data      : Map<'KD, obj>
//        mutable listeners : Map<'KD, Map<'KL, (obj -> unit)>>
//    } with
//        static member New (v: obj) = { data = Map.empty ; listeners = Map.empty  }

    type Tube<'KD, 'KL when 'KD : comparison and 'KL : comparison> = {
        id                : System.IComparable
        mutable data      : Map<'KD list, obj>
        mutable listeners : Map<'KD list, Map<'KL, (obj option -> unit)>>
    } with
        static member New (id: System.IComparable) = { id = id ; data = Map.empty ; listeners = Map.empty }
        member this.getDataO        key                 =                   Map.tryFind key   this.data
        member this.remove          key                 = this.data      <- Map.remove  key   this.data
        member this.setOnly         key (v :obj)        = this.data      <- Map.add     key v this.data
        member this.setOnlyO        key (vO:obj option) = match vO with | None -> this.remove key | Some v -> this.setOnly key v
        member this.setAndTriggerO  key (vO:obj option) = this.setOnlyO                 key vO
                                                          Map.tryFind key this.listeners |> Option.iter (fun dict -> dict |> Map.toSeq |> Seq.iter (fun (_, f) -> f       vO))
        member this.setAndTrigger   key (v :obj)        = this.setAndTriggerO           key (Some v)
        member this.setDataO        key (vO:obj option) = if this.getDataO key <> vO 
                                                              then this.setAndTriggerO  key vO
        member this.setData         key (v :obj)        = if this.getDataO key <> Some v 
                                                              then this.setAndTrigger   key v
        member this.subscribe       kd     kl      f    = this.listeners <- 
                                                              Map.tryFind kd this.listeners 
                                                              |> Option.defaultValue Map.empty 
                                                              |> Map.add  kl f
                                                              |> Map.add  kd 
                                                              <| this.listeners
        member this.subCell subKey                      = Cell(this, [subKey])
                                                  
    and  Cell<'D, 'KD, 'KL when 'KD : comparison and 'KL : comparison> = Cell of Tube<'KD, 'KL> * 'KD list
      with
        member this.getDataO      ()             = match this with Cell (tube, key) -> tube.getDataO        key |> Option.map unbox<'D>
        member this.setOnly       (v :'D)        = match this with Cell (tube, key) -> tube.setOnly         key v
        member this.setAndTrigger (v :'D)        = match this with Cell (tube, key) -> tube.setAndTrigger   key v
        member this.setData       (v :'D)        = match this with Cell (tube, key) -> tube.setData         key v
        member this.setDataO      (vO:'D option) = match this with Cell (tube, key) -> tube.setDataO        key (vO |> Option.map box)
        member this.subscribe   listenKey  f     = match this with Cell (tube, key) -> tube.subscribe       key listenKey (fun oO -> oO |> Option.map unbox<'D> |> f)
        member this.subCell subKey               = match this with Cell (tube, key) -> Cell(tube, subKey :: key)

    let generalCell () = Tube<string, string>.New("X").subCell("V")


