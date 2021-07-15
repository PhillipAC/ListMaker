import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { List } from 'src/app/models/list';
import { ListService } from 'src/app/services/list.service';

@Component({
  selector: 'app-list-update',
  templateUrl: './list-update.component.html',
  styleUrls: ['./list-update.component.scss']
})
export class ListUpdateComponent implements OnInit {

  public list: List = new List(0, "", "");

  private _id: number = 0;

  constructor(private _listService: ListService,
              private _route: ActivatedRoute,
              private _router: Router) { }

  ngOnInit(): void {
    this._id = Number(this._route.snapshot.paramMap.get('id'));
    this._listService.getById(this._id).subscribe(list => this.list = list);
  }

  public update()
  {
    this._listService.update(this._id, this.list.name, this.list.description).subscribe(
      x => {
        this._router.navigate(['..']);
      }
    )
  }
}
