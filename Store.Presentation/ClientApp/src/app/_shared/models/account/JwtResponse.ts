export class JwtReponse {
    private _accessToken: string;
    private _refreshToken: string;
    private _roles: string[];

    get accessToken(): string {
        return this._accessToken;
    }
    set accessToken(value: string) {
        this._accessToken = value;
    }

    get refreshToken(): string {
        return this._refreshToken;
    }
    set refreshToken(value: string) {
        this._refreshToken = value;
    }

    get roles(): string[] {
        return this._roles;
    }
    set roles(value: string[]) {
        this._roles = value;
    }
}