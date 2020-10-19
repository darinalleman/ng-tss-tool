import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Input } from '@angular/core';
import { Zone } from '../../../models';
import { FileService } from 'src/app/services/file.service';
import { NgxSpinnerService } from 'ngx-spinner';

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
    private _file: FileService,
    private _spinner: NgxSpinnerService
  ) { }

  ngOnInit() {
    this.zones.push({name: "Zone 1 ends:", bpm: 162});
    this.zones.push({name: "Zone 2 ends:", bpm: 176});
    this.zones.push({name: "Zone 3 ends:", bpm: 188});
    this.zones.push({name: "Zone 4 ends:", bpm: 200});
    this.zones.push({name: "Zone 5 ends:", bpm: 215});

  }

  submit() {
    this._spinner.show();
    this._http.post('/api/Estimate/'+ this._file.getFileId(),  this.zones.map(zone => zone.bpm))
      .subscribe(res => {
        this.tss = res['tss'];
        this._spinner.hide();
        this.averagePowerMissingFTP = res['averagePowerMissingFTP'];
      })
  }

  encode() {
    if (this.averagePower > 0) {
      this._spinner.show();
      this._http.post('/api/Modify/'+ this._file.getFileId(), Math.round(this.averagePower))
        .subscribe(res => {
          this._http.get('/api/Download/'+ this._file.getFileId(), {responseType: 'blob'}).subscribe((response: Blob) => {
            this._spinner.hide();
            var filename = "TSSTool_" + this._file.getFileName();
            if (window.navigator.msSaveOrOpenBlob) { // for IE and Edge
              window.navigator.msSaveBlob(response, filename);
            } else {
                // for modern browsers, click an invisible button that will download the file
                var a = document.createElement('a');
                a.href = window.URL.createObjectURL(response);
                a.download = filename;
                a.style.display = 'none';
                document.body.appendChild(a);
                a.click();
                a.remove();
            }
          });
      });
    }
  }

  ftpListener() {
    this.averagePower = Math.sqrt(this.averagePowerMissingFTP * this.ftp * this.ftp);
  }

}
