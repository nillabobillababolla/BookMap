import { Component, OnInit, ViewChild } from '@angular/core';

import { ToastrService } from 'ngx-toastr';
import { AuthorService } from '../../services/author.service';
import { Author } from '../../models/author';

declare var $: any;

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})

export class AuthorComponent implements OnInit {
  author = new Author();
  allAuthors: Author[];
  response: object;
  isEdit = false;
  authorId: any;
  hasData = true;

  constructor(private authorService: AuthorService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.getAuthor();
  }

  refreshForm(): void {
    const dirtyFormID = 'authorForm';
    const resetForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    resetForm.reset();
  }

  postAuthor(): object {
    const result = this.authorService.postAuthor(this.author).subscribe((response) => {
      if (response.body != null && response.ok && response.body !== false) {
        this.toastrService.success('Author saved successfully');
        this.author = new Author();
        this.getAuthor();
        this.refreshForm();

        return;
      }

      if (response.body === false) {
        this.toastrService.error('This author saved already');
        this.focusErrorInput();

        return;
      }
    });

    return result;
  }

  getAuthor(): void {
    this.authorService.getAllAuthors()
      .subscribe(data => {
        if (data.length === 0) {
          this.hasData = false;
        }
        else {
          this.hasData = true;
          this.allAuthors = data;
        }
      });
  }

  editAuthor(selectedAuthor: Author): void {
    this.author = selectedAuthor;
    this.isEdit = true;
  }

  updateAuthor(): void {
    this.authorService.updateAuthor(this.author).subscribe(
      (res) => {
        if (res.body != null && res.ok && res.body !== false) {
          this.toastrService.success('Author edited successfully.');
          this.getAuthor();
          this.refreshForm();
          this.author = new Author();
          this.isEdit = false;
        }

        if (res.body === false) {
          this.toastrService.error('Please make a change to edit.');
          this.focusErrorInput();
        }
      });
  }

  focusErrorInput() {
    const dirtyFormID = 'authorName';
    const focusForm = <HTMLFormElement>document.getElementById(dirtyFormID);
    focusForm.focus();
  }

  onDelete(id: any): void {
    $('#deleteAuthor').modal('show');
    this.authorId = id;
  }

  deleteAuthor(): void {
    this.authorService.deleteAuthor(this.authorId).subscribe((res) => {
      {
        this.toastrService.success('Author deleted successfully.');
        this.getAuthor();
        this.refreshForm();
        this.author = new Author();
        this.isEdit = false;
        $('#deleteAuthor').modal('hide');
      }
    });
  }

  cancelUpdate() {
    this.author = new Author();
    this.isEdit = false;
    this.getAuthor();
    this.refreshForm();
  }
}
