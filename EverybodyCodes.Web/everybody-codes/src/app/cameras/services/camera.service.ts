import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { Camera } from "../models/camera.model";

@Injectable()
export class CameraService {

    private apiUrl: string = 'https://localhost:7229/api';

    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<Camera[]>(this.apiUrl + '/cameras');
    }

    getDivisibleBy(numbers: number[], negation: boolean = false) {
        let numbersArg = numbers.join('&numbers=');
        return this.http.get<Camera[]>(this.apiUrl + '/cameras/divisibleby?numbers=' + numbersArg + '&negation=' + negation);
    }
}