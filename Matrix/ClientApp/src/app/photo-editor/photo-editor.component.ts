import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { UserService } from '../services/user.service';
import { FileUploader } from 'ng2-file-upload';
import { PhotoDto } from '../models/photodto';


@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css']
})
export class PhotoEditorComponent implements OnInit {

  @Input() photos: PhotoDto[];

  uploader: FileUploader;
  constructor(private auth: AuthService, private userService: UserService) { }
  initializeUploader() {
    this.uploader = new FileUploader({
      url:
      this.baseUrl +
      '/users/' +
      JSON.parse(localStorage.getItem('user')).id +
      '/photos',
      authToken: 'Bearer ' + localStorage.getItem('token'),
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });
  }

  ngOnInit() {
  }

}
