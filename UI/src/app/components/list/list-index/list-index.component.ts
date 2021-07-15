import { Component, OnInit } from '@angular/core';
import { List } from 'src/app/models/list';
import { ListService } from 'src/app/services/list.service';

@Component({
  selector: 'app-list-index',
  templateUrl: './list-index.component.html',
  styleUrls: ['./list-index.component.scss']
})
export class ListIndexComponent implements OnInit {

  public lists: List[] = [];

  constructor(private _listService: ListService) { }

  ngOnInit(): void {
    this._listService.getAll().subscribe(lists => this.lists = lists);
  }

}
