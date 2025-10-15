export class Room {
    id : number;
    name : string;
    description : string;
    capacity : number;
    createdBy : number;
    createdOn : Date;
    eventOn : Date;
    totalCollection : number;
    collectedTillNow : number;
    members : string;
    constructor(id : number, name : string, description : string, capacity : number, createdBy : number,
                createdOn : Date, eventOn : Date, totalCollection : number, collectedTillNow : number,
                members : string)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.capacity = capacity;
        this.createdBy = createdBy;
        this.createdOn = createdOn;
        this.eventOn = eventOn;
        this.totalCollection = totalCollection;
        this.collectedTillNow = collectedTillNow;
        this.members = members;
    }
}
