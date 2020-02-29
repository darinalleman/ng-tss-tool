import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FileService {
private fileId;
constructor() { }

setFileId(fileId) {
  this.fileId = fileId;
}
getFileId() {
  return this.fileId;
}
}


