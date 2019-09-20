
export class BaseResponse {
    private _errors: string[];

    public get Errors() {
        return this._errors;
    }

    public set Errors(value: string[]) {
        this._errors = value;
    }
}