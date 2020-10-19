import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { HttpClient } from '@angular/common/http';
import { FileService } from 'src/app/services/file.service';

@Component({
  selector: 'has-power',
  templateUrl: './has-power.component.html',
  styleUrls: ['./has-power.component.css']
})
export class HasPowerComponent implements OnInit {
  public averagePower: number = 0;

  constructor(
    private _spinner: NgxSpinnerService,
    private _http: HttpClient,
    private _file: FileService) { }

  ngOnInit() {
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
}
