import { Component, OnInit, Output } from '@angular/core';
import { HttpClient, HttpEventType } from '@angular/common/http';
import { EventEmitter } from '@angular/core';
import { FileService } from 'src/app/services/file.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent {
  @Output() uploaded = new EventEmitter();
  @Output() elapsedTime: EventEmitter<number> = new EventEmitter<number>();

  private fileData: File = null;
  private previewUrl:any = null;
  private fileUploadProgress: string = null;
  private uploadedFilePath: string = null;
  uploadProgress: number  = 0;
  uploadString: string = "Uploading... ";
  constructor(private http: HttpClient, private _file: FileService, private spinner: NgxSpinnerService) { }

  changed(fileInput) {
    this.fileData = <File>fileInput.target.files[0];
    this.uploaded.emit("");//for testing
    const formData = new FormData();
    formData.append('file', this.fileData);
    this.spinner.show("upload");
    this.http.post<any>('/api/Upload', formData, {reportProgress: true, observe: 'events'}).subscribe(res => {
          if (res.type === HttpEventType.Response) {
            this.spinner.hide("upload");
            this._file.setFileId(res.body.fileId);
            this._file.setFileName(this.fileData.name);
            this.elapsedTime.emit(Number.parseInt(res.body['elapsedTime']));
            this.uploaded.emit("");
          }
          else if (res.type === HttpEventType.UploadProgress) {
            this.uploadProgress = Math.round(100 * res.loaded / res.total);
            this.uploadString += this.uploadProgress + "%";
            if (this.uploadProgress == 100) {
              this.uploadString = "Processing file...";
            }
          }
      });
  }

}
