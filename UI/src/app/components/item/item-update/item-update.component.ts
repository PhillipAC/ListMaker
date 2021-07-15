import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from 'src/app/models/item';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-item-update',
  templateUrl: './item-update.component.html',
  styleUrls: ['./item-update.component.scss']
})
export class ItemUpdateComponent implements OnInit {

  public item: Item = new Item(0, "", 0, 0, false);

  private _id: number = 0;

  constructor(private _itemService: ItemService,
              private _route: ActivatedRoute) { }

  ngOnInit(): void {
    this._id = Number(this._route.snapshot.paramMap.get('id'));
    this._itemService.getById(this._id).subscribe(item => this.item = item);
  }

}
