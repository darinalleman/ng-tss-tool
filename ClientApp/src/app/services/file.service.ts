import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  private fileId;
  private fileName: string;
  constructor() { }

  setFileId(fileId) {
    this.fileId = fileId;
  }
  getFileId() {
    return this.fileId;
  }
  setFileName(fileName) {
    this.fileName = fileName;
  }
  getFileName() {
    return this.fileName;
  }
}


