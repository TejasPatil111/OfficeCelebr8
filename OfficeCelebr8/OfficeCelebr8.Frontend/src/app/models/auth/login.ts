export class LoginRequest {
    email : string;
    password : string;
    constructor(email : string, password : string) {
        this.email = email;
        this.password = password;
    }
}
export class LoginResponse {
    isLoggedIn : boolean;
    email : string;
    employeeId : number;
    constructor(isLoggedIn : boolean, email : string, employeeId : number) {
        this.isLoggedIn = isLoggedIn;
        this.email = email;
        this.employeeId = employeeId;
    }
}