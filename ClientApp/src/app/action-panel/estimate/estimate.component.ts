import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { Zone } from '../../models';
import { FileService } from 'src/app/services/file.service';

@Component({
  selector: 'estimate',
  templateUrl: './estimate.component.html',
  styleUrls: ['./estimate.component.scss']
})
export class EstimateComponent implements OnInit {
  @Input() fileUploaded: boolean = false;
  public zones: Zone[] = [];
  public tss: number;
  public ftp: number;
  public averagePower: number;
  public averagePowerMissingFTP: number;
  constructor(
    private _http: HttpClient,
    private _file: FileService
  ) { }

  ngOnInit() {
    this.zones.push({name: "Zone 1 ends:", bpm: 162});
    this.zones.push({name: "Zone 2 ends:", bpm: 176});
    this.zones.push({name: "Zone 3 ends:", bpm: 188});
    this.zones.push({name: "Zone 4 ends:", bpm: 200});
    this.zones.push({name: "Zone 5 ends:", bpm: 215});

  }

  submit() {
    this._http.post('/api/Estimate/'+ this._file.getFileId(),  this.zones.map(zone => zone.bpm))
      .subscribe(res => {
        this.tss = res['tss'];
        this.averagePowerMissingFTP = res['averagePowerMissingFTP'];
      })
  }

  encode() {
    if (this.averagePower > 0) {
      this._http.post('/api/Modify/'+ this._file.getFileId(), Math.round(this.averagePower))
        .subscribe(res => {
      });
    }
  }

  ftpListener() {
    console.log(this.averagePowerMissingFTP);
    this.averagePower = Math.sqrt(this.averagePowerMissingFTP * this.ftp * this.ftp);
  }

}
