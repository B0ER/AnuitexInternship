import { BaseResponse } from "../base/BaseResponse";

export class UserItem extends BaseResponse {
    private _Id: string;
    private _UserName: string;

    public get Id() {
        return this._Id;
    }

    public set Id(value: string) {
        this._Id = value;
    }

    public get UserName() {
        return this._UserName;
    }

    public set UserName(value: string) {
        this._UserName = value;
    }
}