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
  constructor(
    private _http: HttpClient,
    private _file: FileService
  ) { }

  ngOnInit() {
    this.zones.push({name: "Zone 1", bpm: 162});
    this.zones.push({name: "Zone 2", bpm: 176});
    this.zones.push({name: "Zone 3", bpm: 188});
    this.zones.push({name: "Zone 4", bpm: 200});
    this.zones.push({name: "Zone 5", bpm: 215});

  }

  submit() {
    this._http.post('/api/Estimate/'+ this._file.getFileId(),  this.zones.map(zone => zone.bpm))
      .subscribe(res => {
        this.tss = res['tss'];
      })

  }

}
