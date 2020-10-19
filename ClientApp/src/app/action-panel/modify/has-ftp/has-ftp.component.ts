import { Component, OnInit, Input } from '@angular/core';
import { NgxSpinnerComponent, NgxSpinnerService } from 'ngx-spinner';
import { HttpClient } from '@angular/common/http';
import { FileService } from 'src/app/services/file.service';

@Component({
  selector: 'has-ftp',
  templateUrl: './has-ftp.component.html',
  styleUrls: ['./has-ftp.component.css']
})
export class HasFtpComponent implements OnInit {
  @Input() fileUploaded: boolean = false;
  @Input() elapsedTime: number = 0;

  public tss: number;
  public ftp: number;
  public averagePower: number;
  constructor(
    private _spinner: NgxSpinnerService,
    private _http: HttpClient,
    private _file: FileService
      ){ }

  ngOnInit() {
  }

  calculatePower() {
    if (this.tss > 0 && this.ftp > 0) {
      this.averagePower = (Math.sqrt(this.ftp*this.ftp*this.tss*36/this.elapsedTime));
    }
  }

  encode() {
    if (this.averagePower > 0) {
      this._spinner.show("processing");
      this._http.post('/api/Modify/'+ this._file.getFileId(), Math.round(this.averagePower))
        .subscribe(res => {
          this._http.get('/api/Download/'+ this._file.getFileId(), {responseType: 'blob'}).subscribe((response: Blob) => {
            this._spinner.hide("processing");
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

}
