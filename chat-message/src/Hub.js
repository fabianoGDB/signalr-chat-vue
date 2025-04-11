import { HubConnectionBuilder, LogLevel } from "@aspnet/signalr";

export default class Hub {

    constructor(){
        this.connection = new HubConnectionBuilder()
        .withUrl('https://localhost:7124/Hub', {
            withCredentials: true
        })
        .configureLogging(LogLevel.Information)
        .build();
    }
}