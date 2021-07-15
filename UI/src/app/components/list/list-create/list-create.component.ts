import { LEADING_TRIVIA_CHARS } from '@angular/compiler/src/render3/view/template';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { List } from 'src/app/models/list';
import { ListService } from 'src/app/services/list.service';

@Component({
  selector: 'app-list-create',
  templateUrl: './list-create.component.html',
  styleUrls: ['./list-create.component.scss']
})
export class ListCreateComponent implements OnInit {

  public list: List = new List(0, "", "", []);

  constructor(private _listService: ListService, private _router: Router) { }

  ngOnInit(): void {
  }

  public create(name: string, description: string)
  {
    this._listService.create(name, description).subscribe()
    {
      this._router.navigate(['..']);
    }
  }

}
