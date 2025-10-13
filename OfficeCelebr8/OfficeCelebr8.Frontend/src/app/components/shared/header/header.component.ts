import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {

  checkLoggedIn : boolean = false;
  ngOnInit(): void {
    if(sessionStorage.getItem('email') != null) {
      this.checkLoggedIn = true;
    }
  }

}
