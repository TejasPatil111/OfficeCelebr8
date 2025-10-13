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
    constructor(isLoggedIn : boolean, email : string) {
        this.isLoggedIn = isLoggedIn;
        this.email = email;
    }
}