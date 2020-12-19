import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'action-panel',
  templateUrl: './action-panel.component.html',
  styleUrls: ['./action-panel.component.scss']
})
export class ActionPanelComponent implements OnInit {
  public fileUploaded: boolean = false;
  public elapsedTime: number = 0;
  constructor() { }

  ngOnInit() {
  }

  fileUploadListener(validFile: boolean) {
      this.fileUploaded = validFile;
  }

  elapsedTimeListener(seconds: number) {
    console.log(seconds);
    this.elapsedTime = seconds;
}


}
