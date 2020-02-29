import { Component, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EventEmitter } from '@angular/core';
import { FileService } from 'src/app/services/file.service';

@Component({
  selector: 'upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent {
  @Output() uploaded = new EventEmitter();

  fileData: File = null;
  previewUrl:any = null;
  fileUploadProgress: string = null;
  uploadedFilePath: string = null;
  constructor(private http: HttpClient, private _file: FileService) { }

  changed(fileInput) {
    this.fileData = <File>fileInput.target.files[0];
    this.uploaded.emit("");//for testing
    const formData = new FormData();
      formData.append('file', this.fileData);
      this.http.post<any>('/api/Upload', formData)
        .subscribe(res => {
          console.log(res);
          this._file.setFileId(res.fileId);
          this.uploaded.emit("");
        });
  }

}
