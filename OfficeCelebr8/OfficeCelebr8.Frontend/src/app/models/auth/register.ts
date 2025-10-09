export class RegisterRequest {
    employeeId : number;
    name : string;
    email : string;
    password : string;
    designation : string;
    constructor(employeeId : number, name : string, email : string, password : string, designation : string) {
        this.employeeId = employeeId;
        this.name = name;
        this.email = email;
        this.password = password;
        this.designation = designation;
    }
}
export class RegisterResponse {
    id : string;
    isRegistered : boolean;
    constructor(id : string, isRegistered : boolean) {
        this.id = id;
        this.isRegistered = isRegistered;
    }
}