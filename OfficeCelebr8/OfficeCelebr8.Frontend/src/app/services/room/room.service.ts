import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../utils/environment';
import { Observable } from 'rxjs';
import { Room } from '../../models/room/room';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private apiUrl = `${environment.apiUrl}/Room`;

  constructor(private http: HttpClient) { }

  getYourRooms(employeeId : number) : Observable<Room[]> {
    return this.http.get<Room[]>(`${this.apiUrl}/GetYourRooms?employeeId=${employeeId}`);
  }

  deleteRoom(roomId : number, employeeId : number) : Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/DeleteRoom/${roomId}/${employeeId}`);
  }
  
}
