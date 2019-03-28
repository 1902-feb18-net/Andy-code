import { Component, OnInit } from '@angular/core';
import { MessageService } from '../message.service';

// The MessagesComponent should display all messages, including the message sent by the HeroService when it fetches heroes.
@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.css']
})
export class MessagesComponent implements OnInit {

  // The messageService property must be public because you're about to bind to it in the template.
  constructor(public messageService: MessageService) { }

  ngOnInit() {
  }

}
