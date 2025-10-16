import { Component, OnInit } from '@angular/core';
import { Room } from '../../models/room/room';
import { RoomService } from '../../services/room/room.service';
import { Router, RouterModule } from '@angular/router';
import { Alert } from '../../utils/sweetalert/alert';
import { TYPE } from '../../utils/sweetalert/alertTypes.constants';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-rooms',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './rooms.component.html',
  styleUrl: './rooms.component.css'
})
export class RoomsComponent implements OnInit {
  rooms : Room[] = [];
  errorMsg : string = '';

  constructor(private route : Router, private roomService : RoomService) { }
  ngOnInit(): void {
    this.getYourRooms();
  }
  getYourRooms() {
    if(sessionStorage.getItem('employeeId') == null) {
      this.route.navigate(['/login']);
      Alert.toast(TYPE.WARNING, true, 'Please log in first!');
      return;
    }
    this.roomService.getYourRooms(Number(sessionStorage.getItem('employeeId'))).subscribe({
      next: (response : Room[]) => {
        this.rooms = response;
        console.log(this.rooms);
      }, error: (error) => {
        console.error('Failed to fetch your rooms :(', error);
        this.errorMsg = JSON.stringify(error.error.message != null ? error.error.message : error.message);
        Alert.toast(TYPE.ERROR, true, this.errorMsg.replaceAll('"', ''));
      }
    });
  }

  deleteRoom(id : number) {
    Alert.confirmToast('Delete Room', 'Are you sure you want to delete this room?', TYPE.QUESTION,
      'Delete', 'Bye-bye ;(', 'Room has been deleted successfully!', TYPE.SUCCESS, () => {
        this.roomService.deleteRoom(id, Number(sessionStorage.getItem('employeeId'))).subscribe({
          next: (response:boolean) => {
            if(response)
              this.getYourRooms();
          }, error: (error) => {
            console.error('Failed to delete your room :(', error);
            this.errorMsg = JSON.stringify(error.error.message != null ? error.error.message : error.message);
            Alert.toast(TYPE.ERROR, true, this.errorMsg.replaceAll('"', ''));
          }
        });
      }
    )
  }
}
