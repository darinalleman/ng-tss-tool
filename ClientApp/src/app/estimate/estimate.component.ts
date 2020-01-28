import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, NgControl } from '@angular/forms';
import { Zone } from '../models';

@Component({
  selector: 'estimate',
  templateUrl: './estimate.component.html',
  styleUrls: ['./estimate.component.scss']
})
export class EstimateComponent implements OnInit {
  private zones: Zone[] = [];
  private tss: number;
  constructor(private _http: HttpClient
  ) { }

  ngOnInit() {
    this.zones.push({name: "Zone 1", bpm: 162});
    this.zones.push({name: "Zone 2", bpm: 176});
    this.zones.push({name: "Zone 3", bpm: 188});
    this.zones.push({name: "Zone 4", bpm: 200});
    this.zones.push({name: "Zone 5", bpm: 220});

  }

  submit() {
    console.log(this.zones);

    this._http.post('/api/Estimate',  this.zones.map(zone => zone.bpm))
      .subscribe(res => {
        this.tss = res['tss'];
      })

  }

}
