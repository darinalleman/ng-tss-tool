import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'action-panel',
  templateUrl: './action-panel.component.html',
  styleUrls: ['./action-panel.component.css']
})
export class ActionPanelComponent implements OnInit {
  private fileUploaded: boolean = false;
  constructor() { }

  ngOnInit() {
  }

  fileUploadListener() {
      this.fileUploaded = true;
  }
}
