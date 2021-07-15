import { Component, Input, OnInit } from '@angular/core';
import { Item } from 'src/app/models/item';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-item-index',
  templateUrl: './item-index.component.html',
  styleUrls: ['./item-index.component.scss']
})
export class ItemIndexComponent implements OnInit {

  @Input() listId: number = 0;
  @Input() public items: Item[] = [];

  public isAddMode: boolean = false;

  constructor(private _itemService: ItemService) { }

  ngOnInit(): void {
  }

  public toggleAddMode(): void {
    this.isAddMode = !this.isAddMode;
  }

  public addItem(newItem: Item)
  {
    this.items.push(newItem);
    this.isAddMode = false;
  }

  public deleteItem(item: Item)
  {
    let index = this.items.findIndex(i => i.id == item.id);
    this.items.splice(index, 1);
  }
}
