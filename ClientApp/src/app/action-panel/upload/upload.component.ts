import { Component, OnInit, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EventEmitter } from '@angular/core';

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
  constructor(private http: HttpClient) { }

  changed(fileInput) {
    this.fileData = <File>fileInput.target.files[0];
    const formData = new FormData();
      formData.append('file', this.fileData);
      this.http.post('/api/Upload', formData)
        .subscribe(res => {
          this.uploaded.emit("");
        });
  }

}
