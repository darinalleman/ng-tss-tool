import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'modify',
  templateUrl: './modify.component.html',
  styleUrls: ['./modify.component.scss']
})
export class ModifyComponent implements OnInit {
  @Input() fileUploaded: boolean = false;
  constructor() { }

  ngOnInit() {
  }

}
